//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.13.0
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	/// <summary>Noticia</summary>
	[PublishedModel("noticia")]
	public partial class Noticia : PublishedContentModel, IAjustesNoticias, INoticiasRelacionadas, ISEO
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new const string ModelTypeAlias = "noticia";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Noticia, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Noticia(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// categories
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("categories")]
		public virtual global::System.Collections.Generic.IEnumerable<string> Categories => this.Value<global::System.Collections.Generic.IEnumerable<string>>("categories");

		///<summary>
		/// Título
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("titulo")]
		public virtual string Titulo => this.Value<string>("titulo");

		///<summary>
		/// Autor
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("autor")]
		public virtual string Autor => global::Umbraco.Web.PublishedModels.AjustesNoticias.GetAutor(this);

		///<summary>
		/// Categorías
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("categorias")]
		public virtual global::System.Collections.Generic.IEnumerable<string> Categorias => global::Umbraco.Web.PublishedModels.AjustesNoticias.GetCategorias(this);

		///<summary>
		/// Eslogan
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("eslogan")]
		public virtual string Eslogan => global::Umbraco.Web.PublishedModels.AjustesNoticias.GetEslogan(this);

		///<summary>
		/// Fecha De Publicación
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("fechaDePublicacion")]
		public virtual global::System.DateTime FechaDePublicacion => global::Umbraco.Web.PublishedModels.AjustesNoticias.GetFechaDePublicacion(this);

		///<summary>
		/// Foto Principal
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("fotoPrincipal")]
		public virtual global::Umbraco.Core.Models.PublishedContent.IPublishedContent FotoPrincipal => global::Umbraco.Web.PublishedModels.AjustesNoticias.GetFotoPrincipal(this);

		///<summary>
		/// Miniatura
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("miniatura")]
		public virtual global::Umbraco.Core.Models.PublishedContent.IPublishedContent Miniatura => global::Umbraco.Web.PublishedModels.AjustesNoticias.GetMiniatura(this);

		///<summary>
		/// Texto
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("texto")]
		public virtual global::Newtonsoft.Json.Linq.JToken Texto => global::Umbraco.Web.PublishedModels.AjustesNoticias.GetTexto(this);

		///<summary>
		/// Relacionados
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("relacionados")]
		public virtual global::Umbraco.Core.Models.Blocks.BlockListModel Relacionados => global::Umbraco.Web.PublishedModels.NoticiasRelacionadas.GetRelacionados(this);

		///<summary>
		/// Descripcion
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("seoDescripcion")]
		public virtual string SeoDescripcion => global::Umbraco.Web.PublishedModels.SEO.GetSeoDescripcion(this);

		///<summary>
		/// Titulo
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("seoTitulo")]
		public virtual string SeoTitulo => global::Umbraco.Web.PublishedModels.SEO.GetSeoTitulo(this);
	}
}