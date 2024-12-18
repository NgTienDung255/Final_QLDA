using Project_CuoiKi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Math;


namespace Project_CuoiKi.All_User_Control
{
    public partial class UC_Baocao : UserControl
    {
        public UC_Baocao()
        {
            InitializeComponent();
            functions.ketnoi();
        }
        DataTable dt, baocao;
        private string ngay1, ngay2, ngay3;
        private void UC_Baocao_Load(object sender, EventArgs e)
        {
            Load_DataGridView();
            ResetValues();
            functions.fillcombo("SELECT MaHDB FROM HoaDonBan", cboMahoadon, "MaHDB", "MaHDB");
            cboMahoadon.SelectedIndex = -1;
            functions.fillcombo("SELECT MaNV  FROM NhanVien", cboManhanvien, "MaNV", "MaNV");
            cboManhanvien.SelectedIndex = -1;
        }
        public void Load_DataGridView()
        {
            string sql;
            sql = "SELECT * FROM HoaDonBan  ";
            dt = functions.GetDataToTable(sql);
            datagridview.DataSource = dt;
            datagridview.Columns[0].HeaderText = "Mã Hoá đơn";
            datagridview.Columns[1].HeaderText = "Mã máy";
            datagridview.Columns[2].HeaderText = "Mã phòng";
            datagridview.Columns[3].HeaderText = "Ngày thuê";
            datagridview.Columns[4].HeaderText = "Giờ vào";
            datagridview.Columns[5].HeaderText = "Giờ ra";
            datagridview.Columns[6].HeaderText = "Mã nhân viên";
            datagridview.Columns[7].HeaderText = "Tổng tiền";
            datagridview.Columns[8].HeaderText = "Ghi chú";

            foreach (DataGridViewColumn col in datagridview.Columns)
            {
                col.Width = 100;
            }
            datagridview.AllowUserToAddRows = false;
            datagridview.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            rbtn1.Enabled = true;
            rbtn2.Enabled = true;
            date1.Enabled = false;
            date2.Enabled = false;
            date3.Enabled = false;
            functions.fillcombo("SELECT MaHDB FROM HoaDonBan", cboMahoadon, "MaHDB", "MaHDB");
            cboMahoadon.SelectedIndex = -1;
            functions.fillcombo("SELECT MaNV  FROM NhanVien", cboManhanvien, "MaNV", "MaNV");
            cboManhanvien.SelectedIndex = -1;
            date3.Value = DateTime.Now;
            rbtn1.Checked = false;
            rbtn2.Checked = false;

        }

