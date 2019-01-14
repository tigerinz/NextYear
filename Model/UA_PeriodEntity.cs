using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateNextYear
{

    /// <summary>
    /// 数据库表UA_Period所对应的实体类
    /// </summary>
    public class UA_PeriodEntity
    {
        private String m_Cacc_id;
        private String m_Iyear;
        private String m_Iid;
        private String m_Dbegin;
        private String m_Dend;
        private String m_Bisdelete;

        /// <summary>
        ///设置或返回值Cacc_id
        /// </summary>
        public String Cacc_id
        {
            get { return m_Cacc_id; }
            set { m_Cacc_id = value; }
        }

        /// <summary>
        ///设置或返回值Iyear
        /// </summary>
        public String Iyear
        {
            get { return m_Iyear; }
            set { m_Iyear = value; }
        }

        /// <summary>
        ///设置或返回值Iid
        /// </summary>
        public String Iid
        {
            get { return m_Iid; }
            set { m_Iid = value; }
        }

        /// <summary>
        ///设置或返回值Dbegin
        /// </summary>
        public String Dbegin
        {
            get { return m_Dbegin; }
            set { m_Dbegin = value; }
        }

        /// <summary>
        ///设置或返回值Dend
        /// </summary>
        public String Dend
        {
            get { return m_Dend; }
            set { m_Dend = value; }
        }

        /// <summary>
        ///设置或返回值Bisdelete
        /// </summary>
        public String Bisdelete
        {
            get { return m_Bisdelete; }
            set { m_Bisdelete = value; }
        }

    }

}
