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
            // Gán dữ liệu mẫu cho ComboBox (nếu chưa có)
            cboNhomTre.Items.Add("Nhóm mẫu giáo");
            cboNhomTre.Items.Add("Nhóm nhà trẻ");
            cboNhomTre.SelectedIndex = 0; // Gán mặc định để tránh null

            // Hiển thị dữ liệu phân tích
            dgvAnalysis.DataSource = analysisData;

            // Hiển thị dữ liệu so sánh
            dgvComparison.DataSource = comparisonData;

            // Gọi phương thức với 2 tham số
            DisplaySummary(analysisData, comparisonData);
            SetupNutritionChart(analysisData, cboNhomTre.SelectedItem.ToString());


        }
           private void DisplaySummary(DataTable analysisData, DataTable comparisonData)
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
        private void SetupNutritionChart(DataTable analysisData, string nhomTre)
        {
            chartNutrition.Series.Clear();
            chartNutrition.ChartAreas.Clear();
            chartNutrition.Titles.Clear();
            chartNutrition.Legends.Clear(); // ✅ Xóa các legend cũ

            // ✅ Thêm legend mặc định
            chartNutrition.Legends.Add(new Legend("Default"));

            // Tạo ChartArea
            ChartArea area = new ChartArea("MainArea");
            chartNutrition.ChartAreas.Add(area);

            // Lấy giá trị trung bình từ dữ liệu thực tế
            double avgCalories = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Calories"]));
            double avgProtein = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Protein (g)"]));
            double avgCarbs = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Carbs (g)"]));
            double avgFat = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Fat (g)"]));
            double avgFiber = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Fiber (g)"]));

            // Lấy tiêu chuẩn
            var standard = GetStandardNutrition(nhomTre);

            // Series 1: Trung bình
            Series avgSeries = new Series("Thực tế (Trung bình)");
            avgSeries.ChartType = SeriesChartType.Column;
            avgSeries.Points.AddXY("Calories", avgCalories);
            avgSeries.Points.AddXY("Protein", avgProtein);
            avgSeries.Points.AddXY("Carbs", avgCarbs);
            avgSeries.Points.AddXY("Fat", avgFat);
            avgSeries.Points.AddXY("Fiber", avgFiber);

            // Series 2: Tiêu chuẩn
            Series stdSeries = new Series("Tiêu chuẩn yêu cầu");
            stdSeries.ChartType = SeriesChartType.Column;
            stdSeries.Points.AddXY("Calories", standard.Calories);
            stdSeries.Points.AddXY("Protein", standard.Protein);
            stdSeries.Points.AddXY("Carbs", standard.Carbs);
            stdSeries.Points.AddXY("Fat", standard.Fat);
            stdSeries.Points.AddXY("Fiber", standard.Fiber);

            // Thêm series vào chart
            chartNutrition.Series.Add(avgSeries);
            chartNutrition.Series.Add(stdSeries);

            // Giao diện biểu đồ
            chartNutrition.Titles.Add("SO SÁNH DINH DƯỠNG THỰC TẾ VÀ TIÊU CHUẨN");
            chartNutrition.ChartAreas["MainArea"].AxisX.Title = "Chỉ số";
            chartNutrition.ChartAreas["MainArea"].AxisY.Title = "Giá trị";
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

