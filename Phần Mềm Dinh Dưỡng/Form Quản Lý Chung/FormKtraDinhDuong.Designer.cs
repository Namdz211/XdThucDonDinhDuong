using System.Windows.Forms;

namespace Phần_Mềm_Dinh_Dưỡng.Form_Quản_Lý_Chung
{
    partial class FormKtraDinhDuong
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lblAvgFiber = new System.Windows.Forms.Label();
            this.lblAvgCarbs = new System.Windows.Forms.Label();
            this.lblAvgFat = new System.Windows.Forms.Label();
            this.lblAvgProtein = new System.Windows.Forms.Label();
            this.dgvAnalysis = new System.Windows.Forms.DataGridView();
            this.txtComparison = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAvgCalories = new System.Windows.Forms.Label();
            this.chartNutrition = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNhomTre = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNutrition)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAvgFiber
            // 
            this.lblAvgFiber.AutoSize = true;
            this.lblAvgFiber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgFiber.Location = new System.Drawing.Point(227, 349);
            this.lblAvgFiber.Name = "lblAvgFiber";
            this.lblAvgFiber.Size = new System.Drawing.Size(61, 25);
            this.lblAvgFiber.TabIndex = 15;
            this.lblAvgFiber.Text = "Fiber";
            // 
            // lblAvgCarbs
            // 
            this.lblAvgCarbs.AutoSize = true;
            this.lblAvgCarbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgCarbs.Location = new System.Drawing.Point(227, 253);
            this.lblAvgCarbs.Name = "lblAvgCarbs";
            this.lblAvgCarbs.Size = new System.Drawing.Size(154, 25);
            this.lblAvgCarbs.TabIndex = 14;
            this.lblAvgCarbs.Text = "Carbohydrates";
            // 
            // lblAvgFat
            // 
            this.lblAvgFat.AutoSize = true;
            this.lblAvgFat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgFat.Location = new System.Drawing.Point(227, 297);
            this.lblAvgFat.Name = "lblAvgFat";
            this.lblAvgFat.Size = new System.Drawing.Size(43, 25);
            this.lblAvgFat.TabIndex = 13;
            this.lblAvgFat.Text = "Fat";
            // 
            // lblAvgProtein
            // 
            this.lblAvgProtein.AutoSize = true;
            this.lblAvgProtein.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgProtein.Location = new System.Drawing.Point(227, 197);
            this.lblAvgProtein.Name = "lblAvgProtein";
            this.lblAvgProtein.Size = new System.Drawing.Size(80, 25);
            this.lblAvgProtein.TabIndex = 12;
            this.lblAvgProtein.Text = "Protein";
            // 
            // dgvAnalysis
            // 
            this.dgvAnalysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAnalysis.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalysis.Location = new System.Drawing.Point(321, 519);
            this.dgvAnalysis.Name = "dgvAnalysis";
            this.dgvAnalysis.RowHeadersWidth = 51;
            this.dgvAnalysis.RowTemplate.Height = 24;
            this.dgvAnalysis.Size = new System.Drawing.Size(240, 150);
            this.dgvAnalysis.TabIndex = 11;
            this.dgvAnalysis.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnalysis_CellContentClick);
            // 
            // txtComparison
            // 
            this.txtComparison.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtComparison.DefaultText = "";
            this.txtComparison.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtComparison.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtComparison.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtComparison.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtComparison.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtComparison.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtComparison.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtComparison.Location = new System.Drawing.Point(339, 426);
            this.txtComparison.Name = "txtComparison";
            this.txtComparison.PasswordChar = '\0';
            this.txtComparison.PlaceholderText = "";
            this.txtComparison.SelectedText = "";
            this.txtComparison.Size = new System.Drawing.Size(200, 36);
            this.txtComparison.TabIndex = 10;
            this.txtComparison.TextChanged += new System.EventHandler(this.txtComparison_TextChanged);
            // 
            // lblAvgCalories
            // 
            this.lblAvgCalories.AutoSize = true;
            this.lblAvgCalories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgCalories.Location = new System.Drawing.Point(227, 141);
            this.lblAvgCalories.Name = "lblAvgCalories";
            this.lblAvgCalories.Size = new System.Drawing.Size(92, 25);
            this.lblAvgCalories.TabIndex = 9;
            this.lblAvgCalories.Text = "Calories";
            // 
            // chartNutrition
            // 
            chartArea1.AxisX.Title = "Ngày";
            chartArea1.AxisY.Title = "Giá trị (kcal/g)";
            chartArea1.Name = "ChartArea1";
            this.chartNutrition.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            legend1.Title = "Chỉ số";
            this.chartNutrition.Legends.Add(legend1);
            this.chartNutrition.Location = new System.Drawing.Point(568, 74);
            this.chartNutrition.Name = "chartNutrition";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartNutrition.Series.Add(series1);
            this.chartNutrition.Size = new System.Drawing.Size(514, 348);
            this.chartNutrition.TabIndex = 8;
            this.chartNutrition.Text = "Phân tích dinh dưỡng thực đơn";
            title1.Name = "Biểu Đồ Dinh Dưỡng Theo Ngày";
            this.chartNutrition.Titles.Add(title1);
            this.chartNutrition.Click += new System.EventHandler(this.chartNutrition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(417, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 32);
            this.label1.TabIndex = 16;
            this.label1.Text = "Phân tích dinh dưỡng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Nhóm trẻ";
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
            this.cboNhomTre.Location = new System.Drawing.Point(374, 88);
            this.cboNhomTre.Name = "cboNhomTre";
            this.cboNhomTre.Size = new System.Drawing.Size(140, 36);
            this.cboNhomTre.TabIndex = 18;
            // 
            // FormKtraDinhDuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 698);
            this.Controls.Add(this.cboNhomTre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAvgFiber);
            this.Controls.Add(this.lblAvgCarbs);
            this.Controls.Add(this.lblAvgFat);
            this.Controls.Add(this.lblAvgProtein);
            this.Controls.Add(this.dgvAnalysis);
            this.Controls.Add(this.txtComparison);
            this.Controls.Add(this.lblAvgCalories);
            this.Controls.Add(this.chartNutrition);
            this.Name = "FormKtraDinhDuong";
            this.Text = "FormKtraDinhDuong";
            this.Load += new System.EventHandler(this.FormKtraDinhDuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartNutrition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAvgFiber;
        private System.Windows.Forms.Label lblAvgCarbs;
        private System.Windows.Forms.Label lblAvgFat;
        private System.Windows.Forms.Label lblAvgProtein;
        private System.Windows.Forms.DataGridView dgvAnalysis;
        private Guna.UI2.WinForms.Guna2TextBox txtComparison;
        private System.Windows.Forms.Label lblAvgCalories;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNutrition;
        private System.Windows.Forms.Label label1;
        private Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cboNhomTre;
    }
}