using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phần_Mềm_Dinh_Dưỡng.Form_Quản_Lý_Chung
{
    public partial class FormKtraDinhDuong : Form
    {
        private NutritionInfo GetStandardNutrition(string nhomTre)
        {
            return new NutritionInfo
            {
                Calories = nhomTre == "Nhóm mẫu giáo" ? 1200 : 900,
                Protein = nhomTre == "Nhóm mẫu giáo" ? 30 : 25,
                Carbs = nhomTre == "Nhóm mẫu giáo" ? 150 : 120,
                Fat = nhomTre == "Nhóm mẫu giáo" ? 40 : 30,
                Fiber = nhomTre == "Nhóm mẫu giáo" ? 15 : 10
            };
        }
        public FormKtraDinhDuong(DataTable analysisData, DataTable comparisonData)
        {
            InitializeComponent();

            // Hiển thị dữ liệu phân tích
            dgvAnalysis.DataSource = analysisData;

            // Hiển thị dữ liệu so sánh
            dgvAnalysis.DataSource = comparisonData;

            // Tính toán và hiển thị tổng quan
            DisplaySummary(analysisData, comparisonData);
        }
           private void DisplaySummary(DataTable analysisData)
        {
            // 1. Tính trung bình các chỉ số
            double avgCalories = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Calories"]));
            double avgProtein = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Protein (g)"]));
            double avgCarbs = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Carbs (g)"]));
            double avgFat = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Fat (g)"]));
            double avgFiber = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Fiber (g)"]));

            // 2. Lấy tiêu chuẩn dinh dưỡng
            var standard = GetStandardNutrition(cboNhomTre.SelectedItem.ToString());

            // 3. Hiển thị kết quả
            lblAvgCalories.Text = $"Calories trung bình: {avgCalories:F2} kcal";
            lblAvgProtein.Text = $"Protein trung bình: {avgProtein:F2} g";
            lblAvgCarbs.Text = $"Carbs trung bình: {avgCarbs:F2} g";
            lblAvgFat.Text = $"Fat trung bình: {avgFat:F2} g";
            lblAvgFiber.Text = $"Fiber trung bình: {avgFiber:F2} g";
            // Thêm đánh giá động
            string assessment = GenerateNutritionAssessment(analysisData, cboNhomTre.SelectedItem.ToString());

            // Hiển thị lên TextBox/Label
            txtComparison.Text = assessment; // Hoặc lblAssessment.Text

            // Hoặc hiển thị trong MessageBox
            MessageBox.Show(assessment, "Kết Quả Đánh Giá", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private void FormKtraDinhDuong_Load(object sender, EventArgs e)
        {
          
        }

        private void chartNutrition_Click(object sender, EventArgs e)
        {
                
        }
        private void SetupNutritionChart()
        {
            // 1. Thiết lập biểu đồ
            chartNutrition.Series.Clear();
            Series series = new Series("Dinh dưỡng");
            series.ChartType = SeriesChartType.Column;

            // Thêm dữ liệu (ví dụ)
            series.Points.AddXY("Calories", 100);
            series.Points.AddXY("Protein", 80);
            series.Points.AddXY("Carbs", 60);
            series.Points.AddXY("Fat", 40);
            series.Points.AddXY("Fiber", 20);

            chartNutrition.Series.Add(series);

            // 2. Thiết lập các thành phần hiển thị
            chartNutrition.Titles.Add("PHÂN TÍCH DINH DƯỠNG");
            chartNutrition.ChartAreas[0].AxisX.Title = "Chỉ số";
            chartNutrition.ChartAreas[0].AxisY.Title = "Giá trị";

            // 3. Thêm bảng số liệu
            DataTable dt = new DataTable();
            dt.Columns.Add("Chỉ số");
            dt.Columns.Add("Giá trị");
            dt.Columns.Add("Đơn vị");

            dt.Rows.Add("Calories", 100, "kcal");
            dt.Rows.Add("Protein", 80, "g");
            dt.Rows.Add("Carbs", 60, "g");
            dt.Rows.Add("Fat", 40, "g");
            dt.Rows.Add("Fiber", 20, "g");
            dgvAnalysis.DataSource = dt;
        }

        private void dgvAnalysis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private string GenerateNutritionAssessment(DataTable analysisData, string nhomTre)
        {
            // Lấy tiêu chuẩn dinh dưỡng
            var standard = GetStandardNutrition(nhomTre);

            // Tính tổng các chỉ số
            double totalCalories = analysisData.AsEnumerable().Sum(r => Convert.ToDouble(r["Calories"]));
            double totalProtein = analysisData.AsEnumerable().Sum(r => Convert.ToDouble(r["Protein (g)"]));
            double totalCarbs = analysisData.AsEnumerable().Sum(r => Convert.ToDouble(r["Carbs (g)"]));
            double totalFat = analysisData.AsEnumerable().Sum(r => Convert.ToDouble(r["Fat (g)"]));
            double totalFiber = analysisData.AsEnumerable().Sum(r => Convert.ToDouble(r["Fiber (g)"]));

            // Tính phần trăm đạt được
            double percentCalories = (totalCalories / standard.Calories) * 100;
            double percentProtein = (totalProtein / standard.Protein) * 100;
            double percentCarbs = (totalCarbs / standard.Carbs) * 100;
            double percentFat = (totalFat / standard.Fat) * 100;
            double percentFiber = (totalFiber / standard.Fiber) * 100;

            // Đánh giá từng chỉ số
            StringBuilder assessment = new StringBuilder();

            assessment.AppendLine("ĐÁNH GIÁ DINH DƯỠNG");
            assessment.AppendLine("-------------------");
            assessment.AppendLine($"Calories: {EvaluatePercentage(percentCalories)}");
            assessment.AppendLine($"Protein: {EvaluatePercentage(percentProtein)}");
            assessment.AppendLine($"Carbs: {EvaluatePercentage(percentCarbs)}");
            assessment.AppendLine($"Fat: {EvaluatePercentage(percentFat)}");
            assessment.AppendLine($"Fiber: {EvaluatePercentage(percentFiber)}");

            // Đánh giá tổng thể
            double overallScore = (percentCalories + percentProtein + percentCarbs + percentFat + percentFiber) / 5;
            assessment.AppendLine("\nTỔNG QUAN: " + GetOverallRating(overallScore));

            return assessment.ToString();
        }

        private string EvaluatePercentage(double percent)
        {
            if (percent >= 95) return $"{percent:F2}% (Đạt)";
            if (percent >= 80) return $"{percent:F2}% (Hơi thiếu)";
            return $"{percent:F2}% (Thiếu nhiều)";
        }

        private string GetOverallRating(double score)
        {
            if (score >= 90) return "THỰC ĐƠN CÂN ĐỐI";
            if (score >= 70) return "CẦN BỔ SUNG MỘT SỐ CHẤT";
            return "THIẾU DINH DƯỠNG NGHIÊM TRỌNG";
        }

        private void txtComparison_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}

