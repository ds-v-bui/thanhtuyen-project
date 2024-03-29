using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using QL_nhansu.Class;
using QL_nhansu.Controller;
using DevComponents.DotNetBar.Controls;


namespace QL_nhansu
{
    public partial class frmBangchamcong : DevComponents.DotNetBar.Office2007Form
    {
        public frmBangchamcong()
        {
            InitializeComponent();
        }
        clsLaybangchamcong laybangchamcong = new clsLaybangchamcong();
        clsLaybangchiluong laybangchiluong = new clsLaybangchiluong();
        clsLaybangnhanvien laybangnhanvien = new clsLaybangnhanvien();
        clsLayphongban layphongban = new clsLayphongban();

        clsBangchamcongController control = new clsBangchamcongController();
        clsBangchiluongController chicontrol = new clsBangchiluongController();

        DataTable dtCC = new DataTable();
        DataTable dtCCtrongnam = new DataTable();
        DataTable dtNV = new DataTable();
        DataTable dtchiluongtheothangnam = new DataTable();
        DataTable dtNhanvientheophong = new DataTable();
        DataTable dtNVtheophongdanglam = new DataTable();
        DataTable dtNVthuviec = new DataTable();
        //Download source code FREE tai Sharecode.vn
        private void frmBangchamcong_Load(object sender, EventArgs e)
        {
            control.Hienthitextboxmachamcong(txtmaCC);
            control.HienthicomboboxNhanvien(cmbnhanvien);
            control.Hienthitexboxthang(txtthang);
            control.Hienthicombobox1(n1);
            control.Hienthicombobox2(n2);
            control.Hienthicombobox3(n3);
            control.Hienthicombobox4(n4);
            control.Hienthicombobox5(n5);
            control.Hienthicombobox6(n6);
            control.Hienthicombobox7(n7);
            control.Hienthicombobox8(n8);
            control.Hienthicombobox9(n9);
            control.Hienthicombobox10(n10);
            control.Hienthicombobox11(n11);
            control.Hienthicombobox12(n12);
            control.Hienthicombobox13(n13);
            control.Hienthicombobox14(n14);
            control.Hienthicombobox15(n15);
            control.Hienthicombobox16(n16);
            control.Hienthicombobox17(n17);
            control.Hienthicombobox18(n18);
            control.Hienthicombobox19(n19);
            control.Hienthicombobox20(n20);
            control.Hienthicombobox21(n21);
            control.Hienthicombobox22(n22);
            control.Hienthicombobox23(n23);
            control.Hienthicombobox24(n24);
            control.Hienthicombobox25(n25);
            control.Hienthicombobox26(n26);
            control.Hienthicombobox27(n27);
            control.Hienthicombobox28(n28);
            control.Hienthicombobox29(n29);
            control.Hienthicombobox30(n30);
            control.Hienthicombobox31(n31);
            control.Hienthitextboxngaydilam(txtngaydilam);
            control.Hienthitextboxngayvang(txtngayvang);
            control.Hienthitextboxtongngay(txttongngay);

            for (int i = 1; i < 10; i++)
            {
                cmbthang.Items.Add("Tháng 0" + i);
            }
            for (int i = 10; i < 13; i++)
            {
                cmbthang.Items.Add("Tháng " + i);
            }
            cmbthang.SelectedIndex = 0;
            for (int i = 2000; i < 2020; i++)
            {
                cmbnam.Items.Add("Năm " + i);
            }
            cmbnam.SelectedIndex = 02;
            cmbphongban.DataSource = layphongban.Layphongban();
            cmbphongban.DisplayMember = "Tenphong";
            cmbphongban.ValueMember = "Maphongban";
            cmbphongban.SelectedIndex = 0;
            groupchon1.Enabled = false;
            groupchon2.Enabled = false;
            bntXoa.Enabled = false;
            btn_Chamcong.Enabled = false;
            dtgBangChamCong.Enabled = false;
            bntCC.Enabled = false;
            dtCC = laybangchamcong.Laybangchamcong();
            control.HienthiGridtheothangnam(dtCC, dtgBangChamCong, bdnBangchamcong);
            //Download source code FREE tai Sharecode.vn
        }
        public void Them(string manhanvien, string thangthem, string namthem)
        {
            string nt1 = "", nt2 = "", nt3 = "", nt4 = "", nt5 = "", nt6 = "", nt7 = "", nt8 = "", nt9 = "", nt10 = "", nt11 = "", nt12 = "", nt13 = "", nt14 = "", nt15 = "", nt16 = "", nt17 = "", nt18 = "", nt19 = "", nt20 = "", nt21 = "", nt22 = "", nt23 = "", nt24 = "", nt25 = "", nt26 = "", nt27 = "", nt28 = "", nt29 = "", nt30 = "", nt31 = "";
            string macc = "CC";
            string masothutu;
            string thang = DateTime.Now.Month.ToString();
            if (thang.Length == 1)
                thang = "0" + thang;
            string nam = DateTime.Now.Year.ToString();
            string nam02 = nam[2].ToString() + nam[3].ToString();
            string thangnam = thang + nam02;
            int phantu = 0;
            dtCC = laybangchamcong.Laybangchamcong();
            foreach (DataRow dr in dtCC.Rows)
            {
                string ma = dr["Machamcong"].ToString();
                string mathangnam = ma[2].ToString() + ma[3].ToString() + ma[4].ToString() + ma[5].ToString();
                string mathuthu = ma[6].ToString() + ma[7].ToString() + ma[8].ToString() + ma[9].ToString();
                if (thangnam == mathangnam)
                {
                    int stt = Convert.ToInt32(mathuthu);
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
                macc = macc + thangnam + masothutu;

            }
            else
            {
                macc = macc + thangnam + "0001";
            }
            DataRowView row = (DataRowView)bdnBangchamcong.BindingSource.AddNew();
            row["Machamcong"] = macc;
            row["MaNV"] = manhanvien;
            row["Thangchamcong"] = "01/" + thangthem + "/" + namthem;
            if (thangthem == "02")
            {
                laybangchamcong.Themmoi(macc, thangthem + "/01" + "/" + namthem, manhanvien, nt1, nt2, nt3, nt4, nt5, nt6, nt7, nt8, nt9, nt10, nt11, nt12, nt13, nt14, nt15, nt16, nt17, nt18, nt19, nt20, nt21, nt22, nt23, nt24, nt25, nt26, nt27, nt28, null, null, null, 0, 0, 0);
            }
            else
            {
                if (thangthem == "04" || thangthem == "06" || thangthem == "09" || thangthem == "10" || thangthem == "11")
                {
                    laybangchamcong.Themmoi(macc, thangthem + "/01" + "/" + namthem, manhanvien, nt1, nt2, nt3, nt4, nt5, nt6, nt7, nt8, nt9, nt10, nt11, nt12, nt13, nt14, nt15, nt16, nt17, nt18, nt19, nt20, nt21, nt22, nt23, nt24, nt25, nt26, nt27, nt28, nt29, nt30, null, 0, 0, 0);
                }
                else
                {
                    laybangchamcong.Themmoi(macc, thangthem + "/01" + "/" + namthem, manhanvien, nt1, nt2, nt3, nt4, nt5, nt6, nt7, nt8, nt9, nt10, nt11, nt12, nt13, nt14, nt15, nt16, nt17, nt18, nt19, nt20, nt21, nt22, nt23, nt24, nt25, nt26, nt27, nt28, nt29, nt30, nt31, 0, 0, 0);
                }
            }

        }
        public void Hienthichamcong(int load)
        {
            if (cmbthang.SelectedItem.ToString() == "Tháng 02")
            {
                dtgBangChamCong.Columns["n29"].ReadOnly = true;
                dtgBangChamCong.Columns["n30"].ReadOnly = true;
                dtgBangChamCong.Columns["n31"].ReadOnly = true;
            }
            else
            {
                if (cmbthang.SelectedItem.ToString() == "Tháng 04" || cmbthang.SelectedItem.ToString() == "Tháng 06" || cmbthang.SelectedItem.ToString() == "Tháng 09" || cmbthang.SelectedItem.ToString() == "Tháng 10" || cmbthang.SelectedItem.ToString() == "Tháng 11")
                {
                    dtgBangChamCong.Columns["n31"].ReadOnly = true;
                }
                else
                {
                    dtgBangChamCong.Columns["n29"].ReadOnly = false;
                    dtgBangChamCong.Columns["n30"].ReadOnly = false;
                    dtgBangChamCong.Columns["n31"].ReadOnly = false;
                }

            }
            string thang = cmbthang.SelectedItem.ToString();
            string nam = cmbnam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();

            dtNhanvientheophong = laybangnhanvien.Laynhanvientheophongban(cmbphongban.SelectedValue.ToString());
            dtCC = laybangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));
            if (dtNhanvientheophong.Rows.Count != 0)
            {
                DataTable dtCCNVtheophong = new DataTable();
                dtCCNVtheophong = dtCC.Clone();
                foreach (DataRow dr1 in dtCC.Rows)
                {
                    foreach (DataRow dr2 in dtNhanvientheophong.Rows)
                    {
                        if (dr1["MaNV"].ToString() == dr2["MaNV"].ToString())
                        {
                            dtCCNVtheophong.ImportRow(dr1);
                            break;
                        }
                    }
                }
                if (dtCCNVtheophong.Rows.Count != 0)
                {
                    control.HienthiGridtheothangnam(dtCCNVtheophong, dtgBangChamCong, bdnBangchamcong);
                }
                else
                {
                    if (load == 0)
                    {
                        dtNV = new DataTable();
                        dtNV = laybangnhanvien.Laynhanvientheophongban(cmbphongban.SelectedValue.ToString());
                        string[] maNV = new string[2000];
                        int stt = 0;
                        foreach (DataRow dr in dtNV.Rows)
                        {
                            maNV[stt] = dr["MaNV"].ToString();
                            stt++;
                        }
                        for (int i = 0; i < maNV.Length; i++)
                        {
                            if (maNV[i] != null)
                            {
                                foreach (DataRow dr in dtNV.Rows)
                                {
                                    if (dr["Tinhtranglamviec"].ToString() == "Đang làm việc")
                                    {
                                        Them(maNV[i], thang, nam);
                                        frmBangchiluong frmchiluong = new frmBangchiluong();
                                        frmchiluong.Them(0, maNV[i], thang, nam);
                                        break;
                                    }
                                    else
                                    {
                                        Them(maNV[i], thang, nam);
                                        frmBangchiluong frmchiluong = new frmBangchiluong();
                                        frmchiluong.Them(1, maNV[i], thang, nam);
                                        break;
                                    }
                                }
                            }
                            else
                                break;
                        }
                        Hienthichamcong(load);
                    }
                }
            }
            else
            {
                MessageBoxEx.Show(" Không có nhân viên ở phòng ban này", "Thông báo");
                DataTable dtCCNVtheophong = new DataTable();
                dtCCNVtheophong = dtCC.Clone();
                control.HienthiGridtheothangnam(dtCCNVtheophong, dtgBangChamCong, bdnBangchamcong);
            }
        }
        public void Luu()
        {
            dtgBangChamCong.EndEdit();
            int donghh = dtgBangChamCong.CurrentRow.Index;
            laybangchamcong.Capnhat(dtgBangChamCong["txtmaCC", donghh].Value.ToString(), dtgBangChamCong["n1", donghh].Value.ToString(), dtgBangChamCong["n2", donghh].Value.ToString(), dtgBangChamCong["n3", donghh].Value.ToString(), dtgBangChamCong["n4", donghh].Value.ToString(), dtgBangChamCong["n5", donghh].Value.ToString(), dtgBangChamCong["n6", donghh].Value.ToString(), dtgBangChamCong["n7", donghh].Value.ToString(), dtgBangChamCong["n8", donghh].Value.ToString(), dtgBangChamCong["n9", donghh].Value.ToString(), dtgBangChamCong["n10", donghh].Value.ToString(), dtgBangChamCong["n11", donghh].Value.ToString(), dtgBangChamCong["n12", donghh].Value.ToString(), dtgBangChamCong["n13", donghh].Value.ToString(), dtgBangChamCong["n14", donghh].Value.ToString(), dtgBangChamCong["n15", donghh].Value.ToString(), dtgBangChamCong["n16", donghh].Value.ToString(), dtgBangChamCong["n17", donghh].Value.ToString(), dtgBangChamCong["n18", donghh].Value.ToString(), dtgBangChamCong["n19", donghh].Value.ToString(), dtgBangChamCong["n20", donghh].Value.ToString(), dtgBangChamCong["n21", donghh].Value.ToString(), dtgBangChamCong["n22", donghh].Value.ToString(), dtgBangChamCong["n23", donghh].Value.ToString(), dtgBangChamCong["n24", donghh].Value.ToString(), dtgBangChamCong["n25", donghh].Value.ToString(), dtgBangChamCong["n26", donghh].Value.ToString(), dtgBangChamCong["n27", donghh].Value.ToString(), dtgBangChamCong["n28", donghh].Value.ToString(), dtgBangChamCong["n29", donghh].Value.ToString(), dtgBangChamCong["n30", donghh].Value.ToString(), dtgBangChamCong["n31", donghh].Value.ToString(), Convert.ToInt32(dtgBangChamCong["txttongngay", donghh].Value.ToString()), Convert.ToInt32(dtgBangChamCong["txtngaydilam", donghh].Value.ToString()), Convert.ToInt32(dtgBangChamCong["txtngayvang", donghh].Value.ToString()));
        }
        int thongbao = 0;

