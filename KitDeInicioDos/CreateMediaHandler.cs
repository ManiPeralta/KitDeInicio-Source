using Newtonsoft.Json;
using Our.Umbraco.BlockListMvc.Composing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Logging;
using System.Xml.Linq;
using Umbraco.Core.PackageActions;
using Umbraco.Core.PropertyEditors.ValueConverters;
using Umbraco.Core.Services;
using Umbraco.Web.Composing;
using Umbraco.Core.Models;

namespace KitDeInicioDos
{
    public class CreateMediaHandler : IPackageAction
    {
        public bool Execute(string packageName, XElement xmlData)
        {
            var contentService = Umbraco.Web.Composing.Current.Services.ContentService;
            var mediaTypeService = Umbraco.Web.Composing.Current.Services.MediaTypeService;
            var mediaService = Umbraco.Web.Composing.Current.Services.MediaService;

            var sampleFolderId = CreateMediaItem(mediaService, mediaTypeService, -1, "folder",
                new Guid("9bae5a55-05d4-46a9-b2b3-f1ddb9a2bc38"), "Sample Images", "");

            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid(" ba66d084-c9d0-44ba-89c3-47c9b044243f"), "Empanadas", "/media/qlignowq/empanadas.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("949abf1d-71e9-493e-9978-d5b2d709984c"), "Llauchas", "/media/do5jvfhj/llauchas.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("1bd8b52c-2f3b-4ee4-92d6-3fa11c33e61b"), "Llauchas2", "/media/fk0nqgz1/llauchas2.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("356daf74-f670-4703-88a0-1694fb15a1ae"), "Salteñas", "/media/okxh0nlq/salteñas.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("526f41d1-8064-42b0-8872-e2d5cbf2c1fe"), "Salteñas (Plaza Mayor) 2011", "/media/03ah4ute/salteñas_-plaza_mayor-2011.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("834c197b-ae4a-413f-b54a-e0f4315fddeb"), "Salteñas (Plaza Mayor) 2011", "/media/pumfza0k/salteñas_-plaza_mayor-2011-01.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("fb72198a-28ca-49af-995a-6713101c5687"), "Tucumanas Bolivianas", "/media/rqmhf44k/tucumanas_bolivianas.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("c7869a7e-b8c9-45ba-8382-fd48c5ca0731"), "Pucacapas Spicy Boliviana", "/media/pcninr4j/pucacapas-spicy-boliviana.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("16af8813-f8b8-41e9-8117-e6ecc29454c8"), "Pukacapas1", "/media/cwek4fvy/pukacapas1.jpg", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid(" 6be8f27f-15ea-4beb-823c-3ffede9e1946"), "Pucacapas Bolivian Spicy Cheese Empanadas", "/media/phzoq05k/pucacapas-bolivian-spicy-cheese-empanadas.png", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid(" 3aa147e1-e911-49ac-bbd6-f13168f425bd"), "Logotipo", "/media/23dlcoqr/logotipo.png", false);
            CreateMediaItem(mediaService, mediaTypeService, sampleFolderId, "image",
                new Guid("78afa595-5c1e-4bb5-91bd-23d44a569010"), "Favicon", "/media/sosl44a4/favicon.png", false);

            var contentHome = contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "inicio");
            if (contentHome != null)
            {
                // publish everything (moved here due to Deploy dependency checking)
                contentService.SaveAndPublishBranch(contentHome, true);
            }
            else
            {
                Umbraco.Web.Composing.Current.Logger.Warn<CreateMediaHandler>("Se encontro el inicio instalado");
            }

            return true;
        }

        public string Alias()
        {
            return "KitDeInicioDos";
        }

        public bool Undo(string packageName, XElement xmlData)
        {
            //no undo path
            return true;
        }

        private int CreateMediaItem(IMediaService service, IMediaTypeService mediaTypeService,
            int parentFolderId, string nodeTypeAlias, Guid key, string nodeName, string mediaPath, bool checkForDuplicateName = false)
        {
            //if the item with the exact id exists we cannot install it (the package was probably already installed)
            if (service.GetById(key) != null)
                return -1;

            //cannot continue if the media type doesn't exist
            var mediaType = mediaTypeService.Get(nodeTypeAlias);
            if (mediaType == null)
            {
                Umbraco.Web.Composing.Current.Logger.Warn<CreateMediaHandler>("Could not create media, the {NodeTypeAlias} media type is missing, kit de inicio package will not function correctly", nodeTypeAlias);
                return -1;
            }

            var isDuplicate = false;

            if (checkForDuplicateName)
            {
                IEnumerable<IMedia> children;
                if (parentFolderId == -1)
                {
                    children = service.GetRootMedia();
                }
                else
                {
                    var parentFolder = service.GetById(parentFolderId);
                    if (parentFolder == null)
                    {
                        Umbraco.Web.Composing.Current.Logger.Warn<CreateMediaHandler>("No media parent found by Id {ParentFolderId} the media item {NodeName} cannot be installed", parentFolderId, nodeName);
                        return -1;
                    }

                    children = service.GetPagedChildren(parentFolderId, 0, int.MaxValue, out long totalRecords);
                }
                foreach (var m in children)
                {
                    if (m.Name == nodeName)
                    {
                        isDuplicate = true;
                        break;
                    }
                }
            }

            if (isDuplicate) return -1;

            if (parentFolderId != -1)
            {
                var parentFolder = service.GetById(parentFolderId);
                if (parentFolder == null)
                {
                    Umbraco.Web.Composing.Current.Logger.Warn<CreateMediaHandler>("No media parent found by Id {ParentFolderId} the media item {NodeName} cannot be installed", parentFolderId, nodeName);
                    return -1;
                }
            }

            var media = service.CreateMedia(nodeName, parentFolderId, nodeTypeAlias);
            if (nodeTypeAlias != "folder")
                media.SetValue("umbracoFile", JsonConvert.SerializeObject(new ImageCropperValue { Src = mediaPath }));
            if (key != Guid.Empty)
            {
                media.Key = key;
            }
            service.Save(media);
            return media.Id;
        }
    }
}