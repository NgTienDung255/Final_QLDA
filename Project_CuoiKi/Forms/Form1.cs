using Project_CuoiKi.All_User_Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CuoiKi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeUserControls();
        }
        private void InitializeUserControls()
        {

        }

            private void Form1_Load(object sender, EventArgs e)
        {
            Class.functions.ketnoi();
            uC_Phong2.Visible = false;
            btnPhong.PerformClick();
            uC_Nhanvien1.Visible = false;
            uC_ThemThietBi2.Visible = false;
            uC_HOADON1.Visible = false;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBaotri_Click(object sender, EventArgs e)
        {
            PanelMoving.Top = btnBaotri.Top + 436;
            uC_Baotri2.Visible = true;
            uC_Baotri2.BringToFront();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            PanelMoving.Top = btnPhong.Top + 30;
            uC_Phong2.Visible = true;
            uC_Phong2.BringToFront();
        }

        private void btnNhanvien_Click(object sender, EventArgs e)
        {
            PanelMoving.Top = btnNhanvien.Top + 298;
            uC_Nhanvien2.Visible = true;
            uC_Nhanvien2.BringToFront();

        }

        private void btnThietbi_Click(object sender, EventArgs e)
        {
            PanelMoving.Top = btnThietbi.Top + 367;
            
            uC_ThemThietBi3.Visible = true;
            uC_ThemThietBi3.BringToFront();
        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            PanelMoving.Top = btnBaocao.Top + 161 ;
            uC_Baocao3.Visible = true;
            uC_Baocao3.BringToFront();
            uC_Baocao3.Load_DataGridView();
        }
        private void btnHoadon_Click(object sender, EventArgs e)
        {
            PanelMoving.Top = btnHoadon.Top + 230;
            uC_HOADON1.Visible = true;
            uC_HOADON1.BringToFront() ;
            
        }
        private void btnNCC_Click(object sender, EventArgs e)
        {
            PanelMoving.Top = btnBaocao.Top + 96;
            uC_NhaCungCap1 .Visible = true;
            uC_NhaCungCap1.BringToFront();

        }

        private void uC_Baotri1_Load(object sender, EventArgs e)
        {

        }

        private void uC_NhaCungCap1_Load(object sender, EventArgs e)
        {

        }

        private void uC_HOADON1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uC_Nhanvien2_Load(object sender, EventArgs e)
        {

        }
    }
}
