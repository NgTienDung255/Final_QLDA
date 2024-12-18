using Microsoft.Office.Interop.Excel;
using Project_CuoiKi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Text.RegularExpressions;

namespace Project_CuoiKi.All_User_Control
{
    public partial class UC_HOADON : UserControl
    {
        System.Data.DataTable tblhoadonnhap;
        System.Data.DataTable tblhoadonban;
        System.Data.DataTable tblchitiethoadonnhap;
        public UC_HOADON()
        {
            InitializeComponent();
            functions.ketnoi();
            load_hoadonnhap();
            load_hoadonban();
            load_chitiethoadonnhap();
        }

        private void UC_HOADON_Load(object sender, EventArgs e)
        {
            btnluu3.Enabled = false;
            btnboqua3.Enabled = false;
            functions.fillcombo("SELECT MaNCC, MaNCC FROM NhaCungCap", cbonhacungcap, "MaNCC", "MaNCC");
            cbonhacungcap.SelectedIndex = -1;
            if (tabControl1.SelectedIndex == 0)
            {
                
                load_hoadonnhap();

            }
            btnluu1.Enabled = false;
            btnboqua1.Enabled = false;
            functions.fillcombo("SELECT MaTB,MaTB FROM ThietBi", cbomncc, "MaTB", "MaTB");
            cbomncc.SelectedIndex = -1;
            functions.fillcombo("SELECT MaLoaiTB,TenLoaiTB  FROM LoaiThietBi", cboloaithietbi, "MaLoaiTB", "TenLoaiTB");
            cboloaithietbi.SelectedIndex = -1;
            functions.fillcombo("SELECT MaNhomTB,TenNhomTB  FROM NhomThietBi", cbonhomthietbi, "MaNhomTB", "TenNhomTB");
            cbonhomthietbi.SelectedIndex = -1;
            if (tabControl1.SelectedIndex == 1)
            {
               
                load_chitiethoadonnhap();
            }

            functions.fillcombo("SELECT MaMay,MaMay FROM May", cbomamay, "MaMay", "MaMay");
            cbomamay.SelectedIndex = -1;
            functions.fillcombo("SELECT MaPhong,MaPhong  FROM Phong", cbomaphong, "MaPhong", "MaPhong");
            cbomaphong.SelectedIndex = -1;
            if (tabControl1.SelectedIndex == 2)
            {
                load_hoadonban();
            }

        }
        System.Data.DataTable tbllhoadonnhap;
        public void load_hoadonnhap()
        {
            string sql = "SELECT * FROM HoaDonNhap";
            tbllhoadonnhap = functions.GetDataToTable(sql);
            dgridhoadonnhap.DataSource = tbllhoadonnhap;
            dgridhoadonnhap.Columns[0].HeaderText = "Mã Hóa Đơn Nhập";
            dgridhoadonnhap.Columns[1].HeaderText = "Mã Nhà Cung Cấp";
            dgridhoadonnhap.Columns[2].HeaderText = "Ngày Nhập";
            dgridhoadonnhap.Columns[3].HeaderText = "Tổng Tiền";

            foreach (DataGridViewColumn col in dgridhoadonnhap.Columns)
            {
                col.Width = 100;
            }
            dgridhoadonnhap.AllowUserToAddRows = false;
            dgridhoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgridhoadonnhap.AllowUserToAddRows = false;
            dgridhoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
            foreach (DataGridViewRow row in dgridhoadonnhap.Rows)
            {
                if (row.Cells["NgayNhap"].Value != null && row.Cells["NgayNhap"].Value.ToString() != "")
                {
                    DateTime ngaynhap;
                    if (DateTime.TryParse(row.Cells["NgayNhap"].Value.ToString(), out ngaynhap))
                    {
                        row.Cells["NgayNhap"].Value = ngaynhap.ToString("MM-dd-yyyy");
                    }
                }
            }
        }


       

