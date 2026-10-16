using System;

namespace Calculator
{
    public class Diem
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Diem(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public class HinhChuNhat
    {
        public Diem TopLeft { get; set; }
        public Diem BottomRight { get; set; }

        public HinhChuNhat(Diem topLeft, Diem bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public double TinhDienTich()
        {
            double width = Math.Abs(BottomRight.X - TopLeft.X);
            double height = Math.Abs(TopLeft.Y - BottomRight.Y);
            return width * height;
        }

        public bool KiemTraGiaoNhau(HinhChuNhat hcn)
        {
            if (this.TopLeft.X > hcn.BottomRight.X || hcn.TopLeft.X > this.BottomRight.X)
                return false;

            if (this.BottomRight.Y > hcn.TopLeft.Y || hcn.BottomRight.Y > this.TopLeft.Y)
                return false;

            return true;
        }
    }
}