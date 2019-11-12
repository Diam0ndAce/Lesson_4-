using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Длинная_арфметика
{
    class LongArifmetik
    {
        char[] num;
        private LongArifmetik()
        {

        }
        private LongArifmetik(int len)
        {
            Array.Resize(ref this.num, len);
        }
        public LongArifmetik(string num)
        {
            this.num = num.ToCharArray();
            Array.Reverse(this.num);
            string numerics = "0123456789";
            for (int i = 0; i < this.num.Length; i++)
            {
                bool flag = false;
                for (int k = 0; k < numerics.Length; k++)
                {
                    if (this.num[i] == numerics[k])
                        flag = true;
                }
                if (flag == false)
                {
                    Console.WriteLine("Некорекктный ввод числа.");
                    
                }

            }
            
        }
        public override string ToString()
        {
            if (this == null)
            {
                //Console.WriteLine("Произошла ошибка");
                return "Произошла ошибка. Объект равен null.";
            }
            string output = "";
            for (int i = this.num.Length - 1; i >= 0; i--)
            {
                output += (this.num[i]);
            }
            return output;
        }
        public static LongArifmetik Parse(string x)
        {
            var temp = new LongArifmetik(x.Length);
            temp.num = x.ToCharArray();
            Array.Reverse(temp.num);
            return temp;
        }
        public LongArifmetik PushBack (char b)
        {

            Array.Reverse(num);
            Array.Resize(ref num, num.Length + 1);
            num[num.Length - 1] = b;
            Array.Reverse(num);
            return this;
        }
        static public void print(LongArifmetik a)
        {
            
            if (a  == null)
            {
                Console.WriteLine("Произошла ошибка");
                return;
            }
            for (int i = a.num.Length -1; i>=0 ; i--)
            {
                Console.Write(a.num[i]);
            }
            Console.WriteLine();
            
            
        }
        public static void Statistic(LongArifmetik a, LongArifmetik b)
        {
            var stw = new Stopwatch();
            LongArifmetik c;
            stw.Start();
            for (int i = 0; i < 1000; i++)
            {
                c = a + b;
            }
            stw.Stop();
            Console.WriteLine("Время выполнения сложения: " + stw.ElapsedMilliseconds/1000.0);
            stw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                c = a - b;
                if (c == null)
                    break;
            }
            stw.Stop();
            Console.WriteLine("Время выполнения вычитания: " + stw.ElapsedMilliseconds / 1000.0);
            stw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                c = a * b;
            }
            stw.Stop();
            Console.WriteLine("Время выполнения умножения: " + stw.ElapsedMilliseconds / 1000.0);
            stw.Restart();
            for (int i = 0; i < 1000; i++)
            {
                c = a / b;
                if (c == null)
                    break;
            }
            stw.Stop();
            Console.WriteLine("Время выполнения деления: " + stw.ElapsedMilliseconds / 1000.0);
          
        }
        public static void StatisticPower(LongArifmetik a, LongArifmetik b)
        {
            var stw = new Stopwatch();
            LongArifmetik c;
            stw.Start();
            for (int i = 0; i < 1000; i++)
            {
                c = LongArifmetik.FastPow(a, b);
            }
            stw.Stop();
            Console.WriteLine("Время возведения в степень: " + stw.ElapsedMilliseconds / 1000.0);
        }
        public static LongArifmetik operator +(LongArifmetik a, LongArifmetik b)
        {
            int s = 0;

            if (b.num.Length > a.num.Length)
            {
                for (int i = a.num.Length; i < b.num.Length; i++)
                {
                    Array.Resize(ref a.num, a.num.Length + 1);
                    a.num[i] = '0';
                }
            }
            else
            {
                for (int i = b.num.Length; i < a.num.Length; i++)
                {
                    Array.Resize(ref b.num, b.num.Length + 1);
                    b.num[i] = '0';
                }
            }
            LongArifmetik c = new LongArifmetik(a.num.Length);

            for (int i = 0; i < a.num.Length; i++)
            {
                int temp = (int)Char.GetNumericValue(a.num[i]) + (int)Char.GetNumericValue(b.num[i]) + s;
                s = temp / 10;
                c.num[i] = Char.Parse(Convert.ToString(temp % 10));

            }
            if (s == 1)
            {
                Array.Resize(ref c.num, c.num.Length + 1);
                c.num[c.num.Length - 1] = Char.Parse(Convert.ToString(s));

            }
            for (int i = a.num.Length - 1; i > 0; i--)
            {
                if (a.num[i] == '\0' || a.num[i] == '0')
                {
                    Array.Resize(ref a.num, a.num.Length - 1);

                }
                else
                    break;

            }
            for (int i = b.num.Length - 1; i > 0; i--)
            {
                if (b.num[i] == '\0' || b.num[i] == '0')
                {
                    Array.Resize(ref b.num, b.num.Length - 1);

                }
                else
                    break;

            }
            for (int i = c.num.Length - 1; i > 0; i--)
            {
                if (c.num[i] == '\0' || c.num[i] == '0')
                {
                    Array.Resize(ref c.num, c.num.Length - 1);

                }
                else
                    break;

            }
            return c;
        }

        public static LongArifmetik operator -(LongArifmetik a, LongArifmetik b)
        {
            //for (int i = a.num.Length - 1; i > 0; i--)
            //{
            //    if (a.num[i] == '\0' || a.num[i] == '0')
            //    {
            //        Array.Resize(ref a.num, a.num.Length - 1);

            //    }
            //    else
            //        break;

            //}
            //for (int i = b.num.Length - 1; i > 0; i--)
            //{
            //    if (b.num[i] == '\0' || b.num[i] == '0')
            //    {
            //        Array.Resize(ref b.num, b.num.Length - 1);

            //    }
            //    else
            //        break;

            //}
            if (b.num.Length > a.num.Length)
            {
                Console.WriteLine("Вычитаемое больше уменьшаемого, что не допустимо.");
                return null;
            }
            if (b.num.Length < a.num.Length)
            {
                for (int i = b.num.Length; i < a.num.Length; i++)
                {
                    Array.Resize(ref b.num, b.num.Length + 1);
                    b.num[i] = '0';
                }
            }


            for (int i = a.num.Length - 1; i >= 0; i--)
            {
                bool flag = false;
                if (a.num[i] > b.num[i]) break;
                if (a.num[i] < b.num[i])
                {
                    flag = true;
                    Console.WriteLine("Вычитаемое больше уменьшаемого, что не допустимо.");
                }

                if (flag == true) return null;
            }
            LongArifmetik c = new LongArifmetik(a.num.Length);
            int s = 0;
            for (int i = 0; i < a.num.Length; i++)
            {
                int temp = (int)Char.GetNumericValue(a.num[i]) - (int)Char.GetNumericValue(b.num[i]) + s;
                s = (int)Math.Round(temp / 10.0, MidpointRounding.ToNegativeInfinity);
                if (temp < 0) temp += 10;
                c.num[i] = Char.Parse(Convert.ToString(temp));
            }
            for (int i = a.num.Length - 1; i > 0; i--)
            {
                if (a.num[i] == '\0' || a.num[i] == '0')
                {
                    Array.Resize(ref a.num, a.num.Length - 1);

                }
                else
                    break;

            }
            for (int i = b.num.Length - 1; i > 0; i--)
            {
                if (b.num[i] == '\0' || b.num[i] == '0')
                {
                    Array.Resize(ref b.num, b.num.Length - 1);

                }
                else
                    break;

            }
            for (int i = c.num.Length - 1; i > 0; i--)
            {
                if (c.num[i] == '\0' || c.num[i] == '0')
                {
                    Array.Resize(ref c.num, c.num.Length - 1);

                }
                else
                    break;

            }
            return c;

        }
        public static LongArifmetik operator -(LongArifmetik a, int bb)
        {
            LongArifmetik b = new LongArifmetik(bb.ToString());
            if (b.num.Length > a.num.Length)
            {
                Console.WriteLine("Вычитаемое больше уменьшаемого, что не допустимо.");
                return null;
            }
            if (b.num.Length < a.num.Length)
            {
                for (int i = b.num.Length; i < a.num.Length; i++)
                {
                    Array.Resize(ref b.num, b.num.Length + 1);
                    b.num[i] = '0';
                }
            }


            for (int i = a.num.Length - 1; i >= 0; i--)
            {
                bool flag = false;
                if (a.num[i] > b.num[i]) break;
                if (a.num[i] < b.num[i])
                {
                    flag = true;
                    Console.WriteLine("Вычитаемое больше уменьшаемого, что не допустимо.");
                }

                if (flag == true) return null;
            }
            LongArifmetik c = new LongArifmetik(a.num.Length);
            int s = 0;
            for (int i = 0; i < a.num.Length; i++)
            {
                int temp = (int)Char.GetNumericValue(a.num[i]) - (int)Char.GetNumericValue(b.num[i]) + s;
                s = (int)Math.Round(temp / 10.0, MidpointRounding.ToNegativeInfinity);
                if (temp < 0) temp += 10;
                c.num[i] = Char.Parse(Convert.ToString(temp));
            }
            return c;

        }

        public static char[] operator -(LongArifmetik a, char[] b)
        {
            if (b.Length > a.num.Length)
            {
                Console.WriteLine("Вычитаемое больше уменьшаемого, что не допустимо.");
                return null;
            }
            if (b.Length < a.num.Length)
            {
                for (int i = b.Length; i < a.num.Length; i++)
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[i] = '0';
                }
            }


            for (int i = a.num.Length - 1; i >= 0; i--)
            {
                bool flag = false;
                if (a.num[i] > b[i]) break;
                if (a.num[i] < b[i])
                {
                    flag = true;
                    Console.WriteLine("Вычитаемое больше уменьшаемого, что не допустимо.");
                }

                if (flag == true) return null;
            }
            char[] c = new char[a.num.Length];
            int s = 0;
            for (int i = 0; i < a.num.Length; i++)
            {
                int temp = (int)Char.GetNumericValue(a.num[i]) - (int)Char.GetNumericValue(b[i]) + s;
                s = (int)Math.Round(temp / 10.0, MidpointRounding.ToNegativeInfinity);
                if (temp < 0) temp += 10;
                c[i] = Char.Parse(Convert.ToString(temp));
            }

            return c;

        }
        public static LongArifmetik operator *(LongArifmetik a, LongArifmetik b)
        {
            bool perest = false;
            

            if (b.num.Length > a.num.Length)
            {
                char[] temp = a.num;
                a.num = b.num;
                b.num = temp;
                perest = true;
            }
            var c = new LongArifmetik(2 * a.num.Length);
            //char[] c = new char[a.num.Length];
            for (int i = 0; i < a.num.Length; i++)
            {
                c.num[i] = '0';
            }
            for (int i = 0; i < a.num.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < b.num.Length; j++)
                {

                    int t = 0;
                    t = (int)Char.GetNumericValue(c.num[i + j]) + (int)Char.GetNumericValue(a.num[i]) * (int)Char.GetNumericValue(b.num[j]) + s;
                    c.num[i + j] = Char.Parse(Convert.ToString(t % 10));
                    s = t / 10;
                }
                c.num[i + b.num.Length] = Char.Parse(Convert.ToString(s)); 
            }
            for (int i = c.num.Length - 1; i >0; i--)
            {
                if (c.num[i] == '\0' || c.num[i] == '0')
                {
                    Array.Resize(ref c.num, c.num.Length - 1);

                }
                else
                    break;
             
            }
            for (int i = a.num.Length - 1; i > 0; i--)
            {
                if (a.num[i] == '\0' || a.num[i] == '0')
                {
                    Array.Resize(ref a.num, a.num.Length - 1);

                }
                else
                    break;

            }
            for (int i = b.num.Length - 1; i > 0; i--)
            {
                if (b.num[i] == '\0' || b.num[i] == '0')
                {
                    Array.Resize(ref b.num, b.num.Length - 1);

                }
                else
                    break;

            }
            if (perest)
            {
                char[] temp = a.num;
                a.num = b.num;
                b.num = temp;
            }
            return c;
        }
        public static LongArifmetik operator *(LongArifmetik a, int b)
        {
            LongArifmetik b_ = new LongArifmetik(b.ToString());
            if (b_.num.Length > a.num.Length)
            {
                char[] temp = a.num;
                a.num = b_.num;
                b_.num = temp;
            }
            var c = new LongArifmetik(2 * a.num.Length);
            //char[] c = new char[a.num.Length];
            for (int i = 0; i < a.num.Length; i++)
            {
                c.num[i] = '0';
            }
            for (int i = 0; i < a.num.Length; i++)
            {
                int s = 0;
                for (int j = 0; j < b_.num.Length; j++)
                {

                    int t = 0;
                    t = (int)Char.GetNumericValue(c.num[i + j]) + (int)Char.GetNumericValue(a.num[i]) * (int)Char.GetNumericValue(b_.num[j]) + s;
                    c.num[i + j] = Char.Parse(Convert.ToString(t % 10));
                    s = t / 10;
                }
                c.num[i + b_.num.Length] = Char.Parse(Convert.ToString(s));
            }
            for (int i = c.num.Length - 1; i >= 0; i--)
            {
                if (c.num[i] == '\0' )
                {
                    Array.Resize(ref c.num, c.num.Length - 1);

                }
                else
                    break;

            }
            return c;
        }

        public static bool operator <(LongArifmetik a, int bbb)
        {
            string bb = bbb.ToString();
            char[] b = bb.ToCharArray();
            Array.Reverse(b);

            if (b.Length > a.num.Length)
            {
                for (int k = a.num.Length; k < b.Length; k++)
                {
                    Array.Resize(ref a.num, a.num.Length + 1);
                    a.num[k] = '0';
                }
            }
            else
            {
                for (int k = b.Length; k < a.num.Length; k++)
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[k] = '0';
                }
            }



            //if (a.num.Length < b.Length)
            //    return true;
            //if(a.num.Length > b.Length)return false;

            int i = b.Length -1;
            while(true)
            {
                if(a.num[i] == b[i])
                {
                    i--;
                    if (i < 0) return false;
                    continue;
                }
                if (a.num[i] < b[i])
                {
                    return true;
                }
                else return false;
            }
        }
        public static bool operator >(LongArifmetik a, int bbb)
        {
            string bb = bbb.ToString();
            char[] b = bb.ToCharArray();
            Array.Reverse(b);
            //if (a.num.Length > b.Length)
            //    return true;
            //if (a.num.Length < b.Length) return false;

            if (b.Length > a.num.Length)
            {
                for (int k = a.num.Length; k < b.Length; k++)
                {
                    Array.Resize(ref a.num, a.num.Length + 1);
                    a.num[k] = '0';
                }
            }
            else
            {
                for (int k = b.Length; k < a.num.Length; k++)
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[k] = '0';
                }
            }

            int i = b.Length -1;
            while (true)
            {
                if (a.num[i] == b[i])
                {
                    i--;
                    if (i < 0) return false;
                    continue;
                }
                if (a.num[i] > b[i])
                {
                    return true;
                }
                else return false;
            }
        }

        public static bool operator >(LongArifmetik a, LongArifmetik b)
        {

            //if (a.num.Length > b.num.Length)
            //    return true;
            //if (a.num.Length < b.num.Length) return false;

            if (b.num.Length > a.num.Length)
            {
                for (int k = a.num.Length; k < b.num.Length; k++)
                {
                    Array.Resize(ref a.num, a.num.Length + 1);
                    a.num[k] = '0';
                }
            }
            else
            {
                for (int k = b.num.Length; k < a.num.Length; k++)
                {
                    Array.Resize(ref b.num, b.num.Length + 1);
                    b.num[k] = '0';
                }
            }

            int i = b.num.Length -1;
            while (true)
            {
                if (a.num[i] == b.num[i])
                {
                    i--;
                    if (i < 0) return false;
                    continue;
                }
                if (a.num[i] > b.num[i])
                {
                    return true;
                }
                else return false;
            }
        }
        public static bool operator <(LongArifmetik a, LongArifmetik b)
        {

            //if (a.num.Length < b.num.Length)
            //    return true;
            //if (a.num.Length > b.num.Length) return false;

            if (b.num.Length > a.num.Length)
            {
                for (int k = a.num.Length; k < b.num.Length; k++)
                {
                    Array.Resize(ref a.num, a.num.Length + 1);
                    a.num[k] = '0';
                }
            }
            else
            {
                for (int k = b.num.Length; k < a.num.Length; k++)
                {
                    Array.Resize(ref b.num, b.num.Length + 1);
                    b.num[k] = '0';
                }
            }

            int i = b.num.Length -1;
            while (true)
            {
                if (a.num[i] == b.num[i])
                {
                    i--;
                    if (i < 0) return false;
                    continue;
                }
                if (a.num[i] < b.num[i])
                {
                    return true;
                }
                else return false;
            }
        }

        //public static bool operator ==(LongArifmetik a, LongArifmetik b)
        //{
        //    //if (a == null)
        //    //{
        //    //    Console.WriteLine("Произошла ошибка");
        //    //    return false;
        //    //}
        //    //if (b == null)
        //    //{
        //    //    Console.WriteLine("Произошла ошибка");
        //    //    return false;
        //    //}

        //    if (b.num.Length > a.num.Length)
        //    {
        //        for (int k = a.num.Length; k < b.num.Length; k++)
        //        {
        //            Array.Resize(ref a.num, a.num.Length + 1);
        //            a.num[k] = '0';
        //        }
        //    }
        //    else
        //    {
        //        for (int k = b.num.Length; k < a.num.Length; k++)
        //        {
        //            Array.Resize(ref b.num, b.num.Length + 1);
        //            b.num[k] = '0';
        //        }
        //    }

        //    int i = b.num.Length - 1;
        //    while (true)
        //    {
        //        if (a.num[i] == b.num[i])
        //        {
        //            i--;
        //            if (i < 0) return true;
        //            continue;
        //        }
        //        return false;
        //    }
        //}

        //public static bool operator !=(LongArifmetik a, LongArifmetik b)
        //{
        //    if (b.num.Length > a.num.Length)
        //    {
        //        for (int k = a.num.Length; k < b.num.Length; k++)
        //        {
        //            Array.Resize(ref a.num, a.num.Length + 1);
        //            a.num[k] = '0';
        //        }
        //    }
        //    else
        //    {
        //        for (int k = b.num.Length; k < a.num.Length; k++)
        //        {
        //            Array.Resize(ref b.num, b.num.Length + 1);
        //            b.num[k] = '0';
        //        }
        //    }

        //    int i = b.num.Length - 1;
        //    while (true)
        //    {
        //        if (a.num[i] == b.num[i])
        //        {
        //            i--;
        //            if (i < 0) return false;
        //            continue;
        //        }
        //        return true;
        //    }
        //}
        public static LongArifmetik operator /(LongArifmetik a, LongArifmetik b)
        {
            if (b.num.Length == 0)
            {
                Console.WriteLine("Делитель не введен.");
                return null;
            }
            bool errorFlag = true;
            for (int i = 0; i < b.num.Length; i++)
            {
                if (b.num[i] != '0')
                {
                    errorFlag = false;
                    break;
                }
            }
            if(errorFlag == true)
            {
                Console.WriteLine("На ноль делить нельзя.");
                return null;
            }
            
            if (b > a)
            {
                Console.WriteLine("Делитель больше делимого. Ответ 0.");
                var e = new LongArifmetik("0");
                return e;
            }
            
            var tempA = new LongArifmetik(0);
         
            var q = new LongArifmetik(0);
            
            for (int i = a.num.Length -1; i >=0; i--)
            {
                int divisor = 0;
                tempA.PushBack(a.num[i]);
               
                if (!(tempA > 0))
                {
                    q.PushBack('0');
                    continue;
                }
                if (tempA < b && q.num.Length != 0)
                {
                    q.PushBack('0');
                    continue;
                }
                if (tempA < b)
                {
                    continue;
                }
                while(!(tempA < b))
                {
                    tempA = tempA - b;
                    divisor++;
                }
                q.PushBack(Convert.ToChar(divisor.ToString()));
            }

            for (int i = q.num.Length - 1; i >= 0; i--)
            {
                if (q.num[i] == '\0' || q.num[i] == '0')
                {
                    Array.Resize(ref q.num, q.num.Length - 1);

                }
                else
                    break;

            }
            for (int i = a.num.Length - 1; i > 0; i--)
            {
                if (a.num[i] == '\0' || a.num[i] == '0')
                {
                    Array.Resize(ref a.num, a.num.Length - 1);

                }
                else
                    break;

            }
            for (int i = b.num.Length - 1; i > 0; i--)
            {
                if (b.num[i] == '\0' || b.num[i] == '0')
                {
                    Array.Resize(ref b.num, b.num.Length - 1);

                }
                else
                    break;

            }
            return q;
        }
        public static LongArifmetik operator /(LongArifmetik a, int bb)
        {
            LongArifmetik b = new LongArifmetik(bb.ToString());
            if (b.num.Length == 0)
            {
                Console.WriteLine("Делитель не введен.");
                return null;
            }
            bool errorFlag = true;
            for (int i = 0; i < b.num.Length; i++)
            {
                if (b.num[i] != '0')
                {
                    errorFlag = false;
                    break;
                }
            }
            if (errorFlag == true)
            {
                Console.WriteLine("На ноль делить нельзя.");
                return null;
            }

            if (b > a)
            {
                Console.WriteLine("Делитель больше делимого. Ответ 0.");
                var e = new LongArifmetik("0");
                return e;
            }

            var tempA = new LongArifmetik(0);

            var q = new LongArifmetik(0);

            for (int i = a.num.Length - 1; i >= 0; i--)
            {
                int divisor = 0;
                tempA.PushBack(a.num[i]);

                if (!(tempA > 0))
                {
                    q.PushBack('0');
                    continue;
                }
                if (tempA < b && q.num.Length != 0)
                {
                    q.PushBack('0');
                    continue;
                }
                if (tempA < b)
                {
                    continue;
                }
                while (!(tempA < b))
                {
                    tempA = tempA - b;
                    divisor++;
                }
                q.PushBack(Convert.ToChar(divisor.ToString()));
            }

            for (int i = q.num.Length - 1; i >= 0; i--)
            {
                if (q.num[i] == '\0' || q.num[i] == '0')
                {
                    Array.Resize(ref q.num, q.num.Length - 1);

                }
                else
                    break;

            }
            return q;
        }
        public static LongArifmetik operator %(LongArifmetik a, LongArifmetik b)
        {
            if (b.num.Length == 0)
            {
                Console.WriteLine("Делитель не введен.");
                return null;
            }
            bool errorFlag = true;
            for (int i = 0; i < b.num.Length; i++)
            {
                if (b.num[i] != '0')
                {
                    errorFlag = false;
                    break;
                }
            }
            if (errorFlag == true)
            {
                Console.WriteLine("На ноль делить нельзя.");
                return null;
            }

            //if (b > a)
            //{
            //    Console.WriteLine("Делитель больше делимого. Ответ 0.");
            //    var e = new LongArifmetik("0");
            //    return e;
            //}

            var tempA = new LongArifmetik(0);

            var q = new LongArifmetik(0);

            for (int i = a.num.Length - 1; i >= 0; i--)
            {
                int divisor = 0;
                tempA.PushBack(a.num[i]);

                if (!(tempA > 0))
                {
                    q.PushBack('0');
                    continue;
                }
                if (tempA < b && q.num.Length != 0)
                {
                    q.PushBack('0');
                    continue;
                }
                if (tempA < b)
                {
                    continue;
                }
                while (!(tempA < b))
                {
                    tempA = tempA - b;
                    divisor++;
                }
                q.PushBack(Convert.ToChar(divisor.ToString()));
            }

            for (int i = tempA.num.Length - 1; i > 0; i--)
            {
                if (tempA.num[i] == '\0' || tempA.num[i] == '0')
                {
                    Array.Resize(ref tempA.num, tempA.num.Length - 1);

                }
                else
                    break;

            }
            return tempA;
        }
        public static LongArifmetik operator %(LongArifmetik a, int bb)
        {
            LongArifmetik b = new LongArifmetik(bb.ToString());
            if (b.num.Length == 0)
            {
                Console.WriteLine("Делитель не введен.");
                return null;
            }
            bool errorFlag = true;
            for (int i = 0; i < b.num.Length; i++)
            {
                if (b.num[i] != '0')
                {
                    errorFlag = false;
                    break;
                }
            }
            if (errorFlag == true)
            {
                Console.WriteLine("На ноль делить нельзя.");
                return null;
            }

            //if (b > a)
            //{
            //    Console.WriteLine("Делитель больше делимого. Ответ 0.");
            //    var e = new LongArifmetik("0");
            //    return e;
            //}

            var tempA = new LongArifmetik(0);

            var q = new LongArifmetik(0);

            for (int i = a.num.Length - 1; i >= 0; i--)
            {
                int divisor = 0;
                tempA.PushBack(a.num[i]);

                if (!(tempA > 0))
                {
                    q.PushBack('0');
                    continue;
                }
                if (tempA < b && q.num.Length != 0)
                {
                    q.PushBack('0');
                    continue;
                }
                if (tempA < b)
                {
                    continue;
                }
                while (!(tempA < b))
                {
                    tempA = tempA - b;
                    divisor++;
                }
                q.PushBack(Convert.ToChar(divisor.ToString()));
            }

            for (int i = tempA.num.Length - 1; i > 0; i--)
            {
                if (tempA.num[i] == '\0' || tempA.num[i] == '0')
                {
                    Array.Resize(ref tempA.num, tempA.num.Length - 1);

                }
                else
                    break;

            }
            return tempA;
        }

        public static LongArifmetik FastPow(LongArifmetik a, LongArifmetik n)
        {
            var result = new LongArifmetik("1");
            while(n > 0)
            {
                var tempN = n % 2;
                if (tempN.num[0] == '0')
                {
                    a = a *a;
                    n = n / 2;
                }
                else
                {
                    result = result * a;
                    n = n - 1;
                }
            }
            return result;
        }
     

    }
}