        private void dtgBangChamCong_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dong = dtgBangChamCong.CurrentRow.Index;
            int dilam = 0;
            int vang = 0;
            int tongngay = 0;
            for (int i = 01; i < 32; i++)
            {
                if (dtgBangChamCong["n" + i.ToString(), dong].Value.ToString() == "x")
                    dilam++;
                if (dtgBangChamCong["n" + i.ToString(), dong].Value.ToString() == "v"||dtgBangChamCong["n" + i.ToString(), dong].Value.ToString() == "P")
                    vang++;
            }
            tongngay = dilam + vang;
            dtgBangChamCong["txtngaydilam", dong].Value = dilam;
            dtgBangChamCong["txtngayvang", dong].Value = vang;
            dtgBangChamCong["txttongngay", dong].Value = tongngay;
            Luu();
            if (vang > 7 && thongbao == 0)
            {
                MessageBoxEx.Show("Nhân viên này đã nghỉ quá 7 ngày trong tháng đề nghị cho thôi việc", "Thông báo");
                thongbao = 1;
            }
            DateTime nam1 = Convert.ToDateTime(dtgBangChamCong["txtthang", dtgBangChamCong.CurrentRow.Index].Value);
            dtCCtrongnam = laybangchamcong.Laybangchamcongtheonamcuanhanvien(dtgBangChamCong["cmbnhanvien", dtgBangChamCong.CurrentRow.Index].Value.ToString(), nam1.Year);
            int vangtrongnam = 0;
            foreach (DataRow dr in dtCCtrongnam.Rows)
                vangtrongnam += Convert.ToInt32(dr["Ngayvang"].ToString());
            if (vangtrongnam > 25)
            {
                MessageBoxEx.Show("Nhân viên này đã nghỉ quá 25 ngày trong năm đề nghị cho thôi việc", "Thông báo");
                thongbao = 1;
            }
            Capnhatchochiluong(vangtrongnam);
        }
        public void Capnhatchochiluong(int ngayvang)
        {
            string thang = cmbthang.SelectedItem.ToString();
            string nam = cmbnam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
            int thamnien = 1;
            dtNV = laybangnhanvien.Laynhanvien();
            foreach (DataRow dr in dtNV.Rows)
            {
                if (dtgBangChamCong["cmbnhanvien", dtgBangChamCong.CurrentRow.Index].Value.ToString() == dr["MaNV"].ToString())
                {
                    thamnien = Convert.ToInt32(dr["Thamnien"].ToString());
                    break;
                }
            }
            dtchiluongtheothangnam = laybangchiluong.Laybangluongtheothangnam(Convert.ToInt32(thang), Convert.ToInt32(nam));
            foreach (DataRow dr in dtchiluongtheothangnam.Rows)
            {
                if (dtgBangChamCong["cmbnhanvien", dtgBangChamCong.CurrentRow.Index].Value.ToString() == dr["MaNV"].ToString())
                {
                    laybangchiluong.Capnhatngaylamtheothangnam(Convert.ToInt32(thang), Convert.ToInt32(nam), Convert.ToInt32(dtgBangChamCong["txtngaydilam", dtgBangChamCong.CurrentRow.Index].Value.ToString()), dr["MaNV"].ToString());
                    break;
                }
            }
            int ngayvangchophep = 7 - ngayvang;
            if (ngayvangchophep < 0)
            {
                dtchiluongtheothangnam = laybangchiluong.Laybangluongtheothangnam(Convert.ToInt32(thang), Convert.ToInt32(nam));
                foreach (DataRow dr1 in dtchiluongtheothangnam.Rows)
                {
                    if (dtgBangChamCong["cmbnhanvien", dtgBangChamCong.CurrentRow.Index].Value.ToString() == dr1["MaNV"].ToString())
                    {
                        double truluong = 150000;
                        truluong = truluong * (-ngayvangchophep);
                        double thuclinh = (Convert.ToDouble(dr1["Tongluong"].ToString()) * 0.92) - truluong;
                        if (thamnien == 1)
                            thuclinh = thuclinh * 90 / 100;
                        laybangchiluong.Capnhattruluong(Convert.ToInt32(thang), Convert.ToInt32(nam), dr1["MaNV"].ToString(), Convert.ToDouble(truluong), Convert.ToDouble(thuclinh));
                        break;

                    }
                }
            }

        }

        

        private void bntLuu_Click(object sender, EventArgs e)
        {
            Luu();
            MessageBox.Show("Bạn đã lưu thành công"); 
        }

      
       

        private void btn_Chamcong_Click(object sender, EventArgs e)
        {
            string thang = cmbthang.SelectedItem.ToString();
            string nam = cmbnam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
            if (check1.Checked == true && check2.Checked == true)
            {
                bntXoa.Enabled = true;
                bntCC.Enabled = true;
                dtNhanvientheophong = laybangnhanvien.Laynhanvientheophongban(cmbphongban.SelectedValue.ToString());
                dtCC = laybangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));
                dtgBangChamCong.Enabled = true;
                if (dtNhanvientheophong.Rows.Count != 0)
                {
                    DataTable dtCCNVtheophong = new DataTable();
                    dtCCNVtheophong = dtCC.Clone();
                    foreach (DataRow dr1 in dtCC.Rows)
                    {
                        foreach (DataRow dr2 in dtNhanvientheophong.Rows)
                        {
                            if (dr1["MaNV"].ToString() == dr2["MaNV"].ToString())
                            {
                                dtCCNVtheophong.ImportRow(dr1);
                                break;
                            }
                        }
                    }
                    if (dtCCNVtheophong.Rows.Count == 0)
                    {
                        dtCC = laybangchamcong.Laybangchamcongrong();
                        control.HienthiGridtheothangnam(dtCC, dtgBangChamCong, bdnBangchamcong);
                        MessageBoxEx.Show("Không có bản chấm công nào");
                    }
                    else
                        Hienthichamcong(1);
                }
            }
            else
            {
                if (check1.Checked == true && check2.Checked == false)
                {
                    bntXoa.Enabled = true;
                    dtgBangChamCong.Enabled = true;
                    bntCC.Enabled = false;
                    DataTable dtCCthangnam = new DataTable();
                    dtCCthangnam = laybangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));
                    control.HienthiGridtheothangnam(dtCCthangnam, dtgBangChamCong, bdnBangchamcong);
                }
                else
                {
                    if (check1.Checked == false && check2.Checked == true)
                    {
                        bntXoa.Enabled = false;
                        dtgBangChamCong.Enabled = true;
                        bntCC.Enabled = false;
                        dtNhanvientheophong = laybangnhanvien.Laynhanvientheophongban(cmbphongban.SelectedValue.ToString());
                        DataTable dtCC = new DataTable();
                        dtCC = laybangchamcong.Laybangchamcong();
                        DataTable dtCCNVtheophong = new DataTable();
                        dtCCNVtheophong = dtCC.Clone();
                        foreach (DataRow dr1 in dtCC.Rows)
                        {
                            foreach (DataRow dr2 in dtNhanvientheophong.Rows)
                            {
                                if (dr1["MaNV"].ToString() == dr2["MaNV"].ToString())
                                {
                                    dtCCNVtheophong.ImportRow(dr1);
                                    break;
                                }
                            }
                        }
                        control.HienthiGridtheothangnam(dtCCNVtheophong, dtgBangChamCong, bdnBangchamcong);
                    }
                }

            }
            
        }

        private void bntCC_Click(object sender, EventArgs e)
        {
            string thang = cmbthang.SelectedItem.ToString();
            string nam = cmbnam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
            dtNhanvientheophong = laybangnhanvien.Laynhanvientheophongban(cmbphongban.SelectedValue.ToString());
            dtCC = laybangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));
            if (check1.Checked == true && check2.Checked == true)
            {
                if (dtNhanvientheophong.Rows.Count != 0)
                {
                    DataTable dtCCNVtheophong = new DataTable();
                    dtCCNVtheophong = dtCC.Clone();
                    foreach (DataRow dr1 in dtCC.Rows)
                    {
                        foreach (DataRow dr2 in dtNhanvientheophong.Rows)
                        {
                            if (dr1["MaNV"].ToString() == dr2["MaNV"].ToString())
                            {
                                dtCCNVtheophong.ImportRow(dr1);
                                break;
                            }
                        }
                    }
                    if (dtCCNVtheophong.Rows.Count != 0)
                    {
                        control.HienthiGridtheothangnam(dtCCNVtheophong, dtgBangChamCong, bdnBangchamcong);
                        MessageBoxEx.Show("Đã tồn tại bảng chấm công nhân viên tháng " + thang.ToString() + " năm " + nam.ToString() + " tại phòng " + cmbphongban.SelectedValue.ToString());
                    }
                    else
                    {
                        Hienthichamcong(0);
                        MessageBoxEx.Show("Bạn đã thêm thành công bảng chấm công của nhân viên tháng " + thang.ToString() + " năm " + nam.ToString() + " tại phòng " + cmbphongban.SelectedValue.ToString());
                    }
                }
            }

            else
            {
                if (check1.Checked == true && check2.Checked == false)
                {
                    dtCC = new DataTable();
                    dtCC = laybangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));
                    if (dtCC.Rows.Count != 0)
                    {
                        MessageBoxEx.Show("Đã tồn tại bảng chấm công nhân viên tháng " + thang.ToString() + " năm " + nam.ToString());
                        control.HienthiGridtheothangnam(dtCC, dtgBangChamCong, bdnBangchamcong);
                    }
                    else
                    {
                        dtNV = new DataTable();
                        dtNV = laybangnhanvien.Laynhanvien();
                        string[] maNV = new string[2000];
                        int stt = 0;
                        foreach (DataRow dr in dtNV.Rows)
                        {
                            maNV[stt] = dr["MaNV"].ToString();
                            stt++;
                        }
                        for (int i = 0; i < maNV.Length; i++)
                        {
                            if (maNV[i] != null)
                            {
                                foreach (DataRow dr in dtNV.Rows)
                                {
                                    if (dr["Tinhtranglamviec"].ToString() == "Đang làm việc")
                                    {
                                        Them(maNV[i], thang, nam);
                                        frmBangchiluong frmchiluong = new frmBangchiluong();
                                        frmchiluong.Them(0, maNV[i], thang, nam);
                                        break;
                                    }
                                    else
                                    {
                                        Them(maNV[i], thang, nam);
                                        frmBangchiluong frmchiluong = new frmBangchiluong();
                                        frmchiluong.Them(1, maNV[i], thang, nam);
                                        break;
                                    }
                                }
                            }
                            else
                                break;
                        }
                        MessageBoxEx.Show("Bạn đã thêm thành công bảng chấm công của nhân viên tháng " + thang.ToString() + " năm " + nam.ToString());
                        dtCC = laybangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));
                        control.HienthiGridtheothangnam(dtCC, dtgBangChamCong, bdnBangchamcong);
                    }
                }
                else
                {
                    MessageBoxEx.Show("Bạn chỉ thêm được vào bảng chấm công khi chọn tháng, năm và chọn phòng ban");
                }
            }
        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbaoxoa = MessageBox.Show("Bạn có muốn xóa bảng chấm công và bảng chi lương của tháng, năm này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (thongbaoxoa == DialogResult.OK)
            {
                string thang = cmbthang.SelectedItem.ToString();
                string nam = cmbnam.SelectedItem.ToString();
                thang = thang[6].ToString() + thang[7].ToString();
                nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
                dtCC = laybangchamcong.Laybangchamcongtheonamthang(Convert.ToInt32(thang), Convert.ToInt32(nam));
                dtchiluongtheothangnam = laybangchiluong.Laybangluongtheothangnam(Convert.ToInt32(thang), Convert.ToInt32(nam));
                string[] ma = new string[2000];
                int stt = 0;
                foreach (DataRow dr in dtCC.Rows)
                {
                    ma[stt] = dr["Machamcong"].ToString();
                    stt++;
                }
                for (int i = 0; i < 2000; i++)
                {
                    if (ma[i] != null)
                    {
                        laybangchamcong.Xoa(ma[i]);
                    }
                    else
                        break;
                }
                string[] macl = new string[2000];
                int sttcl = 0;
                foreach (DataRow dr1 in dtchiluongtheothangnam.Rows)
                {
                    macl[sttcl] = dr1["Maluong"].ToString();
                    sttcl++;
                }
                for (int i = 0; i < 2000; i++)
                {
                    if (macl[i] != null)
                    {
                        //MessageBox.Show(macl[i]);
                        laybangchiluong.Xoa(macl[i]);
                        //break;
                    }
                    else
                        break;
                }
                dtCC = laybangchamcong.Laybangchamcongrong();
                control.HienthiGridtheothangnam(dtCC, dtgBangChamCong, bdnBangchamcong);
            }

        }

        private void check1_CheckedChanged(object sender, EventArgs e)
        {
            if (check1.Checked == false)
            {
                groupchon1.Enabled = false;
            }
            else
            {
                groupchon1.Enabled = true;
                bntCC.Enabled = true;
                btn_Chamcong.Enabled = true;
                dtgBangChamCong.EndEdit();
            }
        }

        private void check2_CheckedChanged(object sender, EventArgs e)
        {
            if (check2.Checked == false)
            {
                groupchon2.Enabled = false;
            }
            else
            {
                groupchon2.Enabled = true;
                btn_Chamcong.Enabled = true;
            }

        }

        private void btn_bangchiluong_Click(object sender, EventArgs e)
        {
            //xoa = 0;
            //string thang = cmbthang.SelectedItem.ToString();
            //string nam = cmbnam.SelectedItem.ToString();
            //thang = thang[6].ToString() + thang[7].ToString();
            //nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
            //frmBangchiluong frmchiluong = null;
            //frmchiluong = new frmBangchiluong(1, Convert.ToInt32(thang), Convert.ToInt32(nam), cmbphongban.SelectedValue.ToString());
            //frmchiluong.StartPosition = FormStartPosition.CenterScreen;
            //frmchiluong.ShowDialog();

            string thang = cmbthang.SelectedItem.ToString();
            string nam = cmbnam.SelectedItem.ToString();
            thang = thang[6].ToString() + thang[7].ToString();
            nam = nam[4].ToString() + nam[5].ToString() + nam[6].ToString() + nam[7].ToString();
            frmBangchiluong frmchiluong = new frmBangchiluong();
            frmchiluong.Chiluong(Convert.ToInt32(thang), Convert.ToInt32(nam), cmbphongban.SelectedValue.ToString());
            //frmchiluong= new frmBangchiluong(1, Convert.ToInt32(thang), Convert.ToInt32(nam), cmbphongban.SelectedValue.ToString());
            //frmchiluong.StartPosition = FormStartPosition.CenterScreen;
            frmchiluong.ShowDialog();
        }

        

        private void dtgBangChamCong_MouseClick(object sender, MouseEventArgs e)
        {
            if (check1.Checked == true && check2.Checked == false || check1.Checked == false && check2.Checked == true
                || check1.Checked==false&&check2.Checked==false)
            {
                MessageBoxEx.Show("Bạn chỉ được chấm công nhân viên khi đã chọn tháng năm và phòng ban", "Thông báo");
                return;
            }

        }

      

       

      
        













    }
}