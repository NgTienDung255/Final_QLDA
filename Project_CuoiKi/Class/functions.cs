using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project_CuoiKi.Class
{
    internal class functions
    {
        public static SqlConnection conn; // Declare the connection object
        public static string connstring; // Declare the variable to hold the connection string

        public static void ketnoi()
        {
            // Corrected connection string
            connstring = "Data Source=DESKTOP-T0ROIGQ;Initial Catalog=Project_C#;Integrated Security=True;Encrypt=False";
            conn = new SqlConnection(connstring);
            conn.ConnectionString = connstring;
            conn.Open();
        }
        public static DataTable GetDataToTable(string sql) //Lấy dữ liệu vào datagridview
        {
            SqlDataAdapter Mydata = new SqlDataAdapter();
            Mydata.SelectCommand = new SqlCommand();
            Mydata.SelectCommand.Connection = functions.conn;
            Mydata.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            Mydata.Fill(table);
            return table;
        }

        public static bool CheckKey(string sql)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, functions.conn);
            DataTable table = new DataTable();
            mydata.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public static void runsql(string sql)
        {
            SqlCommand cmd;
            cmd = new SqlCommand(sql);
            cmd.Connection = functions.conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (System.Exception loi)
            {
                MessageBox.Show(loi.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static bool isdate(string d)
        {
            string[] parts = d.Split('/');
            if ((Convert.ToInt32(parts[0]) >= 1) && (Convert.ToInt32(parts[0]) <= 31) && (Convert.ToInt32(parts[1]) >= 1) && (Convert.ToInt32(parts[1]) <= 12) && (Convert.ToInt32(parts[2]) >= 1900))
                return true;
            else
                return false;
        }

        public static string convertdatetime(string d)
        {
            string[] parts = d.Split('/');
            if (parts.Length != 3)
            {
                throw new ArgumentException("Chuỗi không đúng định dạng dd/MM/yyyy.");
            }
            string dt = string.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            return dt;
        }
        public static void fillcombo(string sql, ComboBox cbo, string ma, string ten)
        {
            SqlDataAdapter mydata = new SqlDataAdapter(sql, Class.functions.conn);
            DataTable table = new DataTable();
            mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;

        }

        public static string getfieldvalues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Class.functions.conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        public static string ChuyenSoSangChu(string sNumber)
        {
            int mLen, mDigit;
            string mTemp = "";
            string[] mNumText;
            //Xóa các dấu "," nếu có
            sNumber = sNumber.Replace(",", "");
            mNumText =
           "không;một;hai;ba;bốn;năm;sáu;bảy;tám;chín".Split(';');
            mLen = sNumber.Length - 1; // trừ 1 vì thứ tự đi từ 0
            for (int i = 0; i <= mLen; i++)
            {
                mDigit = Convert.ToInt32(sNumber.Substring(i, 1));
                mTemp = mTemp + " " + mNumText[mDigit];
                if (mLen == i) // Chữ số cuối cùng không cần xét tiếp
                    break;
                switch ((mLen - i) % 9)
                {
                    case 0:
                        mTemp = mTemp + " tỷ";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 6:
                        mTemp = mTemp + " triệu";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                        break;
                    case 3:
                        mTemp = mTemp + " nghìn";
                        if (sNumber.Substring(i + 1, 3) == "000")
                            i = i + 3;
                break;
                    default:
                        switch ((mLen - i) % 3)
                        {
                            case 2:
                                mTemp = mTemp + " trăm";
                                break;
                            case 1:
                                mTemp = mTemp + " mươi";
                                break;
                        }
                        break;
                }
            }
            //Loại bỏ trường hợp x00
            mTemp = mTemp.Replace("không mươi không ", "");
            mTemp = mTemp.Replace("không mươi không", "");
            //Loại bỏ trường hợp 00x
            mTemp = mTemp.Replace("không mươi ", "linh ");
            //Loại bỏ trường hợp x0, x>=2
            mTemp = mTemp.Replace("mươi không", "mươi");
            //Fix trường hợp 10
            mTemp = mTemp.Replace("một mươi", "mười");
            //Fix trường hợp x4, x>=2
            mTemp = mTemp.Replace("mươi bốn", "mươi tư");
            //Fix trường hợp x04
            mTemp = mTemp.Replace("linh bốn", "linh tư");
            //Fix trường hợp x5, x>=2
            mTemp = mTemp.Replace("mươi năm", "mươi lăm");
            //Fix trường hợp x1, x>=2
            mTemp = mTemp.Replace("mươi một", "mươi mốt");
            //Fix trường hợp x15
            mTemp = mTemp.Replace("mười năm", "mười lăm");
            //Bỏ ký tự space
            mTemp = mTemp.Trim();
            //Viết hoa ký tự đầu tiên
            mTemp = mTemp.Substring(0, 1).ToUpper() + mTemp.Substring(1)
           + " đồng";
            return mTemp;
        }

        public static int GetTotalMachines1()
        {
            string sql1 = "SELECT COUNT(*) FROM May where maphong = 'P01'";

            using (SqlCommand command = new SqlCommand(sql1, conn))
            {
                try
                {
                    // Thực hiện truy vấn và trả về kết quả
                    return (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có và trả về giá trị mặc định
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    return 0;
                }
            }
        }
        public static int GetTotalMachines2()
        {
            string sql2 = "SELECT COUNT(*) FROM May where maphong = 'P02'";

            using (SqlCommand command = new SqlCommand(sql2, conn))
            {
                try
                {
                    // Thực hiện truy vấn và trả về kết quả
                    return (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có và trả về giá trị mặc định
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    return 0;
                }
            }
        }

        public static int GetTotalMachines3()
        {
            string sql3 = "SELECT COUNT(*) FROM May where maphong = 'P03'";

            using (SqlCommand command = new SqlCommand(sql3, conn))
            {
                try
                {
                    // Thực hiện truy vấn và trả về kết quả
                    return (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có và trả về giá trị mặc định
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                    return 0;
                }
            }
        }

        public static string GenerateMaHDB()
        {
            string maHDB = "";
            int count;
            string sql = "SELECT COUNT(*) FROM HoaDonBan";
            SqlCommand cmd = new SqlCommand(sql, conn);
            count = (int)cmd.ExecuteScalar() + 1;
            maHDB = "HDB" + count.ToString("D4");
            return maHDB;
        }

    }
}
