/**  版本信息模板在安装目录下，可自行修改。
* ShopInfo.cs
*
* 功 能： N/A
* 类 名： ShopInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-11-13 9:40:44   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Dong.DAL
{
	/// <summary>
	/// 数据访问类:ShopInfo
	/// </summary>
	public partial class Dictionary
	{
        public Dictionary()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return DbHelperOleDb.GetMaxID("Id", "Dictionary"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) from Dictionary");
			strSql.Append(" where Id=" + Id.ToString());
			

			return DbHelperOleDb.Exists(strSql.ToString());
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Dong.Model.Dictionary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Dictionary(");
            strSql.Append("KeyStr,ValueStr,Mark)");
			strSql.Append(" values (");
            strSql.Append("@KeyStr,@ValuStre,@Mark)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@KeyStr", OleDbType.VarChar,50),
					new OleDbParameter("@ValueStr", OleDbType.VarChar,100),
					new OleDbParameter("@Mark", OleDbType.VarChar,50)};
            parameters[0].Value = model.KeyStr;
            parameters[1].Value = model.ValueStr;
			parameters[2].Value = model.Mark;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Dong.Model.Dictionary model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Dictionary set ");
            strSql.Append("ValueStr=@ValueStr");
            strSql.Append(" where KeyStr=@KeyStr");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ValueStr", OleDbType.VarChar,100),
					new OleDbParameter("@KeyStr", OleDbType.VarChar,100)};
			parameters[0].Value = model.ValueStr;
            parameters[1].Value = model.KeyStr;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Dictionary ");
			strSql.Append(" where Id=@Id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("delete from Dictionary ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dong.Model.Dictionary GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select Id,KeyStr,ValueStr,Mark from Dictionary ");
			strSql.Append(" where Id=@Id");
			OleDbParameter[] parameters = {
					new OleDbParameter("@Id", OleDbType.Integer,4)
			};
			parameters[0].Value = Id;

			Dong.Model.Dictionary model=new Dong.Model.Dictionary();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dong.Model.Dictionary DataRowToModel(DataRow row)
		{
			Dong.Model.Dictionary model=new Dong.Model.Dictionary();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["KeyStr"]!=null)
				{
                    model.KeyStr = row["KeyStr"].ToString();
				}
                if (row["ValueStr"] != null)
				{
                    model.ValueStr = row["ValueStr"].ToString();
				}
				if(row["Mark"]!=null)
				{
                    model.Mark = row["Mark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select Id,KeyStr,ValueStr,Mark ");
            strSql.Append(" FROM Dictionary ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Dictionary ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
            strSql.Append(")AS Row, T.*  from Dictionary T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "ShopInfo";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