        private void rbtn1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn1.Checked)
            {
                date1.Enabled = true;
                date2.Enabled = true;
                date3.Enabled = false;
            }
        }

        private void rbtn2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn2.Checked)
            {
                date1.Enabled = false;
                date2.Enabled = false;
                date3.Enabled = true;
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {

            if ((cboMahoadon.SelectedIndex == -1) && (cboManhanvien.SelectedIndex == -1) && (rbtn1.Checked == false) && (rbtn2.Checked == false))
            {
                MessageBox.Show("Bạn phải chọn 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from hoadonban where 1=1";
            if (rbtn2.Checked)
            {
                cboMahoadon.Enabled = false;
                DateTime selectedDate = date3.Value.Date;
                sql = sql + "and ngaythue = '" + selectedDate + "'";
                baocao = functions.GetDataToTable(sql);
                datagridview.DataSource = baocao;
                if (baocao.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboManhanvien.SelectedIndex != -1)
                {
                    string manv = cboManhanvien.SelectedValue.ToString();
                    sql = sql + "and manv = N'" + manv + "'";
                    baocao = functions.GetDataToTable(sql);
                    datagridview.DataSource = baocao;
                    if (baocao.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (rbtn1.Checked)
            {
                cboMahoadon.Enabled = false;
                DateTime selectedDate1 = date1.Value.Date;
                DateTime selectedDate2 = date2.Value.Date;
                sql = sql + "and ngaythue between '" + selectedDate1 + "' and '" + selectedDate2 + "'";
                baocao = functions.GetDataToTable(sql);
                datagridview.DataSource = baocao;
                if (baocao.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cboManhanvien.SelectedIndex != -1)
                {
                    cboMahoadon.Enabled = false;
                    string manv = cboManhanvien.SelectedValue.ToString();
                    sql = sql + "and manv = N'" + manv + "'";
                    baocao = functions.GetDataToTable(sql);
                    datagridview.DataSource = baocao;
                    if (baocao.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (cboMahoadon.SelectedIndex != -1)
            {
                rbtn1.Enabled = false;
                rbtn2.Enabled = false;
                cboManhanvien.Enabled = false;
                string mahd = cboMahoadon.SelectedValue.ToString();
                sql = sql + "and mahdb = N'" + mahd + "'";
                baocao = functions.GetDataToTable(sql);
                datagridview.DataSource = baocao;
                if (baocao.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cboManhanvien.SelectedIndex != -1)
            {
                cboMahoadon.Enabled = false;
                string manv = cboManhanvien.SelectedValue.ToString();
                sql = sql + "and manv = N'" + manv + "'";
                baocao = functions.GetDataToTable(sql);
                datagridview.DataSource = baocao;
                if (baocao.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            btnBoqua.Enabled = true;

        }

        private void btnDT_Click(object sender, EventArgs e)
        {
            if (rbtn1.Checked)
            {
                // Truy vấn tổng tiền trong khoảng thời gian từ date1 đến date2
                string sql = $"SELECT SUM(TongTien) as tt FROM HoaDonBan WHERE NgayThue BETWEEN '{date1.Value.ToString("yyyy-MM-dd")}' AND '{date2.Value.ToString("yyyy-MM-dd")}'";
                string result = functions.getfieldvalues(sql);

                // Kiểm tra nếu kết quả là null hoặc rỗng
                if (string.IsNullOrEmpty(result))
                {
                    result = "0";
                }

                // Hiển thị giá trị trong hộp thoại MessageBox
                MessageBox.Show("Doanh thu từ ngày " + date1.Value.ToString("dd/MM/yyyy") + " đến ngày " + date2.Value.ToString("dd/MM/yyyy") + " là: " + result, "Doanh thu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (rbtn2.Checked)
            {
                // Truy vấn tổng tiền vào ngày được chọn
                string sql = $"SELECT SUM(TongTien) as tt FROM HoaDonBan WHERE NgayThue = '{date3.Value.ToString("yyyy-MM-dd")}'";
                string result = functions.getfieldvalues(sql);

                // Kiểm tra nếu kết quả là null hoặc rỗng
                if (string.IsNullOrEmpty(result))
                {
                    result = "0";
                }

                // Hiển thị giá trị trong hộp thoại MessageBox
                MessageBox.Show("Doanh thu ngày " + date3.Value.ToString("dd/MM/yyyy") + " là: " + result, "Doanh thu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void datagridview_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cboMahoadon.SelectedValue = datagridview.CurrentRow.Cells["MaHDB"].Value.ToString();
            cboManhanvien.SelectedValue = datagridview.CurrentRow.Cells["MaNV"].Value.ToString();
            rbtn2.Checked = true;
            date3.Value = (DateTime)datagridview.CurrentRow.Cells["NgayThue"].Value;
            btnBoqua.Enabled = true;
            btnTimkiem.Enabled = false;

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnTimkiem.Enabled = true;
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            ngay1 = date1.Value.ToString();
        }

        private void btnHienthitatca_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
            cboMahoadon.SelectedIndex = -1;
            cboManhanvien.SelectedIndex = -1;
            rbtn1.Checked = false;
            rbtn2.Checked = false;
            cboMahoadon.Enabled = true;
            cboManhanvien.Enabled = true;
            rbtn1.Enabled = true;
            rbtn2.Enabled = true;
            btnTimkiem.Enabled = true;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string dulieu;

            if (rbtn1.Checked)
            {
                // Truy vấn dữ liệu theo khoảng thời gian từ date1 đến date2
                dulieu = $"SELECT MaHDB, NgayThue, GioVao, GioRa, TongTien FROM HoaDonBan WHERE NgayThue BETWEEN '{date1.Value.ToString("yyyy-MM-dd")}' AND '{date2.Value.ToString("yyyy-MM-dd")}'";


            }
            else if (rbtn2.Checked)
            {
                // Truy vấn dữ liệu theo ngày date3
                dulieu = $"SELECT MaHDB, NgayThue, GioVao, GioRa, TongTien FROM HoaDonBan WHERE NgayThue = '{date3.Value.ToString("yyyy-MM-dd")}'";


            }
            else
            {
                MessageBox.Show("Vui lòng chọn khoảng thời gian hoặc ngày cụ thể để xuất báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            baocao = functions.GetDataToTable(dulieu);

            if (baocao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Tạo đối tượng Excel Application
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook;
                Excel.Worksheet exSheet;
                Excel.Range exRange;

                // Thêm một Workbook mới
                exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                // Định dạng chung cho trang tính
                exRange = (Excel.Range)exSheet.Cells[1, 1];
                exRange.Range["A1:Z300"].Font.Name = "Times New Roman";
                exRange.Range["A1:B3"].Font.Size = 11;
                exRange.Range["A1:B3"].Font.Bold = true;
                exRange.Range["A1:B3"].Font.ColorIndex = 5;
                exRange.Range["A1:A1"].ColumnWidth = 10;
                exRange.Range["B1:B1"].ColumnWidth = 16;
                exRange.Range["A1:C1"].MergeCells = true;
                exRange.Range["A1:C1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["A1:C1"].Value = "Tiny Cyber";
                exRange.Range["A2:C2"].MergeCells = true;
                exRange.Range["A2:C2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["A2:C2"].Value = "Hà Nội";
                exRange.Range["A3:C3"].MergeCells = true;
                exRange.Range["A3:C3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["A3:C3"].Value = "Điện thoại: 0123456789";
                exRange.Range["D2:F2"].Font.Size = 16;
                exRange.Range["D2:F2"].Font.Bold = true;
                exRange.Range["D2:F2"].Font.ColorIndex = 3;
                exRange.Range["D2:F2"].MergeCells = true;
                exRange.Range["D2:F2"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["D2:F2"].Value = "BÁO CÁO DOANH THU";
                exRange.Range["D3:F3"].Font.Size = 14;
                exRange.Range["D3:F3"].Font.Bold = true;
                exRange.Range["D3:F3"].Font.ColorIndex = 3;
                exRange.Range["D3:F3"].MergeCells = true;
                exRange.Range["D3:F3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["D3:F3"].Value = rbtn1.Checked
                    ? $"Từ ngày {date1.Value.ToString("dd/MM/yyyy")} đến ngày {date2.Value.ToString("dd/MM/yyyy")}"
                    : $"Ngày {date3.Value.ToString("dd/MM/yyyy")}";

                // Định dạng tiêu đề cột
                exRange.Range["B5:F5"].Font.Bold = true;
                exRange.Range["B5:F5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["B5:B100"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["B5:B5"].ColumnWidth = 8;
                exRange.Range["C5:C5"].ColumnWidth = 16;
                exRange.Range["D5:D5"].ColumnWidth = 20;
                exRange.Range["E5:E5"].ColumnWidth = 18;
                exRange.Range["F5:F5"].ColumnWidth = 22;
                exRange.Range["H9:H9"].ColumnWidth = 22;
                exRange.Range["I9:I9"].ColumnWidth = 22;
                exRange.Range["J9:J9"].ColumnWidth = 22;
                exRange.Range["K9:K9"].ColumnWidth = 22;
                exRange.Range["E5:E5"].Font.Bold = true;
                exRange.Range["E5:E5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Tiêu đề cột
                exRange.Range["B5:B5"].Value = "STT";
                exRange.Range["C5:C5"].Value = "Mã Hoá Đơn Bán";
                exRange.Range["D5:D5"].Value = "Ngày Thuê";
                exRange.Range["E5:E5"].Value = "Giờ vào";
                exRange.Range["F5:F5"].Value = "Giờ ra";
                exRange.Range["G5:G5"].Value = "Tổng tiền";

                // Đổ dữ liệu vào Excel
                for (int hang = 0; hang < baocao.Rows.Count; hang++)
                {
                    exSheet.Cells[hang + 6, 2] = hang + 1; // Số thứ tự
                    for (int cot = 0; cot < baocao.Columns.Count; cot++)
                    {
                        exSheet.Cells[hang + 6, cot + 3] = baocao.Rows[hang][cot].ToString();
                    }
                }

                // Tính tổng của cột "Tổng tiền"
                double doanhthu = 0;
                foreach (DataRow row in baocao.Rows)
                {
                    if (double.TryParse(row["TongTien"].ToString(), out double value))
                    {
                        doanhthu += value;
                    }
                }
                int lastRow = baocao.Rows.Count + 6; // Xác định vị trí hàng cuối cùng
                exRange = (Excel.Range)exSheet.Cells[lastRow + 1, 5];
                exRange.Range["A1:A1"].Font.Bold = true;
                exRange.Range["A1:A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["A1:A1"].Value = "Doanh thu:";

                exRange = (Excel.Range)exSheet.Cells[lastRow + 1, 6];
                exRange.Range["A1:A1"].Font.Bold = true;
                exRange.Range["A1:A1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["A1:A1"].Value = doanhthu.ToString();

                // Chữ ký
                exRange = (Excel.Range)exSheet.Cells[baocao.Rows.Count + 8, 4];
                exRange.Range["A1:C1"].Font.Italic = true;
                exRange.Range["A1:C1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                exRange.Range["A1:C1"].MergeCells = true;
                exRange.Range["A1:C1"].Value = "Hà Nội, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                // Hiển thị Excel
                exSheet.Name = "Báo cáo doanh thu";
                exApp.Visible = true;
                MessageBox.Show("Đã in báo cáo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Thông báo lỗi
                MessageBox.Show("Có lỗi xảy ra trong quá trình xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void date2_ValueChanged(object sender, EventArgs e)
        {
            ngay2 = date2.Value.ToString();
        }

        private void date3_ValueChanged(object sender, EventArgs e)
        {
            ngay3 = date3.Value.ToString();
        }
    }
}