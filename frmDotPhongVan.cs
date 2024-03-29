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
    public partial class frmDotPhongVan : DevComponents.DotNetBar.Office2007Form
    {
        Class.clsDieuKien dk = new QL_nhansu.Class.clsDieuKien();
        Class.clsDotPhongVan nvdn = new QL_nhansu.Class.clsDotPhongVan();
        public frmDotPhongVan()
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
            DialogResult dr = MessageBox.Show("Bạn có chắc không ?", "Xóa đợt phỏng vấn", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                nvdn.Xoa_DotPV(txtMaPV.Text);
                nvdn.LoadDataGridView_PhongVan(dgvPhongVan);
                Xoa();

            }
        }

        private void frmDotPhongVan_Load(object sender, EventArgs e)
        {
            dk.LoadLen(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            nvdn.LoadDataGridView_PhongVan(dgvPhongVan);
            nvdn.LoadDataGridView_UngVien(dgvUngVien, txtMaPV.Text.ToString());
            nvdn.LoadComboBox_DotTuyenDung(cmbDotTD);
            nvdn.LoadComboBox_NguoiPV(cmbNguoiPV);
            nvdn.LoadComboBox_Diadiem(cmbDiaDiem);
            nvdn.LoadComboBox_TinhTrang(cmbTinhTrang);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = true;
            int MaPV = dk.MaTuTang(dgvPhongVan);


            if (MaPV <= 9)
            {
                txtMaPV.Text = "PV" + "0" + MaPV.ToString();
            }
            else
            {
                txtMaPV.Text = "PV" + MaPV.ToString();
            }


            dk.Them(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            txtTenPV.Text = "";
            txtGhiChu.Text = "";
            txtChuDe.Text = "";
            dtiNgayBatDau.Text = "";
            dtiNgayKetThuc.Text = "";
            cmbDiaDiem.Text = "";
            cmbDotTD.Text = "";
            cmbDotTD.Text = "";
            cmbNguoiPV.Text = "";
            
      
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai=false;
            
            dk.Sua(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
        }

        private void dgvPhongVan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = dgvPhongVan.CurrentRow.Index;
            txtMaPV.Text = dgvPhongVan[0, hang].Value.ToString();
            txtTenPV.Text = dgvPhongVan[1, hang].Value.ToString();
            cmbDotTD.Text = dgvPhongVan[2, hang].Value.ToString();
            cmbNguoiPV.Text = dgvPhongVan[3, hang].Value.ToString();

            dtiNgayBatDau.Text = dgvPhongVan[4, hang].Value.ToString();
            dtiNgayKetThuc.Text = dgvPhongVan[5, hang].Value.ToString();
            txtChuDe.Text = dgvPhongVan[6, hang].Value.ToString();
            cmbDiaDiem.Text = dgvPhongVan[7, hang].Value.ToString();
            cmbTinhTrang.Text = dgvPhongVan[8, hang].Value.ToString();
            txtGhiChu.Text = dgvPhongVan[9, hang].Value.ToString();
            nvdn.LoadDataGridView_UngVien(dgvUngVien, txtMaPV.Text.ToString());


        }

        private void btnDotTD_Click(object sender, EventArgs e)
        {
            frmDotTuyenDung f_TuyenDung = new frmDotTuyenDung();
            f_TuyenDung.ShowDialog();
        }

        private void btnPV_Click(object sender, EventArgs e)
        {
            frmNhanVien f_Nhanvien = new frmNhanVien();
            f_Nhanvien.ShowDialog();
        }

        private void btnDiadiem_Click(object sender, EventArgs e)
        {
            frmDiaDiem f_Diadiem = new frmDiaDiem();
            f_Diadiem.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if (txtMaPV.Text.Trim() == "")
            {
                MessageBoxEx.Show("Mã phỏng vấn  không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPV.Focus();
            }

            else if (txtTenPV.Text.Trim() == "")
            {
                MessageBoxEx.Show("Tên phỏng vấn không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPV.Focus();
            }
            else if (cmbNguoiPV.Text.Trim() == "")
            {
                MessageBoxEx.Show("Người phỏng vấn không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbNguoiPV.Focus();
            }

            else if (dtiNgayBatDau.Text.Trim() == "")
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
                    if(Trangthai==true)
                    {
                        
                    nvdn.Them_DotPV(txtMaPV.Text, txtTenPV.Text,cmbDotTD.SelectedValue.ToString(), cmbNguoiPV.SelectedValue.ToString(),Convert.ToDateTime(dtiNgayBatDau.Text.ToString()), Convert.ToDateTime(dtiNgayKetThuc.Text.ToString()), txtChuDe.Text, cmbDiaDiem.SelectedValue.ToString(), cmbTinhTrang.SelectedValue.ToString(), txtGhiChu.Text);
                   
                    }
                    else
                    {
                    nvdn.Sua_DotPV(txtMaPV.Text, txtTenPV.Text, cmbDotTD.SelectedValue.ToString(), cmbNguoiPV.SelectedValue.ToString(), Convert.ToDateTime(dtiNgayBatDau.Text.ToString()), Convert.ToDateTime(dtiNgayKetThuc.Text.ToString()), txtChuDe.Text, cmbDiaDiem.SelectedValue.ToString(), cmbTinhTrang.SelectedValue.ToString(), txtGhiChu.Text);
                    
                    }
                      nvdn.LoadDataGridView_PhongVan(dgvPhongVan);
                nvdn.LoadDataGridView_UngVien(dgvUngVien, txtMaPV.Text);
                    dk.Luu(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                    Xoa();
                }
        }
        public void Xoa()
        {
            txtMaPV.Text = "";
            txtTenPV.Text = "";
            txtGhiChu.Text = "";
            txtChuDe.Text = "";
            dtiNgayBatDau.Text = "";
            dtiNgayKetThuc.Text = "";
            cmbDiaDiem.Text = "";
            cmbDotTD.Text = "";
            cmbDotTD.Text = "";
            cmbNguoiPV.Text = "";
           
        }
    }
}