        //Hoa don nhap
        private void dgridhoadonnhap_Click_1(object sender, EventArgs e)
        {
            functions.fillcombo("SELECT MaNCC,MaNCC FROM NhaCungCap", cbonhacungcap, "MaNCC", "MaNCC");
            cbonhacungcap.SelectedIndex = -1;

            if (btnthem3.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahoadonnhap.Focus();
                return;
            }

            if (tbllhoadonnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmahoadonnhap.Text = dgridhoadonnhap.CurrentRow.Cells["MaHDN"].Value.ToString();
            cbonhacungcap.SelectedValue = dgridhoadonnhap.CurrentRow.Cells["MaNCC"].Value.ToString();
            mskngaynhap.Text = dgridhoadonnhap.CurrentRow.Cells["NgayNhap"].Value.ToString();
            txttongtien.Text = dgridhoadonnhap.CurrentRow.Cells["TongTien"].Value.ToString();
            string ngaynhapstr = dgridhoadonnhap.CurrentRow.Cells["NgayNhap"].Value.ToString();
           
            DateTime ngaynhap;
            if (DateTime.TryParse(ngaynhapstr, out ngaynhap))
            {
                mskngaynhap.Text = ngaynhap.ToString("dd-MM-yyyy");
            }
            else
            {
                mskngaynhap.Text = ""; // Hoặc gán giá trị mặc định nếu không chuyển đổi được
            }
            btnsua3.Enabled = true;
            btnxoa3.Enabled = true;
            btnboqua3.Enabled = true;
        }
        private void ResetValueshdn()
        {
            txtmahoadonnhap.Text = "";
            cbonhacungcap.Text = "";
            mskngaynhap.Text = "";
            txttongtien.Text = "0";
        }

        private void btnthem3_Click_1(object sender, EventArgs e)
        {
            btnsua3.Enabled = false;
            btnxoa3.Enabled = false;
            btnboqua3.Enabled = true;
            btnluu3.Enabled = true;
            btnthem3.Enabled = false;
            ResetValueshdn();
            txtmahoadonnhap.Enabled = true;
            txtmahoadonnhap.Focus();
        }


        private void btnsua3_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (tbllhoadonnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                return;
            }
            if (txtmahoadonnhap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbonhacungcap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbonhacungcap.Focus();
                return;
            }

            if (mskngaynhap.Text == " / /")
            {
                MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaynhap.Focus();
                return;
            }
            if (!functions.isdate(mskngaynhap.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaynhap.Text = "";
                mskngaynhap.Focus();
                return;
            }
            sql = "UPDATE HoaDonNhap SET  MaNCC = N'" + cbonhacungcap.SelectedValue.ToString() + "',NgayNhap='" + functions.convertdatetime(mskngaynhap.Text) +
            "',TongTien = N'" + txttongtien.Text.Trim() + "'  WHERE MaHDN=N'" + txtmahoadonnhap.Text + "'";
            functions.runsql(sql);
            load_hoadonnhap();
            ResetValueshdn();
            btnboqua3.Enabled = false;
        }

        

        private void btnluu3_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (txtmahoadonnhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmahoadonnhap.Focus();
                return;
            }

            if (cbonhacungcap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbonhacungcap.Focus();
                return;
            }
            if (mskngaynhap.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaynhap.Focus();
                return;
            }
            if (txttongtien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tổng tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttongtien.Focus();
                return;
            }
            if (!functions.isdate(mskngaynhap.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskngaynhap.Text = "";
                mskngaynhap.Focus();
                return;
            }
            sql = "SELECT MaHDN FROM HoaDonNhap WHERE MaNCC = N'" + txtmahoadonnhap.Text.Trim() + "'";
            if (functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hóa đơn này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmahoadonnhap.Focus();
                txtmahoadonnhap.Text = "";
                return;
            }
            sql = "INSERT INTO HoaDonNhap(MaHDN, MaNCC, NgayNhap, TongTien) VALUES(N'" + txtmahoadonnhap.Text.Trim() + "', N'" + cbonhacungcap.SelectedValue.ToString() + "', '" + functions.convertdatetime(mskngaynhap.Text).ToString() + "',N'" + txttongtien.Text.Trim() + "')";
            functions.runsql(sql);
            load_hoadonnhap();
            ResetValueshdn();
            btnxoa3.Enabled = true;
            btnthem3.Enabled = true;
            btnsua3.Enabled = true;
            btnboqua3.Enabled = false;
            btnluu3.Enabled = false;
            txtmahoadonnhap.Enabled = false;
        }

        private void btnboqua3_Click_1(object sender, EventArgs e)
        {
            ResetValueshdn();
            btnboqua3.Enabled = false;
            btnthem3.Enabled = true;
            btnxoa3.Enabled = true;
            btnsua3.Enabled = true;
            btnluu3.Enabled = false;
            txtmahoadonnhap.Enabled = false;
        }

        private void btndong3_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng cửa sổ hóa đơn nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void btninhoadon_Click(object sender, EventArgs e)
        {
            System.Data.DataTable hdn;
            string sql = "SELECT MaHDN, MaNCC, NgayNhap, TongTien " +
                         "FROM HoaDonNhap WHERE MaHDN = N'" + txtmahoadonnhap.Text + "'";
            hdn = functions.GetDataToTable(sql);
            if (dgridhoadonnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmahoadonnhap.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
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
                    exRange.Range["D2:F2"].Value = "HÓA ĐƠN NHẬP";
                    exRange.Range["D3:F3"].Font.Size = 14;
                    exRange.Range["D3:F3"].Font.Bold = true;
                    exRange.Range["D3:F3"].Font.ColorIndex = 3;
                    exRange.Range["D3:F3"].MergeCells = true;
                    exRange.Range["D3:F3"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                    // Định dạng tiêu đề cột
                    exRange.Range["B5:F5"].Font.Bold = true;
                    exRange.Range["B5:F5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    exRange.Range["B5:B100"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    exRange.Range["B5:B5"].ColumnWidth = 8;
                    exRange.Range["C5:C5"].ColumnWidth = 22;
                    exRange.Range["D5:D5"].ColumnWidth = 22;
                    exRange.Range["E5:E5"].ColumnWidth = 22;
                    exRange.Range["F5:F5"].ColumnWidth = 22;
                    exRange.Range["E5:E5"].Font.Bold = true;
                    exRange.Range["E5:E5"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                    // Tiêu đề cột
                    exRange.Range["B5:B5"].Value = "STT";
                    exRange.Range["C5:C5"].Value = "Mã Hóa Đơn Nhập";
                    exRange.Range["D5:D5"].Value = "Mã Nhà Cung Cấp";
                    exRange.Range["E5:E5"].Value = "Ngày Nhập";
                    exRange.Range["F5:F5"].Value = "Tổng Tiền";
                    int hang = 0, cot = 0;

                    for (hang = 0; hang <= hdn.Rows.Count - 1; hang++)
                    {
                        exSheet.Cells[2][hang + 6] = hang + 1; // Assuming column B for STT
                        for (cot = 0; cot <= hdn.Columns.Count - 1; cot++)
                        {
                            if (cot == hdn.Columns["NgayNhap"].Ordinal) // Check if it's the NgayNhap column
                            {
                                exSheet.Cells[cot + 3][hang + 6] = hdn.Rows[hang][cot].ToString();
                                ((Excel.Range)exSheet.Cells[cot + 3][hang + 6]).NumberFormat = "dd/mm/yyyy"; // Set the format to "dd/mm/yyyy" (or your preferred format)
                            }
                            else
                            {
                                exSheet.Cells[cot + 3][hang + 6] = hdn.Rows[hang][cot].ToString();
                            }
                        }
                    }
                    exRange = (Excel.Range)exSheet.Cells[hdn.Rows.Count + 8, 4];
                    exRange.Range["A1:C1"].MergeCells = true;
                    exRange.Range["A1:C1"].Font.Italic = true;
                    exRange.Range["A1:C1"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    exRange.Range["A1:C1"].Value = "Hà Nội, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    exSheet.Name = "Hóa Đơn Nhập";
                    exApp.Visible = true;
                    MessageBox.Show("Đã in báo cáo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if ((txtmahoadonnhap.Text == "") && (cbonhacungcap.SelectedIndex == -1) && (mskngaynhap.Text == "  /  /") && (txttongtien.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from hoadonnhap where 1=1";
            if (txtmahoadonnhap.Text != "")
            {
                sql = sql + "and mahdn like N'%" + txtmahoadonnhap.Text + "%'";
                tblhoadonnhap = functions.GetDataToTable(sql);
                dgridhoadonnhap.DataSource = tblhoadonnhap;
                if (tblhoadonnhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cbonhacungcap.SelectedIndex != -1)
            {
                string mancc = cbonhacungcap.SelectedValue.ToString();
                sql = sql + "and mancc like N'%" + mancc + "%'";
                tblhoadonnhap = functions.GetDataToTable(sql);
                dgridhoadonnhap.DataSource = tblhoadonnhap;
                if (tblhoadonnhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (mskngaynhap.Text != "")
            {
                string input = mskngaynhap.Text;

                string[] parts = input.Split('/');
                string ngay = parts[0].Trim();
                string thang = parts[1].Trim();
                string nam = parts[2].Trim();

                string condition = "";
                if (!string.IsNullOrEmpty(ngay))
                {
                    condition += "DAY(ngaynhap) = " + ngay;
                }
                if (!string.IsNullOrEmpty(thang))
                {
                    if (condition != "") condition += " AND ";
                    condition += "MONTH(ngaynhap) = " + thang;
                }
                if (!string.IsNullOrEmpty(nam))
                {
                    if (condition != "") condition += " AND ";
                    condition += "YEAR(ngaynhap) = " + nam;
                }

                if (condition != "")
                {
                    sql = sql + "and " + condition;
                    tblhoadonnhap = functions.GetDataToTable(sql);
                    dgridhoadonnhap.DataSource = tblhoadonnhap;
                    if (tblhoadonnhap.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (txttongtien.Text != "")
            {
                sql = sql + "and tongtien = N'" + txttongtien.Text + "'";
                tblhoadonnhap = functions.GetDataToTable(sql);
                dgridhoadonnhap.DataSource = tblhoadonnhap;
                if (tblhoadonnhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void btnHienthi_Click_1(object sender, EventArgs e)
        {
            load_hoadonnhap();
            txtmahoadonnhap.Text = "";
            cbonhacungcap.SelectedIndex = -1;
            mskngaynhap.Text = "  /  /";
            txttongtien.Text = "";
        }


        //CHITIET HOA DON NHAP
        private void dgridchitiethoadonnhap_Click(object sender, EventArgs e)
        {
            functions.fillcombo("SELECT MaTB, MaTB FROM ThietBi", cbomncc, "MaTB", "MaTB");
            cbomncc.SelectedIndex = -1;
            functions.fillcombo("SELECT MaLoaiTB, MaLoaiTB FROM LoaiThietBi", cboloaithietbi, "MaLoaiTB", "MaLoaiTB");
            cboloaithietbi.SelectedIndex = -1;
            functions.fillcombo("SELECT MaNhomTB, MaNhomTB FROM NhomThietBi", cbonhomthietbi, "MaNhomTB", "MaNhomTB");
            cbonhomthietbi.SelectedIndex = -1;

            if (btnthem3.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahdn.Focus();
                return;
            }

            if (tblchitiethoadonnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtmahdn.Text = dgridchitiethoadonnhap.CurrentRow.Cells["MaHDN"].Value.ToString();
            cbomncc.SelectedValue = dgridchitiethoadonnhap.CurrentRow.Cells["MaTB"].Value.ToString();
            cboloaithietbi.SelectedValue = dgridchitiethoadonnhap.CurrentRow.Cells["MaLoaiTB"].Value.ToString();
            cbonhomthietbi.SelectedValue = dgridchitiethoadonnhap.CurrentRow.Cells["MaNhomTB"].Value.ToString();

            btnsua3.Enabled = true;
            btnxoa3.Enabled = true;
            btnboqua3.Enabled = true;
            btnluu3.Enabled = false;
        }

        private void load_chitiethoadonnhap()
        {
            string sql = "SELECT * FROM ChiTietHDN";
            tblchitiethoadonnhap = functions.GetDataToTable(sql);
            dgridchitiethoadonnhap.DataSource = tblchitiethoadonnhap;

            dgridchitiethoadonnhap.Columns[0].HeaderText = "Mã Hóa Đơn Nhập";
            dgridchitiethoadonnhap.Columns[1].HeaderText = "Mã Thiết Bị";
            dgridchitiethoadonnhap.Columns[2].HeaderText = "Mã Loại Thiết Bị";
            dgridchitiethoadonnhap.Columns[3].HeaderText = "Mã Nhóm Thiết Bị";
            dgridchitiethoadonnhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgridchitiethoadonnhap.AllowUserToAddRows = false;
            dgridchitiethoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgridchitiethoadonnhap.CellMouseLeave += dgridchitiethoadonnhap_CellMouseLeave;
        }
        private void dgridchitiethoadonnhap_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgridchitiethoadonnhap.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray; // Change to desired color
            }
        }
        private void dgridchitiethoadonnhap_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                dgridchitiethoadonnhap.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White; // Change to default color
            }
        }
        private void btnthem1_Click(object sender, EventArgs e)
        {
            btnsua1.Enabled = false;
            btnxoa1.Enabled = false;
            btnboqua1.Enabled = true;
            btnluu1.Enabled = true;
            btnthem1.Enabled = false;
            ResetValues();
            txtmahdn.Enabled = true;
            txtmahdn.Focus();
        }

        private void btnsua1_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblchitiethoadonnhap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmahdn.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbomncc.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboloaithietbi.Focus();
                return;
            }
            if (cboloaithietbi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn loại thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboloaithietbi.Focus();
                return;
            }
            if (cbonhomthietbi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn loại thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbonhomthietbi.Focus();
                return;
            }


            sql = "UPDATE ChiTietHDN SET MaNCC = N'" + cbomncc.SelectedValue.ToString() +
               "', MaLoaiTB = N'" + cboloaithietbi.SelectedValue.ToString() +
               "',MaNhomTB = N'" + cbonhomthietbi.SelectedValue.ToString() + "' where MaHDN = N'" + txtmahdn.Text + "'";

            functions.runsql(sql);
            load_chitiethoadonnhap();
            ResetValues();
            btnboqua1.Enabled = true;
        }

        private void ResetValues()
        {
            txtmahdn.Text = "";
            cbomncc.Text = "";
            cboloaithietbi.Text = "";
            cbonhomthietbi.Text = "";
        }

       

        private void btndong1_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng cửa sổ chi tiết hóa đơn nhập?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void btnboqua1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thực hiện bỏ qua?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ResetValues();
                btnboqua1.Enabled = false;
                btnthem1.Enabled = true;
                btnxoa1.Enabled = true;
                btnsua1.Enabled = true;
                btnluu1.Enabled = false;
                txtmahdn.Enabled = false;
            }
        }

        private void btnluu1_Click(object sender, EventArgs e)
        {
            if (txtmahdn.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hóa đơn nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmahdn.Focus();
                return;
            }
            if (cbomncc.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn mã thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbomncc.Focus();
                return;
            }
            if (cboloaithietbi.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn loại thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboloaithietbi.Focus();
                return;
            }
            if (cbonhomthietbi.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn nhóm thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbonhomthietbi.Focus();
                return;
            }

            string sql = "INSERT INTO ChiTietHDN(MaHDN, MaTB, MaLoaiTB, MaNhomTB) VALUES (N'" + txtmahdn.Text.Trim() + "', N'" + cbomncc.SelectedValue.ToString() + "', N'" + cboloaithietbi.SelectedValue.ToString() + "', N'" + cbonhomthietbi.SelectedValue.ToString() + "')";
            functions.runsql(sql);
            load_chitiethoadonnhap();
            ResetValues();
            btnxoa1.Enabled = true;
            btnthem1.Enabled = true;
            btnsua1.Enabled = true;
            btnboqua1.Enabled = true;
            btnluu1.Enabled = false;
            txtmahdn.Enabled = false;
        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void btntimkiem1_Click(object sender, EventArgs e)
        {
            
            if ((txtmahdn.Text == "") && (cbomncc.SelectedIndex == -1) && (cboloaithietbi.SelectedIndex == -1) && (cbonhomthietbi.SelectedIndex == -1))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from chitiethdn where 1=1"; if (txtmahdn.Text != "")
            {
                sql = sql + "and mahdn like N'%" + txtmahdn.Text + "%'";
                tblchitiethoadonnhap = functions.GetDataToTable(sql);
                dgridchitiethoadonnhap.DataSource = tblchitiethoadonnhap;
                if (tblchitiethoadonnhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cbomncc.SelectedIndex != -1)
            {
                string matb = cbomncc.SelectedValue.ToString();
                sql = sql + "and matb = N'" + matb + "'";
                tblchitiethoadonnhap = functions.GetDataToTable(sql);
                dgridchitiethoadonnhap.DataSource = tblchitiethoadonnhap;
                if (tblchitiethoadonnhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cboloaithietbi.SelectedIndex != -1)
            {
                string maltb = cboloaithietbi.SelectedValue.ToString();
                sql = sql + "and maloaitb = N'" + maltb + "'";
                tblchitiethoadonnhap = functions.GetDataToTable(sql);
                dgridchitiethoadonnhap.DataSource = tblchitiethoadonnhap;
                if (tblchitiethoadonnhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cbonhomthietbi.SelectedIndex != -1)
            {
                string ntb = cbonhomthietbi.SelectedValue.ToString();
                sql = sql + "and manhomtb = N'" + ntb + "'";
                tblchitiethoadonnhap = functions.GetDataToTable(sql);
                dgridchitiethoadonnhap.DataSource = tblchitiethoadonnhap;
                if (tblchitiethoadonnhap.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnhienthi1_Click_1(object sender, EventArgs e)
        {
            load_chitiethoadonnhap();
            txtmahdn.Text = "";
            cbomncc.SelectedIndex = -1;
            cboloaithietbi.SelectedIndex = -1;
            cbonhomthietbi.SelectedIndex = -1;
        }
        //HOA DON BAN
        private void load_hoadonban()
        {
            functions.fillcombo("SELECT MaMay,MaMay FROM May", cbomamay, "MaMay", "MaMay");
            cbomamay.SelectedIndex = -1;
            functions.fillcombo("SELECT MaPhong,MaPhong  FROM Phong", cbomaphong, "MaPhong", "MaPhong");
            cbomaphong.SelectedIndex = -1;
            string sql = "SELECT * FROM HoaDonBan";
            tblhoadonban = functions.GetDataToTable(sql);
            dgridhoadonban.DataSource = tblhoadonban;
            dgridhoadonban.Columns[0].HeaderText = "Mã Hóa Đơn";
            dgridhoadonban.Columns[1].HeaderText = "Mã Máy";
            dgridhoadonban.Columns[2].HeaderText = "Mã Phòng";
            dgridhoadonban.Columns[3].HeaderText = "Ngày Thuê";
            dgridhoadonban.Columns[4].HeaderText = "Giờ vào";
            dgridhoadonban.Columns[5].HeaderText = "Giờ ra";
            dgridhoadonban.Columns[6].HeaderText = "Mã Nhân Viên";
            dgridhoadonban.Columns[7].HeaderText = "Tổng Tiền";
            dgridhoadonban.Columns[8].HeaderText = "Ghi Chú";
            foreach (DataGridViewColumn col in dgridhoadonban.Columns)
            {
                col.Width = 100;
            }
            dgridhoadonban.AllowUserToAddRows = false;
            dgridhoadonban.EditMode = DataGridViewEditMode.EditProgrammatically;
            foreach (DataGridViewRow row in dgridhoadonban.Rows)
            {
                if (row.Cells["NgayThue"].Value != null && row.Cells["NgayThue"].Value.ToString() != "")
                {
                    DateTime ngaythue;
                    if (DateTime.TryParse(row.Cells["NgayThue"].Value.ToString(), out ngaythue))
                    {
                        row.Cells["NgayThue"].Value = ngaythue.ToString("MM/dd/yyyy");
                    }
                }
            }
        }

        private void resetvalue()
        {
            txtghichu.Text = "";
            txtmahoadonban.Text = "";
            txtmanhanvien.Text = "";
            txttt.Text = "0";
            functions.fillcombo("SELECT MaMay, May", cbomamay, "MaMay", "MaMay");
            cbomamay.SelectedIndex = -1;
            functions.fillcombo("SELECT MaPhong,MaPhong  FROM Phong", cbomaphong, "MaPhong", "MaPhong");
            cbomaphong.SelectedIndex = -1;
            mskngaythue.Text = "";
            mskgiora.Text = "";
            mskgiovao.Text = "";
            txtghichu.Text = "";
        }

        private void dgridhoadonban_Click_1(object sender, EventArgs e)
        {
            functions.fillcombo("SELECT MaMay,MaMay FROM May", cbomamay, "MaMay", "MaMay");
            cbomamay.SelectedIndex = -1;
            functions.fillcombo("SELECT MaPhong,MaPhong  FROM Phong", cbomaphong, "MaPhong", "MaPhong");
            cbomaphong.SelectedIndex = -1;
            if (tblhoadonban.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmahoadonban.Text = dgridhoadonban.CurrentRow.Cells["MaHDB"].Value.ToString();
            cbomamay.SelectedValue = dgridhoadonban.CurrentRow.Cells["MaMay"].Value.ToString();
            cbomaphong.SelectedValue = dgridhoadonban.CurrentRow.Cells["MaPhong"].Value.ToString();
            mskngaythue.Text = dgridhoadonban.CurrentRow.Cells["NgayThue"].Value.ToString();
            mskgiovao.Text = dgridhoadonban.CurrentRow.Cells["GioVao"].Value.ToString();
            mskgiora.Text = dgridhoadonban.CurrentRow.Cells["GioRa"].Value.ToString();
            txtmanhanvien.Text = dgridhoadonban.CurrentRow.Cells["MaNV"].Value.ToString();
            txttt.Text = dgridhoadonban.CurrentRow.Cells["TongTien"].Value.ToString();
            txtghichu.Text = dgridhoadonban.CurrentRow.Cells["GhiChu"].Value.ToString();
            string ngaythuestr = dgridhoadonban.CurrentRow.Cells["NgayThue"].Value.ToString();
            DateTime ngaythue;
            if (DateTime.TryParse(ngaythuestr, out ngaythue))
            {
                mskngaythue.Text = ngaythue.ToString("dd-MM-yyyy");
            }
            else
            {
                mskngaythue.Text = ""; // Hoặc gán giá trị mặc định nếu không chuyển đổi được
            }
            btnboqua.Enabled = true;
        }

        private void btnboqua_Click_1(object sender, EventArgs e)
        {
            resetvalue();
            btnboqua.Enabled = false;
        }

        private void btndong_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng cửa sổ hóa đơn bán?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void btntimkiem2_Click(object sender, EventArgs e)
        {
            if ((txtmahoadonban.Text == "") && (cbomamay.SelectedIndex == -1) && (cbomaphong.SelectedIndex == -1) && (mskngaythue.Text == "  /  /") && (txtmanhanvien.Text == "") && (txttt.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from HoaDonBan where 1=1";
            if (txtmahoadonban.Text != "")
            {
                sql = sql + "and MaHDB like N'%" + txtmahoadonban.Text + "%'";
                tblhoadonban = functions.GetDataToTable(sql);
                dgridhoadonban.DataSource = tblhoadonban;
                if (tblhoadonban.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cbomamay.SelectedIndex != -1)
            {
                string mamay = cbomamay.SelectedValue.ToString();
                sql = sql + "and MaMay = N'" + mamay + "'";
                tblhoadonban = functions.GetDataToTable(sql);
                dgridhoadonban.DataSource = tblhoadonban;
                if (tblhoadonban.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cbomaphong.SelectedIndex != -1)
            {
                string maphong = cbomaphong.SelectedValue.ToString();
                sql = sql + "and MaPhong = N'" + maphong + "'";
                tblhoadonban = functions.GetDataToTable(sql);
                dgridhoadonban.DataSource = tblhoadonban;
                if (tblhoadonban.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (mskngaythue.Text != "  /  /")
            {
                string input = mskngaythue.Text;

                string[] parts = input.Split('/');
                string ngay = parts[0].Trim();
                string thang = parts[1].Trim();
                string nam = parts[2].Trim();

                string condition = "";
                if (!string.IsNullOrEmpty(ngay))
                {
                    condition += "DAY(ngaythue) = " + ngay;
                }
                if (!string.IsNullOrEmpty(thang))
                {
                    if (condition != "") condition += " AND ";
                    condition += "MONTH(ngaythue) = " + thang;
                }
                if (!string.IsNullOrEmpty(nam))
                {
                    if (condition != "") condition += " AND ";
                    condition += "YEAR(ngaythue) = " + nam;
                }

                if (condition != "")
                {
                    sql = sql + "and " + condition;
                    tblhoadonban = functions.GetDataToTable(sql);
                    dgridhoadonban.DataSource = tblhoadonban;
                    if (tblhoadonban.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (txtmanhanvien.Text != "")
            {
                sql = sql + "and manv like N'%" + txtmanhanvien.Text + "%'";
                tblhoadonban = functions.GetDataToTable(sql);
                dgridhoadonban.DataSource = tblhoadonban;
                if (tblhoadonban.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (txttt.Text != "")
            {
                sql = sql + "and tongtien = N'" + txttt.Text + "'";
                tblhoadonban = functions.GetDataToTable(sql);
                dgridhoadonban.DataSource = tblhoadonban;
                if (tblhoadonban.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void btnhienthi2_Click_1(object sender, EventArgs e)
        {
            load_hoadonban();
            txtmahoadonban.Text = "";
            cbomamay.SelectedIndex = -1;
            cbomaphong.SelectedIndex = -1;
            mskngaythue.Text = "  /  /";
            txtmanhanvien.Text = "";
            txttt.Text = "";
        }
    }
}
