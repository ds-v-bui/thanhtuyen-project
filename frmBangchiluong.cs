using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
//using System.Data;
using System.Data.SqlClient;
using QL_nhansu.Class;
using QL_nhansu.Controller;

namespace QL_nhansu
{
    public partial class frmBangchiluong : DevComponents.DotNetBar.Office2007Form
    {
        public frmBangchiluong()
        {
            InitializeComponent();
        }
        int goituchamcong = 0;
        int thangcc = 1;
        int namcc = 2009;
        string maphongcc = null;
        public frmBangchiluong(int call, int thang, int nam, string maphong)
        {
            goituchamcong = call;
            thangcc = thang;
            namcc = nam;
        }

        clsLaybangchamcong bangchamcong = new clsLaybangchamcong();
        clsLaybangchiluong bangchiluong = new clsLaybangchiluong();
        clsLaybangchucvu laychucvu = new clsLaybangchucvu();
        clsLayphongban phongban = new clsLayphongban();
        clsLaybangnhanvien NV = new clsLaybangnhanvien();
        clsLaybangbangcap bangcap = new clsLaybangbangcap();
        clsCapnhatchiluong CapnhatCL = new clsCapnhatchiluong();

        clsBangchiluongController control = new clsBangchiluongController();

        DataTable dtCL = new DataTable();
        DataTable dtCC = new DataTable();
        DataTable dtCCthangnam = new DataTable();
        DataTable dtNV = new DataTable();
        DataTable dtNVdanglam = new DataTable();
        DataTable dtNVthuviec = new DataTable();
        DataTable dtCV = new DataTable();
        DataTable dtBC = new DataTable();

        private void frmBangchiluong_Load(object sender, EventArgs e)
        {
            control.HienthicomboboxNV(comboNhanvien);
            control.Hienthicomboboxphongban(combophongban);

            for (int i = 1; i <= 9; i++)
            {
                combochonthang.Items.Add("Tháng 0" + i);
            }
            for (int i = 10; i < 13; i++)
            {
                combochonthang.Items.Add("Tháng " + i);
            }
            if (goituchamcong == 0)
                combochonthang.SelectedIndex = 0;
            else
                combochonthang.SelectedIndex = thangcc - 1;
            for (int i = 1900; i < 2301; i++)
            {
                combochonnam.Items.Add("Năm " + i);
            }
            if (goituchamcong == 0)
            {
                combochonthang.SelectedIndex = 0;
                combochonnam.SelectedIndex = 109;
                combophongban.SelectedIndex = 0;
            }
            else
            {
                combochonthang.SelectedIndex = thangcc - 1;
                combochonnam.SelectedIndex = namcc - 1900;
                combophongban.SelectedValue = maphongcc;
            }
            DataTable dt = new DataTable();
            dt = bangchiluong.Laybangluong();
            control.HienThiGridTheoThangNam(dt, dgvBangchiluong, bnBangchiluong);
            groupchon1.Enabled = false;
            groupchon2.Enabled = false;
          
            bnt_chiluong.Enabled = false;
        }

        //--------------------
        double luongCB;
        double trocaptrachnhiem;
        double trocapQLDN;

        public void Them(int thuviec, string manhanvien, string thangchi, string namchi)
        {
            string maCL = "CL";
            string masothutu;
            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;
            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();
            string thangnam = thang + nam02;
            dtCL = bangchiluong.Laybangluong();
            int phantu = 0;
            foreach (DataRow dt in dtCL.Rows)
            {
                string ma = dt["Maluong"].ToString();
                string mathangnam = ma[2].ToString() + ma[3].ToString() + ma[4].ToString() + ma[5].ToString();
                string mathutu = ma[6].ToString() + ma[7].ToString() + ma[8].ToString() + ma[9].ToString();

                if (thangnam == mathangnam)
                {
                    int stt = Convert.ToInt32(mathutu);
                    if (stt > phantu)
                        phantu = stt;
                }
            }
            if (phantu != 0)
            {
                phantu++;
                if (phantu.ToString().Length == 1)
                    masothutu = "000" + phantu.ToString();
                else if (phantu.ToString().Length == 2)
                    masothutu = "00" + phantu.ToString();
                else if (phantu.ToString().Length == 3)
                    masothutu = "0" + phantu.ToString();
                else
                    masothutu = phantu.ToString();

                maCL = maCL + thangnam + masothutu;


            }
            else
                maCL = maCL + thangnam + "0001";
            //lay luong co ban
            DataTable dtCNCL = new DataTable();
            //dtCV = laychucvu.Laychucvu();
            dtCNCL = CapnhatCL.LaybangcapnhatCL();
            DataRow drLuongCB = dtCNCL.Rows[0];
            luongCB = Convert.ToDouble(drLuongCB["Luongcoban"].ToString());


            dtCCthangnam = bangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thangchi), Convert.ToInt32(namchi));
            int ngaylamviec = 0;
            foreach (DataRow drCC in dtCCthangnam.Rows)

