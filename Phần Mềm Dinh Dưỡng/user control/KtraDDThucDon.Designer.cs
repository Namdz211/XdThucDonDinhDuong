namespace Phần_Mềm_Dinh_Dưỡng.user_control
{
    partial class KtraDDThucDon
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartNutrition = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblAvgCalories = new System.Windows.Forms.Label();
            this.txtComparison = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvAnalysis = new System.Windows.Forms.DataGridView();
            this.lblAvgProtein = new System.Windows.Forms.Label();
            this.lblAvgFat = new System.Windows.Forms.Label();
            this.lblAvgCarbs = new System.Windows.Forms.Label();
            this.lblAvgFiber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartNutrition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // chartNutrition
            // 
            chartArea1.Name = "ChartArea1";
            this.chartNutrition.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartNutrition.Legends.Add(legend1);
            this.chartNutrition.Location = new System.Drawing.Point(354, 23);
            this.chartNutrition.Name = "chartNutrition";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartNutrition.Series.Add(series1);
            this.chartNutrition.Size = new System.Drawing.Size(300, 300);
            this.chartNutrition.TabIndex = 0;
            this.chartNutrition.Text = "chart1";
            // 
            // lblAvgCalories
            // 
            this.lblAvgCalories.AutoSize = true;
            this.lblAvgCalories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgCalories.Location = new System.Drawing.Point(307, 338);
            this.lblAvgCalories.Name = "lblAvgCalories";
            this.lblAvgCalories.Size = new System.Drawing.Size(92, 25);
            this.lblAvgCalories.TabIndex = 1;
            this.lblAvgCalories.Text = "Calories";
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
            this.txtComparison.Location = new System.Drawing.Point(383, 504);
            this.txtComparison.Name = "txtComparison";
            this.txtComparison.PasswordChar = '\0';
            this.txtComparison.PlaceholderText = "";
            this.txtComparison.SelectedText = "";
            this.txtComparison.Size = new System.Drawing.Size(200, 36);
            this.txtComparison.TabIndex = 2;
            // 
            // dgvAnalysis
            // 
            this.dgvAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalysis.Location = new System.Drawing.Point(354, 626);
            this.dgvAnalysis.Name = "dgvAnalysis";
            this.dgvAnalysis.RowHeadersWidth = 51;
            this.dgvAnalysis.RowTemplate.Height = 24;
            this.dgvAnalysis.Size = new System.Drawing.Size(240, 150);
            this.dgvAnalysis.TabIndex = 3;
            // 
            // lblAvgProtein
            // 
            this.lblAvgProtein.AutoSize = true;
            this.lblAvgProtein.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgProtein.Location = new System.Drawing.Point(307, 363);
            this.lblAvgProtein.Name = "lblAvgProtein";
            this.lblAvgProtein.Size = new System.Drawing.Size(80, 25);
            this.lblAvgProtein.TabIndex = 4;
            this.lblAvgProtein.Text = "Protein";
            // 
            // lblAvgFat
            // 
            this.lblAvgFat.AutoSize = true;
            this.lblAvgFat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgFat.Location = new System.Drawing.Point(307, 413);
            this.lblAvgFat.Name = "lblAvgFat";
            this.lblAvgFat.Size = new System.Drawing.Size(43, 25);
            this.lblAvgFat.TabIndex = 5;
            this.lblAvgFat.Text = "Fat";
            // 
            // lblAvgCarbs
            // 
            this.lblAvgCarbs.AutoSize = true;
            this.lblAvgCarbs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgCarbs.Location = new System.Drawing.Point(307, 388);
            this.lblAvgCarbs.Name = "lblAvgCarbs";
            this.lblAvgCarbs.Size = new System.Drawing.Size(154, 25);
            this.lblAvgCarbs.TabIndex = 6;
            this.lblAvgCarbs.Text = "Carbohydrates";
            // 
            // lblAvgFiber
            // 
            this.lblAvgFiber.AutoSize = true;
            this.lblAvgFiber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgFiber.Location = new System.Drawing.Point(307, 438);
            this.lblAvgFiber.Name = "lblAvgFiber";
            this.lblAvgFiber.Size = new System.Drawing.Size(61, 25);
            this.lblAvgFiber.TabIndex = 7;
            this.lblAvgFiber.Text = "Fiber";
            // 
            // KtraDDThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblAvgFiber);
            this.Controls.Add(this.lblAvgCarbs);
            this.Controls.Add(this.lblAvgFat);
            this.Controls.Add(this.lblAvgProtein);
            this.Controls.Add(this.dgvAnalysis);
            this.Controls.Add(this.txtComparison);
            this.Controls.Add(this.lblAvgCalories);
            this.Controls.Add(this.chartNutrition);
            this.Name = "KtraDDThucDon";
            this.Size = new System.Drawing.Size(1882, 852);
            this.Load += new System.EventHandler(this.KtraDDThucDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartNutrition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartNutrition;
        private System.Windows.Forms.Label lblAvgCalories;
        private Guna.UI2.WinForms.Guna2TextBox txtComparison;
        private System.Windows.Forms.DataGridView dgvAnalysis;
        private System.Windows.Forms.Label lblAvgProtein;
        private System.Windows.Forms.Label lblAvgFat;
        private System.Windows.Forms.Label lblAvgCarbs;
        private System.Windows.Forms.Label lblAvgFiber;
    }
}
