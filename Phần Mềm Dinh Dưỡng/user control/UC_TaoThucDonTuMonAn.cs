using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Phần_Mềm_Dinh_Dưỡng.Form_Quản_Lý_Chung;

namespace Phần_Mềm_Dinh_Dưỡng.user_control
{
   
    public partial class UC_TaoThucDonTuMonAn: UserControl
    {
        // 🔹 Định nghĩa chuỗi kết nối trước
        string connectionString = "Data Source=.;Initial Catalog=Thực đơn dinh dưỡng;Integrated Security=True";

        public UC_TaoThucDonTuMonAn()
        {
            InitializeComponent();
        }
        private void dgvThucDonMonAn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void UC_TaoThucDonTuMonAn_Load(object sender, EventArgs e)
        {
            // Kiểm tra tên cột trong DataGridView
            foreach (DataGridViewColumn column in dgvThucDonMonAn.Columns)
            {
                Console.WriteLine(column.Name);
            }

            // Thêm lựa chọn nhóm trẻ
            cboNhomTre.Items.Add("Nhóm mẫu giáo");
            cboNhomTre.Items.Add("Nhóm nhà trẻ");
            cboNhomTre.SelectedIndexChanged += CboNhomTre_SelectedIndexChanged;
            // Đặt giá trị mặc định trước khi gọi sự kiện
            if (cboNhomTre.Items.Count > 0)
                cboNhomTre.SelectedIndex = 0;
            // Gọi hàm cập nhật DataGridView khi mở form
            CboNhomTre_SelectedIndexChanged(null, null);
            cboNhomTre.SelectedIndex = 0;
        }
     
        private void CboNhomTre_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvThucDonMonAn.Columns.Clear(); // Xóa cột cũ
            dgvThucDonMonAn.Rows.Clear(); // Xóa dòng cũ

