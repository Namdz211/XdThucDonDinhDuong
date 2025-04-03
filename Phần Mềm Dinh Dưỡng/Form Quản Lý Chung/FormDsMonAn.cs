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
        Thực_đơn_dinh_dưỡngEntities3 db = new Thực_đơn_dinh_dưỡngEntities3();


        public FormDsMonAn()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormDsMonAn_Load(object sender, EventArgs e)
        {
            Load_duLieu();

        }
        public void Load_duLieu()
        {
            dgvDsMonAn.DataSource = db.chon_MonAn();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtTenMonAn.Clear();
            txtTenMonAn.Clear();
            txtTenMonAn.Focus();
            opt = 1;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(opt == 1)//Them moi
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
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvDsMonAn[0, dgvDsMonAn.CurrentRow.Index].Value.ToString());
            db.xoa_MonAn(id);
            Load_duLieu();
            MessageBox.Show("Xóa dữ liệu thành công");



        }


        private void dgvDsMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTenMonAn.Text = dgvDsMonAn[1, dgvDsMonAn.CurrentRow.Index].Value.ToString();
            txtLoaiMonAn.Text = dgvDsMonAn[2, dgvDsMonAn.CurrentRow.Index].Value.ToString();
        }

        
        
    }
}
