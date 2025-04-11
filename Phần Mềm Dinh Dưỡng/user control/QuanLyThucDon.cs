using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phần_Mềm_Dinh_Dưỡng.user_control
{
    public partial class QuanLyThucDon : UserControl
    {
        public QuanLyThucDon()
        {
            InitializeComponent();
        }

        using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Phần_Mềm_Dinh_Dưỡng.user_control
    {
        public partial class QuanLyThucDon : UserControl
        {
            public QuanLyThucDon()
            {
                InitializeComponent();
            }

            string connectionString = "Data Source=.;Initial Catalog=ThucDonDinhDuong;Integrated Security=True";

            private void UC_ThucDon_Load(object sender, EventArgs e)
            {
                cboNhomTre.Items.Add("Nhóm mẫu giáo");
                cboNhomTre.Items.Add("Nhóm nhà trẻ");
                cboNhomTre.SelectedIndexChanged += cboNhomTre_SelectedIndexChanged;
                cboNhomTre.SelectedIndex = 0;

                btnThem.Click += btnThem_Click;
                btnSua.Click += btnSua_Click;
                btnXoa.Click += btnXoa_Click;
            }

            private void cboNhomTre_SelectedIndexChanged(object sender, EventArgs e)
            {
                LoadThucDonTheoNhomTre();
            }

            private void LoadThucDonTheoNhomTre()
            {
                string nhomTre = cboNhomTre.SelectedItem.ToString();
                string query = @"
                SELECT TD.ID, TD.Ngay, TD.Thu, TD.NhomTre,";

                if (nhomTre == "Nhóm mẫu giáo")
                {
                    query += @"
                    MA1.TenMonAn AS [Sáng - Món chính],
                    MA2.TenMonAn AS [Sáng - Tráng miệng],
                    MA3.TenMonAn AS [Trưa - Món mặn],
                    MA4.TenMonAn AS [Trưa - Món canh],
                    MA5.TenMonAn AS [Trưa - Rau củ],
                    MA6.TenMonAn AS [Trưa - Tráng miệng],
                    MA7.TenMonAn AS [Chiều - Món chính],
                    MA8.TenMonAn AS [Chiều - Tráng miệng]";
                }
                else
                {
                    query += @"
                    MA9.TenMonAn AS [Sáng - Cháo],
                    MA10.TenMonAn AS [Trưa - Cháo],
                    MA11.TenMonAn AS [Trưa - Tráng miệng],
                    MA12.TenMonAn AS [Chiều - Cháo],
                    MA13.TenMonAn AS [Chiều - Sữa chua]";
                }

                query += @"
                FROM ThucDon TD
                LEFT JOIN MonAn MA1  ON TD.Sang_MonChinh = MA1.MaMonAn
                LEFT JOIN MonAn MA2  ON TD.Sang_TrangMieng = MA2.MaMonAn
                LEFT JOIN MonAn MA3  ON TD.Trua_MonMan = MA3.MaMonAn
                LEFT JOIN MonAn MA4  ON TD.Trua_MonCanh = MA4.MaMonAn
                LEFT JOIN MonAn MA5  ON TD.Trua_RauCu = MA5.MaMonAn
                LEFT JOIN MonAn MA6  ON TD.Trua_TrangMieng = MA6.MaMonAn
                LEFT JOIN MonAn MA7  ON TD.Chieu_MonChinh = MA7.MaMonAn
                LEFT JOIN MonAn MA8  ON TD.Chieu_TrangMieng = MA8.MaMonAn
                LEFT JOIN MonAn MA9  ON TD.Sang_Chao = MA9.MaMonAn
                LEFT JOIN MonAn MA10 ON TD.Trua_Chao = MA10.MaMonAn
                LEFT JOIN MonAn MA11 ON TD.Trua_TrangMieng_NhaTre = MA11.MaMonAn
                LEFT JOIN MonAn MA12 ON TD.Chieu_Chao = MA12.MaMonAn
                LEFT JOIN MonAn MA13 ON TD.Chieu_TrangMieng_NhaTre = MA13.MaMonAn
                WHERE TD.NhomTre = @NhomTre
                ORDER BY TD.Ngay";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NhomTre", nhomTre);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvThucDon.DataSource = dt;
                }
            }

            private void btnThem_Click(object sender, EventArgs e)
            {
                FormThemThucDon form = new FormThemThucDon();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadThucDonTheoNhomTre();
                }
            }

            private void btnSua_Click(object sender, EventArgs e)
            {
                if (dgvThucDon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng cần sửa.");
                    return;
                }

                int id = Convert.ToInt32(dgvThucDon.SelectedRows[0].Cells["ID"].Value);
                FormThemThucDon form = new FormThemThucDon(id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadThucDonTheoNhomTre();
                }
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                if (dgvThucDon.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa.");
                    return;
                }

                int id = Convert.ToInt32(dgvThucDon.SelectedRows[0].Cells["ID"].Value);
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM ThucDon WHERE ID = @ID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadThucDonTheoNhomTre();
                }
            }
        }
    }



}

}

