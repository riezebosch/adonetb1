﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
[assembly: System.Data.Entity.Infrastructure.MappingViews.DbMappingViewCacheTypeAttribute(typeof(CodeFirstDemo2NuInHetEchie.MijnContext), typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySetsdca4d4296beb4c9c86fd6be3a9957290))]
namespace Edm_EntityMappingGeneratedViews
{
	using System.Collections.Generic;
	using System.Data.Entity.Core.Metadata.Edm;
	using System.Data.Entity.Infrastructure.MappingViews;
	using System.Reflection;
	using System.Xml;
	using System.Xml.Linq;

	/// <Summary>
	/// The type contains views for EntitySets and AssociationSets that were generated at design time.
	/// </Summary>
	public sealed class ViewsForBaseEntitySetsdca4d4296beb4c9c86fd6be3a9957290 : DbMappingViewCache
	{
		private static Dictionary<string, DbMappingView> extentViews = null;
		private readonly static object lockObject = new object();

		public override string MappingHashValue { get { return "0ed246cddab2b3e45ac4f671b427c091a0ac50379a78271ab9be6a39b262995a"; } }

		/// <Summary>
		/// The constructor stores the views for the extents and also the hash values generated based on the metadata and mapping closure and views.
		/// </Summary>
		public ViewsForBaseEntitySetsdca4d4296beb4c9c86fd6be3a9957290()
		{
		}

		/// <Summary>
		/// The method returns the view for the index given.
		/// </Summary>
		public override DbMappingView GetView(EntitySetBase extent)
		{
			// do not lock if views are loaded
			if (extentViews == null)
			{
				lock(lockObject)
				{
					if (extentViews == null)
					{
						LoadViews();
					}
				}
			}

			DbMappingView view;
			extentViews.TryGetValue(GetExtentFullName(extent), out view);
			return view;
		}

		private static void LoadViews()
		{
			extentViews = new Dictionary<string, DbMappingView>();

			using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CodeFirstDemo2NuInHetEchie.MijnContext.Views.xml"))
			using (var reader = XmlReader.Create(stream))
			{
				while (reader.ReadToFollowing("view"))
				{
					extentViews.Add(reader["extent"], new DbMappingView(reader.ReadElementContentAsString()));
				}
			}
		}

		private static string GetExtentFullName(EntitySetBase entitySet)
		{
			return string.Format("{0}.{1}", entitySet.EntityContainer.Name, entitySet.Name);
		}
	}
}
