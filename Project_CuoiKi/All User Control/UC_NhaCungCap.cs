using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_CuoiKi.Class;

namespace Project_CuoiKi.All_User_Control
{
    public partial class UC_NhaCungCap : UserControl
    {
        public UC_NhaCungCap()
        {
            InitializeComponent();
        }

        private void UC_NhaCungCap_Load(object sender, EventArgs e)
        {

            txtMaNCC.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            Load_DataGrid();
        }
        DataTable tblncc;
        private void Load_DataGrid()
        {
            string sql;
            sql = "select * from NhaCungCap";
            tblncc = Class.functions.GetDataToTable(sql);
            dgridNCC.DataSource = tblncc;
            dgridNCC.Columns[0].HeaderText = "Mã Nhà cung cấp";
            dgridNCC.Columns[1].HeaderText = "Tên Nhà cung cấp";
            dgridNCC.Columns[2].HeaderText = "Điện Thoại";
            dgridNCC.Columns[3].HeaderText = "Điạ Chỉ";
            dgridNCC.Columns[0].Width = 160;
            dgridNCC.Columns[1].Width = 160;
            dgridNCC.Columns[2].Width = 200;
            dgridNCC.Columns[3].Width = 550;
            dgridNCC.AllowUserToAddRows = false;
            dgridNCC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgridNCC_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Dang o che do them moi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Khong co du lieu trong csdl", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaNCC.Text = dgridNCC.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtTenNCC.Text = dgridNCC.CurrentRow.Cells["TenNCC"].Value.ToString();
            txtDiaChi.Text = dgridNCC.CurrentRow.Cells["DiaChi"].Value.ToString();
            mskDienThoai.Text = dgridNCC.CurrentRow.Cells["DienThoai"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void resetvalues()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            mskDienThoai.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnBoqua.Enabled = true;
            txtMaNCC.Enabled = true;
            resetvalues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Ban phai nhap ma nha cung cap", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNCC.Focus();
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Ban phai nhap ten nha cung cap", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNCC.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Ban phai nhap dia chi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return;
            }
            if (mskDienThoai.Text == "(   )    -")
            {
                MessageBox.Show("Ban phai nhap dien thoai", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDienThoai.Focus();
                return;
            }
            string sdt = mskDienThoai.Text;
            string sdt1 = new string(sdt.Where(char.IsDigit).ToArray());
            string sql;
            sql = "insert into NhaCungCap(MaNCC,TenNCC,DienThoai, DiaChi) values(N'" + txtMaNCC.Text.Trim() + "',N'" + txtTenNCC.Text.Trim() + "',N'" + sdt1 + "', N'" + txtDiaChi.Text.Trim() + "')";
            Class.functions.runsql(sql);
            Load_DataGrid();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txtMaNCC.Enabled = false;
            resetvalues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Focus();
                return;
            }
            if (mskDienThoai.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDienThoai.Focus();
                return;
            }

            string sdt = mskDienThoai.Text;
            string sdt1 = new string(sdt.Where(char.IsDigit).ToArray());

            sql = "UPDATE NhaCungCap SET TenNCC=N'" + txtTenNCC.Text.ToString() + "', DiaChi=N'" + txtDiaChi.Text.ToString() + "', DienThoai= N'" + sdt1 + "' WHERE MaNCC=N'" + txtMaNCC.Text + "'";
            Class.functions.runsql(sql);
            Load_DataGrid();
            resetvalues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblncc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE FROM NhaCungCap WHERE MaNCC =N'" + txtMaNCC.Text + "'";
                Class.functions.runsql(sql);
                Load_DataGrid();
                resetvalues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = true;
        }
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if ((txtMaNCC.Text == "") && (txtDiaChi.Text == "") && (txtTenNCC.Text == "") && (mskDienThoai.Text == "(   )    -"))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from nhacungcap where 1=1";
            if (txtMaNCC.Text != "")
            {
                sql = sql + "and mancc like N'%" + txtMaNCC.Text + "%'";
                tblncc = functions.GetDataToTable(sql);
                dgridNCC.DataSource = tblncc;
                if (tblncc.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtTenNCC.Text != "")
            {
                sql = sql + "and tenncc like N'%" + txtTenNCC.Text + "%'";
                tblncc = functions.GetDataToTable(sql);
                dgridNCC.DataSource = tblncc;
                if (tblncc.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtDiaChi.Text != "")
            {
                sql = sql + "and diachi like N'%" + txtDiaChi.Text + "%'";
                tblncc = functions.GetDataToTable(sql);
                dgridNCC.DataSource = tblncc;
                if (tblncc.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (mskDienThoai.Text != "(   )    -")
            {
                string sdt = mskDienThoai.Text;
                string sdt1 = new string(sdt.Where(char.IsDigit).ToArray());
                sql = sql + "and dienthoai = '" + sdt1 + "'";
                tblncc = functions.GetDataToTable(sql);
                dgridNCC.DataSource = tblncc;
                if (tblncc.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void btnHienthitatca_Click(object sender, EventArgs e)
        {
            Load_DataGrid();
            txtDiaChi.Text = "";
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            mskDienThoai.Text = "(   )    -";
        }

    }
}
