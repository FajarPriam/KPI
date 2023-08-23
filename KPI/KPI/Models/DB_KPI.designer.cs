﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KPI.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DB_FATB_KPI_KPT")]
	public partial class DB_KPIDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion

        public DB_KPIDataContext() :
                base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DB_FATB_KPI_KPTConnectionString"].ConnectionString, mappingSource)
        {
            OnCreated();
        }

        public DB_KPIDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DB_KPIDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DB_KPIDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DB_KPIDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<VW_MENU_ROLE> VW_MENU_ROLEs
		{
			get
			{
				return this.GetTable<VW_MENU_ROLE>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.VW_MENU_ROLE")]
	public partial class VW_MENU_ROLE
	{
		
		private int _ID;
		
		private System.Nullable<int> _ROLE_ID;
		
		private string _ROLE;
		
		private System.Nullable<int> _MENU_ID;
		
		private System.Nullable<int> _ID_PARENT_MENU;
		
		private string _MENU_DESC;
		
		private string _URL;
		
		private string _ICON;
		
		private System.Nullable<int> _ORDER;
		
		public VW_MENU_ROLE()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROLE_ID", DbType="Int")]
		public System.Nullable<int> ROLE_ID
		{
			get
			{
				return this._ROLE_ID;
			}
			set
			{
				if ((this._ROLE_ID != value))
				{
					this._ROLE_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROLE", DbType="VarChar(50)")]
		public string ROLE
		{
			get
			{
				return this._ROLE;
			}
			set
			{
				if ((this._ROLE != value))
				{
					this._ROLE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MENU_ID", DbType="Int")]
		public System.Nullable<int> MENU_ID
		{
			get
			{
				return this._MENU_ID;
			}
			set
			{
				if ((this._MENU_ID != value))
				{
					this._MENU_ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID_PARENT_MENU", DbType="Int")]
		public System.Nullable<int> ID_PARENT_MENU
		{
			get
			{
				return this._ID_PARENT_MENU;
			}
			set
			{
				if ((this._ID_PARENT_MENU != value))
				{
					this._ID_PARENT_MENU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MENU_DESC", DbType="VarChar(150)")]
		public string MENU_DESC
		{
			get
			{
				return this._MENU_DESC;
			}
			set
			{
				if ((this._MENU_DESC != value))
				{
					this._MENU_DESC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_URL", DbType="NChar(10)")]
		public string URL
		{
			get
			{
				return this._URL;
			}
			set
			{
				if ((this._URL != value))
				{
					this._URL = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ICON", DbType="VarChar(50)")]
		public string ICON
		{
			get
			{
				return this._ICON;
			}
			set
			{
				if ((this._ICON != value))
				{
					this._ICON = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[ORDER]", Storage="_ORDER", DbType="Int")]
		public System.Nullable<int> ORDER
		{
			get
			{
				return this._ORDER;
			}
			set
			{
				if ((this._ORDER != value))
				{
					this._ORDER = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
