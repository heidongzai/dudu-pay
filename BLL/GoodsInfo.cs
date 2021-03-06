﻿/**  版本信息模板在安装目录下，可自行修改。
* GoodsInfo.cs
*
* 功 能： N/A
* 类 名： GoodsInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-11-20 22:50:30   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Dong.Model;
namespace Dong.BLL
{
	/// <summary>
	/// GoodsInfo
	/// </summary>
	public partial class GoodsInfo
	{
		private readonly Dong.DAL.GoodsInfo dal=new Dong.DAL.GoodsInfo();
		public GoodsInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(string Code)
        {
            return dal.Exists(Code);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Dong.Model.GoodsInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Dong.Model.GoodsInfo model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string Code)
		{
			
			return dal.Delete(Code);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Codelist )
		{
			return dal.DeleteList(Codelist );
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Dong.Model.GoodsInfo GetModelById(int id)
        {

            return dal.GetModelById(id);
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Dong.Model.GoodsInfo GetModel(string Code)
		{
			
			return dal.GetModel(Code);
		}

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dong.Model.GoodsInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Dong.Model.GoodsInfo> DataTableToList(DataTable dt)
		{
			List<Dong.Model.GoodsInfo> modelList = new List<Dong.Model.GoodsInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Dong.Model.GoodsInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

        public DataSet GetListPage(string strWhere, int pageSize, int page)
        {
            DataSet ds = new DataSet();
            string strSql = "";
            if (strWhere != "")
            {
                strSql = "select top " + pageSize + " * from GoodsInfo where id >=(select top 1 max(id) from (select top " + (((page - 1) * pageSize) + 1).ToString() + " * from GoodsInfo where  1=1 " + strWhere + " order by id)) and 1=1 " + strWhere;
            }
            else
            {
                strSql = "select top " + pageSize + " * from GoodsInfo where id >=(select top 1 max(id) from (select top " + (((page - 1) * pageSize) + 1).ToString() + " * from GoodsInfo order by id)) order by id";

            }
            ds = Maticsoft.DBUtility.DbHelperOleDb.Query(strSql);
            return ds;
        }

        public bool UpdateCount(int counts, string code)
        {
            return dal.UpdateCount(counts, code);
        }

        public DataTable getChengBenList()
        {
            DataTable dt = new DataTable();
            dt = Maticsoft.DBUtility.DbHelperOleDb.Query("SELECT Code ,GoodName,CategoryName,Counts,Price2 ,Price2*Counts as CostsAll FROM GoodsInfo where 1=1 and Counts>0").Tables[0];

            return dt;
        }
        public DataTable getChengBen()
        {
            DataTable dt = new DataTable();
            dt = Maticsoft.DBUtility.DbHelperOleDb.Query("SELECT sum(Price2*Counts) as Counts from GoodsINfo where 1=1 and Counts>0").Tables[0];

            return dt;
        }
        public DataTable getKCZS()
        {
            DataTable dt = new DataTable();
            dt = Maticsoft.DBUtility.DbHelperOleDb.Query("SELECT sum(Counts) as Counts from GoodsINfo where 1=1 and Counts>0").Tables[0];

            return dt;
        }
		#endregion  ExtensionMethod
	}
}