            // Cột "Thứ"
            dgvThucDonMonAn.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Thu",
                HeaderText = "Thứ",
                ReadOnly = true
            });

            if (cboNhomTre.SelectedItem.ToString() == "Nhóm mẫu giáo")
            {
                // Bữa sáng
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Sang_MonChinh", "Bữa sáng - Món chính", "Món chính"));
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Sang_TrangMieng", "Bữa sáng - Tráng miệng", "Tráng miệng"));

                // Bữa trưa
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Trua_MonMan", "Bữa trưa - Món mặn", "Món mặn"));
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Trua_MonCanh", "Bữa trưa - Món canh", "Món canh"));
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Trua_MonRauCu", "Bữa trưa - Món rau củ", "Món rau củ"));
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Trua_TrangMieng", "Bữa trưa - Tráng miệng", "Tráng miệng"));

                // Bữa chiều
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Chieu_MonChinh", "Bữa chiều - Món chính", "Món chính"));
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Chieu_TrangMieng", "Bữa chiều - Tráng miệng", "Tráng miệng"));
            }
            else
            {
                // Nhóm nhà trẻ
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Sang_Chao", "Bữa sáng - Cháo", "Cháo"));

                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Trua_Chao", "Bữa trưa - Cháo", "Cháo"));
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Trua_TrangMieng_NhaTre", "Bữa trưa - Tráng miệng", "Tráng miệng"));

                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Chieu_Chao", "Bữa chiều - Cháo", "Cháo"));
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Chieu_TrangMieng_NhaTre", "Bữa chiều - Sữa chua", "Sữa chua"));
            }

            // 🔹 Thêm dòng dữ liệu (thứ 2 -> thứ 6)
            string[] thuList = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6" };
            foreach (string thu in thuList)
            {
                dgvThucDonMonAn.Rows.Add(thu);
            }
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn(string name, string header, string loaiMon)
        {
            var column = new DataGridViewComboBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataSource = GetMonAnByLoai(loaiMon),
                DisplayMember = "TenMon",
                ValueMember = "MaMon"
            };
            return column;
        }
        private DataTable GetMonAnByLoai(string loaiMon)
        {
            DataTable dt = new DataTable();
            string query = "SELECT MaMon, TenMon FROM MonAn WHERE LoaiMon = @LoaiMon";

            // 🔹 Định nghĩa chuỗi kết nối trước
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@LoaiMon", loaiMon);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                conn.Open();
               
                foreach (DataGridViewRow row in dgvThucDonMonAn.Rows)
                {
                    if (row.IsNewRow) continue;

                    string query = @"
                INSERT INTO ThucDon (NhomTre, Thu, 
                                     Sang_MonChinh, Sang_TrangMieng, 
                                     Trua_MonMan, Trua_MonCanh, Trua_MonRauCu, Trua_TrangMieng, 
                                     Chieu_MonChinh, Chieu_TrangMieng, 
                                     Sang_Chao, Trua_Chao, Trua_TrangMieng_NhaTre, Chieu_Chao, Chieu_TrangMieng_NhaTre)
                VALUES (@NhomTre, @Thu, 
                        @Sang_MonChinh, @Sang_TrangMieng, 
                        @Trua_MonMan, @Trua_MonCanh, @Trua_MonRauCu, @Trua_TrangMieng, 
                        @Chieu_MonChinh, @Chieu_TrangMieng, 
                        @Sang_Chao, @Trua_Chao, @Trua_TrangMieng_NhaTre, @Chieu_Chao, @Chieu_TrangMieng_NhaTre)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NhomTre", cboNhomTre.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Thu", row.Cells["Thu"].Value ?? DBNull.Value);

                        // Mẫu giáo
                        cmd.Parameters.AddWithValue("@Sang_MonChinh", row.Cells["Sang_MonChinh"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Sang_TrangMieng", row.Cells["Sang_TrangMieng"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Trua_MonMan", row.Cells["Trua_MonMan"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Trua_MonCanh", row.Cells["Trua_MonCanh"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Trua_MonRauCu", row.Cells["Trua_MonRauCu"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Trua_TrangMieng", row.Cells["Trua_TrangMieng"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Chieu_MonChinh", row.Cells["Chieu_MonChinh"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Chieu_TrangMieng", row.Cells["Chieu_TrangMieng"].Value ?? DBNull.Value);

                        // Nhà trẻ
                        cmd.Parameters.AddWithValue("@Sang_Chao", row.Cells["Sang_Chao"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Trua_Chao", row.Cells["Trua_Chao"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Trua_TrangMieng_NhaTre", row.Cells["Trua_TrangMieng_NhaTre"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Chieu_Chao", row.Cells["Chieu_Chao"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Chieu_TrangMieng_NhaTre", row.Cells["Chieu_TrangMieng_NhaTre"].Value ?? DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private void btnMonAn_Click(object sender, EventArgs e)
        {
            FormDsMonAn dsMonAn= new FormDsMonAn();
            dsMonAn.Show();
        }
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


        private void btnPhanTichDinhDuong_Click(object sender, EventArgs e)
        {
            if (dgvThucDonMonAn.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng tạo thực đơn trước khi phân tích");
                return;
            }

            // Tạo DataTable để lưu kết quả phân tích
            DataTable dtAnalysis = new DataTable();
            dtAnalysis.Columns.Add("Ngày");
            dtAnalysis.Columns.Add("Calories", typeof(double));
            dtAnalysis.Columns.Add("Protein (g)", typeof(double));
            dtAnalysis.Columns.Add("Carbs (g)", typeof(double));
            dtAnalysis.Columns.Add("Fat (g)", typeof(double));
            dtAnalysis.Columns.Add("Fiber (g)", typeof(double));

            // Phân tích từng ngày trong thực đơn
            foreach (DataGridViewRow row in dgvThucDonMonAn.Rows)
            {
                if (row.IsNewRow) continue;

                double dayCalories = 0;
                double dayProtein = 0;
                double dayCarbs = 0;
                double dayFat = 0;
                double dayFiber = 0;

                string thu = row.Cells["Thu"].Value.ToString();

                // Phân tích từng bữa ăn
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell is DataGridViewComboBoxCell comboBoxCell && comboBoxCell.Value != null)
                    {
                        string maMon = comboBoxCell.Value.ToString();
                        var nutrition = GetDinhDuong(maMon);

                        dayCalories += nutrition.Calories;
                        dayProtein += nutrition.Protein;
                        dayCarbs += nutrition.Carbs;
                        dayFat += nutrition.Fat;
                        dayFiber += nutrition.Fiber;
                    }
                }

                dtAnalysis.Rows.Add(thu, dayCalories, dayProtein, dayCarbs, dayFat, dayFiber);
            }

            // Lấy tiêu chuẩn dinh dưỡng
            var standard = GetStandardNutrition(cboNhomTre.SelectedItem.ToString());

            // Tạo bảng so sánh với định dạng mới
            DataTable dtComparison = CreateComparisonTable(dtAnalysis, standard);

            // Hiển thị kết quả
            FormKtraDinhDuong resultForm = new FormKtraDinhDuong(dtAnalysis, dtComparison);
            resultForm.Show();
        }


        private DinhDuong GetDinhDuong(string maMon)
        {
            DinhDuong info = new DinhDuong();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Calories, Protein, Carbohydrates, Fat, Fiber FROM MonAn WHERE MaMon = @MaMon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaMon", maMon);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    info.Calories = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader["Calories"]);
                    info.Protein = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader["Protein"]);
                    info.Carbs = reader.IsDBNull(2) ? 0 : Convert.ToDouble(reader["Carbohydrates"]);
                    info.Fat = reader.IsDBNull(3) ? 0 : Convert.ToDouble(reader["Fat"]);
                    info.Fiber = reader.IsDBNull(4) ? 0 : Convert.ToDouble(reader["Fiber"]);
                }
            }

            return info;
        }
        private DataTable CreateComparisonTable(DataTable analysisData, NutritionInfo standard)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ngày");
            dt.Columns.Add("Calories", typeof(string));
            dt.Columns.Add("Protein", typeof(string));
            dt.Columns.Add("Carbs", typeof(string));
            dt.Columns.Add("Fat", typeof(string));
            dt.Columns.Add("Fiber", typeof(string));
            dt.Columns.Add("Đánh giá", typeof(string));

            foreach (DataRow row in analysisData.Rows)
            {
                double dayCalories = Convert.ToDouble(row["Calories"]);
                double dayProtein = Convert.ToDouble(row["Protein (g)"]);
                double dayCarbs = Convert.ToDouble(row["Carbs (g)"]);
                double dayFat = Convert.ToDouble(row["Fat (g)"]);
                double dayFiber = Convert.ToDouble(row["Fiber (g)"]);

                // Tính phần trăm so với tiêu chuẩn
                string caloriesText = $"{dayCalories:F0} kcal ({(dayCalories / standard.Calories * 100):F0}%)";
                string proteinText = $"{dayProtein:F0}g ({(dayProtein / standard.Protein * 100):F0}%)";
                string carbsText = $"{dayCarbs:F0}g ({(dayCarbs / standard.Carbs * 100):F0}%)";
                string fatText = $"{dayFat:F0}g ({(dayFat / standard.Fat * 100):F0}%)";
                string fiberText = $"{dayFiber:F0}g ({(dayFiber / standard.Fiber * 100):F0}%)";

                // Đánh giá tổng thể
                string danhGia = "Đạt";
                if (dayCalories < standard.Calories * 0.9 ||
                    dayProtein < standard.Protein * 0.9 ||
                    dayFiber < standard.Fiber * 0.9)
                {
                    danhGia = "Thiếu";
                }

                dt.Rows.Add(
                    row["Ngày"],
                    caloriesText,
                    proteinText,
                    carbsText,
                    fatText,
                    fiberText,
                    danhGia
                );
            }

            return dt;
        }
    }
}
