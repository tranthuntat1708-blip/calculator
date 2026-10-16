using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

// Sử dụng Alias để tránh xung đột tên giữa Project Test và Class Calculation
using CalcLib = Calculator.Calculation;
using Calculator;

namespace CalculationTests
{
    [TestClass]
    public class UnitTest1
    {
        // =========================================================================
        // 1. UNIT TEST CHO LỚP CALCULATION (PHẦN LAB CƠ BẢN)
        // =========================================================================
        private CalcLib cal;

        [TestInitialize]
        public void SetUp()
        {
            // Chạy tự động trước mỗi phương thức test
            this.cal = new CalcLib(10, 5);
        }

        [TestMethod]
        public void TestAddOperator()
        {
            Assert.AreEqual(15, cal.Execute("+"));
        }

        [TestMethod]
        public void TestSubOperator()
        {
            Assert.AreEqual(5, cal.Execute("-"));
        }

        [TestMethod]
        public void TestMulOperator()
        {
            Assert.AreEqual(50, cal.Execute("*"));
        }

        [TestMethod]
        public void TestDivOperator()
        {
            Assert.AreEqual(2, cal.Execute("/"));
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivByZero()
        {
            CalcLib c = new CalcLib(2, 0);
            c.Execute("/");
        }

        // =========================================================================
        // 2. DATA-DRIVEN UNIT TEST (ĐỌC DỮ LIỆU TỪ TESTDATA.CSV)
        // =========================================================================
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            int expected = int.Parse(TestContext.DataRow[2].ToString());

            CalcLib c = new CalcLib(a, b);
            int actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }

        // =========================================================================
        // 3. UNIT TEST BÀI 1: TÍNH X^N BẰNG ĐỆ QUY
        // =========================================================================
        [TestMethod]
        public void TestPower_NIsZero_ReturnsOne()
        {
            Assert.AreEqual(1.0, PowerProgram.Power(5.0, 0), 0.00001);
        }

        [TestMethod]
        public void TestPower_PositiveExponent()
        {
            Assert.AreEqual(8.0, PowerProgram.Power(2.0, 3), 0.00001);
        }

        [TestMethod]
        public void TestPower_NegativeExponent()
        {
            Assert.AreEqual(0.25, PowerProgram.Power(2.0, -2), 0.00001);
        }

        // =========================================================================
        // 4. UNIT TEST BÀI 2: TÍNH ĐA THỨC (POLYNOMIAL)
        // =========================================================================
        [TestMethod]
        public void TestPolynomial_Cal_ValidData()
        {
            // P(x) = 1 + 2x + 3x^2 tại x = 2 => 1 + 4 + 12 = 17
            List<int> coeffs = new List<int> { 1, 2, 3 };
            Polynomial p = new Polynomial(2, coeffs);
            Assert.AreEqual(17, p.Cal(2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPolynomial_InvalidData_ThrowsException()
        {
            // Bậc n = 2 nhưng chỉ truyền vào 2 hệ số (thiếu 1 hệ số)
            List<int> coeffs = new List<int> { 1, 2 };
            Polynomial p = new Polynomial(2, coeffs);
        }

        // =========================================================================
        // 5. UNIT TEST BÀI 3: CHUYỂN ĐỔI CƠ SỐ (RADIX)
        // =========================================================================
        [TestMethod]
        public void TestRadix_ConvertDecimalToBinary()
        {
            Radix r = new Radix(10);
            Assert.AreEqual("1010", r.ConvertDecimalToAnother(2));
        }

        [TestMethod]
        public void TestRadix_ConvertDecimalToHex()
        {
            Radix r = new Radix(255);
            Assert.AreEqual("FF", r.ConvertDecimalToAnother(16));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRadix_InvalidRadix_ThrowsException()
        {
            Radix r = new Radix(10);
            r.ConvertDecimalToAnother(20); // Cơ số k nằm ngoài phạm vi [2, 16]
        }

        // =========================================================================
        // 6. UNIT TEST BÀI 4: LỚP DIEM & HINH CHU NHAT
        // =========================================================================
        [TestMethod]
        public void TestHinhChuNhat_TinhDienTich()
        {
            Diem tl = new Diem(0, 5);
            Diem br = new Diem(4, 0);
            HinhChuNhat hcn = new HinhChuNhat(tl, br);

            Assert.AreEqual(20.0, hcn.TinhDienTich(), 0.00001);
        }

        [TestMethod]
        public void TestHinhChuNhat_KiemTraGiaoNhau_True()
        {
            HinhChuNhat hcn1 = new HinhChuNhat(new Diem(0, 10), new Diem(10, 0));
            HinhChuNhat hcn2 = new HinhChuNhat(new Diem(5, 15), new Diem(15, 5));

            Assert.IsTrue(hcn1.KiemTraGiaoNhau(hcn2));
        }

        // =========================================================================
        // 7. UNIT TEST BÀI 5: QUẢN LÝ HỌC VIÊN & XÉT HỌC BỔNG
        // =========================================================================
        [TestMethod]
        public void TestHocVien_DuDieuKienHocBong_Valid()
        {
            HocVien hv = new HocVien("HV01", "Nguyen Van A", "HCM", 8.5, 8.0, 9.0);
            Assert.IsTrue(hv.DuDieuKienHocBong());
        }

        [TestMethod]
        public void TestHocVien_DuDieuKienHocBong_HasScoreBelow5()
        {
            // Điểm trung bình >= 8.0 nhưng có 1 môn dưới 5 => Không đạt học bổng
            HocVien hv = new HocVien("HV02", "Tran Van B", "HN", 10.0, 10.0, 4.5);
            Assert.IsFalse(hv.DuDieuKienHocBong());
        }
    }
}