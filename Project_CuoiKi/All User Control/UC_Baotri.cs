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

namespace Project_CuoiKi.All_User_Control
{
    public partial class UC_Baotri : UserControl
    {
        public UC_Baotri()
        {
            InitializeComponent();
        }
        DataTable tblnbt;
        DataTable tblbt;
        private void UC_Baotri_Load(object sender, EventArgs e)
        {
            btnLuuNBT.Enabled = false;
            btnBoquaNBT.Enabled = false;
            Load_DataGrid_NBT();
            Load_DataGrid_BT();
            resetvalue_NBT();
            resetvalue_BT();
        }

        //NHÀ BẢO TRÌ
        private void Load_DataGrid_NBT()
        {
            string sql;
            sql = "select * from nhabaotri";
            tblnbt = Class.functions.GetDataToTable(sql);
            dgridNbt.DataSource = tblnbt;
            dgridNbt.Columns[0].HeaderText = "Mã nhà bảo trì";
            dgridNbt.Columns[1].HeaderText = "Tên nhà bảo trì";
            dgridNbt.Columns[2].HeaderText = "Địa chỉ";
            dgridNbt.Columns[3].HeaderText = "Điện thoại";
            dgridNbt.AllowUserToAddRows = false;
            dgridNbt.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void resetvalue_NBT()
        {
            txtManbt.Text = "";
            txtTennbt.Text = "";
            txtDiachinbt.Text = "";
            mskDienthoainbt.Text = "(   )    -";
        }

        private void dgridNbt_Click(object sender, EventArgs e)
        {
            if(btnThemNBT.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTennbt.Focus();
                return;
            }
            if (tblnbt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                return;
            }
            txtManbt.Text = dgridNbt.CurrentRow.Cells["manbt"].Value.ToString();
            txtTennbt.Text = dgridNbt.CurrentRow.Cells["tennbt"].Value.ToString();
            txtDiachinbt.Text = dgridNbt.CurrentRow.Cells["DiaChi"].Value.ToString();
            mskDienthoainbt.Text = dgridNbt.CurrentRow.Cells["DienThoai"].Value.ToString();
            btnSuaNBT.Enabled = true;
            btnXoaNBT.Enabled = true;
            btnBoquaNBT.Enabled = true;
        }

        private void btnThemNBT_Click(object sender, EventArgs e)
        {
            btnThemNBT.Enabled = false;
            btnSuaNBT.Enabled = false;
            btnXoaNBT.Enabled = false;
            btnLuuNBT.Enabled = true;
            btnBoquaNBT.Enabled = true;
            txtManbt.Enabled = true;
            btnTimkiemNBT.Enabled = false;
            btnHienthiNBT.Enabled = false;
            resetvalue_NBT();
        }

        private void btnLuuNBT_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtManbt.Text=="")
            {
                MessageBox.Show("Bạn phải nhập mã nhà bảo trì", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManbt.Focus();
                return;
            }
            if(txtTennbt.Text=="")
            {
                MessageBox.Show("Bạn phải nhập tên nhà bảo trì", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTennbt.Focus();
                return;
            }
            if(txtDiachinbt.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachinbt.Focus();
                return;
            }
            if(mskDienthoainbt.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDienthoainbt.Focus();
                return;
            }
            string sql1;
            sql1 = "select manbt from nhabaotri where manbt = N'" + txtManbt.Text + "'";
            if (Class.functions.CheckKey(sql1))
            {
                MessageBox.Show("Mã nhà bảo trì này đã có, vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManbt.Text = "";
                txtManbt.Focus();
                return;
            }
            string sdt = mskDienthoainbt.Text;
            // Loại bỏ các ký tự không phải là số
            string sdt1 = new string(sdt.Where(char.IsDigit).ToArray());
            sql = "insert into nhabaotri (manbt, tennbt, diachi, dienthoai) values ( N'"+txtManbt.Text.Trim() + "', N'"+txtTennbt.Text.Trim()+"', N'"+txtDiachinbt.Text.Trim()+"', '"+sdt1+"')";
            Class.functions.runsql(sql);
            Load_DataGrid_NBT();
            resetvalue_NBT();
            btnXoaNBT.Enabled = true;
            btnThemNBT.Enabled = true;
            btnBoquaNBT.Enabled = true;
            btnLuuNBT.Enabled = true;
            btnTimkiemNBT.Enabled = true;
            btnHienthiNBT.Enabled = true;
            txtManbt.Enabled = true;
        }

        private void btnSuaNBT_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnbt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtManbt.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTennbt.Text.Length == 0) 
            {
                MessageBox.Show("Bạn phải nhập tên nhà bảo trì", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDiachinbt.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiachinbt.Focus();
                return;
            }
            if(mskDienthoainbt.Text == "(   )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mskDienthoainbt.Focus();
                return;
            }
            string sdt = mskDienthoainbt.Text;
            // Loại bỏ các ký tự không phải là số
            string sdt1 = new string(sdt.Where(char.IsDigit).ToArray());
            sql = "update nhabaotri set tennbt = N'" + txtTennbt.Text + "', diachi = N'" + txtDiachinbt.Text + "', dienthoai = '" + sdt1 + "' WHERE manbt = N'" + txtManbt.Text + "'";
            functions.runsql(sql);
            Load_DataGrid_NBT();
            resetvalue_NBT();
            btnBoquaNBT.Enabled = false;
        }

        private void btnXoaNBT_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnbt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtManbt.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn muốn xóa không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE FROM nhabaotri WHERE Manbt =N'" + txtManbt.Text + "'";
                functions.runsql(sql);
                Load_DataGrid_NBT();
                resetvalue_NBT();
            }
        }

