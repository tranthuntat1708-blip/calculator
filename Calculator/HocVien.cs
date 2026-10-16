namespace Calculator
{
    public class HocVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public string QueQuan { get; set; }
        public double DiemMon1 { get; set; }
        public double DiemMon2 { get; set; }
        public double DiemMon3 { get; set; }

        public HocVien(string maSo, string hoTen, string queQuan, double d1, double d2, double d3)
        {
            MaSo = maSo;
            HoTen = hoTen;
            QueQuan = queQuan;
            DiemMon1 = d1;
            DiemMon2 = d2;
            DiemMon3 = d3;
        }

        public double TinhDiemTrungBinh()
        {
            return (DiemMon1 + DiemMon2 + DiemMon3) / 3.0;
        }

        public bool DuDieuKienHocBong()
        {
            double dtb = TinhDiemTrungBinh();
            bool khongMonDuoi5 = DiemMon1 >= 5.0 && DiemMon2 >= 5.0 && DiemMon3 >= 5.0;
            return dtb >= 8.0 && khongMonDuoi5;
        }
    }
}