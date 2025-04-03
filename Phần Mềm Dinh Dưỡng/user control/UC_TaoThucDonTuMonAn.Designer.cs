namespace Phần_Mềm_Dinh_Dưỡng.user_control
{
    partial class UC_TaoThucDonTuMonAn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboNhomTre = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvThucDonMonAn = new System.Windows.Forms.DataGridView();
            this.btnLuu = new Guna.UI2.WinForms.Guna2Button();
            this.btnMonAn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDonMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(230, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn nhóm trẻ";
            // 
            // cboNhomTre
            // 
            this.cboNhomTre.BackColor = System.Drawing.Color.Transparent;
            this.cboNhomTre.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNhomTre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhomTre.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNhomTre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboNhomTre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhomTre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboNhomTre.ItemHeight = 30;
            this.cboNhomTre.Location = new System.Drawing.Point(398, 52);
            this.cboNhomTre.Name = "cboNhomTre";
            this.cboNhomTre.Size = new System.Drawing.Size(226, 36);
            this.cboNhomTre.TabIndex = 6;
            // 
            // dgvThucDonMonAn
            // 
            this.dgvThucDonMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThucDonMonAn.BackgroundColor = System.Drawing.Color.White;
            this.dgvThucDonMonAn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvThucDonMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThucDonMonAn.Location = new System.Drawing.Point(67, 126);
            this.dgvThucDonMonAn.Name = "dgvThucDonMonAn";
            this.dgvThucDonMonAn.RowHeadersWidth = 51;
            this.dgvThucDonMonAn.RowTemplate.Height = 24;
            this.dgvThucDonMonAn.Size = new System.Drawing.Size(1700, 600);
            this.dgvThucDonMonAn.TabIndex = 7;
            this.dgvThucDonMonAn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThucDonMonAn_CellContentClick);
            // 
            // btnLuu
            // 
            this.btnLuu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLuu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLuu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLuu.FillColor = System.Drawing.Color.Red;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(837, 765);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(180, 45);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu thực đơn";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click_1);
            // 
            // btnMonAn
            // 
            this.btnMonAn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMonAn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMonAn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMonAn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMonAn.FillColor = System.Drawing.Color.LimeGreen;
            this.btnMonAn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonAn.ForeColor = System.Drawing.Color.White;
            this.btnMonAn.Location = new System.Drawing.Point(1507, 42);
            this.btnMonAn.Name = "btnMonAn";
            this.btnMonAn.Size = new System.Drawing.Size(220, 45);
            this.btnMonAn.TabIndex = 9;
            this.btnMonAn.Text = "Xem danh sách món ăn";
            this.btnMonAn.Click += new System.EventHandler(this.btnMonAn_Click);
            // 
            // UC_TaoThucDonTuMonAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMonAn);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvThucDonMonAn);
            this.Controls.Add(this.cboNhomTre);
            this.Controls.Add(this.label1);
            this.Name = "UC_TaoThucDonTuMonAn";
            this.Size = new System.Drawing.Size(1882, 852);
            this.Load += new System.EventHandler(this.UC_TaoThucDonTuMonAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThucDonMonAn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboNhomTre;
        private System.Windows.Forms.DataGridView dgvThucDonMonAn;
        private Guna.UI2.WinForms.Guna2Button btnLuu;
        private Guna.UI2.WinForms.Guna2Button btnMonAn;
    }
}
