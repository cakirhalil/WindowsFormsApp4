﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class FormRehber : Form
    {
        public FormRehber()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FormRehber_Load(object sender, EventArgs e)
        {
            //MÜŞTERİ BİLGİLERİ

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,SOYAD,TELEFON,TELEFON2,MAIL from TBL_MUSTERILER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //FİRMA BİLGİLERİ

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX from TBL_FIRMALAR", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FormMail frm = new FormMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            FormMail frm = new FormMail();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                frm.mail = dr["MAIL"].ToString();
            }
            frm.Show();
        }
    }
}
