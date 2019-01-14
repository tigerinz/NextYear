using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace CreateNextYear
{


    /// <summary>
    /// 数据库表GL_mend所对应的实体类
    /// </summary>
    [Table(Name = "GL_mend")]
    public class GL_mendEntity
    {
        private String m_Iperiod;
        private bool? m_Bflag;
        private bool? m_Bcheck;
        private String m_Dpri_check;
        private bool? m_Bflag_ap;
        private bool? m_Bflag_ar;
        private bool? m_Bflag_ca;
        private bool? m_Bflag_fa;
        private bool? m_Bpri_check;
        private bool? m_Bflag_fd;
        private bool? m_Bflag_ia;
        private bool? m_Bflag_po;
        private bool? m_Bflag_pp;
        private bool? m_Bflag_pu;
        private bool? m_Bflag_rp;
        private bool? m_Bflag_so;
        private bool? m_Bflag_wa;
        private bool? m_Bflag_st;
        private bool? m_Bflag_sa;
        private bool? m_Bflag_bi;
        private bool? m_Bflag_nb;
        private bool? m_Bflag_zf;
        private bool? m_Bflag_mp;
        private bool? m_Bflag_mc;
        private bool? m_Bflag_kj;
     
        /// <summary>
        ///设置或返回值Iperiod
        /// </summary>
        [Column(DbType ="tinyint")]
        public String Iperiod
        {
            get { return m_Iperiod; }
            set { m_Iperiod = value; }
        }

        /// <summary>
        ///设置或返回值Bflag
        /// </summary>
        [Column]
        public bool? Bflag
        {
            get { return m_Bflag; }
            set { m_Bflag = value; }
        }

        /// <summary>
        ///设置或返回值Bcheck
        /// </summary>
        [Column]
        public bool? Bcheck
        {
            get { return m_Bcheck; }
            set { m_Bcheck = value; }
        }

        /// <summary>
        ///设置或返回值Dpri_check
        /// </summary>
        [Column]
        public String Dpri_check
        {
            get { return m_Dpri_check; }
            set { m_Dpri_check = value; }
        }

        /// <summary>
        ///设置或返回值Bpri_check
        /// </summary>
        [Column]
        public bool? Bpri_check
        {
            get { return m_Bpri_check; }
            set { m_Bpri_check = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_ap
        /// </summary>
        [Column]
        public bool? Bflag_ap
        {
            get { return m_Bflag_ap; }
            set { m_Bflag_ap = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_ar
        /// </summary>
        [Column]
        public bool? Bflag_ar
        {
            get { return m_Bflag_ar; }
            set { m_Bflag_ar = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_ca
        /// </summary>
        [Column]
        public bool? Bflag_ca
        {
            get { return m_Bflag_ca; }
            set { m_Bflag_ca = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_fa
        /// </summary>
        [Column]
        public bool? Bflag_fa
        {
            get { return m_Bflag_fa; }
            set { m_Bflag_fa = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_fd
        /// </summary>
        [Column]
        public bool? Bflag_fd
        {
            get { return m_Bflag_fd; }
            set { m_Bflag_fd = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_ia
        /// </summary>
        [Column]
        public bool? Bflag_ia
        {
            get { return m_Bflag_ia; }
            set { m_Bflag_ia = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_po
        /// </summary>
        [Column]
        public bool? Bflag_po
        {
            get { return m_Bflag_po; }
            set { m_Bflag_po = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_pp
        /// </summary>
        [Column]
        public bool? Bflag_pp
        {
            get { return m_Bflag_pp; }
            set { m_Bflag_pp = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_pu
        /// </summary>
        [Column]
        public bool? Bflag_pu
        {
            get { return m_Bflag_pu; }
            set { m_Bflag_pu = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_rp
        /// </summary>
        [Column]
        public bool? Bflag_rp
        {
            get { return m_Bflag_rp; }
            set { m_Bflag_rp = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_so
        /// </summary>
        [Column]
        public bool? Bflag_so
        {
            get { return m_Bflag_so; }
            set { m_Bflag_so = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_wa
        /// </summary>
        [Column]
        public bool? Bflag_wa
        {
            get { return m_Bflag_wa; }
            set { m_Bflag_wa = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_st
        /// </summary>
        [Column]
        public bool? Bflag_st
        {
            get { return m_Bflag_st; }
            set { m_Bflag_st = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_sa
        /// </summary>
        [Column]
        public bool? Bflag_sa
        {
            get { return m_Bflag_sa; }
            set { m_Bflag_sa = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_bi
        /// </summary>
        [Column]
        public bool? Bflag_bi
        {
            get { return m_Bflag_bi; }
            set { m_Bflag_bi = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_nb
        /// </summary>
        [Column]
        public bool? Bflag_nb
        {
            get { return m_Bflag_nb; }
            set { m_Bflag_nb = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_zf
        /// </summary>
        [Column]
        public bool? Bflag_zf
        {
            get { return m_Bflag_zf; }
            set { m_Bflag_zf = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_mp
        /// </summary>
        [Column]
        public bool? Bflag_mp
        {
            get { return m_Bflag_mp; }
            set { m_Bflag_mp = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_mc
        /// </summary>
        [Column]
        public bool? Bflag_mc
        {
            get { return m_Bflag_mc; }
            set { m_Bflag_mc = value; }
        }

        /// <summary>
        ///设置或返回值Bflag_kj
        /// </summary>
        [Column]
        public bool? Bflag_kj
        {
            get { return m_Bflag_kj; }
            set { m_Bflag_kj = value; }
        }

    }

}
