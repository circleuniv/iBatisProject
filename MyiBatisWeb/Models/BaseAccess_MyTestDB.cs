using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using MyiBatisWeb.Models.MetaTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyiBatisWeb.Models
{
    public class BaseAccess_MyTestDB
    {
        private ISqlMapper iSqlMapper = null;

        public BaseAccess_MyTestDB()
        {
            DomSqlMapBuilder builder = new DomSqlMapBuilder();

            iSqlMapper = builder.Configure("Models/SqlMaps/SqlMap_MyTestDB.config") as SqlMapper;
        }


        public IList<StudentViewModel> QueryForList<StudentViewModel>(string statementName, object parameterObject = null)
        {

            if (iSqlMapper != null)
            {
                IList<StudentViewModel> list = iSqlMapper.QueryForList<StudentViewModel>(statementName, parameterObject);
                             
                return list;

            }
            return null;
        }

        public object QueryForObject(string statementName, object parameterObject = null)
        {
            if (iSqlMapper != null)
            {
                var outTopOne = iSqlMapper.QueryForObject(statementName, parameterObject);
                return (StudentViewModel)outTopOne;
            }
            return null;
        }


        //public IList<T> QueryForList<T>(string statementName, object parameterObject = null)
        //{
        //    if (iSqlMapper != null)
        //    {
        //        IList<T> list = iSqlMapper.QueryForList<T>(statementName, parameterObject).ToList();
        //        return list;

        //    }
        //    return null;
        //}

        //public object QueryForObject(string statementName, object parameterObject =null) {
        //    if (iSqlMapper != null)
        //    {
        //        var outTopOne = iSqlMapper.QueryForObject(statementName, parameterObject);
        //        return outTopOne;
        //    }
        //    return null;
        //}

        ////public int InsertBatch<T>(string statementName, object parameterObject = null)
        ////{
        ////    if (iSqlMapper != null)
        ////    {
        ////        iSqlMapper.BeginTransaction();
        ////        try
        ////        {
        ////            foreach (var batchObj in (List<Hashtable>)parameterObject)
        ////            {
        ////                iSqlMapper.Insert(statementName, batchObj);
        ////            }
        ////            iSqlMapper.CommitTransaction();
        ////            return 1;
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            iSqlMapper.RollBackTransaction();
        ////            throw ex;
        ////        }
        ////    }
        ////    return 0;
        ////}

        //public int Insert<T>(string statementName, object parameterObject = null)
        //{
        //    if (iSqlMapper != null)
        //    {
        //        try
        //        {
        //            return (int)iSqlMapper.Insert(statementName, parameterObject);
        //        }
        //        catch (Exception ex)
        //        {
        //            return 0;
        //        }
        //    }
        //    return 0;
        //}

        public int Update(string statementname, object parameterobject = null)
        {
            if (iSqlMapper != null)
            {
                return iSqlMapper.Update(statementname, parameterobject);
            }
            return 0;
        }

        public int Delete(string statementName, string primaryKeyId)
        {
            if (iSqlMapper != null)
            {
                return iSqlMapper.Delete(statementName, primaryKeyId);
            }
            return 0;
        }

        //public int Delete<T>(string statementName, object parameterObject = null)
        //{
        //    if (iSqlMapper != null)
        //    {
        //        return iSqlMapper.Delete(statementName, parameterObject);
        //    }
        //    return 0;
        //}


    }
}