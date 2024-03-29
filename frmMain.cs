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
using DevComponents.DotNetBar.Rendering;

using QL_nhansu.Class;

namespace QL_nhansu
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007Form
    {
       
         public static string thongtindn = "";
         frmDangNhap f_DangNhap = null;
         frmNhanVien f_NhanVien = null;
         frmChucVu f_ChucVu = null;
         frmPhongBan f_PhongBan = null;
         frmKyLuat f_KyLuat = null;
         frmKhenThuong f_KhenThuong = null;
         frmNghiViec f_NghiViec = null;
         frmDotPhongVan f_PhongVan = null;
         frmDotTuyenDung f_TuyenDung = null;
         frmUngVien f_UngVien = null;
         frmHopDong f_HopDong = null;
         frmTimKiem f_TimKiem = null;
         frmBangchiluong f_ChiLuong = null;
         frmBangchamcong f_ChamCong = null;

         frmPhanQuyen f_PhanQuyen = null;
         frmTKTheoCacTieuChi f_TK = null;
         frmDoiMatKhau f_MatKhau = null;
        frmThemNguoiDung f_NguoiDung = null;
        frmBC_Bangchiluong f_BC_ChiLuong = null;
        frmBC_Bangchamcong f_BC_ChamCong = null;
        frmBaocaonhansu f_BC_NhanSu = null;
        frmToLamViec f_ToLamViec = null;
        frmCapnhatchiluong f_CapNhat_Chiluong = null;

        public frmMain()
        {
            InitializeComponent();
        }
        public void frmMain_Load(object sender, EventArgs e)
        {


            expandablePanel1ThanhChucNang.Enabled = true;
            toolStripBtnChiLuong.Enabled = false;
            toolStripBtnChamCong.Enabled = false;
            toolStripBtnHopDong.Enabled = false;
            toolStripBtnKhenThuong.Enabled = false;
            toolStripBtnNghiViec.Enabled = false;
            toolStripBtnTuyenDung.Enabled = false;
            toolStripBtnChucVu.Enabled = false;
            toolStripBtnNhanVien.Enabled = false;
            toolStripBtnUngVien.Enabled = false;
            tsmBaoCao.Enabled = false;
            tsmLuongBong.Enabled = false;
            tsmThongTin.Enabled = false;
            tsmTuyenDung.Enabled = false;
            tsmTimKiem.Enabled = false;
            sideBarPanelBaoCao.Enabled = false;
            sideBarPanelLuongBong.Enabled = false;
            sideBarPanelThongTin.Enabled = false;
            sideBarPanelTimKiem.Enabled = false;
            sideBarPanelTuyenDung.Enabled = false;
            toolStripMenuPhanQuyen.Enabled = false;
            if (frmDangNhap.TenDangNhap == null)
            {

                f_DangNhap = new frmDangNhap();
                //f_DangNhap.FormBorderStyle = FormBorderStyle.None;
                f_DangNhap.MdiParent = this;
                f_DangNhap.Show();


            }
            else
            {
                loadData();
            }
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Quản Lý Nhân Sự", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Exit();
        }

      
        public string Q;

        private void loadData()
        {
           
            if (frmDangNhap.TenDN !="")
            {
                frmDangNhap f = new frmDangNhap();
                int i = Convert.ToInt32(Q);
                //MessageBox.Show(i.ToString());
               
                switch (i)
                {
                    case 0:
                        {
                            toolStripBtnKhenThuong.Enabled =true;
                            toolStripBtnNghiViec.Enabled = true;
                            toolStripBtnTuyenDung.Enabled = true;
                            toolStripBtnChucVu.Enabled = true;
                            toolStripBtnNhanVien.Enabled = true;
                            toolStripBtnUngVien.Enabled = true;
                            //tsmBaoCao.Enabled = false;
                            //tsmLuongBong.Enabled = false;
                            tsmThongTin.Enabled = true;
                            tsmTuyenDung.Enabled = true;
                            tsmTimKiem.Enabled = true;
                            //sideBarPanelBaoCao.Enabled = false;
                            //sideBarPanelLuongBong.Enabled = false;
                            sideBarPanelThongTin.Enabled = true;
                            sideBarPanelTimKiem.Enabled = true;
                            sideBarPanelTuyenDung.Enabled = true;
                            toolStripMenuHopDong.Enabled = false;
                            break;
                        }
                    case 1:
                        {
                            toolStripBtnHopDong.Enabled =true;
                            toolStripBtnChamCong.Enabled = true;
                            toolStripBtnChiLuong.Enabled = true;
                            toolStripBtnKhenThuong.Enabled = true;
                            toolStripBtnNghiViec.Enabled = true;
                            toolStripBtnTuyenDung.Enabled = true;
                            toolStripBtnChucVu.Enabled = true;
                            toolStripBtnNhanVien.Enabled = true;
                            toolStripBtnUngVien.Enabled = true;
                            tsmBaoCao.Enabled = true;
                            tsmLuongBong.Enabled = true;
                            tsmThongTin.Enabled = true;
                            tsmTuyenDung.Enabled = true;
                            tsmTimKiem.Enabled = true;
                            sideBarPanelBaoCao.Enabled = true;
                            sideBarPanelLuongBong.Enabled = true;
                            sideBarPanelThongTin.Enabled = true;
                            sideBarPanelTimKiem.Enabled = true;
                            sideBarPanelTuyenDung.Enabled = true;
                            toolStripMenuHopDong.Enabled = true;
                            break;
                        }
                    case 2:
                        {
                            toolStripBtnHopDong.Enabled = true;
                            toolStripBtnChamCong.Enabled = true;
                            toolStripBtnChiLuong.Enabled = true;
                            toolStripBtnKhenThuong.Enabled = true;
                            toolStripBtnNghiViec.Enabled = true;
                            toolStripBtnTuyenDung.Enabled = true;
                            toolStripBtnChucVu.Enabled = true;
                            toolStripBtnNhanVien.Enabled = true;
                            toolStripBtnUngVien.Enabled = true;
                            tsmBaoCao.Enabled = true;
                            tsmLuongBong.Enabled = true;
                            tsmThongTin.Enabled = true;
                            tsmTuyenDung.Enabled = true;
                            tsmTimKiem.Enabled = true;
                            sideBarPanelBaoCao.Enabled = true;
                            sideBarPanelLuongBong.Enabled = true;
                            sideBarPanelThongTin.Enabled = true;
                            sideBarPanelTimKiem.Enabled = true;
                            sideBarPanelTuyenDung.Enabled = true;
                            toolStripMenuHopDong.Enabled = true;
                            toolStripMenuPhanQuyen.Enabled =true;
                            
                            

                            break;
                        }
                }
            }
            
        }

        private void toolStripBtnNhanVien_Click(object sender, EventArgs e)
        {
            if (f_NhanVien == null || f_NhanVien.IsDisposed)
            {
                f_NhanVien = new frmNhanVien();
                //f_NhanVien.FormBorderStyle = FormBorderStyle.None;
                f_NhanVien.MdiParent = this;
                f_NhanVien.Show();
            }
            else
                f_NhanVien.Activate();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            if (f_DangNhap == null || f_DangNhap.IsDisposed)//dang nhap he thong
            {
                f_DangNhap = new frmDangNhap();
                //f_DangNhap.FormBorderStyle = FormBorderStyle.None;

                f_DangNhap.MdiParent = this;
            }
            f_DangNhap.Show();
            //loadData();
           
        }

        private void toolStripMenuNhanVien_Click(object sender, EventArgs e)
        {
            //frmNhanVien f_NhanVien = null;
            if (f_NhanVien == null || f_NhanVien.IsDisposed)
            {
                f_NhanVien = new frmNhanVien();
               // f_NhanVien.FormBorderStyle = FormBorderStyle.None;
                f_NhanVien.MdiParent = this;
                f_NhanVien.Show();
            }
            else
                f_NhanVien.Activate();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            //frmNhanVien f_NhanVien = null;
            if (f_NhanVien == null || f_NhanVien.IsDisposed)
            {
                f_NhanVien = new frmNhanVien();
                //f_NhanVien.FormBorderStyle = FormBorderStyle.None;
                f_NhanVien.MdiParent = this;
                f_NhanVien.Show();
            }
            else
                f_NhanVien.Activate();
        }

        private void toolStripBtnChucVu_Click(object sender, EventArgs e)
        {
            if (f_ChucVu == null || f_ChucVu.IsDisposed)
            {
                f_ChucVu = new frmChucVu();
               // f_ChucVu.FormBorderStyle = FormBorderStyle.None;
                f_ChucVu.MdiParent = this;
                f_ChucVu.Show();
            }
            else
                f_ChucVu.Activate();
        }

        private void toolStripMenuChucVu_Click(object sender, EventArgs e)
        {
            //frmChucVu f_ChucVu = null;
            if (f_ChucVu == null || f_ChucVu.IsDisposed)
            {
                f_ChucVu = new frmChucVu();
                //f_ChucVu.FormBorderStyle = FormBorderStyle.None;
                f_ChucVu.MdiParent = this;
                f_ChucVu.Show();
            }
            else
                f_ChucVu.Activate();
        }

        private void toolStripMenuPhongBan_Click(object sender, EventArgs e)
        {
            if (f_PhongBan == null || f_PhongBan.IsDisposed)
            {
                f_PhongBan = new frmPhongBan();
                f_PhongBan.MdiParent = this;
                f_PhongBan.Show();
            }
            else
                f_PhongBan.Activate();
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            if (f_PhongBan == null || f_PhongBan.IsDisposed)
            {
                f_PhongBan = new frmPhongBan();
                //f_PhongBan.FormBorderStyle = FormBorderStyle.None;
                f_PhongBan.MdiParent = this;
                f_PhongBan.Show();
            }
            else
                f_PhongBan.Activate();
        }

        private void toolStripMenuKhenThuong_Click(object sender, EventArgs e)
        {
            if (f_KhenThuong == null || f_KhenThuong.IsDisposed)
            {
                f_KhenThuong = new frmKhenThuong();
                //f_KhenThuong.FormBorderStyle = FormBorderStyle.None;
                f_KhenThuong.MdiParent = this;
                f_KhenThuong.Show();
            }
            else
                f_KhenThuong.Activate();
        }

        private void toolStripBtnKhenThuong_Click(object sender, EventArgs e)
        {

            if (f_KhenThuong == null || f_KhenThuong.IsDisposed)
            {
                f_KhenThuong = new frmKhenThuong();
                //f_KhenThuong.FormBorderStyle = FormBorderStyle.None;
                f_KhenThuong.MdiParent = this;
                f_KhenThuong.Show();
            }
            else
                f_KhenThuong.Activate();
        }

        private void toolStripMenuKyLuat_Click(object sender, EventArgs e)
        {

            if (f_KyLuat == null || f_KyLuat.IsDisposed)
            {
                f_KyLuat = new frmKyLuat();
                //f_KyLuat.FormBorderStyle = FormBorderStyle.None;
                f_KyLuat.MdiParent = this;
                f_KyLuat.Show();
            }
            else
                f_KyLuat.Activate();
        }

        private void btnKyLuat_Click(object sender, EventArgs e)
        {
            if (f_KyLuat == null || f_KyLuat.IsDisposed)
            {
                f_KyLuat = new frmKyLuat();
               // f_KyLuat.FormBorderStyle = FormBorderStyle.None;
                f_KyLuat.MdiParent = this;
                f_KyLuat.Show();
            }
            else
                f_KyLuat.Activate();
        }

        private void toolStripMenuNghiViec_Click(object sender, EventArgs e)
        {
            if (f_NghiViec == null || f_NghiViec.IsDisposed)
            {
                f_NghiViec = new frmNghiViec();
                //f_NghiViec.FormBorderStyle = FormBorderStyle.None;
                f_NghiViec.MdiParent = this;
                f_NghiViec.Show();
            }
            else
                f_NghiViec.Activate();
        }

        private void toolStripBtnNghiViec_Click(object sender, EventArgs e)
        {
            if (f_NghiViec == null || f_NghiViec.IsDisposed)
            {
                f_NghiViec = new frmNghiViec();
               // f_NghiViec.FormBorderStyle = FormBorderStyle.None;
                f_NghiViec.MdiParent = this;
                f_NghiViec.Show();
            }
            else
                f_NghiViec.Activate();
        }

        private void btnNghiViec_Click(object sender, EventArgs e)
        {
            if (f_NghiViec == null || f_NghiViec.IsDisposed)
            {
                f_NghiViec = new frmNghiViec();
                //f_NghiViec.FormBorderStyle = FormBorderStyle.None;
                f_NghiViec.MdiParent = this;
                f_NghiViec.Show();
            }
            else
                f_NghiViec.Activate();
        }

        private void toolStripMenuDotPV_Click(object sender, EventArgs e)
        {
            if (f_PhongVan == null || f_PhongVan.IsDisposed)
            {
                f_PhongVan = new frmDotPhongVan();
                //f_PhongVan.FormBorderStyle = FormBorderStyle.None;
                f_PhongVan.MdiParent = this;
                f_PhongVan.Show();
            }
            else
                f_PhongVan.Activate();
        }

        private void btnDotPhongVan_Click(object sender, EventArgs e)
        {
            if (f_PhongVan == null || f_PhongVan.IsDisposed)
            {
                f_PhongVan = new frmDotPhongVan();
                //f_PhongVan.FormBorderStyle = FormBorderStyle.None;
                f_PhongVan.MdiParent = this;
                f_PhongVan.Show();
            }
            else
                f_PhongVan.Activate();
        }

        private void toolStripMenuDotTD_Click(object sender, EventArgs e)
        {
            if (f_TuyenDung == null || f_TuyenDung.IsDisposed)
            {
                f_TuyenDung = new frmDotTuyenDung();
                //f_TuyenDung.FormBorderStyle = FormBorderStyle.None;
                f_TuyenDung.MdiParent = this;
                f_TuyenDung.Show();
            }
            else
                f_TuyenDung.Activate();
        }

        private void toolStripBtnUngVien_Click(object sender, EventArgs e)
        {
            if (f_UngVien == null || f_UngVien.IsDisposed)
            {
                f_UngVien = new frmUngVien();
                //f_UngVien.FormBorderStyle = FormBorderStyle.None;
                f_UngVien.MdiParent = this;
                f_UngVien.Show();
            }
            else
                f_UngVien.Activate();
        }

        private void btnUngVien_Click(object sender, EventArgs e)
        {
            if (f_UngVien == null || f_UngVien.IsDisposed)
            {
                f_UngVien = new frmUngVien();
                //f_UngVien.FormBorderStyle = FormBorderStyle.None;
                f_UngVien.MdiParent = this;
                f_UngVien.Show();
            }
            else
                f_UngVien.Activate();
        }

        private void toolStripMenuUngVien_Click(object sender, EventArgs e)
        {
            if (f_UngVien == null || f_UngVien.IsDisposed)
            {
                f_UngVien = new frmUngVien();
               // f_UngVien.FormBorderStyle = FormBorderStyle.None;
                f_UngVien.MdiParent = this;
                f_UngVien.Show();
            }
            else
                f_UngVien.Activate();
        }

        private void btnDotTuyenDung_Click(object sender, EventArgs e)
        {
            if (f_TuyenDung == null || f_TuyenDung.IsDisposed)
            {
                f_TuyenDung = new frmDotTuyenDung();
                //f_TuyenDung.FormBorderStyle = FormBorderStyle.None;
                f_TuyenDung.MdiParent = this;
                f_TuyenDung.Show();
            }
            else
                f_TuyenDung.Activate();
        }

        private void toolStripMenuHopDong_Click(object sender, EventArgs e)
        {
            if (f_HopDong == null || f_HopDong.IsDisposed)
            {
                f_HopDong = new frmHopDong();
               // f_HopDong.FormBorderStyle = FormBorderStyle.None;
                f_HopDong.MdiParent = this;
                f_HopDong.Show();
            }
            else
                f_HopDong.Activate();
        }

        private void toolStripBtnHopDong_Click(object sender, EventArgs e)
        {
            if (f_HopDong == null || f_HopDong.IsDisposed)
            {
                f_HopDong = new frmHopDong();
               // f_HopDong.FormBorderStyle = FormBorderStyle.None;
                f_HopDong.MdiParent = this;
                f_HopDong.Show();
            }
            else
                f_HopDong.Activate();
        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            if (f_HopDong == null || f_HopDong.IsDisposed)
            {
                f_HopDong = new frmHopDong();
                //f_HopDong.FormBorderStyle = FormBorderStyle.None;
                f_HopDong.MdiParent = this;
                f_HopDong.Show();
            }
            else
                f_HopDong.Activate();
        }

        private void toolStripMenuThemTk_Click(object sender, EventArgs e)
        {
            if (f_NguoiDung == null || f_NguoiDung.IsDisposed)
            {
                f_NguoiDung = new frmThemNguoiDung();
                //f_NguoiDung.FormBorderStyle = FormBorderStyle.None;
                f_NguoiDung.MdiParent = this;
                f_NguoiDung.Show();
            }
            else
                f_NguoiDung.Activate();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (f_TimKiem == null || f_TimKiem.IsDisposed)
            {
                f_TimKiem = new frmTimKiem();
                //f_TimKiem.FormBorderStyle = FormBorderStyle.None;
                f_TimKiem.MdiParent = this;
                f_TimKiem.Show();
            }
            else
                f_TimKiem.Activate();
        }

        private void toolStripMenuTimKiemNV_Click(object sender, EventArgs e)
        {

            if (f_TimKiem == null || f_TimKiem.IsDisposed)
            {
                f_TimKiem = new frmTimKiem();
               // f_TimKiem.FormBorderStyle = FormBorderStyle.None;
                f_TimKiem.MdiParent = this;
                f_TimKiem.Show();
            }
            else
                f_TimKiem.Activate();
        }

        private void toolStripMenuTKtheoTC_Click(object sender, EventArgs e)
        {

            if (f_TK == null || f_TK.IsDisposed)
            {
                f_TK = new frmTKTheoCacTieuChi();
                //f_TK.FormBorderStyle = FormBorderStyle.None;
                f_TK.MdiParent = this;
                f_TK.Show();
            }
            else
                f_TK.Activate();
        }

        private void btnTKtheoTC_Click(object sender, EventArgs e)
        {
            if (f_TK == null || f_TK.IsDisposed)
            {
                f_TK = new frmTKTheoCacTieuChi();
               // f_TK.FormBorderStyle = FormBorderStyle.None;
                f_TK.MdiParent = this;
                f_TK.Show();
            }
            else
                f_TK.Activate();
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {

            if (f_NguoiDung == null || f_NguoiDung.IsDisposed)
            {
                f_NguoiDung = new frmThemNguoiDung();
                //f_NguoiDung.FormBorderStyle = FormBorderStyle.None;
                f_NguoiDung.MdiParent = this;
                f_NguoiDung.Show();
            }
            else
                f_NguoiDung.Activate();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {

            if (f_MatKhau == null || f_MatKhau.IsDisposed)
            {
                f_MatKhau = new frmDoiMatKhau();
               // f_MatKhau.FormBorderStyle = FormBorderStyle.None;
                f_MatKhau.MdiParent = this;
                f_MatKhau.Show();
            }
            else
                f_MatKhau.Activate();
        }

        private void toolStripMenuDoiMK_Click(object sender, EventArgs e)
        {

            if (f_MatKhau == null || f_MatKhau.IsDisposed)
            {
                f_MatKhau = new frmDoiMatKhau();
                //f_MatKhau.FormBorderStyle = FormBorderStyle.None;
                f_MatKhau.MdiParent = this;
                f_MatKhau.Show();
            }
            else
                f_MatKhau.Activate();
        }

        private void toolStripMenuDangNhap_Click(object sender, EventArgs e)
        {
            if (f_DangNhap == null || f_DangNhap.IsDisposed)//dang nhap he thong
            {
                f_DangNhap = new frmDangNhap();
                //f_DangNhap.FormBorderStyle = FormBorderStyle.None;

                f_DangNhap.MdiParent = this;
                f_DangNhap.Show();
            }
            else
                f_DangNhap.Activate();
            //loadData();
        }

        private void toolStripMenuDangXuat_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //f_DangNhap.Show();
        }

        private void toolStripMenuThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát khỏi chương trình không?", "Quản Lý Nhân Sự", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Application.Exit();
        }

        private void toolStripMenuChamCong_Click(object sender, EventArgs e)
        {
            if (f_ChamCong == null || f_ChamCong.IsDisposed)
            {
                f_ChamCong = new frmBangchamcong();
                //f_ChamCong.FormBorderStyle = FormBorderStyle.None;

                f_ChamCong.MdiParent = this;

                f_ChamCong.Show();
            }
            else
                f_ChamCong.Activate();
        }

        private void toolStripBtnTuyenDung_Click(object sender, EventArgs e)
        {
            if (f_TuyenDung == null || f_TuyenDung.IsDisposed)
            {
                f_TuyenDung = new frmDotTuyenDung();
                //f_TuyenDung.FormBorderStyle = FormBorderStyle.None;
                f_TuyenDung.MdiParent = this;
                f_TuyenDung.Show();
            }
            else
                f_TuyenDung.Activate();
        }

        private void toolStripMenuPhanQuyen_Click(object sender, EventArgs e)
        {

            if (f_PhanQuyen == null || f_PhanQuyen.IsDisposed)
            {
                f_PhanQuyen = new frmPhanQuyen();
                f_PhanQuyen.MdiParent = this;
                f_PhanQuyen.Show();
            }
            else
                f_PhanQuyen.Activate();
        }

        private void toolStripMenuChiLuong_Click(object sender, EventArgs e)
        {
            if (f_ChiLuong == null || f_ChiLuong.IsDisposed)
            {
                f_ChiLuong = new frmBangchiluong();
                f_ChiLuong.MdiParent = this;
                f_ChiLuong.Show();
            }
            else
                f_ChiLuong.Activate();
        }

        private void toolStripMenuBCChamCong_Click(object sender, EventArgs e)
        {
            if (f_BC_ChamCong == null || f_BC_ChamCong.IsDisposed)
            {
                f_BC_ChamCong = new frmBC_Bangchamcong();
                //f_BC_ChamCong.MdiParent = this;
                f_BC_ChamCong.Show();
            }
            else
                f_BC_ChamCong.Activate();
        }

        private void toolStripMenuBCTienLuong_Click(object sender, EventArgs e)
        {
            if (f_BC_ChiLuong == null || f_BC_ChiLuong.IsDisposed)
            {
                f_BC_ChiLuong = new frmBC_Bangchiluong();
               // f_BC_ChiLuong.MdiParent = this;
                f_BC_ChiLuong.Show();
            }
            else
                f_BC_ChiLuong.Activate();
        }

        private void toolStripMenuNhanSu_Click(object sender, EventArgs e)
        {

            if (f_BC_NhanSu == null || f_BC_NhanSu.IsDisposed)
            {
                f_BC_NhanSu = new frmBaocaonhansu();
                f_BC_NhanSu.MdiParent = this;
                f_BC_NhanSu.Show();
            }
            else
                f_BC_NhanSu.Activate();
        }

      

        private void toolStripMenuGioiThieu_Click_1(object sender, EventArgs e)
        {
            frmTacgia f_TacGia = null;
            if (f_TacGia == null || f_TacGia.IsDisposed)
            {
                f_TacGia = new frmTacgia();
                f_TacGia.MdiParent = this;
                f_TacGia.Show();
            }
            else
                f_TacGia.Activate();
        }

        private void toolStripBtnChamCong_Click(object sender, EventArgs e)
        {
            if (f_ChamCong == null || f_ChamCong.IsDisposed)
            {
                f_ChamCong = new frmBangchamcong();
                //f_ChamCong.FormBorderStyle = FormBorderStyle.None;

                f_ChamCong.MdiParent = this;

                f_ChamCong.Show();
            }
            else
                f_ChamCong.Activate();
        }

        private void toolStripBtnChiLuong_Click(object sender, EventArgs e)
        {
            if (f_ChiLuong == null || f_ChiLuong.IsDisposed)
            {
                f_ChiLuong = new frmBangchiluong();
                f_ChiLuong.MdiParent = this;
                f_ChiLuong.Show();
            }
            else
                f_ChiLuong.Activate();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            if (f_ChamCong == null || f_ChamCong.IsDisposed)
            {
                f_ChamCong = new frmBangchamcong();
                //f_ChamCong.FormBorderStyle = FormBorderStyle.None;

                f_ChamCong.MdiParent = this;

                f_ChamCong.Show();
            }
            else
                f_ChamCong.Activate();
        }

        private void btnChiLuong_Click(object sender, EventArgs e)
        {
            if (f_ChiLuong == null || f_ChiLuong.IsDisposed)
            {
                f_ChiLuong = new frmBangchiluong();
                f_ChiLuong.MdiParent = this;
                f_ChiLuong.Show();
            }
            else
                f_ChiLuong.Activate();
        }

        private void btnBCTienLương_Click(object sender, EventArgs e)
        {
            if (f_BC_ChiLuong == null || f_BC_ChiLuong.IsDisposed)
            {
                f_BC_ChiLuong = new frmBC_Bangchiluong();
               // f_BC_ChiLuong.MdiParent = this;
                f_BC_ChiLuong.Show();
            }
            else
                f_BC_ChiLuong.Activate();
        }

        private void btnBCNhanSu_Click(object sender, EventArgs e)
        {
            if (f_BC_NhanSu == null || f_BC_NhanSu.IsDisposed)
            {
                f_BC_NhanSu = new frmBaocaonhansu();
                f_BC_NhanSu.MdiParent = this;
                f_BC_NhanSu.Show();
            }
            else
                f_BC_NhanSu.Activate();
        }

        private void btnBCChamCong_Click(object sender, EventArgs e)
        {

            if (f_BC_ChamCong == null || f_BC_ChamCong.IsDisposed)
            {
                f_BC_ChamCong = new frmBC_Bangchamcong();
               // f_BC_ChamCong.MdiParent = this;
                f_BC_ChamCong.Show();
            }
            else
                f_BC_ChamCong.Activate();
        }

        private void toolStripMenuToLamViec_Click(object sender, EventArgs e)
        {
            if (f_ToLamViec == null || f_ToLamViec.IsDisposed)
            {
                f_ToLamViec = new frmToLamViec();
                f_ToLamViec.MdiParent = this;
                f_ToLamViec.Show();
            }
            else
                f_ToLamViec.Activate();
        }

        private void toolStripMenuCapNhatChiLuong_Click(object sender, EventArgs e)
        {
            if (f_CapNhat_Chiluong == null || f_CapNhat_Chiluong.IsDisposed)
            {
                f_CapNhat_Chiluong = new frmCapnhatchiluong();
                f_CapNhat_Chiluong.MdiParent = this;
                f_CapNhat_Chiluong.Show();
            }
            else
                f_CapNhat_Chiluong.Activate();
        }

        private void btnCapNhatChiLuong_Click(object sender, EventArgs e)
        {
            if (f_CapNhat_Chiluong == null || f_CapNhat_Chiluong.IsDisposed)
            {
                f_CapNhat_Chiluong = new frmCapnhatchiluong();
                f_CapNhat_Chiluong.MdiParent = this;
                f_CapNhat_Chiluong.Show();
            }
            else
                f_CapNhat_Chiluong.Activate();
        }

      

       

        

    }
}