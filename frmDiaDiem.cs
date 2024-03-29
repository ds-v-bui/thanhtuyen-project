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
    public partial class frmDiaDiem : DevComponents.DotNetBar.Office2007Form
    {
        Class.clsDieuKien dk = new QL_nhansu.Class.clsDieuKien();
        Class.clsDiaDiem nvdn = new QL_nhansu.Class.clsDiaDiem();
        public frmDiaDiem()
        {
            InitializeComponent();
        }
        bool Trangthai = true;
        private void frmDiaDiem_Load(object sender, EventArgs e)
        {
            dk.LoadLen(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            nvdn.LoadDataGridView(dgvDiaDiem);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc không ?", "Xóa địa điểm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                nvdn.Xoa_DiaDiem(txtMaDiaDiem.Text);
                nvdn.LoadDataGridView(dgvDiaDiem);
                Xoa();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai = false;
                
                    dk.Sua(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
               
          

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = true;
            int MaDD = dk.MaTuTang(dgvDiaDiem);

            if (MaDD <= 9)
            {
                txtMaDiaDiem.Text = "DD" + "0" + MaDD.ToString();
            }
            else
            {
                txtMaDiaDiem.Text = "DD" + MaDD.ToString();
            }

                   
                    dk.Them(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                    txtTenDiaDiem.Text = "";

               
        }

        private void dgvDiaDiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = dgvDiaDiem.CurrentRow.Index;
            txtMaDiaDiem.Text = dgvDiaDiem[0, hang].Value.ToString();
            txtTenDiaDiem.Text = dgvDiaDiem[1, hang].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDiaDiem.Text.Trim() == "")
            {
                MessageBoxEx.Show("Mã địa điểm không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDiaDiem.Focus();
            }
            else

                if (txtTenDiaDiem.Text.Trim() == "")
                {
                    MessageBoxEx.Show("Tên địa điểm không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenDiaDiem.Focus();
                }
                else
                {
                    if (Trangthai == true)
                    {
                        nvdn.Them_DiaDiem(txtMaDiaDiem.Text, txtTenDiaDiem.Text);
                    }
                    else
                    {
                        nvdn.Sua_DiaDiem(txtMaDiaDiem.Text, txtTenDiaDiem.Text);
                    }
                    nvdn.LoadDataGridView(dgvDiaDiem);
                    dk.Luu(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                    Xoa();
                }
        }
        public void Xoa()
        {
            txtMaDiaDiem.Text = "";
            txtTenDiaDiem.Text = "";

        }
    }
}