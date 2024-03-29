using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;


namespace QL_nhansu
{
    public partial class frmDotTuyenDung : DevComponents.DotNetBar.Office2007Form
    {
        Class.clsDieuKien dk = new QL_nhansu.Class.clsDieuKien();
        Class.clsDotTuyenDung nvdn = new QL_nhansu.Class.clsDotTuyenDung();
        public frmDotTuyenDung()
        {
            InitializeComponent();
        }
        bool Trangthai = true;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc không ?", "Xóa đợt tuyển dụng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                nvdn.Xoa_DotTD(txtMaDotTD.Text);
                nvdn.LoadDataGridView(dgvTuyenDung);
                Xoa();

            }
        }

        private void frmDotTuyenDung_Load(object sender, EventArgs e)
        {
            dk.LoadLen(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            nvdn.LoadDataGridView(dgvTuyenDung);
            nvdn.LoadComboBox_PhongBan(cmbPhongBan);
            nvdn.LoadComboBox_NguoiPhuTrach(cmbNguoiPhuTrach);
            nvdn.LoadComboBox_BangCap(cmbBangCap);
            nvdn.LoadComboBox_TrangThai(cmbTrangThai);
        }

       

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = true;
            int MaTD = dk.MaTuTang(dgvTuyenDung);


            if (MaTD <= 9)
            {
                txtMaDotTD.Text = "TD" + "0" + MaTD.ToString();
            }
            else
            {
                txtMaDotTD.Text = "TD" + MaTD.ToString();
            }


          
            dk.Them(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            txtSoLuong.Text = "";
            txtTenTD.Text = "";
            txtGioiTinh.Text = "";
            txtDoTuoi.Text = "";
            txtCapBac.Text = "";
            cmbBangCap.Text = "";
            cmbNguoiPhuTrach.Text = "";
            cmbPhongBan.Text = "";
            cmbTrangThai.Text = "";

               
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai=false;
                
                   
            dk.Sua(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
               
        }

        private void dgvTuyenDung_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int hang = dgvTuyenDung.CurrentRow.Index;
            txtMaDotTD.Text = dgvTuyenDung[0, hang].Value.ToString();
            txtTenTD.Text = dgvTuyenDung[1, hang].Value.ToString();
            cmbPhongBan.Text = dgvTuyenDung[2, hang].Value.ToString();

            cmbNguoiPhuTrach.Text = dgvTuyenDung[3, hang].Value.ToString();
            cmbBangCap.Text = dgvTuyenDung[4, hang].Value.ToString();
            txtCapBac.Text = dgvTuyenDung[5, hang].Value.ToString();
            txtDoTuoi.Text = dgvTuyenDung[6, hang].Value.ToString();
            txtGioiTinh.Text = dgvTuyenDung[7, hang].Value.ToString();
            txtSoLuong.Text = dgvTuyenDung[8, hang].Value.ToString();
            cmbTrangThai.Text = dgvTuyenDung[9, hang].Value.ToString();
        }

        private void btnBangcap_Click(object sender, EventArgs e)
        {
            frmBangCap f_BangCap = new frmBangCap();
            f_BangCap.ShowDialog();
        }

        private void btnPBan_Click(object sender, EventArgs e)
        {
            frmPhongBan f_Phongban = new frmPhongBan();
            f_Phongban.ShowDialog();
        }

        private void btnNguoiPT_Click(object sender, EventArgs e)
        {
            frmNhanVien f_NhanVien = new frmNhanVien();
            f_NhanVien.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDotTD.Text.Trim() == "")
            {
                MessageBoxEx.Show("Mã tuyển dụng  không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDotTD.Focus();
            }

            else if (txtTenTD.Text.Trim() == "")
            {
                MessageBoxEx.Show("Tên tuyển dụng không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenTD.Focus();
            }
            else if (cmbPhongBan.Text.Trim() == "")
            {
                MessageBoxEx.Show("Phòng ban không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbPhongBan.Focus();
            }

            else if (cmbNguoiPhuTrach.Text.Trim() == "")
            {
                MessageBoxEx.Show("Người phụ trách không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNguoiPhuTrach.Focus();
            }
            else if (txtDoTuoi.Text.Trim() == "" )
            {
                MessageBoxEx.Show("Độ tuổi không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDoTuoi.Focus();
            }
            else
            
                if (txtSoLuong.Text.Trim() == ""||(Convert.ToInt32(txtSoLuong.Text)<0))
                {
                    MessageBoxEx.Show("Số lượng không được trống và nhỏ hơn 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Focus();
                }
                else
                {
                    if(Trangthai==true)
                    {
                        
                    nvdn.Them_DotTD(txtMaDotTD.Text, txtTenTD.Text, cmbPhongBan.SelectedValue.ToString(), cmbNguoiPhuTrach.SelectedValue.ToString(), cmbBangCap.SelectedValue.ToString(),
                      txtCapBac.Text,txtDoTuoi.Text,txtGioiTinh.Text,int.Parse(txtSoLuong.Text),cmbTrangThai.SelectedValue.ToString());
                    
                    }
                    else
                    {
                        nvdn.Sua_DotTD(txtMaDotTD.Text, txtTenTD.Text, cmbPhongBan.SelectedValue.ToString(), cmbNguoiPhuTrach.SelectedValue.ToString(), cmbBangCap.SelectedValue.ToString(),
                     txtCapBac.Text, txtDoTuoi.Text, txtGioiTinh.Text, int.Parse(txtSoLuong.Text), cmbTrangThai.SelectedValue.ToString());
                   
                    }
                     nvdn.LoadDataGridView(dgvTuyenDung);
                     dk.Luu(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                     Xoa();
                    }

        }
        public void Xoa()
        {
            txtMaDotTD.Text = "";
            txtSoLuong.Text = "";
            txtTenTD.Text = "";
            txtGioiTinh.Text = "";
            txtDoTuoi.Text = "";
            txtCapBac.Text = "";
            cmbBangCap.Text = "";
            cmbNguoiPhuTrach.Text = "";
            cmbPhongBan.Text = "";
            cmbTrangThai.Text = "";
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            dk.NhapSoNguyen(sender, e, txtSoLuong);

        }
    }
}