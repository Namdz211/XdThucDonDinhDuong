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
                dgvThucDonMonAn.Columns.Add(CreateComboBoxColumn("Chieu_SuaChua", "Bữa chiều - Sữa chua", "Sữa chua"));
            }

            // 🔹 Thêm dòng dữ liệu (thứ 2 -> thứ 7)
            string[] thuList = { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7" };
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
                                     Sang_Chao, Trua_Chao, Trua_TrangMieng_NhaTre, Chieu_Chao, Chieu_SuaChua)
                VALUES (@NhomTre, @Thu, 
                        @Sang_MonChinh, @Sang_TrangMieng, 
                        @Trua_MonMan, @Trua_MonCanh, @Trua_MonRauCu, @Trua_TrangMieng, 
                        @Chieu_MonChinh, @Chieu_TrangMieng, 
                        @Sang_Chao, @Trua_Chao, @Trua_TrangMieng_NhaTre, @Chieu_Chao, @Chieu_SuaChua)";

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
                        cmd.Parameters.AddWithValue("@Chieu_SuaChua", row.Cells["Chieu_SuaChua"].Value ?? DBNull.Value);

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
    }
}
