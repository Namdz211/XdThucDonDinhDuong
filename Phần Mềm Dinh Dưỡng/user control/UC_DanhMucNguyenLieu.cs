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

namespace Phần_Mềm_Dinh_Dưỡng.user_control
{
    public partial class UC_DanhMucNguyenLieu : UserControl
    {
        public UC_DanhMucNguyenLieu()
        {
            InitializeComponent();
            LoadData();
        }
        private System.ComponentModel.IContainer components = null;
        private string connectionString = "Data Source=.;Initial Catalog=DanhMucNguyenLieu;Integrated Security=True;";


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM NguyenLieu";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);


                    guna2DataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối hoặc truy vấn: " + ex.ToString());
                }
            }
        }

        private void UC_DanhMucNguyenLieu_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        // THÊM DỮ LIỆU VÀO
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNl.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDonVi.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn vị!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNhomNL.Text))
            {
                MessageBox.Show("Vui lòng nhập nhóm nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTLTB.Text))
            {
                MessageBox.Show("Vui lòng nhập tỷ lệ thải bỏ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Chuyển đổi dữ liệu đầu vào
            string tenNl = txtTenNl.Text.Trim();
            string donVi = txtDonVi.Text.Trim();
            decimal donGia;
            decimal tyLeThaiBo;

            // Kiểm tra giá trị hợp lệ
            if (!decimal.TryParse(txtDonGia.Text, out donGia))
            {
                MessageBox.Show("Đơn giá phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtTLTB.Text, out tyLeThaiBo))
            {
                MessageBox.Show("Tỷ lệ thải bỏ phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nhomNl = txtNhomNL.Text.Trim();

            // Kết nối SQL để thêm dữ liệu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO NguyenLieu (TenNguyenLieu, DonVi, DonGia, NhomNguyenLieu, TyLeThaiBo) VALUES (@TenNL, @DonVi, @DonGia, @NhomNL, @TLTB)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenNL", tenNl);
                    cmd.Parameters.AddWithValue("@DonVi", donVi);
                    cmd.Parameters.AddWithValue("@DonGia", donGia);
                    cmd.Parameters.AddWithValue("@NhomNL", nhomNl);
                    cmd.Parameters.AddWithValue("@TLTB", tyLeThaiBo);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Cập nhật lại DataGridView sau khi thêm
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm nguyên liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }
        }

        // TÌM KIẾM DỰA VÀO NHÓM NGUYÊN LIỆU

        private void SearchByNhomNguyenLieu(string nhomNl)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM NguyenLieu WHERE NhomNguyenLieu LIKE @NhomNL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NhomNL", "%" + nhomNl + "%");  // Tìm kiếm nhóm nguyên liệu chứa từ khóa

                    try
                    {
                        conn.Open();
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);
                        guna2DataGridView1.DataSource = dt;  // Cập nhật DataGridView với dữ liệu tìm được
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btn_Tim(object sender, EventArgs e)
        {

            string nhomNl = txtNhomNL.Text.Trim();  // Lấy giá trị từ TextBox tìm kiếm

            // Nếu TextBox rỗng, load lại dữ liệu đầy đủ
            if (string.IsNullOrEmpty(nhomNl))
            {
                LoadData(); // Load lại dữ liệu đầy đủ
            }
            else
            {
                SearchByNhomNguyenLieu(nhomNl); // Tìm kiếm theo nhóm nguyên liệu
            }
        }


        // XÓA NGUYÊN LIỆU
        
        
private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenToXoa = txtTenNl.Text.Trim();  // Lấy giá trị từ TextBox tìm kiếm

            if (string.IsNullOrEmpty(tenToXoa))
            {
                MessageBox.Show("Vui lòng nhập tên nguyên liệu cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM NguyenLieu WHERE TenNguyenLieu = @TenNL";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenNL", tenToXoa);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {

                            MessageBox.Show("Xóa nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Sau khi xóa thành công từ cơ sở dữ liệu, xóa dữ liệu trong DataGridView
                            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                            { // ở cột row.Cells Dưới phải điền tên của datagridview  chứ  ko phải điền tên của cái bảng 
                                if (row.Cells["tenNguyenLieuDataGridViewTextBoxColumn"].Value != null && row.Cells["tenNguyenLieuDataGridViewTextBoxColumn"].Value.ToString().Equals(tenToXoa, StringComparison.OrdinalIgnoreCase))
                                {
                                    guna2DataGridView1.Rows.Remove(row);
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nguyên liệu cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
   
}
    


