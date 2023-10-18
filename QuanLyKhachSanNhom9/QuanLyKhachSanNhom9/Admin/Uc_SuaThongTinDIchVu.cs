using QuanLyKhachSanNhom9.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSanNhom9.Admin
{
    public partial class Uc_SuaThongTinDIchVu : Form
    {
        public delegate void LoadTrang(object sender, EventArgs e);
        public LoadTrang loadTrangForm;

        //   public event EventHandler QuanLiPhongBanFormClosed;
        QLKSContextDB suadichvu = new QLKSContextDB();
        public Uc_SuaThongTinDIchVu()
        {
            InitializeComponent();
        }

        private void Uc_SuaThongTinDIchVu_Load(object sender, EventArgs e)
        {
            List<DichVu> list = suadichvu.DichVus.ToList();
            BingGridDataView(list);
        }

        public void BingGridDataView(List<DichVu> dichVus)
        {
            dgvdichvu.Rows.Clear();
            foreach (var item in dichVus)
            {
                int index = dgvdichvu.Rows.Add();
                dgvdichvu.Rows[index].Cells[0].Value = item.ID_Service;
                dgvdichvu.Rows[index].Cells[1].Value = item.Name;
                dgvdichvu.Rows[index].Cells[2].Value = item.Price;
                // Kiểm tra xem có đường dẫn hình ảnh không


            }

        }
        private void btthemdv_Click(object sender, EventArgs e)
        {
            try
            {
                string ID_dichvu = textIDdichvu.Text.Trim();
                string tendichvu = textTenDichVu.Text.Trim();
                float giatien = float.Parse(textGiaTien.Text);
                // Kiểm tra xem tên phòng ban có hợp lệ hay không
                if (string.IsNullOrEmpty(tendichvu))
                {
                    MessageBox.Show("Vui lòng nhập tên phòng ban.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (suadichvu.DichVus.Any(p => p.ID_Service == ID_dichvu))
                {
                    MessageBox.Show("ID dịch vụ đã tồn tại. Vui lòng chọn một ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo một đối tượng PhongBan mới và thêm vào cơ sở dữ liệu
                DichVu newDichVu = new DichVu()
                {
                    ID_Service = ID_dichvu,
                    Name = tendichvu,
                    Price = giatien
                };

                suadichvu.DichVus.Add(newDichVu);
                suadichvu.SaveChanges();

                // Cập nhật lại DataGridView sau khi thêm
                List<DichVu> dichVus = suadichvu.DichVus.ToList();
                BingGridDataView(dichVus);

                // Xóa nội dung TextBox sau khi thêm thành công
                textTenDichVu.Clear();

                // Đặt tiêu điểm (focus) ở dòng cuối cùng của DataGridView
                dgvdichvu.CurrentCell = dgvdichvu.Rows[dgvdichvu.Rows.Count - 1].Cells[0];
                dgvdichvu.Rows[dgvdichvu.Rows.Count - 1].Selected = true;

                MessageBox.Show("Thêm phòng ban thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadTrangForm?.Invoke(this, e);
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                string ID_dichvu = textIDdichvu.Text.Trim();
                string tendichvu = textTenDichVu.Text.Trim();
                float giatien = float.Parse(textGiaTien.Text);

                // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
                if (string.IsNullOrEmpty(ID_dichvu) || string.IsNullOrEmpty(tendichvu))
                {
                    MessageBox.Show("Vui lòng chọn một phòng ban từ danh sách và cập nhật tên phòng ban.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                // Kiểm tra xem có phòng ban có mã ID_service trong cơ sở dữ liệu không
                DichVu dichVu = suadichvu.DichVus.FirstOrDefault(p => p.ID_Service == ID_dichvu);

                if (dichVu != null)
                {
                    // Cập nhật tên dịch vụ
                    //cập nhật giá tiền
                    dichVu.Name = tendichvu;
                    dichVu.Price = giatien;
                    suadichvu.SaveChanges();

                    // Cập nhật lại DataGridView sau khi sửa
                    List<DichVu> dichVus = suadichvu.DichVus.ToList();
                    BingGridDataView(dichVus);

                    MessageBox.Show("Cập nhật phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phòng ban để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadTrangForm?.Invoke(this, e);

        }

        private void btxoaDV_Click(object sender, EventArgs e)
        {
            if (dgvdichvu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa các dòng đã chọn?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvdichvu.SelectedRows)
                {
                    string ID_dichvu = row.Cells[0].Value?.ToString();
                    if (!string.IsNullOrEmpty(ID_dichvu))
                    {
                        DichVu dichvuToDelete = suadichvu.DichVus.FirstOrDefault(p => p.ID_Service == ID_dichvu);
                        if (dichvuToDelete != null)
                        {
                            suadichvu.DichVus.Remove(dichvuToDelete);
                        }
                    }
                }

                suadichvu.SaveChanges();

                // Cập nhật lại DataGridView sau khi xóa
                List<DichVu> dichVus = suadichvu.DichVus.ToList();
                BingGridDataView(dichVus);

                MessageBox.Show("Xóa dòng đã chọn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            loadTrangForm?.Invoke(this, e);
        }



        private void btload_Click(object sender, EventArgs e)
        {
            loadTrangForm?.Invoke(this, e);
            this.Close();

        }

        private void dgvdichvu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo người dùng đã chọn một dòng hợp lệ
            {
                // Lấy dữ liệu của dịch vụ được chọn
                string ID_dichvu = dgvdichvu.Rows[e.RowIndex].Cells[0].Value?.ToString();
                string tendichvu = dgvdichvu.Rows[e.RowIndex].Cells[1].Value?.ToString();
                string giatien = dgvdichvu.Rows[e.RowIndex].Cells[2].Value?.ToString();

                // Hiển thị thông tin chi tiết dịch vụ trong các TextBox hoặc các điều khiển khác trên giao diện của bạn
                textIDdichvu.Text = ID_dichvu;
                textTenDichVu.Text = tendichvu;
                textGiaTien.Text = giatien;

                // Bạn có thể thêm mã code khác để hiển thị thông tin chi tiết dịch vụ theo nhu cầu của bạn.
            }
        }

        private void textTenDichVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;


            if (!char.IsLetter(ch) && ch != 8 && ch != ' ') // 8 là mã ASCII của backspace
            {
                MessageBox.Show("Chỉ được nhập chữ cái!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void textGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Nếu người dùng nhập dấu chấm thập phân hoặc là số thì cho phép
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

            // Nếu đã có một dấu chấm thập phân và người dùng nhập thêm dấu chấm, thì chặn
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void textIDdichvu_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Danh sách các ký tự không dấu cho phép
            string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

            // Kiểm tra xem ký tự nhập vào có trong danh sách cho phép và có phải là backspace hay không
            if (!allowedChars.Contains(ch) && ch != 8) // 8 là mã ASCII của backspace
            {
                MessageBox.Show("Nhập đúng ký tự a-Z và '_'");
                e.Handled = true; // Ngăn chặn ký tự không phù hợp được nhập vào
            }
        }
    }
}
