using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace CreateNextYear
{
    /// <summary>
    /// 数据库表UA_Account_sub所对应的实体类
    /// </summary>
    [Table(Name = "UA_Account_sub")]
    public class UA_Account_subEntity
    {
        private String m_Cacc_id;
        private String m_Iyear;
        private String m_Csub_id;
        private String m_Bisdelete;
        private String m_Bclosing;
        private String m_Imodiperi;
        private String m_Dsubsysused;

        /// <summary>
        ///设置或返回值Cacc_id
        /// </summary>
        [Column(IsPrimaryKey = true)]
        public String Cacc_id
        {
            get { return m_Cacc_id; }
            set { m_Cacc_id = value; }
        }

        /// <summary>
        ///设置或返回值Iyear
        /// </summary>
        [Column(DbType ="smallint")]
        public String Iyear
        {
            get { return m_Iyear; }
            set { m_Iyear = value; }
        }

        /// <summary>
        ///设置或返回值Csub_id
        /// </summary>
        [Column]
        public String Csub_id
        {
            get { return m_Csub_id; }
            set { m_Csub_id = value; }
        }

        /// <summary>
        ///设置或返回值Bisdelete
        /// </summary>
        [Column(DbType ="bit")]
        public String Bisdelete
        {
            get { return m_Bisdelete; }
            set { m_Bisdelete = value; }
        }

        /// <summary>
        ///设置或返回值Bclosing
        /// </summary>
        [Column(DbType ="bit")]
        public String Bclosing
        {
            get { return m_Bclosing; }
            set { m_Bclosing = value; }
        }

        /// <summary>
        ///设置或返回值Imodiperi
        /// </summary>
        [Column(DbType ="tinyint")]
        public String Imodiperi
        {
            get { return m_Imodiperi; }
            set { m_Imodiperi = value; }
        }

        /// <summary>
        ///设置或返回值Dsubsysused
        /// </summary>
        [Column(DbType ="datetime")]
        public String Dsubsysused
        {
            get { return m_Dsubsysused; }
            set { m_Dsubsysused = value; }
        }

    }

}
