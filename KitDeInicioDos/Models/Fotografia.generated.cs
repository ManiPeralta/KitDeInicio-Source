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
	// Mixin Content Type with alias "fotografia"
	/// <summary>Fotografia</summary>
	public partial interface IFotografia : IPublishedElement
	{
		/// <summary>Foto</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		global::Umbraco.Core.Models.PublishedContent.IPublishedContent Foto { get; }
	}

	/// <summary>Fotografia</summary>
	[PublishedModel("fotografia")]
	public partial class Fotografia : PublishedElementModel, IFotografia
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new const string ModelTypeAlias = "fotografia";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Fotografia, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Fotografia(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Foto
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		[ImplementPropertyType("foto")]
		public virtual global::Umbraco.Core.Models.PublishedContent.IPublishedContent Foto => GetFoto(this);

		/// <summary>Static getter for Foto</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.13.0")]
		public static global::Umbraco.Core.Models.PublishedContent.IPublishedContent GetFoto(IFotografia that) => that.Value<global::Umbraco.Core.Models.PublishedContent.IPublishedContent>("foto");
	}
}