using System;

namespace Calculator
{
    public class Calculation
    {
        private int a;
        private int b;

        public Calculation(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int Execute(string calSymbol)
        {
            int result = 0;
            switch (calSymbol)
            {
                case "+":
                    result = this.a + this.b;
                    break;
                case "-":
                    result = this.a - this.b;
                    break;
                case "*":
                    result = this.a * this.b;
                    break;
                case "/":
                    if (this.b == 0)
                        throw new DivideByZeroException();
                    result = this.a / this.b;
                    break;
            }
            return result;
        }
    }
}