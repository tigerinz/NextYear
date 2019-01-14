
using System;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace CreateNextYear
{
    /// <summary>
    /// 数据库表UA_Account所对应的实体类
    /// </summary>
    [Table(Name = "UA_Account")]
    public class UA_AccountEntity
    {
        private bool isChoose;
        private String m_Isysid;
        private String m_Cacc_id;
        private String m_Cacc_name;
        private String m_Cacc_path;
        private String m_Iyear;
        private String m_Imonth;
        private String m_Cacc_master;
        private String m_Ccurcode;
        private String m_Ccurname;
        private String m_Cunitname;
        private String m_Cunitabbre;
        private String m_Cunitaddr;
        private String m_Cunitzap;
        private String m_Cunittel;
        private String m_Cunitfax;
        private String m_Cunitemail;
        private String m_Cunittaxno;
        private String m_Cunitlp;
        private String m_Cfinkind;
        private String m_Cfintype;
        private String m_Centtype;
        private String m_Ctradekind;
        private EntitySet<UA_Account_subEntity> ua_Account_subs;
        //方便后期操作的
        private int newyear;
        private int maxyear;
        private string sourceDB;
        private string targerDB;

        public bool IsChoose
        {
            get
            {
                return isChoose;
            }

            set
            {
                isChoose = value;
            }
        }

        /// <summary>
        ///设置或返回值Isysid
        /// </summary>
        [Column]
        public String Isysid
        {
            get { return m_Isysid; }
            set { m_Isysid = value; }
        }

        /// <summary>
        ///设置或返回值Cacc_id
        /// </summary>
        [Column(IsPrimaryKey =true)]
        public String Cacc_id
        {
            get { return m_Cacc_id; }
            set { m_Cacc_id = value; }
        }

        /// <summary>
        ///设置或返回值Cacc_name
        /// </summary>
        [Column]
        public String Cacc_name
        {
            get { return m_Cacc_name; }
            set { m_Cacc_name = value; }
        }

        /// <summary>
        ///设置或返回值Cacc_path
        /// </summary>
        [Column]
        public String Cacc_path
        {
            get { return m_Cacc_path; }
            set { m_Cacc_path = value; }
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
        ///设置或返回值Imonth
        /// </summary>
        [Column(DbType ="smallint")]
        public String Imonth
        {
            get { return m_Imonth; }
            set { m_Imonth = value; }
        }

        /// <summary>
        ///设置或返回值Cacc_master
        /// </summary>
        [Column]
        public String Cacc_master
        {
            get { return m_Cacc_master; }
            set { m_Cacc_master = value; }
        }

        /// <summary>
        ///设置或返回值Ccurcode
        /// </summary>
        [Column]
        public String Ccurcode
        {
            get { return m_Ccurcode; }
            set { m_Ccurcode = value; }
        }

        /// <summary>
        ///设置或返回值Ccurname
        /// </summary>
        [Column]
        public String Ccurname
        {
            get { return m_Ccurname; }
            set { m_Ccurname = value; }
        }

        /// <summary>
        ///设置或返回值Cunitname
        /// </summary>
        [Column]
        public String Cunitname
        {
            get { return m_Cunitname; }
            set { m_Cunitname = value; }
        }

        /// <summary>
        ///设置或返回值Cunitabbre
        /// </summary>
        [Column]
        public String Cunitabbre
        {
            get { return m_Cunitabbre; }
            set { m_Cunitabbre = value; }
        }

        /// <summary>
        ///设置或返回值Cunitaddr
        /// </summary>
        [Column]
        public String Cunitaddr
        {
            get { return m_Cunitaddr; }
            set { m_Cunitaddr = value; }
        }

        /// <summary>
        ///设置或返回值Cunitzap
        /// </summary>
        [Column]
        public String Cunitzap
        {
            get { return m_Cunitzap; }
            set { m_Cunitzap = value; }
        }

        /// <summary>
        ///设置或返回值Cunittel
        /// </summary>
        [Column]
        public String Cunittel
        {
            get { return m_Cunittel; }
            set { m_Cunittel = value; }
        }

        /// <summary>
        ///设置或返回值Cunitfax
        /// </summary>
        [Column]
        public String Cunitfax
        {
            get { return m_Cunitfax; }
            set { m_Cunitfax = value; }
        }

        /// <summary>
        ///设置或返回值Cunitemail
        /// </summary>
        [Column]
        public String Cunitemail
        {
            get { return m_Cunitemail; }
            set { m_Cunitemail = value; }
        }

        /// <summary>
        ///设置或返回值Cunittaxno
        /// </summary>
        [Column]
        public String Cunittaxno
        {
            get { return m_Cunittaxno; }
            set { m_Cunittaxno = value; }
        }

        /// <summary>
        ///设置或返回值Cunitlp
        /// </summary>
        [Column]
        public String Cunitlp
        {
            get { return m_Cunitlp; }
            set { m_Cunitlp = value; }
        }

        /// <summary>
        ///设置或返回值Cfinkind
        /// </summary>
        [Column]
        public String Cfinkind
        {
            get { return m_Cfinkind; }
            set { m_Cfinkind = value; }
        }

        /// <summary>
        ///设置或返回值Cfintype
        /// </summary>
        [Column]
        public String Cfintype
        {
            get { return m_Cfintype; }
            set { m_Cfintype = value; }
        }

        /// <summary>
        ///设置或返回值Centtype
        /// </summary>
        [Column]
        public String Centtype
        {
            get { return m_Centtype; }
            set { m_Centtype = value; }
        }

        /// <summary>
        ///设置或返回值Ctradekind
        /// </summary>
        [Column]
        public String Ctradekind
        {
            get { return m_Ctradekind; }
            set { m_Ctradekind = value; }
        }

        public int Newyear
        {
            get
            {
                return newyear;
            }

            set
            {
                newyear = value;
            }
        }

        public int Maxyear
        {
            get
            {
                return maxyear;
            }

            set
            {
                maxyear = value;
            }
        }

        public string SourceDB
        {
            get
            {
                return "UFData_"+Cacc_id+"_"+Maxyear;
            }

        }

        public string TargerDB
        {
            get
            {
                return  "UFData_" + Cacc_id + "_" + Newyear; ;
            }
        }


        [Association(Name ="FK_Account_Sub",Storage = "ua_Account_subs",OtherKey = "Cacc_id",DeleteRule ="NO ACTION")]
        public EntitySet<UA_Account_subEntity> Ua_Account_subs
        {
            get
            {
                return ua_Account_subs;
            }

            set
            {
                ua_Account_subs = value;
            }
        }
    }
}