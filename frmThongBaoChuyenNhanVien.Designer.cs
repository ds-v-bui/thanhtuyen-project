namespace QL_nhansu
{
    partial class frmThongBaoChuyenNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongBaoChuyenNhanVien));
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmbChucVu = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Docthan = new DevComponents.Editors.ComboItem();
            this.Cogiadinh = new DevComponents.Editors.ComboItem();
            this.cmbPhongBan = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnChuyen = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(2, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(392, 17);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "***Bạn muốn chuyển ứng viên này vào phòng ban nào và chức vụ gì";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(88, 61);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(65, 17);
            this.labelX2.TabIndex = 59;
            this.labelX2.Text = "Phòng ban";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(88, 106);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(50, 17);
            this.labelX3.TabIndex = 60;
            this.labelX3.Text = "Chức vụ";
            // 
            // cmbChucVu
            // 
            this.cmbChucVu.DisplayMember = "Text";
            this.cmbChucVu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChucVu.FormattingEnabled = true;
            this.cmbChucVu.ItemHeight = 14;
            this.cmbChucVu.Items.AddRange(new object[] {
            this.Docthan,
            this.Cogiadinh});
            this.cmbChucVu.Location = new System.Drawing.Point(178, 103);
            this.cmbChucVu.Name = "cmbChucVu";
            this.cmbChucVu.Size = new System.Drawing.Size(120, 20);
            this.cmbChucVu.TabIndex = 2;
            // 
            // Docthan
            // 
            this.Docthan.Text = "Độc thân";
            // 
            // Cogiadinh
            // 
            this.Cogiadinh.Text = "Có gia đình";
            // 
            // cmbPhongBan
            // 
            this.cmbPhongBan.DisplayMember = "Text";
            this.cmbPhongBan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPhongBan.FormattingEnabled = true;
            this.cmbPhongBan.ItemHeight = 14;
            this.cmbPhongBan.Items.AddRange(new object[] {
            this.comboItem3,
            this.comboItem4});
            this.cmbPhongBan.Location = new System.Drawing.Point(178, 58);
            this.cmbPhongBan.Name = "cmbPhongBan";
            this.cmbPhongBan.Size = new System.Drawing.Size(120, 20);
            this.cmbPhongBan.TabIndex = 1;
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "Độc thân";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "Có gia đình";
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnThoat.Location = new System.Drawing.Point(198, 164);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(76, 33);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Không";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnChuyen
            // 
            this.btnChuyen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnChuyen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyen.Image = ((System.Drawing.Image)(resources.GetObject("btnChuyen.Image")));
            this.btnChuyen.ImageFixedSize = new System.Drawing.Size(20, 20);
            this.btnChuyen.Location = new System.Drawing.Point(105, 164);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(76, 33);
            this.btnChuyen.TabIndex = 3;
            this.btnChuyen.Text = "Chuyển";
            this.btnChuyen.Click += new System.EventHandler(this.btnChuyen_Click);
            // 
            // frmThongBaoChuyenNhanVien
            // 
            this.ClientSize = new System.Drawing.Size(397, 240);
            this.Controls.Add(this.btnChuyen);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.cmbPhongBan);
            this.Controls.Add(this.cmbChucVu);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongBaoChuyenNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chuyển Nhân Viên";
            this.Load += new System.EventHandler(this.frmThongBaoChuyenNhanVien_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbChucVu;
        private DevComponents.Editors.ComboItem Docthan;
        private DevComponents.Editors.ComboItem Cogiadinh;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbPhongBan;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnChuyen;
    }
}