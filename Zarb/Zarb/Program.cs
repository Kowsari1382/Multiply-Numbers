using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarb
{
    class Program
    {
        public static void Main(string[] args)
        {
            int sign1;
            int sign2;
            Console.WriteLine("input number of digits for u:");
            int n1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input sign of u. p for positive and n for negative:");
            if(Console.ReadLine()=="p")
            {
                sign1 = 1;
            }
            else
            {
                sign1 = -1;
            }
            Console.WriteLine("input number of digits for v:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("input sign of v. p for positive and n for negative:");
            if (Console.ReadLine() == "p")
            {
                sign2 = 1;
            }
            else
            {
                sign2 = -1;
            }
            int[] u = new int[n1];
            int[] v = new int[n2];
            for (int i=0;i<n1;i++)
            {
                Console.WriteLine("input digit for first number:");
                int a=Convert.ToInt32(Console.ReadLine());
                u[i] = a;
            }
            for(int i=0; i<n2;i++)
            {
                Console.WriteLine("input digit for second number:");
                int b = Convert.ToInt32(Console.ReadLine());
                v[i] = b;
            }
            List<int> result = prod(u, v);
            if((sign1*sign2)==-1)
            {
                Console.Write("-");
            }
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i]);
            }
            Console.ReadKey();
        }
        public static List<int> prod(int[] u,int[] v)
        {
            int n1 = u.Length;
            int n2 = v.Length;
            int n;
            if(u.Length > v.Length) { n = u.Length; }
            else { n = v.Length; }
            int m = n / 2;
            int length1 = n1 - m;
            int length2 = n2 - m;
            if(length1 < 0) { length1 = 0; }
            if(length2 < 0) { length2 = 0; }
            int[] x = new int[length1];
            int[] y = new int[m];
            int[] w = new int[length2];
            int[] z = new int[m];
            int i2 = 0;
            int j2 = 0;
            int length3 = n1 - m;
            int length4 = n2 - m;
            if (length3 < 0)
            {
                i2 = length3 * -1;
                for(int i = 0; i < i2; i++)
                {
                    y[i] = 0;
                }
            }
            if(length4 < 0)
            {
                j2 = length4 * -1;
                for(int i = 0; i < j2; i++)
                {
                    z[i] = 0;
                }
            }
            //
            bool a = true;
            bool b = true;
            for(int i=0; i<u.Length; i++)
            {
                if(u[i] != 0)
                {
                    a = false;
                    break;
                }
            }
            for(int i=0;i<v.Length;i++)
            {
                if(v[i] != 0)
                {
                    b = false;
                    break;
                }
            }
            if(a==true || b==true)
            {
                List<int> r = new List<int>();
                for (int i=0; i<u.Length; i++)
                {
                    r.Insert(i, 0);
                }
                return r;
            }
            else if(n<=4)
            {
                int sum1 = 0;
                int sum2 = 0;
                for (int i = 0; i < n1; i++)
                {
                    sum1 = u[i] + sum1 * 10;
                }
                for (int i = 0; i < n2; i++)
                {
                    sum2 = v[i] + sum2 * 10;
                }
                int sum = sum1 * sum2;
                int summ = sum;
                int numbers = 0;
                while(summ!=0)
                {
                    summ = summ / 10;
                    numbers++;
                }
                List<int> r = new List<int>();
                for(int i=0;i<numbers;i++)
                {
                    r.Insert(i, sum % 10);
                    sum = sum / 10;
                }
                r.Reverse();
                return r;
            }
            else
            {
                for(int i = 0; i < x.Length; i++)
                {
                    x[i] = u[i];
                }
                int k = x.Length;
                for (int i = i2; i < y.Length; i++)
                {
                    y[i] = u[k];
                    k++;
                }
                for (int i = 0; i < w.Length; i++)
                {
                    w[i] = v[i];
                }
                int l = w.Length;
                for (int i = j2; i < z.Length; i++)
                {
                    z[i] = v[l];
                    l++;
                }
                List<int> s = prod(x, w);
                for (int i=0; i < 2 * m; i++)
                {
                    s.Add(0);
                }
                List<int> j = sum(prod(x, z), prod(w, y));
                for (int i = 0; i < m; i++)
                {
                    j.Add(0);
                }
                List<int> r = sum(s,sum(j,prod(y, z)));
                return r;
            }
        }
        public static List<int> sum(List<int> a,List<int> b)
        {
            List<int> result = new List<int>();
            int carry = 0;
            int max;
            if(a.Count > b.Count) { max = a.Count; }
            else { max = b.Count; }
            while(a.Count < b.Count)
            {
                a.Insert(0, 0);
            }
            while(b.Count < a.Count)
            {
                b.Insert(0, 0);
            }
            a.Reverse();
            b.Reverse();
            for(int i = 0; i < max; i++)
            {
                int sum = a[i] + b[i] + carry;
                result.Add(sum % 10);
                carry = sum / 10;
            }
            if (carry > 0)
            {
                result.Add(carry);
            }
            result.Reverse();
            return result;
        }
    }
}
