using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phần_Mềm_Dinh_Dưỡng
{
    public partial class Dashboard: Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Dashboard_Load(object sender, EventArgs e)
                {
                   
                    uC_TaoThucDonTheoMau1.Visible = false;
                    uC_TaoThucDonTuMonAn1.Visible = false;
                    btnHDSD.PerformClick();
                }
     
        
        private void btnAddFromNganHangThucDon_Click(object sender, EventArgs e)
        {
            uC_TaoThucDonTheoMau1.Visible = true;
            uC_TaoThucDonTheoMau1.BringToFront();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddFromMonAn_Click(object sender, EventArgs e)
        {
            uC_TaoThucDonTuMonAn1.Visible = true;
            uC_TaoThucDonTuMonAn1.BringToFront();
        }

        private void btnKtraDD_Click(object sender, EventArgs e)
        {
       
            
        }
    
    }
}
