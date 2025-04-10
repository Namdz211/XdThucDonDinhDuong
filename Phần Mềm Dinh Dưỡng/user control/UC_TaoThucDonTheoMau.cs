using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Phần_Mềm_Dinh_Dưỡng.All_User_Control
{
    public partial class UC_TaoThucDonTheoMau : UserControl
    {
        public UC_TaoThucDonTheoMau()
        {
            InitializeComponent();
        }

        private void UC_TaoThucDonTheoMau_Load(object sender, EventArgs e)
        {
            LoadNhomTre();
        }

        // Load nhóm trẻ vào ComboBox
        void LoadNhomTre()
        {
            string query = "SELECT DISTINCT NhomTre FROM ThucDon";
            DataTable dt = GetData(query);
            cbNhomTre.DataSource = dt;
            cbNhomTre.DisplayMember = "NhomTre";
            cbNhomTre.ValueMember = "NhomTre";
        }

        // Load tên thực đơn theo nhóm trẻ
        void LoadTenThucDon(string nhomTre)
        {
            string query = "SELECT DISTINCT TenThucDon FROM ThucDon WHERE NhomTre = @NhomTre";
            DataTable dt = GetData(query, new SqlParameter("@NhomTre", nhomTre));
            cbTenThucDon.DataSource = dt;
            cbTenThucDon.DisplayMember = "TenThucDon";
            cbTenThucDon.ValueMember = "TenThucDon";
        }
        private void HideColumnsIfExist(params string[] columnNames)
        {
            foreach (string colName in columnNames)
            {
                if (dgvThucDon.Columns.Contains(colName))
                {
                    dgvThucDon.Columns[colName].Visible = false;
                }
            }
        }

        // Load thực đơn theo nhóm trẻ và tên thực đơn
        void LoadThucDon(string nhomTre, string tenThucDon)
        {
            string query = @"
                SELECT Thu, 
                    Sang_MonChinh, Sang_TrangMieng, 
                    Trua_MonMan, Trua_MonCanh, Trua_MonRauCu, Trua_TrangMieng, 
                    Chieu_MonChinh, Chieu_TrangMieng,
                    Sang_Chao, Trua_Chao, Trua_TrangMieng_NhaTre, Chieu_Chao, Chieu_TrangMieng_NhaTre
                FROM ThucDon
                WHERE NhomTre = @NhomTre AND TenThucDon = @TenThucDon";

            DataTable dt = GetData(query,
                new SqlParameter("@NhomTre", nhomTre),
                new SqlParameter("@TenThucDon", tenThucDon)
            );

            dgvThucDon.DataSource = dt;

            // Đặt tiêu đề cột dễ hiểu hơn
            dgvThucDon.Columns["Thu"].HeaderText = "Thứ";
            dgvThucDon.Columns["Sang_MonChinh"].HeaderText = "Sáng - Món chính";
            dgvThucDon.Columns["Sang_TrangMieng"].HeaderText = "Sáng - Tráng miệng";
            dgvThucDon.Columns["Trua_MonMan"].HeaderText = "Trưa - Món mặn";
            dgvThucDon.Columns["Trua_MonCanh"].HeaderText = "Trưa - Món canh";
            dgvThucDon.Columns["Trua_MonRauCu"].HeaderText = "Trưa - Rau củ";
            dgvThucDon.Columns["Trua_TrangMieng"].HeaderText = "Trưa - Tráng miệng";
            dgvThucDon.Columns["Chieu_MonChinh"].HeaderText = "Chiều - Món chính";
            dgvThucDon.Columns["Chieu_TrangMieng"].HeaderText = "Chiều - Tráng miệng";
            dgvThucDon.Columns["Sang_Chao"].HeaderText = "Sáng - Cháo (Nhà trẻ)";
            dgvThucDon.Columns["Trua_Chao"].HeaderText = "Trưa - Cháo (Nhà trẻ)";
            dgvThucDon.Columns["Trua_TrangMieng_NhaTre"].HeaderText = "Trưa - Tráng miệng (Nhà trẻ)";
            dgvThucDon.Columns["Chieu_Chao"].HeaderText = "Chiều - Cháo (Nhà trẻ)";
            dgvThucDon.Columns["Chieu_TrangMieng_NhaTre"].HeaderText = "Chiều - Tráng miệng (Nhà trẻ)";
            if (nhomTre == "Nhóm mẫu giáo")
            {
                // Ẩn các cột dành cho nhóm Nhà trẻ
                HideColumnsIfExist(
                    "Sang_Chao",
                    "Trua_Chao",
                    "Trua_TrangMieng_NhaTre",
                    "Chieu_Chao",
                    "Chieu_TrangMieng_NhaTre"
                );
            }
            else if (nhomTre == "Nhóm nhà trẻ")
            {
                // Ẩn các cột dành cho nhóm Mẫu giáo
                HideColumnsIfExist(
                    "Sang_MonChinh",
                    "Sang_TrangMieng",
                    "Trua_MonMan",
                    "Trua_MonCanh",
                    "Trua_MonRauCu",
                    "Trua_TrangMieng",
                    "Chieu_MonChinh",
                    "Chieu_TrangMieng"
                );
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ThucDon WHERE NhomTre = @NhomTre";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NhomTre", cboNhomTre.SelectedItem.ToString());

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                dgvThucDonMonAn.Rows.Clear();
                while (reader.Read())
                {
                    int rowIndex = dgvThucDonMonAn.Rows.Add();
                    DataGridViewRow row = dgvThucDonMonAn.Rows[rowIndex];

                    row.Cells["Thu"].Value = reader["Thu"].ToString();

                    // Gán MaMon cho các ô ComboBox để nó hiển thị TenMon
                    foreach (DataGridViewColumn col in dgvThucDonMonAn.Columns)
                    {
                        if (col is DataGridViewComboBoxColumn && reader[col.Name] != DBNull.Value)
                        {
                            row.Cells[col.Name].Value = reader[col.Name].ToString();
                        }
                    }
                }
            }
       


        // Hàm lấy dữ liệu từ SQL Server
        private DataTable GetData(string query, params SqlParameter[] parameters)
        {
            string connectionString = "Data Source=.;Initial Catalog=Thực đơn dinh dưỡng;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Sự kiện khi chọn nhóm trẻ
        private void cbNhomTre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhomTre.SelectedValue != null)
            {
                string nhomTre = cbNhomTre.SelectedValue.ToString();
                LoadTenThucDon(nhomTre);
            }
        }

        // Sự kiện khi chọn tên thực đơn
        private void cbTenThucDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhomTre.SelectedValue != null && cbTenThucDon.SelectedValue != null)
            {
                string nhomTre = cbNhomTre.SelectedValue.ToString();
                string tenThucDon = cbTenThucDon.SelectedValue.ToString();
                LoadThucDon(nhomTre, tenThucDon);

                
            }
        }

    }
}