        private void btnBoquaNBT_Click(object sender, EventArgs e)
        {
            resetvalue_NBT();
            btnThemNBT.Enabled = true;
            btnXoaNBT.Enabled = true;
            btnTimkiemNBT.Enabled = true;
            btnHienthiNBT.Enabled = true;
            btnSuaNBT.Enabled = true;
            txtManbt.Enabled = false;
            btnLuuBT.Enabled = true;
        }

        private void btnTimkiemNBT_Click(object sender, EventArgs e)
        {
            if((txtManbt.Text=="")&&(txtTennbt.Text=="")&&(txtDiachinbt.Text=="")&&(mskDienthoainbt.Text== "(   )    -"))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from nhabaotri where 1=1";
            if(txtManbt.Text!="")
            {
                sql = sql + "and manbt like N'%" + txtManbt.Text + "%'";
                tblnbt = functions.GetDataToTable(sql);
                dgridNbt.DataSource = tblnbt;
                if (tblnbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(txtTennbt.Text!="")
            {
                sql = sql + "and tennbt like N'%" + txtTennbt.Text + "%'";
                tblnbt = functions.GetDataToTable(sql);
                dgridNbt.DataSource = tblnbt;
                if (tblnbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(txtDiachinbt.Text != "")
            {
                sql = sql + "and diachi like N'%" + txtDiachinbt.Text + "%'";
                tblnbt = functions.GetDataToTable(sql);
                dgridNbt.DataSource = tblnbt;
                if (tblnbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(mskDienthoainbt.Text != "(   )    -")
            {
                string sdt = mskDienthoainbt.Text;
                string sdt1 = new string(sdt.Where(char.IsDigit).ToArray());
                sql = sql + "and dienthoai = '" + sdt1 + "'";
                tblnbt = functions.GetDataToTable(sql);
                dgridNbt.DataSource = tblnbt;
                if (tblnbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnHienthiNBT_Click(object sender, EventArgs e)
        {
            Load_DataGrid_NBT();
            resetvalue_NBT();
        }

        //BẢO TRÌ

        private void Load_DataGrid_BT()
        {
            string sql;
            sql = "select * from baotri";
            tblbt = Class.functions.GetDataToTable(sql);
            dgridBaotri.DataSource = tblbt;
            dgridBaotri.Columns[0].HeaderText = "Mã bảo trì";
            dgridBaotri.Columns[1].HeaderText = "Mã máy";
            dgridBaotri.Columns[2].HeaderText = "Mã nhà bảo trì";
            dgridBaotri.Columns[3].HeaderText = "Tình trạng";
            dgridBaotri.Columns[4].HeaderText = "Nguyên nhân";
            dgridBaotri.Columns[5].HeaderText = "Giải pháp";
            dgridBaotri.Columns[6].HeaderText = "Thành tiền";
            dgridBaotri.AllowUserToAddRows = false;
            dgridBaotri.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void resetvalue_BT()
        {
            txtMaBT.Text = "";
            txtMamay.Text = "";
            cboNBT.SelectedIndex = -1;
            txtTinhtrang.Text = "";
            txtNguyennhan.Text = "";
            txtGiaiphap.Text = "";
            txtThanhtien.Text = "";
            txtPhong.Text = "";

        }

        private void dgridBaotri_Click(object sender, EventArgs e)
        {
            string ma1;
            string ma2;
            if (btnThemBT.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaBT.Focus();
                return;
            }
            if (tblbt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                return;
            }
            txtMaBT.Text = dgridBaotri.CurrentRow.Cells["Mabt"].Value.ToString();
            txtMamay.Text = dgridBaotri.CurrentRow.Cells["mamay"].Value.ToString();
            ma1 = dgridBaotri.CurrentRow.Cells["manbt"].Value.ToString();
            cboNBT.Text = Class.functions.getfieldvalues("Select Tennbt from nhabaotri where Manbt =N'" + ma1 + "'");
            txtTinhtrang.Text = dgridBaotri.CurrentRow.Cells["tinhtrang"].Value.ToString();
            txtNguyennhan.Text = dgridBaotri.CurrentRow.Cells["nguyennhan"].Value.ToString();
            txtGiaiphap.Text = dgridBaotri.CurrentRow.Cells["giaiphap"].Value.ToString();
            txtThanhtien.Text = dgridBaotri.CurrentRow.Cells["thanhtien"].Value.ToString();
            ma2 = dgridBaotri.CurrentRow.Cells["maphong"].Value.ToString();
            txtPhong.Text = Class.functions.getfieldvalues("select tenphong from phong where maphong =N'" + ma2 + "'");
            btnSuaBT.Enabled = true;
            btnXoaBT.Enabled = true;
            btnBoquaBT.Enabled = true;
            txtMaBT.Enabled = false;
            txtMamay.Enabled = false;
            txtPhong.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThemBT.Enabled = false;
            btnSuaBT.Enabled = false;
            btnXoaBT.Enabled = false;
            btnLuuBT.Enabled = true;
            btnBoquaBT.Enabled = true;
            txtMaBT.Enabled = true;
            btnTimkiemBT.Enabled = false;
            btnHienthitatcaBT.Enabled = false;
            resetvalue_BT();
            txtMamay.Enabled = true;
        }

        private void btnSuaBT_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblbt.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMaBT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtMamay.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboNBT.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn nhà bảo trì", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTinhtrang.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtNguyennhan.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nguyên nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtGiaiphap.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giải pháp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtThanhtien.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maphong = Class.functions.getfieldvalues("SELECT maphong FROM may WHERE mamay = N'" + txtMamay.Text + "'");
            string manbt;
            manbt = Class.functions.getfieldvalues("SELECT manbt FROM nhabaotri WHERE tennbt = N'" + cboNBT.SelectedItem + "'");

            sql = "update baotri set manbt = N'" + manbt + "', tinhtrang = N'" + txtTinhtrang.Text + "', nguyennhan = N'" + txtNguyennhan.Text + "', giaiphap = N'" + txtGiaiphap.Text + "', thanhtien = '" + txtThanhtien.Text + "' WHERE mabt = N'" + txtMaBT.Text + "'";
            functions.runsql(sql);
            Load_DataGrid_BT();
            resetvalue_BT();
            btnBoquaBT.Enabled = false;

        }

        private void btnLuuBT_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaBT.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã bảo trì", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaBT.Focus();
                return;
            }
            if (txtMamay.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã máy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMamay.Focus();
                return;
            }
            if (cboNBT.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn nhà bảo trì", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtTinhtrang.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tình trạng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTinhtrang.Focus();
                return;
            }
            if (txtNguyennhan.Text == "")
            {
                MessageBox.Show("Bạn phải nhập nguyên nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNguyennhan.Focus();
                return;
            }
            if (txtGiaiphap.Text == "")
            {
                MessageBox.Show("Bạn phải nhập nguyên nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaiphap.Focus();
                return;
            }
            if (txtThanhtien.Text == "")
            {
                MessageBox.Show("Bạn phải nhập nguyên nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtThanhtien.Focus();
                return;
            }
            string sql1;
            sql1 = "select mabt from baotri where mabt = N'" + txtMaBT.Text + "'";
            if (Class.functions.CheckKey(sql1))
            {
                MessageBox.Show("Mã bảo trì này đã có, vui lòng nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtManbt.Text = "";
                txtManbt.Focus();
                return;
            }

            string maphong = Class.functions.getfieldvalues("SELECT maphong FROM may WHERE mamay = N'" + txtMamay.Text + "'");
            if (string.IsNullOrEmpty(maphong))
            {
                MessageBox.Show("Không tìm thấy phòng cho mã máy này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string manbt;
            manbt = Class.functions.getfieldvalues("SELECT manbt FROM nhabaotri WHERE tennbt = N'" + cboNBT.SelectedItem + "'");
            sql = "insert into baotri (mabt, mamay, manbt, tinhtrang, nguyennhan, giaiphap, thanhtien, maphong) values ( N'" + txtMaBT.Text + "', N'" + txtMamay.Text + "', N'" + manbt + "', N'" + txtTinhtrang.Text + "', N'" + txtNguyennhan.Text + "', N'" + txtGiaiphap.Text + "', '" + txtThanhtien.Text + "', N'" + maphong + "')";
            Class.functions.runsql(sql);
            Load_DataGrid_BT();
            resetvalue_BT();
            btnXoaBT.Enabled = true;
            btnThemBT.Enabled = true;
            btnBoquaBT.Enabled = true;
            btnLuuBT.Enabled = true;
            btnTimkiemBT.Enabled = true;
            btnHienthitatcaBT.Enabled = true;

        }

        private void btnXoaBT_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblbt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaBT.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn muốn xóa không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE FROM baotri WHERE Mabt =N'" + txtMaBT.Text + "'";
                functions.runsql(sql);
                Load_DataGrid_BT();
                resetvalue_BT();
            }

        }

        private void btnBoquaBT_Click(object sender, EventArgs e)
        {
            resetvalue_BT();
            btnThemBT.Enabled = true;
            btnXoaBT.Enabled = true;
            btnTimkiemBT.Enabled = true;
            btnHienthitatcaBT.Enabled = true;
            btnSuaBT.Enabled = true;
            btnLuuBT.Enabled = true;
            txtMaBT.Enabled = false;

        }

        private void btnTimkiemBT_Click(object sender, EventArgs e)
        {
            if ((txtMaBT.Text == "") && (txtMamay.Text == "") && (cboNBT.SelectedIndex == -1) && (txtTinhtrang.Text == "") && (txtNguyennhan.Text == "") && (txtGiaiphap.Text == "") && (txtThanhtien.Text == "") && (txtPhong.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from baotri where 1=1";
            if (txtMaBT.Text != "")
            {
                sql = sql + "and mabt like N'%" + txtMaBT.Text + "%'";
                tblbt = functions.GetDataToTable(sql);
                dgridBaotri.DataSource = tblbt;
                if (tblbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtMamay.Text != "")
            {
                sql = sql + "and mamay like N'%" + txtMamay.Text + "%'";
                tblbt = functions.GetDataToTable(sql);
                dgridBaotri.DataSource = tblbt;
                if (tblbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (cboNBT.SelectedIndex != -1)
            {
                string nbt = cboNBT.SelectedItem.ToString();
                string sqlnbt = "select manbt from nhabaotri where tennbt = N'" + nbt + "'";
                DataTable dtnbt = functions.GetDataToTable(sqlnbt);
                if (dtnbt.Rows.Count > 0)
                {
                    string manbt = dtnbt.Rows[0]["manbt"].ToString();
                    sql = sql + "and manbt = N'" + manbt + "'";
                    tblbt = functions.GetDataToTable(sql);
                    dgridBaotri.DataSource = tblbt;
                    if (tblbt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            if (txtTinhtrang.Text != "")
            {
                sql = sql + "and tinhtrang like N'%" + txtTinhtrang.Text + "%'";
                tblbt = functions.GetDataToTable(sql);
                dgridBaotri.DataSource = tblbt;
                if (tblbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtNguyennhan.Text != "")
            {
                sql = sql + "and nguyennhan like N'%" + txtNguyennhan.Text + "%'";
                tblbt = functions.GetDataToTable(sql);
                dgridBaotri.DataSource = tblbt;
                if (tblbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtGiaiphap.Text != "")
            {
                sql = sql + "and giaiphap like N'%" + txtGiaiphap.Text + "%'";
                tblbt = functions.GetDataToTable(sql);
                dgridBaotri.DataSource = tblbt;
                if (tblbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtThanhtien.Text != "")
            {
                sql = sql + "and thanhtien = N'" + txtThanhtien.Text + "'";
                tblbt = functions.GetDataToTable(sql);
                dgridBaotri.DataSource = tblbt;
                if (tblbt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtPhong.Text != "")
            {
                string tenphong = txtPhong.Text;
                string sqlphong = "select maphong from phong where tenphong like N'%" + tenphong + "%'";

                DataTable dtphong = functions.GetDataToTable(sqlphong);
                if (dtphong.Rows.Count > 0)
                {
                    string maphong = dtphong.Rows[0]["maphong"].ToString();
                    sql = sql + "and maphong = N'" + maphong + "'";
                    tblbt = functions.GetDataToTable(sql);
                    dgridBaotri.DataSource = tblbt;
                    if (tblbt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnHienthitatcaBT_Click(object sender, EventArgs e)
        {
            Load_DataGrid_BT();
            resetvalue_BT();
            txtPhong.Enabled = true;
            txtMaBT.Enabled = true;
            txtMamay.Enabled = true;
        }

        private void dgridBaotri_Click_1(object sender, EventArgs e)
        {
            string ma1;
            string ma2;
            if (btnThemBT.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaBT.Focus();
                return;
            }
            if (tblbt.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                return;
            }
            txtMaBT.Text = dgridBaotri.CurrentRow.Cells["Mabt"].Value.ToString();
            txtMamay.Text = dgridBaotri.CurrentRow.Cells["mamay"].Value.ToString();
            ma1 = dgridBaotri.CurrentRow.Cells["manbt"].Value.ToString();
            cboNBT.Text = Class.functions.getfieldvalues("Select Tennbt from nhabaotri where Manbt =N'" + ma1 + "'");
            txtTinhtrang.Text = dgridBaotri.CurrentRow.Cells["tinhtrang"].Value.ToString();
            txtNguyennhan.Text = dgridBaotri.CurrentRow.Cells["nguyennhan"].Value.ToString();
            txtGiaiphap.Text = dgridBaotri.CurrentRow.Cells["giaiphap"].Value.ToString();
            txtThanhtien.Text = dgridBaotri.CurrentRow.Cells["thanhtien"].Value.ToString();
            ma2 = dgridBaotri.CurrentRow.Cells["maphong"].Value.ToString();
            txtPhong.Text = Class.functions.getfieldvalues("select tenphong from phong where maphong =N'" + ma2 + "'");
            btnSuaBT.Enabled = true;
            btnXoaBT.Enabled = true;
            btnBoquaBT.Enabled = true;
            txtMaBT.Enabled = false;
            txtMamay.Enabled = false;
            txtPhong.Enabled = false;

        }
    }
}