                if (manhanvien == drCC["MaNV"].ToString())
                {
                    ngaylamviec = Convert.ToInt32(drCC["Ngaydilam"].ToString());
                    break;
                }
            if (thuviec == 0)
            {
                double heso = 1;
                string chucvu = null;
                int thamnien = 1;
                dtNV = NV.Laynhanvien();
                foreach (DataRow dr in dtNV.Rows)
                {
                    if (manhanvien == dr["MaNV"].ToString())
                    {
                        heso = Convert.ToDouble(dr["Heso"].ToString());
                        chucvu = dr["Machucvu"].ToString();
                        thamnien = Convert.ToInt32(dr["Thamnien"].ToString());
                        break;
                    }
                }
                double luongthang;
                luongthang = luongCB * heso;
                //Lay luong phu cap chuc vu
                dtCV = laychucvu.Laychucvu();
                double phucapchucvu = 0;
                foreach (DataRow drCV in dtCV.Rows)
                {
                    if (chucvu == drCV["Machucvu"].ToString())
                    {
                        phucapchucvu = Convert.ToDouble(drCV["Hesochucvu"].ToString());
                        break;
                    }

                }
                double LuongphucapCV;
                LuongphucapCV = luongCB * phucapchucvu;


                //Lay phu cap doc hai, tro cap an trua, tro cap xa nha
                dtCNCL = CapnhatCL.LaybangcapnhatCL();
                double phucapdochai;
                double trocapantrua;
                double trocapxanha;
                DataRow drPC = dtCNCL.Rows[0];
                phucapdochai = Convert.ToDouble(drPC["Phucapdochai"].ToString());
                trocapantrua = Convert.ToDouble(drPC["Trocapantrua"].ToString());
                trocapxanha = Convert.ToDouble(drPC["Trocapxanha"].ToString());
                //Lay tro cap trach nhiem, tro cap quan ly doanh nghiep

                double trocaptrachnhiem1;
                double trocapQLDN1;
                trocaptrachnhiem1 = Convert.ToDouble(drPC["Trocaptrachnhiem"].ToString());
                trocapQLDN1 = Convert.ToDouble(drPC["TrocapQLDN"].ToString());
                DataTable dtCCCV = new DataTable();
                dtCCCV = bangchiluong.Laybangchamcongtheochucvu();
                foreach (DataRow drCCchucvu in dtCCCV.Rows)
                {
                    if (drCCchucvu["Machucvu"].ToString() == "CV01")
                    {
                        trocaptrachnhiem = trocaptrachnhiem1 * 3;
                        trocapQLDN = trocapQLDN1 * 2;
                    }
                    else
                    {
                        if (drCCchucvu["Machucvu"].ToString() == "CV02")
                        {
                            trocaptrachnhiem = trocaptrachnhiem1 * 2;
                            trocapQLDN = trocapQLDN1;
                        }
                        else
                        {
                            if (drCCchucvu["Machucvu"].ToString() == "CV04")
                            {
                                trocaptrachnhiem = trocaptrachnhiem1 * 1;
                                trocapQLDN = trocapQLDN1 * 0;
                            }
                            else
                            {
                                if (drCCchucvu["Machucvu"].ToString() == "CV05")
                                {
                                    trocaptrachnhiem = trocaptrachnhiem1 * 0.5;
                                    trocapQLDN = trocapQLDN1 * 0;
                                }
                                else
                                {
                                    trocaptrachnhiem = trocaptrachnhiem1 * 0;
                                    trocapQLDN = trocapQLDN1 * 0;
                                }
                            }

                        }
                    }

                }

                double tongluong = luongthang + LuongphucapCV;
                double BHXH = tongluong * 0.06;
                double BHYT = tongluong * 0.01;
                double doanphi = tongluong * 0.01;
                double thuclinh = tongluong * 0.92;

                if (thamnien == 1)
                    thuclinh = thuclinh * 90 / 100;
                bangchiluong.Themmoi(maCL, thangchi + "/01" + "/" + namchi, manhanvien, ngaylamviec, luongthang, 0, LuongphucapCV, phucapdochai, trocaptrachnhiem, trocapantrua, trocapxanha, trocapQLDN, tongluong, BHXH, BHYT, doanphi, thuclinh);
            }
            if (thuviec == 1)
            {
                double thuclinh = luongCB * 70 / 100;
                bangchiluong.Themmoi(maCL, thangchi + "/01" + "/" + namchi, manhanvien, ngaylamviec, luongCB, 0, 0, 0, 0, 0, 0, 0, luongCB, 0, 0, 0, thuclinh);
            }

        }
       
         //  

        
        public void Chiluong(int thang, int nam, string phongban)
        {

            if (phongban != null)
                dtNV = NV.Laynhanvientheophongban(phongban);
            dtCC = bangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));

            if (dtNV.Rows.Count != 0)
            {
                DataTable dtCCtheophong = new DataTable();
                dtCCtheophong = dtCC.Clone();
                foreach (DataRow dr1 in dtCC.Rows)
                    foreach (DataRow dr2 in dtNV.Rows)
                    {
                        if (dr1["MaNV"].ToString() == dr2["MaNV"].ToString())
                            dtCCtheophong.ImportRow(dr1);

                    }
                if (dtCCtheophong.Rows.Count != 0)
                {
                    dtCL = bangchiluong.Laybangluongtheothangnam(Convert.ToInt32(thang), Convert.ToInt32(nam));
                    DataTable dtCLtheophong = new DataTable();
                    dtCLtheophong = dtCL.Clone();
                    foreach (DataRow dr3 in dtCL.Rows)
                        foreach (DataRow dr4 in dtNV.Rows)
                        {
                            if (dr3["MaNV"].ToString() == dr4["MaNV"].ToString())
                                dtCLtheophong.ImportRow(dr3);
                        }
                    control.HienThiGridTheoThangNam(dtCLtheophong, dgvBangchiluong, bnBangchiluong);
                }
                else
                {
                    DataTable dtCLrong=new DataTable();
                    dtCLrong=bangchiluong.Laybangluongrong();
                    control.HienThiGridTheoThangNam(dtCLrong, dgvBangchiluong, bnBangchiluong);

                }

            }
            else
                MessageBox.Show("Khong co nhan vien phong ban nay");
        }

        public void Luu()
        {
            int dong = dgvBangchiluong.CurrentRow.Index;
            bangchiluong.Capnhat(dgvBangchiluong["Maluong", dong].Value.ToString(), Convert.ToDouble(dgvBangchiluong["Tongluong", dong].Value.ToString()), Convert.ToDouble(dgvBangchiluong["Thuclinh", dong].Value.ToString()), Convert.ToDouble(dgvBangchiluong["Phucapdochai", dong].Value.ToString()), Convert.ToDouble(dgvBangchiluong["Trocaptrachnhiem", dong].Value.ToString()), Convert.ToDouble(dgvBangchiluong["Trocapantrua", dong].Value.ToString()), Convert.ToDouble(dgvBangchiluong["Trocapxanha", dong].Value.ToString()), Convert.ToDouble(dgvBangchiluong["TrocapQLDN", dong].Value.ToString()));
        }

        private void frmBangchiluong_Activated(object sender, EventArgs e)
        {
            //bnt_chiluong_Click(sender, e);
            string thang = combochonthang.SelectedItem.ToString();
            string nam = combochonnam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();

            dtCL = bangchiluong.Laybangluongtheothangnam(Convert.ToInt32(thang), Convert.ToInt32(nam));
            if (combophongban.SelectedValue != null)
                dtNV = NV.Laynhanvientheophongban(combophongban.SelectedValue.ToString());
            dtCC = bangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));
            DataTable dtCCtheophong = new DataTable();
            dtCCtheophong = dtCC.Clone();
            foreach (DataRow dr1 in dtCC.Rows)
                foreach (DataRow dr2 in dtNV.Rows)
                {
                    if (dr1["MaNV"].ToString() == dr2["MaNV"].ToString())
                        dtCCtheophong.ImportRow(dr1);
                }
            if (dtCCtheophong.Rows.Count != 0)
            {
                DataTable dtCLtheophong = new DataTable();
                dtCLtheophong = dtCL.Clone();
                foreach (DataRow dr1 in dtCL.Rows)
                    foreach (DataRow dr2 in dtNV.Rows)
                    {
                        if (dr1["MaNV"].ToString() == dr2["MaNV"].ToString())
                            dtCLtheophong.ImportRow(dr1);
                    }
                control.HienThiGridTheoThangNam(dtCLtheophong, dgvBangchiluong, bnBangchiluong);

            }
        }

        private void dgvBangchiluong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int donghienhanh = dgvBangchiluong.CurrentRow.Index;
            if (dgvBangchiluong["BHXH", donghienhanh].Value.ToString().Length != 1)
            {
                double luongthang = Convert.ToDouble(dgvBangchiluong["Luongthang", donghienhanh].Value.ToString());
                double phucapchucvu = Convert.ToDouble(dgvBangchiluong["PhucapCV", donghienhanh].Value.ToString());
                double phucapdochai = Convert.ToDouble(dgvBangchiluong["Phucapdochai", donghienhanh].Value.ToString());
                double trocaptrachnhiem = Convert.ToDouble(dgvBangchiluong["Trocaptrachnhiem", donghienhanh].Value.ToString());
                double trocapantrua = Convert.ToDouble(dgvBangchiluong["Trocapantrua", donghienhanh].Value.ToString());
                double trocapxanha = Convert.ToDouble(dgvBangchiluong["Trocapxanha", donghienhanh].Value.ToString());
                double trocapQLDN = Convert.ToDouble(dgvBangchiluong["TrocapQLDN", donghienhanh].Value.ToString());
                double tongluong = luongthang + phucapchucvu + phucapdochai + trocaptrachnhiem + trocapantrua + trocapxanha + trocapQLDN;
                dgvBangchiluong["Tongluong", donghienhanh].Value = tongluong;
                dgvBangchiluong["BHXH", donghienhanh].Value = tongluong * 0.06;
                dgvBangchiluong["BHYT", donghienhanh].Value = tongluong * 0.01;
                dgvBangchiluong["Doanphi", donghienhanh].Value = tongluong * 0.01;

                int thamnien = 1;
                dtNV = NV.Laynhanvien();
                foreach (DataRow dr in dtNV.Rows)
                {
                    if (dgvBangchiluong["comboNhanvien", donghienhanh].Value.ToString() == dr["MaNV"].ToString())
                    {
                        thamnien = Convert.ToInt32(dr["Thamnien"].ToString());
                        break;
                    }
                }
                if (thamnien == 1)
                    dgvBangchiluong["Thuclinh", donghienhanh].Value = (tongluong * 0.92) * 90 / 100;
                else
                    dgvBangchiluong["Thuclinh", donghienhanh].Value = tongluong * 0.92;
                Luu();



            }
        }

        private void bnt_chiluong_Click(object sender, EventArgs e)
        {
            string thang = combochonthang.SelectedItem.ToString();
            string nam = combochonnam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
            if (check1.Checked == true && check2.Checked == true)
            {
                //dgvBangchiluong.Enabled = false;

                Chiluong(Convert.ToInt32(thang), Convert.ToInt32(nam), combophongban.SelectedValue.ToString());
            }
            else
            {
                if (check1.Checked == true && check2.Checked == false)
                {
                    //dgvBangchiluong.Enabled = false;

                    dtCCthangnam = bangchiluong.Laybangluongtheothangnam(Convert.ToInt32(thang), Convert.ToInt32(nam));
                    control.HienThiGridTheoThangNam(dtCCthangnam, dgvBangchiluong, bnBangchiluong);
                }
                else
                {
                    if (check1.Checked == false && check2.Checked == true)
                    {
                        //dgvBangchiluong.Enabled = false;
                        DataTable dtNVtheophong = new DataTable();
                        dtNVtheophong = NV.Laynhanvientheophongban(combophongban.SelectedValue.ToString());
                        dtCL = bangchiluong.Laybangluong();
                        DataTable dtCLtheophong = new DataTable();
                        dtCLtheophong = dtCL.Clone();
                        foreach (DataRow dr1 in dtCL.Rows)
                        {
                            foreach (DataRow dr2 in dtNVtheophong.Rows)
                            {
                                if (dr1["MaNV"].ToString() == dr2["MaNV"].ToString())
                                {
                                    dtCLtheophong.ImportRow(dr1);
                                    break;
                                }
                            }
                        }
                        control.HienThiGridTheoThangNam(dtCLtheophong, dgvBangchiluong, bnBangchiluong);
                    }
                    else
                        MessageBoxEx.Show("Bạn chưa tích chọn tháng năm hoặc phòng ban ");
                }
            }
        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            if (check1.Checked == true)
            {
                groupchon1.Enabled = true;
                combochonthang.Enabled = true;
                combochonnam.Enabled = true;
                bnt_chiluong.Enabled = true;


            }
            else
            {
                groupchon2.Enabled = false;
                combochonthang.Enabled = false;
                combochonnam.Enabled = false;
            }
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            if (check2.Checked == true)
            {
                groupchon2.Enabled = true;
                bnt_chiluong.Enabled = true;
            }
            else
                groupchon2.Enabled = false;
        }

       
               

       


    }
}