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


        
           private void dgvDsMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDsMonAn.CurrentRow == null) return; // Thêm dòng này

            txtTenMonAn.Text = dgvDsMonAn[1, e.RowIndex].Value?.ToString();
            txtLoaiMonAn.Text = dgvDsMonAn[2, e.RowIndex].Value?.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

        
        
    }

