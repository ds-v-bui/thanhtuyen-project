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
    public partial class frmDanToc : DevComponents.DotNetBar.Office2007Form
    {
        Class.clsDieuKien dk = new QL_nhansu.Class.clsDieuKien();
        Class.clsDanToc nvdn = new QL_nhansu.Class.clsDanToc();
        public frmDanToc()
        {
            InitializeComponent();
        }
        bool Trangthai = true;
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDanToc_Load(object sender, EventArgs e)
        {
            dk.LoadLen(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            nvdn.LoadDataGridView(dgvDanToc);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc không ?", "Xóa dân tộc", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                nvdn.Xoa_DanToc(txtMaDanToc.Text);
                nvdn.LoadDataGridView(dgvDanToc);
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
            int MaDT = dk.MaTuTang(dgvDanToc);

            if (MaDT <= 9)
            {
                txtMaDanToc.Text = "DT" + "0" + MaDT.ToString();
            }
            else
            {
                txtMaDanToc.Text = "DT" + MaDT.ToString();
            }

           
                   
                    dk.Them(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                    txtTenDanToc.Text = "";

               
            
        }

        private void dgvDanToc_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int hang = dgvDanToc.CurrentRow.Index;
            txtMaDanToc.Text = dgvDanToc[0, hang].Value.ToString();
            txtTenDanToc.Text = dgvDanToc[1, hang].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDanToc.Text.Trim() == "")
            {
                MessageBoxEx.Show("Mã dân tộc không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDanToc.Focus();
            }
            else

                if (txtTenDanToc.Text.Trim() == "")
                {
                    MessageBoxEx.Show("Tên dân tộc không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenDanToc.Focus();
                }
                else
                {
                    if (Trangthai == true)
                    {
                        nvdn.Them_DanToc(txtMaDanToc.Text, txtTenDanToc.Text);
                    }
                    else
                    {
                        nvdn.Sua_DanToc(txtMaDanToc.Text, txtTenDanToc.Text);
                    }
                    nvdn.LoadDataGridView(dgvDanToc);
                    dk.Luu(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                    Xoa();
                }
        }
        public void Xoa()
        {
            txtMaDanToc.Text = "";
            txtTenDanToc.Text = "";
        }
    }
}