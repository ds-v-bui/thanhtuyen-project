using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;



namespace QL_nhansu
{
    public partial class frmHopDong : DevComponents.DotNetBar.Office2007Form
    {
        Class.clsDieuKien dk = new QL_nhansu.Class.clsDieuKien();
        Class.clsHopDong nvdn = new QL_nhansu.Class.clsHopDong();
        public frmHopDong()
        {
            InitializeComponent();
        }


        bool Trangthai = true;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            dk.LoadLen(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            nvdn.LoadDataGridView(dgvHopDong);
            nvdn.LoadComboBox_NhanVien(cmbNhanVien);
            nvdn.LoadComboBox_LanKy(cmbLanKy);
           // nvdn.LoadComboBox_NguoiKy(cmbNguoiKy);


           
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc không ?", "Xóa hợp đồng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                nvdn.XoaHD(txtMaHopDong.Text);
                nvdn.LoadDataGridView(dgvHopDong);
                Xoa();

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = true;
            int MaHopDong = dk.MaTuTang(dgvHopDong);

            
                if (MaHopDong <= 9)
                {
                    txtMaHopDong.Text = "HD" + "0" + MaHopDong.ToString();
                }
                else
                {
                    txtMaHopDong.Text = "HD" + MaHopDong.ToString();
                }
                    dk.Them(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                    txtNoiDung.Text = "";
                    txtGhiChu.Text = "";
                    dtiNgayBatDau.Text = "";
                    dtiNgayKetThuc.Text = "";
                    dtiNgayKy.Text = "";
                    cmbLanKy.Text = "";
                    txtNguoiKy.Text = "";
                    cmbNhanVien.Text = "";
               
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
           Trangthai=false;
            dk.Sua(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                

        }

        

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string Nhanvien = "";

            try
            {
                if (txtTimKiem.Text.Trim() == "")
                {
                    lblKetQua.Text = "Bạn phải nhập mã nhân viên cần tìm";
                }
                else
                {
                    if (txtTimKiem.Text.Contains("'") == true)
                    {
                        Nhanvien = txtTimKiem.Text.Replace("'", "'" + "'");
                    }
                    else
                    {
                        Nhanvien = txtTimKiem.Text;
                    }
                    nvdn.LoadDataGridView_HopDong_TimKiem(dgvHopDong, Nhanvien);
                    if (dgvHopDong.RowCount == 0)
                    {
                        lblKetQua.Text = "Không tìm thấy " + txtTimKiem.Text;
                    }
                    else
                    {
                        lblKetQua.Text = "Kết quả tìm thấy " + txtTimKiem.Text + " là: " + dgvHopDong.RowCount.ToString();
                    }
                }
            }
            catch (Exception)
            {
                lblKetQua.Text = "Không tìm thấy " + txtTimKiem.Text;
            }
        }


       

        private void btnNguoiky_Click(object sender, EventArgs e)
        {
            frmNhanVien f_NhanVien2 = new frmNhanVien();
            f_NhanVien2.ShowDialog();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            frmNhanVien f_NhanVien = new frmNhanVien();
            f_NhanVien.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
             if (txtMaHopDong.Text.Trim() == "")
            {
                MessageBoxEx.Show("Mã hợp đồng không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHopDong.Focus();
            }

            else 
                 if (cmbNhanVien.Text.Trim() == "")
                {
                    MessageBoxEx.Show("Mã nhân viên không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbNhanVien.Focus();
                }
                 
            else
                     if (dtiNgayBatDau.Text.Trim() == "")
            {
                MessageBoxEx.Show("Ngày bắt đầu không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtiNgayBatDau.Focus();
            }
                 else

                         if (dtiNgayKetThuc.Text.Trim() == "")
                         {
                             MessageBoxEx.Show("Ngày kết thúc không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             dtiNgayKetThuc.Focus();
                         }
                         else
                         {
                             if (Trangthai == true)
                             {
                                 nvdn.ThemHD(txtMaHopDong.Text, cmbNhanVien.SelectedValue.ToString(), Convert.ToDateTime(dtiNgayBatDau.Text.ToString()), Convert.ToDateTime(dtiNgayKetThuc.Text.ToString()), int.Parse(cmbLanKy.SelectedValue.ToString()), txtNoiDung.Text, Convert.ToDateTime(dtiNgayKy.Text.ToString()), txtNguoiKy.Text, txtGhiChu.Text);

                             }
                             else
                             {
                                 nvdn.SuaHD(txtMaHopDong.Text, cmbNhanVien.SelectedValue.ToString(), Convert.ToDateTime(dtiNgayBatDau.Text.ToString()), Convert.ToDateTime(dtiNgayKetThuc.Text.ToString()), int.Parse(cmbLanKy.SelectedValue.ToString()), txtNoiDung.Text, Convert.ToDateTime(dtiNgayKy.Text.ToString()),txtNguoiKy.Text, txtGhiChu.Text);

                             }
                             nvdn.LoadDataGridView(dgvHopDong);
                             dk.Luu(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                             Xoa();
                         }
        }
        public void Xoa()
        {
            txtMaHopDong.Text = "";
            txtNoiDung.Text = "";
            txtGhiChu.Text = "";
            dtiNgayBatDau.Text = "";
            dtiNgayKetThuc.Text = "";
            dtiNgayKy.Text = "";
            cmbLanKy.Text = "";
            txtNguoiKy.Text = "";
            cmbNhanVien.Text = "";

        }

        private void dgvHopDong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = dgvHopDong.CurrentRow.Index;
            txtMaHopDong.Text = dgvHopDong[0, hang].Value.ToString();
            cmbNhanVien.Text = dgvHopDong[1, hang].Value.ToString();
            dtiNgayBatDau.Text = dgvHopDong[2, hang].Value.ToString();
            dtiNgayKetThuc.Text = dgvHopDong[3, hang].Value.ToString();
            cmbLanKy.Text = dgvHopDong[4, hang].Value.ToString();
            txtNoiDung.Text = dgvHopDong[5, hang].Value.ToString();
            dtiNgayKy.Text = dgvHopDong[6, hang].Value.ToString();
            txtNguoiKy.Text = dgvHopDong[7, hang].Value.ToString();
            txtGhiChu.Text = dgvHopDong[8, hang].Value.ToString();
        }

       

        

        

       

     
    }
}