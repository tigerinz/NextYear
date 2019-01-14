using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SqlStatementTemplate
{

    /// <summary>
    /// sql模板类 
    /// </summary>
    public class SQLStatement
    {
        /// <summary>
        /// 空构造方法
        /// </summary>
        public SQLStatement() { }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 干SQL 语句模板
        /// </summary>
        public string DrySQL { get; set; }

        public string ALiveSQL { get; set; }
        /// <summary>
        ///参数 数组 
        /// </summary>
        public string[] ParamNames { get; set; }
        /// <summary>
        ///参数 数组 
        /// </summary>

        public string Introduction { get; set; }


    }

    public class SQLStatementQueue{

        public List<string> sqlStatements { get; set; }
        public string[] paramValues { get; set; }
    }
    /// <summary>
    /// sql语句模板管理类
    /// </summary>
    public class SQLTemplateManage
    {
        /// <summary>
        ///  初始化一个语句组
        /// </summary>
        public List<SQLStatement> SQLStatements = null;
        /// <summary>
        ///  空构造操作
        /// </summary>
        public SQLTemplateManage() { }

        // /// <summary>
        // ///   得到所有干语句
        // /// </summary>
        // /// <param name="xmlPath">xml文件路径</param>
        // /// <returns></returns>
        //public List<SQLStatement> GetSQLStatements(string xmlPath)
        //{
        //    XElement doc = XElement.Load(xmlPath);
        //    var temp = from t in doc.Elements("SQLStatement")
        //               select new SQLStatement()
        //               {
        //                   Name = t.Element("Name").Value.ToString(),
        //                   Introduction = t.Element("Introduction").Value.ToString(),
        //                   DrySQL = t.Element("DrySQL").Value.ToString(),
        //                   IsAlive = false,

        //               };
        //     Dictionary<string, SQLStatement> SQLStatements = new Dictionary<string, SQLStatement>();
        //    foreach (var t in temp)
        //    {
        //        SQLStatements[t.Name] = t;
        //    }
        //return SQLStatements;
        //}
        /// <summary>
        ///   得到所有活语句组
        /// </summary>
        /// <param name="xmlPath">xml文件路径</param>
        /// <param name="sqlStatementParams">参数组</param>
        /// <returns></returns>
        public List<SQLStatement> GetSQLStatements(string xmlPath, SQLStatementQueue statementQueue)
        {
            XElement doc = XElement.Load(xmlPath);
            var temp = from t in doc.Elements("SQLStatement")
                       select new Dictionary<string, string>{
                           
                           t.Element("asd").Value.ToString()="asdf"
                       //    t.Element("Name").Value.ToString(),
                       //    new SQLStatement {
                       //  Name = t.Element("Name").Value.ToString(),
                       //Introduction = t.Element("Introduction").Value.ToString(),
                       //DrySQL = t.Element("DrySQL").Value.ToString(),
                       // ParamNames = t.Element("ParaNames").Value.Split(',')
                       //    }
                       };

                       //select new SQLStatement()
                       //{
                       //    Name = t.Element("Name").Value.ToString(),
                       //    Introduction = t.Element("Introduction").Value.ToString(),
                       //    DrySQL = t.Element("DrySQL").Value.ToString(),
                       //    ParamNames = t.Element("ParaNames").Value.Split(','),

                       //};
            List<SQLStatement> SQLStatements = new List<SQLStatement>();
            foreach (var t in temp)
            {
                //set param value
                t.param = sqlStatementParams[t.Name];
                //set dictionary
                SQLStatements[t.Name] = t;
            }
            return SQLStatements;
        }
        /// <summary>
        ///  通过活语句组，得到所有活语句
        /// </summary>
        /// <param name="xmlPath">xml文件路径</param>
        /// <param name="sqlStatementParams">参数组</param>
        /// <returns></returns>
        public string getALiveSQLs(string xmlPath, Dictionary<string, string[]> sqlStatementParams)
        {
            Dictionary<string, SQLStatement> aliveStatements = this.GetAliveSQLStatements(xmlPath, sqlStatementParams);
            StringBuilder sb = new StringBuilder();
            foreach (var item in aliveStatements)
            {
                sb.Append("--").Append(item.Key).Append("\r\n").
                    Append(item.Value.ALiveSQL.Replace("\r","").Replace("\n","").Replace("\r\n",""))
                    .Append(";").Append("\r\n");
            }
             return  sb.ToString();
        }

    }

  
}


