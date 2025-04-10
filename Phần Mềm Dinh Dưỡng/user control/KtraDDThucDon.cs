using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phần_Mềm_Dinh_Dưỡng.user_control
{
    public partial class KtraDDThucDon : UserControl
    {
        public KtraDDThucDon()
        {
            InitializeComponent();
        }

        private void KtraDDThucDon_Load(object sender, EventArgs e)
        {

        }
        private DataTable analysisData;

        public KtraDDThucDon(DataTable data)
        {
            InitializeComponent();
            analysisData = data;
            SetupChart();
            SetupDataGridView();
            CalculateAverages();
        }

        private void SetupDataGridView()
        {
            

            dgvAnalysis.DataSource = analysisData;
            dgvAnalysis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        
        }

        private void SetupChart()
        {
            chartNutrition.Series.Clear();

            // Thêm các series cho biểu đồ
            Series seriesCalories = new Series("Calories");
            seriesCalories.ChartType = SeriesChartType.Column;

            Series seriesProtein = new Series("Protein");
            seriesProtein.ChartType = SeriesChartType.Column;

            Series seriesCarbs = new Series("Carbs");
            seriesCarbs.ChartType = SeriesChartType.Column;

            Series seriesFat = new Series("Fat");
            seriesFat.ChartType = SeriesChartType.Column;
            Series seriesFiber = new Series("Fiber");
            seriesFiber.ChartType = SeriesChartType.Column;


            // Thêm dữ liệu vào các series
            foreach (DataRow row in analysisData.Rows)
            {
                string day = row["Ngày"].ToString();
                seriesCalories.Points.AddXY(day, row["Calories"]);
                seriesProtein.Points.AddXY(day, row["Protein (g)"]);
                seriesCarbs.Points.AddXY(day, row["Carbs (g)"]);
                seriesFat.Points.AddXY(day, row["Fat (g)"]);
                seriesFiber.Points.AddXY(day, row["Fiber (g)"]);
            }

            // Thêm series vào chart
            chartNutrition.Series.Add(seriesCalories);
            chartNutrition.Series.Add(seriesProtein);
            chartNutrition.Series.Add(seriesCarbs);
            chartNutrition.Series.Add(seriesFat);
            chartNutrition.Series.Add(seriesFiber);

            // Cấu hình chart
            chartNutrition.ChartAreas[0].AxisX.Title = "Ngày";
            chartNutrition.ChartAreas[0].AxisY.Title = "Giá trị dinh dưỡng";
            chartNutrition.Titles.Add("Phân tích dinh dưỡng theo ngày");
        }

        private void CalculateAverages()
        {
            double avgCalories = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Calories"]));
            double avgProtein = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Protein (g)"]));
            double avgCarbs = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Carbs (g)"]));
            double avgFat = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Fat (g)"]));
            double avgFiber = analysisData.AsEnumerable().Average(r => Convert.ToDouble(r["Fiber (g)"]));

            lblAvgCalories.Text = $"Calories trung bình: {avgCalories:F2} kcal";
            lblAvgProtein.Text = $"Protein trung bình: {avgProtein:F2} g";
            lblAvgCarbs.Text = $"Carbs trung bình: {avgCarbs:F2} g";
            lblAvgFat.Text = $"Fat trung bình: {avgFat:F2} g";
            lblAvgFiber.Text = $"Fiber trung bình: {avgFiber:F2} g";

            // So sánh với tiêu chuẩn
            CompareWithStandards(avgCalories, avgProtein, avgCarbs, avgFat, avgFiber);
        }

        private void CompareWithStandards(double calories, double protein, double carbs, double fat, double fiber)
        {
            // Giả sử nhu cầu dinh dưỡng cho trẻ mẫu giáo
            double standardCalories = 1200;
            double standardProtein = 30;
            double standardCarbs = 150;
            double standardFat = 40;
            double standardFiber = 15; 

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("So sánh với nhu cầu dinh dưỡng tiêu chuẩn:");

            sb.AppendLine(CompareValue("Calories", calories, standardCalories));
            sb.AppendLine(CompareValue("Protein", protein, standardProtein));
            sb.AppendLine(CompareValue("Carbs", carbs, standardCarbs));
            sb.AppendLine(CompareValue("Fat", fat, standardFat));
            sb.AppendLine(CompareValue("Fiber", fiber, standardFiber));

            txtComparison.Text = sb.ToString();
        }

        private string CompareValue(string name, double actual, double standard)
        {
            double diff = actual - standard;
            double percent = (diff / standard) * 100;

            if (Math.Abs(percent) < 10)
                return $"{name}: Đạt chuẩn ({actual:F2} vs {standard:F2})";
            else if (percent > 0)
                return $"{name}: Cao hơn {percent:F2}% ({actual:F2} vs {standard:F2})";
            else
                return $"{name}: Thấp hơn {Math.Abs(percent):F2}% ({actual:F2} vs {standard:F2})";
        }
    }
}
    
