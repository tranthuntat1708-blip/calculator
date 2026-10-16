using System;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        // Khai báo các control giao diện
        private Label lblTitle, lblSo1, lblSo2, lblKetQua;
        private TextBox txtSo1, txtSo2, txtKetQua;
        private Button btnCong, btnTru, btnNhan, btnChia;

        public Form1()
        {
            InitializeCustomUI();
        }

        private void InitializeCustomUI()
        {
            // Cấu hình Form chính
            this.Text = "Calculator";
            this.Size = new Size(380, 260);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Title
            lblTitle = new Label
            {
                Text = "CHƯƠNG TRÌNH TÍNH TOÁN ĐƠN GIẢN",
                Font = new Font("Arial", 11, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Location = new Point(30, 15),
                AutoSize = true
            };

            // Label & TextBox - Số thứ nhất
            lblSo1 = new Label { Text = "Số thứ nhất", Location = new Point(30, 50), AutoSize = true };
            txtSo1 = new TextBox { Location = new Point(130, 47), Width = 190 };

            // Label & TextBox - Số thứ hai
            lblSo2 = new Label { Text = "Số thứ hai", Location = new Point(30, 85), AutoSize = true };
            txtSo2 = new TextBox { Location = new Point(130, 82), Width = 190 };

            // Label & TextBox - Kết quả
            lblKetQua = new Label { Text = "Kết quả", Location = new Point(30, 120), AutoSize = true };
            txtKetQua = new TextBox { Location = new Point(130, 117), Width = 190, ReadOnly = true };

            // các nút Button phép tính
            btnCong = new Button { Text = "Cộng", Location = new Point(30, 165), Width = 65, Height = 30 };
            btnTru = new Button { Text = "Trừ", Location = new Point(105, 165), Width = 65, Height = 30 };
            btnNhan = new Button { Text = "Nhân", Location = new Point(180, 165), Width = 65, Height = 30 };
            btnChia = new Button { Text = "Chia", Location = new Point(255, 165), Width = 65, Height = 30 };

            // Gán sự kiện Click
            btnCong.Click += (s, e) => ExecuteCal("+");
            btnTru.Click += (s, e) => ExecuteCal("-");
            btnNhan.Click += (s, e) => ExecuteCal("*");
            btnChia.Click += (s, e) => ExecuteCal("/");

            // Thêm tất cả Control vào Form
            this.Controls.AddRange(new Control[] {
                lblTitle,
                lblSo1, txtSo1,
                lblSo2, txtSo2,
                lblKetQua, txtKetQua,
                btnCong, btnTru, btnNhan, btnChia
            });
        }

        private void ExecuteCal(string symbol)
        {
            try
            {
                int a = int.Parse(txtSo1.Text);
                int b = int.Parse(txtSo2.Text);

                Calculation cal = new Calculation(a, b);
                txtKetQua.Text = cal.Execute(symbol).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số nguyên hợp lệ!");
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Mẫu số không thể bằng 0!");
            }
        }
    }
}