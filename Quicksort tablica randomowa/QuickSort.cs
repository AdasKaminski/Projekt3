using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp85
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tablica randomowa");
            Console.WriteLine("rozmiar" + " " + "QuickSort" + " " + "QuickSortRecursion");
            Random random = new Random();

            for (int j = 50000; j < 200000; j += 10000)
            {

                int[] tab1 = new int[j];
                int[] tab2 = new int[j];
               

                Randomowa(tab1);
                Randomowa(tab2);
               


                var czas = new System.Diagnostics.Stopwatch();
                czas.Start();

                Quicksort(tab1);
                czas.Stop();
                ulong czasroznica = (ulong)czas.ElapsedTicks;


                var czas1 = new System.Diagnostics.Stopwatch();
                czas1.Start();

                Quicksortrecursion(tab2);
                czas1.Stop();
                ulong czas1roznica = (ulong)czas1.ElapsedTicks;

              


                Console.WriteLine(tab1.Length + "  " + czas.ElapsedTicks + "  " + czas1.ElapsedTicks );


            }
            Console.ReadKey();
        }

        static int[] Randomowa(int[] tab)
        {
            Random random = new Random();
            int tab2 = tab.Length;
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = tab2;
                tab2 = random.Next(50000, 200000);


            }
            return tab;
        }
        public static void Quicksort(int[] t)
        {
            int i, j, l, p, sp;
            int[] stos_l = new int[t.Length],
                stos_p = new int[t.Length];
            sp = 0;
            stos_l[sp] = 0;
            stos_p[sp] = t.Length - 1;

            do
            {
                l = stos_l[sp];
                p = stos_p[sp];
                sp--;

                do
                {
                    int x;
                    i = l;
                    j = p;
                    x = t[(l + p) / 2];
                    do
                    {
                        while (t[i] < x) i++;
                        while (x < t[j]) j--;
                        if (i <= j)
                        {
                            int buf = t[i];
                            t[i] = t[j];
                            t[j] = buf;
                            i++;
                            j--;
                        }
                    } while (i <= j);

                    if (i < p)
                    {
                        sp++;
                        stos_l[sp] = i;
                        stos_p[sp] = p;
                    }
                    p = j;
                } while (l < p);
            } while (sp >= 0);
          
        }
        private static void Sort(int[] tab, int left, int right)
        {
            int i, j, x;
            i = left;
            j = right;
            x = tab[(left + right) / 2];

            do
            {
                while (tab[i] < x) i++;
                while (x < tab[j]) j--;
                if (i <= j)
                {
                    int buf = tab[i];
                    tab[i] = tab[j];
                    tab[j] = buf;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) Sort(tab, left, j);
            if (i < right) Sort(tab, i, right);
        }

        public static void Quicksortrecursion(int[] tab)
        {
            Sort(tab, 0, tab.Length - 1);
        }

    }
}