using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Umbraco.Core.Logging;
using kitDeInicioDos.ModelsView;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KitDeInicioDos.Controllers
{
    //@Html.Action("DesplegardFormulario", "Contact")
    public class ContactController : SurfaceController
    {
        string path = "~/Views/Partials/contact/ContactForm.cshtml";
        public ActionResult DesplegardFormulario()
        {
            ContactModel vm = new ContactModel();
            var siteSettings = Umbraco.ContentAtRoot().DescendantsOrSelfOfType("ajustesGenerales").FirstOrDefault();
            if (siteSettings != null)
            {
                var siteKey = siteSettings.Value<string>("recaptchaSiteKey");
                vm.RecaptchaSiteKey = siteKey;
            }
            return PartialView(path, vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResolverFormulario(ContactModel vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "El formulario contiene errores");
                return CurrentUmbracoPage();
            }

            var siteSettings = Umbraco.ContentAtRoot().DescendantsOrSelfOfType("siteSettings").FirstOrDefault();
            if (siteSettings != null)
            {
                var secretKey = siteSettings.Value<string>("recaptchaSecretKey");
                var isCaptchaValid = IsCaptchaValid(Request.Form["GoogleCaptchaToken"], secretKey);
                if (isCaptchaValid)
                {
                    ModelState.AddModelError("Captcha", "Captcha no es valida, solo humanos.");
                    return CurrentUmbracoPage();
                }
            }

            try
            {
                EnviarFormulario(vm);

                TempData["status"] = "OK";

                return RedirectToCurrentUmbracoPage();
            }
            catch (Exception exc)
            {
                Logger.Error<ContactController>("Error al submitir el formulario", exc.Message);
                ModelState.AddModelError("Error", "Inténtelo más tarde");
            }          

            return CurrentUmbracoPage();
        }



        /// <summary>
        /// perform a captcha validity check
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private bool IsCaptchaValid(string token, string secretKey)
        {
            // sending token to google api
            HttpClient httpClient = new HttpClient();
            var res = httpClient
                .GetAsync($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={token}")
                .Result;

            if (res.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            // get response

            string jsonRes = res.Content.ReadAsStringAsync().Result;
            dynamic jsonData = JObject.Parse(jsonRes);
            if (jsonData.success != "true")
            {
                return false;
            }
            // see if good
            return true;
        }

        private void EnviarFormulario(ContactModel vm)
        {
            var ajustesGenerales = Umbraco.ContentAtRoot()
                .DescendantsOrSelfOfType("ajustesGenerales")
                .FirstOrDefault();
            if(ajustesGenerales == null)
            {
                throw new Exception("Ajustes no existen");
            }
            var direcciondDe = ajustesGenerales.Value("emailDeEnvio");
            var direccionA = ajustesGenerales.Value("emailDeRecepcion");

            if (direcciondDe == null)
            {
                throw new Exception("direccion de email no existen");
            }
            if (direccionA == null)
            {
                throw new Exception("direccion donde enviar email no existen");
            }

            var emailTema = vm.Tema;
            var emailCuerpo = $"Un nuevo email fue recibido {vm.Nombre} con el siguiente mensaje: \n{vm.Mensaje}";
            var smtpMensaje = new MailMessage();
            smtpMensaje.Subject = emailTema;
            smtpMensaje.Body = emailCuerpo;
            smtpMensaje.From = new MailAddress(direcciondDe.ToString());

            var listado = direccionA.ToString().Split(',');
            foreach (var item in listado)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    smtpMensaje.To.Add(item);
                }
            }

            using(var smtp = new SmtpClient())
            {
                smtp.Send(smtpMensaje);
            }
        }
    }
}