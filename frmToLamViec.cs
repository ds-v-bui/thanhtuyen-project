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
    public partial class frmToLamViec : DevComponents.DotNetBar.Office2007Form
    {
        Class.clsDieuKien dk = new QL_nhansu.Class.clsDieuKien();
        Class.clsToLamViec nvdn = new QL_nhansu.Class.clsToLamViec();

        public frmToLamViec()
        {
            InitializeComponent();
        }
        bool trangthai = true;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc không ?", "Xóa tổ làm việc", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                nvdn.XoaTo(txtMaTo.Text);
                nvdn.LoadDataGridView(dgvToLamViec);
                txtMaTo.Text = dgvToLamViec[0, 0].Value.ToString();
                txtTenTo.Text = dgvToLamViec[1, 0].Value.ToString();
                txtGhiChu.Text = dgvToLamViec[2, 0].Value.ToString();
                txtMaPhongBan.Text = dgvToLamViec[3, 0].Value.ToString();
                //dk.Xoa(btnThem, btnSua, btnXoa, btnThoat);

            }
        }

        private void dgvToLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = dgvToLamViec.CurrentRow.Index;
            txtMaTo.Text = dgvToLamViec[0, hang].Value.ToString();
            txtTenTo.Text = dgvToLamViec[1, hang].Value.ToString();
            txtGhiChu.Text = dgvToLamViec[3, hang].Value.ToString();
            txtMaPhongBan.Text = dgvToLamViec[2, hang].Value.ToString();

        }

        private void frmToLamViec_Load(object sender, EventArgs e)
        {
            dk.LoadLen(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            nvdn.LoadDataGridView(dgvToLamViec);
            txtMaTo.Text = dgvToLamViec[0, 0].Value.ToString();
            txtTenTo.Text = dgvToLamViec[1, 0].Value.ToString();
            txtGhiChu.Text = dgvToLamViec[3, 0].Value.ToString();
            txtMaPhongBan.Text = dgvToLamViec[2, 0].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            trangthai=false;
                   
               dk.Sua(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                   
                   
               
            }        
         public void xoa()
         {
             txtMaTo.Text = "";
             txtTenTo.Text = "";
             txtMaPhongBan.Text = "";
             txtGhiChu.Text = "";

         }
        private void btnThem_Click(object sender, EventArgs e)
        {trangthai=true;
            int MaTL = dk.MaTuTang(dgvToLamViec);

           
                if (MaTL <= 9)
                {
                    txtMaTo.Text = "TL" + "0" + MaTL.ToString();
                }
                else
                {
                    txtMaTo.Text = "TL" + MaTL.ToString();
                }
            

          
                        dk.Them(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                        txtTenTo.Text = "";
                        txtMaPhongBan.Text = "";
                        txtGhiChu.Text = "";

              
            
        }

        private void btnPBan_Click(object sender, EventArgs e)
        {
            frmPhongBan f_Phongban = new frmPhongBan();
            f_Phongban.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtMaTo.Text.Trim() == "")
            {
                MessageBoxEx.Show("Mã tổ làm việc không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaTo.Focus();
            }
            else

                if (txtTenTo.Text.Trim() == "")
                {
                    MessageBoxEx.Show("Tên tổ làm việc không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenTo.Focus();
                }
                else

                    if (txtMaPhongBan.Text.Trim() == "")
                    {
                        MessageBoxEx.Show("Mã phòng ban không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMaPhongBan.Focus();
                    }
                    else
                    {
                        if (trangthai == true)
                        {
                            nvdn.ThemTo(txtMaTo.Text, txtTenTo.Text, txtGhiChu.Text, txtMaPhongBan.Text);
                        }
                        else
                        {
                            nvdn.SuaTo(txtMaTo.Text, txtTenTo.Text, txtGhiChu.Text, txtMaPhongBan.Text);

                        }

                        nvdn.LoadDataGridView(dgvToLamViec);
                        dk.Luu(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                        xoa();
                    }
        }
    }
}