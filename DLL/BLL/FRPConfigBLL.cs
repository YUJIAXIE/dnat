﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DLL.Models;

namespace DLL.BLL
{
   public class FRPConfigBLL
    {
        DLL.DAL.FRPConfigDAL fd = new DAL.FRPConfigDAL();
        /// <summary>
        /// 查询隧道信息
        /// </summary>
        /// <param name="UId">UserId</param>
        /// <param name="All">是否行转列 true 是 false 否</param>
        /// <returns></returns>
        public DataTable SelectUsersFrpConfig(string UId,bool All)
        {
            return fd.SelectUsersFrpConfig(UId, All);
        }

        public int DeleteUsersFrpConfig(FrpConfig frp)
        {
            return fd.DeleteUsersFrpConfig(frp);
        }

        public int InsertUsersFrpConfig(FrpConfig frp)
        {
            return fd.InsertUsersFrpConfig(frp);
        }
        public string SelectMax(string UId)
        {
            return fd.SelectMax(UId);
        }
        /// <summary>
        /// 根据类型、UID查询数量
        /// </summary>
        /// <param name="Type">类型</param>
        /// <param name="Uid">客户id</param>
        /// <returns>数量</returns>
        public int SelectCount(string Type,string Uid)
        {
            return fd.SelectCount(Type,Uid);
        }
    }
}
