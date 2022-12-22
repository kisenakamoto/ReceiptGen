using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptGen
{

    class Order
    {
        decimal a, b, c, d, e, f, g, h, i;

        public void SetUpDown1(decimal a)
        {
            this.a = a;
        }
        public void SetUpDown2(decimal b)
        {
            this.b = b;
        }
        public void SetUpDown3(decimal c)
        {
            this.c = c;
        }
        public void SetUpDown4(decimal d)
        {
            this.d = d;
        }
        public void SetUpDown5(decimal e)
        {
            this.e = e;
        }
        public void SetUpDown6(decimal f)
        {
            this.f = f;
        }
        public void SetUpDown7(decimal g)
        {
            this.g = g;
        }
        public void SetUpDown8(decimal h)
        {
            this.h = h;
        }
        public void SetUpDown9(decimal i)
        {
            this.i = i;
        }
        public decimal GetOrder1()
        {
            decimal result1 = a * 25;
            return result1;
        }
        public decimal GetOrder2()
        {
            decimal result2 = b * 30;
            return result2;
        }
        public decimal GetOrder3()
        {
            decimal result3 = c * 40;
            return result3;
        }
        public decimal GetOrder4()
        {
            decimal result4 = d * 50;
            return result4;
        }
        public decimal GetOrder5()
        {
            decimal result5 = e * 70;
            return result5;
        }
        public decimal GetOrder6()
        {
            decimal result6 = f * 12;
            return result6;
        }
        public decimal GetOrder7()
        {
            decimal result7 = g * 10;
            return result7;
        }
        public decimal GetOrder8()
        {
            decimal result8 = h * 20;
            return result8;
        }
        public decimal GetOrder9()
        {
            decimal result9 = i * 15;
            return result9;
        }

        public decimal GetTotal()
        {
            decimal total = (a * 25) + (b * 30) + (c * 40) + 
                (d * 50) + (e * 70) + (f * 12) + (g * 10) + (h * 20) + (i * 15);

            return total;
        }  
    }
}
