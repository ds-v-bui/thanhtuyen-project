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
    public partial class frmUngVien : DevComponents.DotNetBar.Office2007Form
    {
        Class.clsDieuKien dk = new QL_nhansu.Class.clsDieuKien();
        Class.clsUngVien nvdn = new QL_nhansu.Class.clsUngVien();
        Class.clsChuyenNhanVien nvdc = new QL_nhansu.Class.clsChuyenNhanVien();

        public frmUngVien()
        {
            InitializeComponent();
        }
        bool Trangthai = true;
        string gioitinh;
       
        private void frmUngVien_Load(object sender, EventArgs e)
        {
            dk.LoadLen(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            nvdn.LoadDataGridView(dgvUngVien);
            //nvdn.LoadComboBox_GioiTinh(cmbGioitinh);
           // nvdn.LoadComboBox_HonNhan(cmbHonNhan);
            nvdn.LoadComboBox_BangCap(cmbBangCap);
            nvdn.LoadComboBox_TinHoc(cmbTinHoc);
            nvdn.LoadComboBox_NgoaiNgu(cmbNgoaiNgu);
           // nvdn.LoadComboBox_Trangthai(cmbTrangThai);
            nvdn.LoadComboBox_DotPV(cmbDotPV);
            nvdn.LoadComboBox_DanToc(cmbDanToc);
            nvdn.LoadComboBox_TonGiao(cmbTonGiao);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc không ?", "Xóa ứng viên ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                nvdn.Xoa_UngVien(txtMaUV.Text);
                nvdn.LoadDataGridView(dgvUngVien);
                Xoa();

            }
        }

        private void dgvUngVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int hang = dgvUngVien.CurrentRow.Index;
            txtMaUV.Text = dgvUngVien[0, hang].Value.ToString();
            txtTenUV.Text = dgvUngVien[1, hang].Value.ToString();
            txtCMND.Text = dgvUngVien[2, hang].Value.ToString();
            dtiNgayCap.Text = dgvUngVien[3, hang].Value.ToString();
            txtNoiCap.Text = dgvUngVien[4, hang].Value.ToString();
            dtiNgaySinh.Text = dgvUngVien[5, hang].Value.ToString();
            //cmbGioitinh.Text = dgvUngVien[6, hang].Value.ToString();
            txtDiaChi.Text = dgvUngVien[7, hang].Value.ToString();
            txtEmail.Text = dgvUngVien[8, hang].Value.ToString();
            txtSDTrieng.Text = dgvUngVien[9, hang].Value.ToString();
            txtSDTnha.Text = dgvUngVien[10, hang].Value.ToString();
            txtHonNhan.Text = dgvUngVien[11, hang].Value.ToString();
            cmbBangCap.Text = dgvUngVien[12, hang].Value.ToString();
            cmbNgoaiNgu.Text = dgvUngVien[13, hang].Value.ToString();
            cmbTinHoc.Text = dgvUngVien[14, hang].Value.ToString();
            txtNamKN.Text = dgvUngVien[15, hang].Value.ToString();
            dtiNgayNopHS.Text = dgvUngVien[16, hang].Value.ToString();
            txtTrangThai.Text = dgvUngVien[17, hang].Value.ToString();
            cmbDotPV.Text = dgvUngVien[18, hang].Value.ToString();

            cmbDanToc.Text = dgvUngVien[19, hang].Value.ToString();
            cmbTonGiao.Text = dgvUngVien[20, hang].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Trangthai = true;
            int MaUV = dk.MaTuTang(dgvUngVien);


            if (MaUV <= 9)
            {
                txtMaUV.Text = "UV" + "0" + MaUV.ToString();
            }
            else
            {
                txtMaUV.Text = "UV" + MaUV.ToString();
            }
          
                   
            dk.Them(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
            txtNamKN.Text = "";
            txtNoiCap.Text = "";
            txtSDTnha.Text = "";
            txtSDTrieng.Text = "";
            txtTenUV.Text = "";
            txtTrangThai.Text = "";
            txtHonNhan.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
            cmbBangCap.Text = "";
            cmbDanToc.Text = "";
            cmbDotPV.Text = "";
            cmbNgoaiNgu.Text = "";
            cmbTinHoc.Text = "";
            cmbTonGiao.Text = "";
            dtiNgayCap.Text = "";
            dtiNgayNopHS.Text = "";
            dtiNgaySinh.Text = "";

               
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Trangthai=false;
           
               
            dk.Sua(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
               
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string Ungvien = "";

            try
            {
                if (txtTimKiem.Text.Trim() == "")
                {
                    lblKetQua.Text = "Bạn phải nhập mã ứng viên cần tìm";
                }
                else
                {
                    if (txtTimKiem.Text.Contains("'") == true)
                    {
                        Ungvien = txtTimKiem.Text.Replace("'", "'" + "'");
                    }
                    else
                    {
                        Ungvien = txtTimKiem.Text;
                    }
                    nvdn.LoadDataGridView_TimKiem(dgvUngVien, Ungvien);
                    if (dgvUngVien.RowCount == 0)
                    {
                        lblKetQua.Text = "Không tìm thấy " + txtTimKiem.Text;
                    }
                    else
                    {
                        lblKetQua.Text = "Kết quả tìm thấy " + txtTimKiem.Text + " là: " + dgvUngVien.RowCount.ToString();
                    }
                }
            }
            catch (Exception)
            {
                lblKetQua.Text = "Không tìm thấy " + txtTimKiem.Text;
            }
        }
        int laymakt()
        {
            return nvdn.DemDong() + 1;
           
        }


       
        public int dem,s;
        private void btnChuyen_Click(object sender, EventArgs e)
        {

            if (laymakt() < 9)
            {
                txtMaUV.Text = "NV" + "0" + laymakt().ToString();
            }
            else
            {
                txtMaUV.Text = "NV" + laymakt().ToString();
            }



            frmThongBaoChuyenNhanVien chuyen = new frmThongBaoChuyenNhanVien();
            chuyen.ShowDialog();
            if (chuyen.chuyen == "1")
            {

                nvdc.Chuyen_NhanVien(txtMaUV.Text, txtTenUV.Text, txtCMND.Text, Convert.ToDateTime(dtiNgayCap.Text.ToString()), txtNoiCap.Text, Convert.ToDateTime(dtiNgaySinh.Text.ToString())
                    , gioitinh, txtDiaChi.Text, txtEmail.Text, txtSDTrieng.Text, txtSDTnha.Text, txtHonNhan.Text
                    , chuyen.maphong, chuyen.machucvu, cmbTinHoc.SelectedValue.ToString(), cmbNgoaiNgu.SelectedValue.ToString(), cmbBangCap.SelectedValue.ToString(), cmbDanToc.SelectedValue.ToString(), cmbTonGiao.SelectedValue.ToString());

                string Makt = txtMaUV.Text.ToString();
                s = Convert.ToInt32(Makt.Substring(2).Trim());
                dem = nvdn.DemDong() + 0;

                if (s == dem)
                {
                    MessageBoxEx.Show("Bạn đã chuyển thành công", "Chúc mừng");
                   
                    int hang = dgvUngVien.CurrentRow.Index;
                    nvdn.Xoa_UngVien(dgvUngVien[0, hang].Value.ToString());
                    nvdn.LoadDataGridView(dgvUngVien);
                    

                }
                else
                {
                    MessageBoxEx.Show("Không chuyển được", "Xin lỗi");

                }
            }
            else
            {
                MessageBoxEx.Show("Không chuyển được", "Xin lỗi");

            }

            
            
        }

        private void txtSDTrieng_KeyPress(object sender, KeyPressEventArgs e)
        {
            dk.NhapSoNguyen(sender, e, txtSDTrieng);

        }

        private void txtSDTnha_KeyPress(object sender, KeyPressEventArgs e)
        {
            dk.NhapSoNguyen(sender, e, txtSDTnha);

        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            dk.NhapSoNguyen(sender, e, txtCMND);

        }

        private void txtNamKN_KeyPress(object sender, KeyPressEventArgs e)
        {
            dk.NhapSoNguyen(sender, e, txtNamKN);

        }

        private void btnNgoaiNgu_Click(object sender, EventArgs e)
        {
            frmNgoaiNgu f_NgoaiNgu = new frmNgoaiNgu();
            f_NgoaiNgu.ShowDialog();
        }

        private void btnBangCap_Click(object sender, EventArgs e)
        {
            frmBangCap f_BangCap = new frmBangCap();
            f_BangCap.ShowDialog();
        }

        private void btnTinHoc_Click(object sender, EventArgs e)
        {
            frmTinHoc f_TinHoc = new frmTinHoc();
            f_TinHoc.ShowDialog();
        }

        private void btnTonGiao_Click(object sender, EventArgs e)
        {
            frmTonGiao f_TonGiao = new frmTonGiao();
            f_TonGiao.ShowDialog();
        }

      

        private void btnDanToc_Click(object sender, EventArgs e)
        {

            frmDanToc f_DanToc = new frmDanToc();
            f_DanToc.ShowDialog();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
         if (rdNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            else
            {
                gioitinh = "Nữ";
            }

            if (txtMaUV.Text.Trim() == "")
            {
                MessageBoxEx.Show("Mã ứng viên không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaUV.Focus();
            }

            else if (txtTenUV.Text.Trim() == "")
            {
                MessageBoxEx.Show("Tên ứng viên không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenUV.Focus();
            }
            else if (dtiNgaySinh.Text.Trim() == "" || Convert.ToDateTime(dtiNgaySinh.Text.Trim()) > DateTime.Now.Date)
            {
                MessageBoxEx.Show("Ngày sinh không hợp lệ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtiNgaySinh.Focus();
            }
            else if (txtCMND.Text.Trim() == "" || txtCMND.Text.Length < 9)
            {
                MessageBoxEx.Show("CMND không được trống hoặc < 9", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCMND.Focus();
            }
            else if (txtSDTrieng.Text.Length < 9 || txtSDTrieng.Text.Length > 15)
            {
                MessageBoxEx.Show("Số điện thoại riêng không được <9 và >15 số", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDTrieng.Focus();
            }
           
            else if (dtiNgayNopHS.Text.Trim() == "")
            {
                MessageBoxEx.Show("Ngày nộp hồ sơ không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtiNgayNopHS.Focus();
            }
            else

                if (txtDiaChi.Text.Trim() == "")
                {
                    MessageBoxEx.Show("Địa chỉ không được trống", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDiaChi.Focus();
                }
                else
                {
                    if (Trangthai == true)
                    {
                        nvdn.Them_UngVien(txtMaUV.Text, txtTenUV.Text, txtCMND.Text, Convert.ToDateTime(dtiNgayCap.Text.ToString()), txtNoiCap.Text, Convert.ToDateTime(dtiNgaySinh.Text.ToString()), gioitinh,
                                            txtDiaChi.Text, txtEmail.Text, txtSDTrieng.Text, txtSDTnha.Text, txtHonNhan.Text, cmbBangCap.SelectedValue.ToString(),
                                              cmbNgoaiNgu.SelectedValue.ToString(), cmbTinHoc.SelectedValue.ToString(), int.Parse(txtNamKN.Text), Convert.ToDateTime(dtiNgayNopHS.Text.ToString()), txtTrangThai.Text, cmbDotPV.SelectedValue.ToString(), cmbDanToc.SelectedValue.ToString(), cmbTonGiao.SelectedValue.ToString());

                    }
                    else
                    {

                        nvdn.Sua_UngVien(txtMaUV.Text, txtTenUV.Text, txtCMND.Text, Convert.ToDateTime(dtiNgayCap.Text.ToString()), txtNoiCap.Text, Convert.ToDateTime(dtiNgaySinh.Text.ToString()), gioitinh, txtDiaChi.Text, txtEmail.Text, txtSDTrieng.Text, txtSDTnha.Text,txtHonNhan.Text, cmbBangCap.SelectedValue.ToString(),
                            cmbNgoaiNgu.SelectedValue.ToString(), cmbTinHoc.SelectedValue.ToString(), int.Parse(txtNamKN.Text), Convert.ToDateTime(dtiNgayNopHS.Text.ToString()), txtTrangThai.Text, cmbDotPV.SelectedValue.ToString(), cmbDanToc.SelectedValue.ToString(), cmbTonGiao.SelectedValue.ToString());

                    }
                    nvdn.LoadDataGridView(dgvUngVien);
                    dk.Luu(btnThem, btnSua, btnLuu, btnXoa, btnThoat);
                    Xoa();
                }
        }
        public void Xoa()
        {
            txtMaUV.Text = "";
            txtNamKN.Text = "";
            txtNoiCap.Text = "";
            txtSDTnha.Text = "";
            txtSDTrieng.Text = "";
            txtTenUV.Text = "";
            txtTrangThai.Text = "";
            txtHonNhan.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtCMND.Text = "";
            cmbBangCap.Text = "";
            cmbDanToc.Text = "";
            cmbDotPV.Text = "";
            cmbNgoaiNgu.Text = "";
            cmbTinHoc.Text = "";
            cmbTonGiao.Text = "";
            dtiNgayCap.Text = "";
            dtiNgayNopHS.Text = "";
            dtiNgaySinh.Text = "";

        }


        
    }
}