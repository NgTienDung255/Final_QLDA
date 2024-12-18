using DocumentFormat.OpenXml.VariantTypes;
using Microsoft.Office.Interop.Excel;
using Project_CuoiKi.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CuoiKi.All_User_Control
{
    public partial class UC_ThemThietBi : UserControl
    {
        System.Data.DataTable tblthietbi;
        System.Data.DataTable tblloaithietbi;
        System.Data.DataTable tblnhomthietbi;
        public UC_ThemThietBi()
        {
            InitializeComponent();
            functions.ketnoi();
            load_datagridview(); // loai thiet bi
            Load_DataGridView(); // thiet bi
            Load_datagridviewtbi(); // nhom thiet tbi
        }
        private void UC_ThemThietBi_Load(object sender, EventArgs e)
        {
            txtmathietbi.Enabled = false;
            btnluu.Enabled = false;
            btnboqua.Enabled = false;
            functions.fillcombo("SELECT MaLoaiTB,TenLoaiTB  FROM LoaiThietBi", cboloaithietbi, "MaLoaiTB", "TenLoaiTB");
            cboloaithietbi.SelectedIndex = -1;
            functions.fillcombo("SELECT MaNhomTB,TenNhomTB  FROM NhomThietBi", cbonhomthietbi, "MaNhomTB", "TenNhomTB");
            cbonhomthietbi.SelectedIndex = -1;
            txtmanhomthietbi.Enabled = false;
            btnluu2.Enabled = false;
            btnboqua2.Enabled = false;
            txtmaloaithietbi.Enabled = false;
            btnluu1.Enabled = false;
            btnboqua1.Enabled = false;
            if (tabControl1.SelectedIndex == 0)

            {
                
                Load_DataGridView();
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                
                load_datagridview();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                
                Load_datagridviewtbi();
            }
        }
        private void Load_datagridviewtbi()
        {
            string sql = "SELECT * FROM NhomThietBi";
            tblnhomthietbi = functions.GetDataToTable(sql);
            if (tblnhomthietbi.Rows.Count > 0)
            {
                dgridnhomthietbi.DataSource = tblnhomthietbi;
                dgridnhomthietbi.Columns[0].HeaderText = "Mã Nhóm Thiết Bị";
                dgridnhomthietbi.Columns[1].HeaderText = "Tên Nhóm Thiết Bị";
                dgridnhomthietbi.Columns[0].Width = 150;
                dgridnhomthietbi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgridnhomthietbi.RowHeadersWidth = 50;
                dgridnhomthietbi.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!");
            }
            dgridnhomthietbi.AllowUserToAddRows = false;
            dgridnhomthietbi.EditMode = DataGridViewEditMode.EditProgrammatically;


            Class.functions.ketnoi();
        }
        private void Load_DataGridView()
        {
            string sql = "SELECT * FROM ThietBi";
            tblthietbi = functions.GetDataToTable(sql);
            dgridthietbi.DataSource = tblthietbi;
            dgridthietbi.Columns[0].HeaderText = "Mã Thiết Bị";
            dgridthietbi.Columns[1].HeaderText = "Tên Thiết Bị";
            dgridthietbi.Columns[2].HeaderText = "Mã Loại Thiết Bị";
            dgridthietbi.Columns[3].HeaderText = "Mã Nhóm Thiết Bị";
            dgridthietbi.Columns[4].HeaderText = "Mã Nhà Cung Cấp";
            dgridthietbi.Columns[5].HeaderText = "Giá";
            dgridthietbi.Columns[6].HeaderText = "Bảo Hành";
            dgridthietbi.Columns[7].HeaderText = "Số Lượng";

            foreach (DataGridViewColumn col in dgridthietbi.Columns)
            {
                col.Width = 100;
            }
            dgridthietbi.AllowUserToAddRows = false;
            dgridthietbi.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgridthietbi.AllowUserToAddRows = false;
            dgridthietbi.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void load_datagridview()
        {
            string sql = "SELECT * FROM LoaiThietBi";
            tblloaithietbi = functions.GetDataToTable(sql);

            if (tblloaithietbi.Rows.Count > 0)
            {
                dgridloaithietbi.DataSource = tblloaithietbi;
                dgridloaithietbi.Columns[0].HeaderText = "Mã Loại Thiết Bị";
                dgridloaithietbi.Columns[1].HeaderText = "Tên Loại Thiết Bị";
                dgridloaithietbi.Columns[0].Width = 150; 
                dgridloaithietbi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgridloaithietbi.RowHeadersWidth = 50;
                dgridloaithietbi.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                dgridloaithietbi.AllowUserToAddRows = false;
                dgridloaithietbi.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu loại thiết bị!");
            }
            dgridloaithietbi.AllowUserToAddRows = false;
            dgridloaithietbi.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
   
        private void ResetValues()
        {
            txtmathietbi.Text = "";
            txttenthietbi.Text = "";
            cboloaithietbi.Text = "";
            cbonhomthietbi.Text = "";
            txtmanhacungcap.Text = "";
            txtgia.Text = "";
            txtbaohanh.Text = "";
            txtsoluong  .Text = "";

        }
        private void btnthem_Click(object sender, EventArgs e)
        {
    
            txtmathietbi.ReadOnly = false;
            txttenthietbi.ReadOnly = false;
            txtmanhacungcap.ReadOnly = false;
            txtgia.ReadOnly = false;
            txtbaohanh.ReadOnly = false;
            txtsoluong.ReadOnly = false;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnboqua.Enabled = true;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            ResetValues();
            txtmathietbi.Enabled = true;
            txttenthietbi.Focus();
        }
        private void dgridthietbi_Click(object sender, EventArgs e)
        {
            functions.fillcombo("SELECT MaLoaiTB,TenLoaiTB  FROM LoaiThietBi", cboloaithietbi, "MaLoaiTB", "TenLoaiTB");
            cboloaithietbi.SelectedIndex = -1;
            functions.fillcombo("SELECT MaNhomTB,TenNhomTB  FROM NhomThietBi", cbonhomthietbi, "MaNhomTB", "TenNhomTB");
            cbonhomthietbi.SelectedIndex = -1;
            if (btnthem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmathietbi.Focus();
                return;
            }

            if (tblthietbi.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmathietbi.Text = dgridthietbi.CurrentRow.Cells["MaTB"].Value.ToString();
            txttenthietbi.Text = dgridthietbi.CurrentRow.Cells["TenTB"].Value.ToString();
            cboloaithietbi.SelectedValue = dgridthietbi.CurrentRow.Cells["MaLoaiTB"].Value.ToString();
            cbonhomthietbi.SelectedValue = dgridthietbi.CurrentRow.Cells["MaNhomTB"].Value.ToString();
            txtmanhacungcap.Text = dgridthietbi.CurrentRow.Cells["MaNCC"].Value.ToString();
            txtgia.Text = dgridthietbi.CurrentRow.Cells["Gia"].Value.ToString();
            txtbaohanh.Text = dgridthietbi.CurrentRow.Cells["BaoHanh"].Value.ToString();
            txtsoluong.Text = dgridthietbi.CurrentRow.Cells["SoLuong"].Value.ToString();

            btnsua.Enabled = true;
            btnxoa.Enabled = true;
            btnboqua.Enabled = true;
            btnluu.Enabled = false; 
            //txtmathietbi.Enabled = false;
            //txttenthietbi.Enabled = false;
            //cboloaithietbi.Enabled = false;
            //cbonhomthietbi.Enabled=false;
            //txtmanhacungcap.Enabled = false;
            //txtgia.Enabled = false;
            //txtsoluong.Enabled = false;
            //txtbaohanh.Enabled = false;
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            {
                if (txtmathietbi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmathietbi.Focus();
                    return;
                }
                if (txttenthietbi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttenthietbi.Focus();
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
                if (txtmanhacungcap.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtmanhacungcap.Focus();
                    return;
                }
                if (txtgia.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giá thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtgia.Focus();
                    return;
                }
                if (txtbaohanh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập thời gian bảo hành", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbaohanh.Focus();
                    return;
                }
                if (txtsoluong.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập số lượng thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtsoluong.Focus();
                    return;
                }
                string sql = "INSERT INTO ThietBi (MaTB, TenTB, MaLoaiTB, MaNhomTB, MaNCC, Gia, BaoHanh, SoLuong) VALUES (N'" + txtmathietbi.Text.Trim() + "', N'" + txttenthietbi.Text.Trim() + "', N'" + cboloaithietbi.SelectedValue.ToString() + "', N'" + cbonhomthietbi.SelectedValue + "', N'" + txtmanhacungcap.Text.Trim() + "', N'" + txtgia.Text.Trim() + "', N'" + txtbaohanh.Text.Trim() + "', N'" + txtsoluong.Text.Trim() + "')"; functions.runsql(sql);
                Load_DataGridView();
                ResetValues();
                btnxoa.Enabled = true;
                btnthem.Enabled = true;
                btnsua.Enabled = true;
                btnboqua.Enabled = true;
                btnluu.Enabled = false;
                txtmathietbi.Enabled = false;
            }
        }

        private void btndong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               this.Hide();
            }
        }
        private void btnboqua_Click(object sender, EventArgs e)
        {
  

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thực hiện bỏ qua?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ResetValues();
                    btnboqua.Enabled = false;
                    btnthem.Enabled = true;
                    btnxoa.Enabled = true;
                    btnsua.Enabled = true;
                    btnluu.Enabled = false;
                    txtmathietbi.Enabled = false;
                }
            
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
                string sql;
                if (tblthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
                if (txtmathietbi.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (txttenthietbi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập tên thiết bị", "Thông báo",MessageBoxButtons.OK,
                   MessageBoxIcon.Warning);
                    txttenthietbi.Focus();
                    return;
                }
                if (cboloaithietbi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn loại thiết bị", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboloaithietbi.Focus();
                    return;
                }
                if (cbonhomthietbi.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải chọn loại thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbonhomthietbi.Focus();
                    return;
                }
            if (txtmanhacungcap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtmanhacungcap.Focus();
                return;
            }
            if (txtgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giá", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtgia.Focus();
                return;
            }
            if (txtbaohanh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tthời hạn bảo hành", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtbaohanh.Focus();
                return;
            }
            if (txtsoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên thiết bị", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtsoluong.Focus();
                return;
            }

            sql = "UPDATE ThietBi SET TenTB = N'" + txttenthietbi.Text.Trim().ToString() +
               "', MaLoaiTB = N'" + cboloaithietbi.SelectedValue.ToString() +
               "',MaNhomTB = N'" + cbonhomthietbi.SelectedValue.ToString() + "'," +
               " MaNCC = N'" + txtmanhacungcap.Text +
               "', Gia = N'" + txtgia.Text +
               "', BaoHanh = N'" + txtbaohanh.Text + "',SoLuong = N'" + txtsoluong.Text + "' where MaTB = N'" + txtmathietbi.Text + "'";
               
                functions.runsql(sql);
                Load_DataGridView();
                ResetValues();
                btnboqua.Enabled = true;
            }
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (tblthietbi.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmathietbi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM ThietBi WHERE MaTB = '" + txtmathietbi.Text + "'";
                functions.runsql(sql);
                Load_DataGridView();
                ResetValues();
            }
        }
        private void dgridloaithietbi_Click(object sender, EventArgs e)
        {
            if (btnthem1.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmathietbi.Focus();
                return;
            }

            if (tblloaithietbi.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmaloaithietbi.Text = dgridloaithietbi.CurrentRow.Cells["MaLoaiTB"].Value.ToString();
            txttenloaithietbi.Text = dgridloaithietbi.CurrentRow.Cells["TenLoaiTB"].Value.ToString();
            //txtmaloaithietbi.ReadOnly = true;
            //txttenloaithietbi.ReadOnly = true;
            btnsua1.Enabled = true;
            btnxoa1.Enabled = true;
            btnboqua1.Enabled = true;
            btnluu1.Enabled = false;

        }
        private void dgridnhomthietbi_Click(object sender, EventArgs e)
        {
            if (btnthem2.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmanhomthietbi.Focus();
                return;
            }

            if (tblnhomthietbi.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtmanhomthietbi.Text = dgridnhomthietbi.CurrentRow.Cells["MaNhomTB"].Value.ToString();
            txttennhomthietbi.Text = dgridnhomthietbi.CurrentRow.Cells["TenNhomTB"].Value.ToString();
            txtmanhomthietbi.Enabled = true;
            txttenloaithietbi.Enabled=true;
            btnsua2.Enabled = true;
            btnxoa2.Enabled = true;
            btnsua.Enabled = true;
            btnboqua2.Enabled = false;
            btnluu2.Enabled = false;
        }

        private void btnthem1_Click(object sender, EventArgs e)
        {
            txtmaloaithietbi.ReadOnly = false;
            txttenloaithietbi.ReadOnly = false;
            btnsua1.Enabled = false;
            btnxoa1.Enabled = false;
            btnboqua1.Enabled = true;
            btnluu1.Enabled = true;
            btnthem1.Enabled = false;
            Resetvalues(); // Resetvalues cho form loai thiet bi
            txtmaloaithietbi.Enabled = true;
            txtmaloaithietbi.Focus();
        }
        private void Resetvalues()
        {
            txtmaloaithietbi.Text = "";
            txttenloaithietbi.Text = "";
        }

        private void btnsua1_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblloaithietbi.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (txtmaloaithietbi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttenloaithietbi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloaithietbi.Focus();
                return;
            }
            sql = "UPDATE LoaiThietBi SET TenLoaiTB=N'" + txttenloaithietbi.Text.ToString() +"' WHERE MaLoaiTB=N'" + txtmaloaithietbi.Text + "'";
            Class.functions.runsql(sql);
            load_datagridview();
            Resetvalues();
            btnboqua1.Enabled = false;

        }

        private void btnluu1_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmaloaithietbi.Text =="")
            {
                MessageBox.Show("Bạn phải nhập mã loại thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloaithietbi.Focus();
                return;
            }
            if (txttenloaithietbi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên loại thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttenloaithietbi.Focus();
                return;
            }
            sql = "SELECT MaLoaiTB FROM LoaiThietBi WHERE MaLoaiTB = N'" + txtmaloaithietbi.Text.Trim() + "'";
            
            if (Class.functions.CheckKey(sql))
            {
            MessageBox.Show("Mã loại chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaloaithietbi.Focus();
                txtmaloaithietbi.Text = "";
                return;
            }
            sql = "INSERT INTO LoaiThietBi(MaLoaiTB,TenLoaiTB) VALUES(N'" + txtmaloaithietbi.Text + "',N'" + txttenloaithietbi.Text + "')";
            Class.functions.runsql(sql);
            load_datagridview();        
            btnxoa1.Enabled = true;
            btnthem1.Enabled = true;
            btnsua1.Enabled = true;
            btnboqua1.Enabled = false;
            btnluu1.Enabled = false;
            Resetvalues();
        }

        private void btnboqua1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thực hiện bỏ qua?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Resetvalues();
                btnboqua1.Enabled = false;
                btnthem1.Enabled = true;
                btnxoa1.Enabled = true;
                btnsua1.Enabled = true;
                btnluu1.Enabled = false;
            }
        }


        private void btndong1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng cửa sổ thiết bị?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                
                this.Hide();
            }
        }

        private void btnxoa1_Click(object sender, EventArgs e)
        {
             
            if (tblloaithietbi.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmaloaithietbi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM LoaiThietBi WHERE MaLoaiTB = '" + txtmaloaithietbi.Text + "'";
                functions.runsql(sql);
                load_datagridview();
                Resetvalues();
            }
        }
        private void btnthem2_Click(object sender, EventArgs e)
        {
            txtmanhomthietbi.ReadOnly = false;
            txttennhomthietbi.ReadOnly = false;
            btnsua2.Enabled = false;
            btnxoa2.Enabled = false;
            btnboqua2.Enabled = true;
            btnluu2.Enabled = true;
            btnthem2.Enabled = false;
            resetvaluestbi(); // Resetvalues cho form loai thiet bi
            txtmanhomthietbi.Enabled = true;
            txttennhomthietbi.Focus();
        }
        private void resetvaluestbi()
        {
            txtmanhomthietbi.Text = "";
            txttennhomthietbi.Text = "";
        } 
        private void btnsua2_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblnhomthietbi.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanhomthietbi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txttennhomthietbi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhóm thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennhomthietbi.Focus();
                return;
            }
            sql = "UPDATE NhomThietBi SET TenNhomTB=N'" + txttennhomthietbi.Text.ToString() + "' WHERE MaNhomTB=N'" + txtmanhomthietbi.Text + "'";
            Class.functions.runsql(sql);
            Load_datagridviewtbi();
            resetvaluestbi();
            btnboqua2.Enabled = false;
        }
        private void btnluu2_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtmanhomthietbi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhóm thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhomthietbi.Focus();
                return;
            }
            if (txttennhomthietbi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhóm thiết bị", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttennhomthietbi.Focus();
                return;
            }
            sql = "SELECT MaNhomTB FROM NhomThietBi WHERE MaNhomTB = N'" + txtmanhomthietbi.Text.Trim() + "'";
            if (Class.functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmanhomthietbi.Focus();
                txtmanhomthietbi.Text = "";
                return;
            }
            sql = "INSERT INTO NhomThietBi(MaNhomTB,TenNhomTB) VALUES(N'" + txtmanhomthietbi.Text + "',N'" + txttennhomthietbi.Text + "')";
            Class.functions.runsql(sql);
            Load_datagridviewtbi();
            btnxoa2.Enabled = true;
            btnthem2.Enabled = true;
            btnsua2.Enabled = true;
            btnboqua2.Enabled = false;
            btnluu2.Enabled = false;
            txtmanhomthietbi.Enabled = false;
        }
        private void btnboqua2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thực hiện bỏ qua?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Resetvalues();
                btnboqua2.Enabled = false;
                btnthem2.Enabled = true;
                btnxoa2.Enabled = true;
                btnsua2.Enabled = true;
                btnluu2.Enabled = false;
            }
        }
        private void btndong2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng cửa sổ thiết bị?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }
        private void btnxoa2_Click(object sender, EventArgs e)
        {
            if (tblnhomthietbi.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtmanhomthietbi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sql = "DELETE FROM NhomThietBi WHERE MaNhomTB = '" + txtmanhomthietbi.Text + "'";
                functions.runsql(sql);
                Load_datagridviewtbi();
                resetvaluestbi();
            }
        }

        private void dgridthietbi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        //TÌM KIẾM THIẾT BỊ
        private void btnTimkiemTB_Click(object sender, EventArgs e)
        {
            if((txtmathietbi.Text=="")&&(txttenthietbi.Text=="")&&(cboloaithietbi.Text=="")&&(cbonhomthietbi.Text=="")&&(txtmanhacungcap.Text=="")&&(txtgia.Text=="")&&(txtbaohanh.Text=="")&&(txtsoluong.Text==""))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from thietbi where 1=1";
            if(txtmathietbi.Text!="")
            {
                sql = sql + "and matb like N'%"+txtmathietbi.Text+"%'";
                tblthietbi = functions.GetDataToTable(sql);
                dgridthietbi.DataSource = tblthietbi;
                if (tblthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txttenthietbi.Text != "")
            {
                sql = sql + "and tentb like N'%" + txttenthietbi.Text + "%'";
                tblthietbi = functions.GetDataToTable(sql);
                dgridthietbi.DataSource = tblthietbi;
                if (tblthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            if (cboloaithietbi.SelectedIndex != -1)
            {
                if (cboloaithietbi.SelectedIndex != -1)
                {
                    string maltb = cboloaithietbi.SelectedValue.ToString();
                    sql += " AND maloaitb = N'" + maltb + "'";
                    System.Data.DataTable tblltb = functions.GetDataToTable(sql);
                    dgridthietbi.DataSource = tblltb;
                    if (tblltb.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (cbonhomthietbi.SelectedIndex != -1)
            {
                if (cbonhomthietbi.SelectedIndex != -1)
                {
                    string mantb = cbonhomthietbi.SelectedValue.ToString();
                    sql += " AND manhomtb = N'" + mantb + "'";
                    System.Data.DataTable tblntb = functions.GetDataToTable(sql);
                    dgridthietbi.DataSource = tblntb;
                    if (tblntb.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (txtmanhacungcap.Text != "")
            {
                sql = sql + "and mancc like N'%" + txtmanhacungcap.Text + "%'";
                tblthietbi = functions.GetDataToTable(sql);
                dgridthietbi.DataSource = tblthietbi;
                if (tblthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if(txtgia.Text != "")
            {
                sql = sql + "and gia = N'"+txtgia.Text+"'";
                tblthietbi = functions.GetDataToTable(sql);
                dgridthietbi.DataSource = tblthietbi;
                if (tblthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (txtbaohanh.Text != "")
            {
                sql = sql + "and baohanh = N'" + txtbaohanh.Text + "'";
                tblthietbi = functions.GetDataToTable(sql);
                dgridthietbi.DataSource = tblthietbi;
                if (tblthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txtsoluong.Text != "")
            {
                sql = sql + "and soluong = N'" + txtsoluong.Text + "'";
                tblthietbi = functions.GetDataToTable(sql);
                dgridthietbi.DataSource = tblthietbi;
                if (tblthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        private void btnHienthiTB_Click(object sender, EventArgs e)
        {
            Load_DataGridView();
            txtmathietbi.Text = "";
            txttenthietbi.Text = "";
            cboloaithietbi.SelectedIndex = -1;
            cbonhomthietbi.SelectedIndex = -1;
            txtmanhacungcap.Text = "";
            txtgia.Text = "";
            txtbaohanh.Text = "";
            txtsoluong.Text = "";
        }



        //TÌM KIẾM LOẠI THIẾT BỊ
        private void btnTimkiemLTB_Click(object sender, EventArgs e)
        {
            if ((txtmaloaithietbi.Text == "") && (txttenloaithietbi.Text ==""))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from loaithietbi where 1=1";
            if(txtmaloaithietbi.Text!="")
            {
                sql = sql + "and maloaitb like N'%" + txtmaloaithietbi.Text + "%'";
                tblloaithietbi = functions.GetDataToTable(sql);
                dgridloaithietbi.DataSource = tblloaithietbi;
                if (tblloaithietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txttenloaithietbi.Text != "")
            {
                sql = sql + "and tenloaitb like N'%" + txttenloaithietbi.Text + "%'";
                tblloaithietbi = functions.GetDataToTable(sql);
                dgridloaithietbi.DataSource = tblloaithietbi;
                if (tblloaithietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnHienthiLTB_Click(object sender, EventArgs e)
        {
            load_datagridview();
            txtmaloaithietbi.Text = "";
            txttenloaithietbi.Text = "";
        }


        //TÌM KIẾM NHÓM THIÉT BỊ

        private void btnTimkiemNTB_Click(object sender, EventArgs e)
        {
            if ((txtmanhomthietbi.Text == "") && (txttennhomthietbi.Text == ""))
            {
                MessageBox.Show("Bạn phải nhập 1 điều kiện tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            string sql;
            sql = "select * from nhomthietbi where 1=1";
            if (txtmanhomthietbi.Text != "")
            {
                sql = sql + "and manhomtb like N'%" + txtmanhomthietbi.Text + "%'";
                tblnhomthietbi = functions.GetDataToTable(sql);
                dgridnhomthietbi.DataSource = tblnhomthietbi;
                if (tblnhomthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txttennhomthietbi.Text != "")
            {
                sql = sql + "and tennhomtb like N'%" + txttennhomthietbi.Text + "%'";
                tblnhomthietbi = functions.GetDataToTable(sql);
                dgridnhomthietbi.DataSource = tblnhomthietbi;
                if (tblnhomthietbi.Rows.Count == 0)
                {
                    MessageBox.Show("Không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnHienthiNTB_Click(object sender, EventArgs e)
        {
            Load_datagridviewtbi();
            txtmanhomthietbi.Text = "";
            txttennhomthietbi.Text = "";
        }
    }    
}

