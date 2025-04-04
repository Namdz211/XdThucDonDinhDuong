using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phần_Mềm_Dinh_Dưỡng.Form_Quản_Lý_Chung
{
    public partial class FormDsMonAn: Form
    {

        int opt = -1;
        MonAnEntities db = new MonAnEntities();


        public FormDsMonAn()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        public void Load_duLieu()
        {
            db = new MonAnEntities(); // Tạo context mới
            dgvDsMonAn.DataSource = db.chon_MonAn().ToList();
            dgvDsMonAn.Refresh();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtTenMonAn.Clear();
            txtLoaiMonAn.Clear();
            txtTenMonAn.Focus();
            opt = 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (opt == 1)//Them moi
                {
                    db.them_MonAn(txtTenMonAn.Text, txtLoaiMonAn.Text);
                    Load_duLieu();
                    MessageBox.Show("Thêm dữ liệu thành công");
                    opt = -1;
                }
                else//Lưu cập nhật hiện tại
                {
                    int id = Convert.ToInt32(dgvDsMonAn[0, dgvDsMonAn.CurrentRow.Index].Value);
                    db.sua_MonAn(id, txtTenMonAn.Text, txtLoaiMonAn.Text);
                    Load_duLieu();
                    MessageBox.Show("Cập nhật dữ liệu thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private void FormDsMonAn_Load(object sender, EventArgs e)
        {
            Load_duLieu();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDsMonAn.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa");
                return;
            }

            // ... code xóa
        
        int id = Convert.ToInt32(dgvDsMonAn[0, dgvDsMonAn.CurrentRow.Index].Value.ToString());
            db.xoa_MonAn(id);
            Load_duLieu();
            MessageBox.Show("Xóa dữ liệu thành công");



        }



      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvDsMonAn_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Bỏ qua khi click vào header hoặc dòng trống
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                // Lấy dòng được chọn
                DataGridViewRow row = dgvDsMonAn.Rows[e.RowIndex];

                // Debug: In ra console để kiểm tra
                Console.WriteLine($"Selected: ID={row.Cells["MaMon"].Value}, Tên={row.Cells["TenMon"].Value}");

                // Gán giá trị vào TextBox - SỬ DỤNG TÊN CỘT CHÍNH XÁC
                txtTenMonAn.Text = row.Cells["TenMon"].Value?.ToString() ?? "";
                txtLoaiMonAn.Text = row.Cells["LoaiMon"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message);
            }
        }
    }

        
        
    }

