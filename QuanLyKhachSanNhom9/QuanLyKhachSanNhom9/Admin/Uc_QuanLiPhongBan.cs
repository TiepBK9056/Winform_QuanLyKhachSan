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
    public partial class Uc_QuanLiPhongBan : Form
    {
        public delegate void LoadTrang(object sender, EventArgs e);
        public LoadTrang loadTrangForm;

        //  public event EventHandler QuanLiPhongBanFormClosed;
        QLKSContextDB listphongban = new QLKSContextDB();
        public Uc_QuanLiPhongBan()
        {
            InitializeComponent();

        }




        private void Uc_QuanLiPhongBan_Load(object sender, EventArgs e)
        {
            List<PhongBan> phongBans = listphongban.PhongBans.ToList();
            BingGridDataView(phongBans);
        }

        private void BingGridDataView(List<PhongBan> phongBans)
        {
            dgvphongban.Rows.Clear();
            foreach (var item in phongBans)
            {
                int index = dgvphongban.Rows.Add();
                dgvphongban.Rows[index].Cells[0].Value = item.ID_PhongBan;
                dgvphongban.Rows[index].Cells[1].Value = item.Name;

            }
        }
        private void btthem_Click(object sender, EventArgs e)
        {
            try
            {
                string ID_Phongban = textIDphongban.Text.Trim();
                string tenPhongBan = textTenPhongBan.Text.Trim();

                // Kiểm tra xem tên phòng ban có hợp lệ hay không
                if (string.IsNullOrEmpty(tenPhongBan))
                {
                    MessageBox.Show("Vui lòng nhập tên phòng ban.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo một đối tượng PhongBan mới và thêm vào cơ sở dữ liệu
                PhongBan newPhongBan = new PhongBan()
                {
                    ID_PhongBan = ID_Phongban,
                    Name = tenPhongBan
                };

                listphongban.PhongBans.Add(newPhongBan);
                listphongban.SaveChanges();

                // Cập nhật lại DataGridView sau khi thêm
                List<PhongBan> phongBans = listphongban.PhongBans.ToList();
                BingGridDataView(phongBans);

                // Xóa nội dung TextBox sau khi thêm thành công
                textTenPhongBan.Clear();

                // Đặt tiêu điểm (focus) ở dòng cuối cùng của DataGridView
                dgvphongban.CurrentCell = dgvphongban.Rows[dgvphongban.Rows.Count - 1].Cells[0];
                dgvphongban.Rows[dgvphongban.Rows.Count - 1].Selected = true;

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
                string ID_Phongban = textIDphongban.Text.Trim();
                string tenPhongBan = textTenPhongBan.Text.Trim();

                // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
                if (string.IsNullOrEmpty(ID_Phongban) || string.IsNullOrEmpty(tenPhongBan))
                {
                    MessageBox.Show("Vui lòng chọn một phòng ban từ danh sách và cập nhật tên phòng ban.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem có phòng ban có mã ID_Phongban trong cơ sở dữ liệu không
                PhongBan phongBan = listphongban.PhongBans.FirstOrDefault(p => p.ID_PhongBan == ID_Phongban);

                if (phongBan != null)
                {
                    // Cập nhật tên phòng ban
                    phongBan.Name = tenPhongBan;
                    listphongban.SaveChanges();

                    // Cập nhật lại DataGridView sau khi sửa
                    List<PhongBan> phongBans = listphongban.PhongBans.ToList();
                    BingGridDataView(phongBans);

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

        private void btxoa_Click(object sender, EventArgs e)
        {
            try
            {

                // Kiểm tra xem người dùng đã chọn một dòng để xóa chưa
                if (dgvphongban.SelectedRows.Count > 0)
                {
                    // Lấy ID của phòng ban cần xóa từ DataGridView
                    string ID_PhongBan = dgvphongban.SelectedRows[0].Cells[0].Value?.ToString();

                    // Xác nhận việc xóa phòng ban
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Thực hiện xóa dữ liệu trong cơ sở dữ liệu
                        PhongBan phongBanToDelete = listphongban.PhongBans.FirstOrDefault(p => p.ID_PhongBan == ID_PhongBan);
                        if (phongBanToDelete != null)
                        {
                            listphongban.PhongBans.Remove(phongBanToDelete);
                            listphongban.SaveChanges();

                            // Cập nhật lại DataGridView sau khi xóa
                            List<PhongBan> phongBans = listphongban.PhongBans.ToList();
                            BingGridDataView(phongBans);

                            MessageBox.Show("Xóa phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy phòng ban để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một phòng ban để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadTrangForm?.Invoke(this, e);

        }

        private void btload_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy danh sách phòng ban từ cơ sở dữ liệu
                List<PhongBan> phongBans = listphongban.PhongBans.ToList();

                // Hiển thị danh sách phòng ban trong DataGridView
                BingGridDataView(phongBans);

                MessageBox.Show("Tải danh sách phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void bttimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = texttimkiem.Text.Trim();

                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    // Gọi hàm TimKiemPhongBan để tìm phòng ban
                    TimKiemPhongBan(tuKhoa);
                }
                else
                {
                    // Nếu từ khóa tìm kiếm rỗng, thì hiển thị lại tất cả phòng ban
                    List<PhongBan> phongBans = listphongban.PhongBans.ToList();

                    // Hiển thị danh sách phòng ban trong DataGridView
                    BingGridDataView(phongBans);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btclose_Click(object sender, EventArgs e)
        {
            loadTrangForm?.Invoke(this, e);
            this.Close();
        }
        private void TimKiemPhongBan(string tuKhoa)
        {
            try
            {
                // Lấy danh sách phòng ban từ cơ sở dữ liệu
                List<PhongBan> phongBans = listphongban.PhongBans.ToList();

                // Tạo danh sách để lưu các phòng ban phù hợp với từ khóa tìm kiếm
                List<PhongBan> ketQuaTimKiem = new List<PhongBan>();

                // Lặp qua danh sách phòng ban và kiểm tra xem tên phòng ban có chứa từ khóa tìm kiếm không
                foreach (var phongBan in phongBans)
                {
                    if (phongBan.Name.Contains(tuKhoa))
                    {
                        ketQuaTimKiem.Add(phongBan);
                    }
                }

                // Hiển thị danh sách phòng ban tìm kiếm được trong DataGridView
                BingGridDataView(ketQuaTimKiem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvphongban_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {

                DataGridViewRow row1 = dgvphongban.Rows[e.RowIndex];

                textIDphongban.Text = row1.Cells[0].Value?.ToString();
                textTenPhongBan.Text = row1.Cells[1].Value?.ToString();



            }

        }

        private void textTenPhongBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }



        private void texttimkiem_Click(object sender, EventArgs e)
        {
            texttimkiem.Clear();
        }

        private void textIDphongban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn người dùng nhập ký tự đặc biệt hoặc dấu cách
            }
        }
    }

}
