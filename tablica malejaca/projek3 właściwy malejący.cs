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
            Console.WriteLine("tablica malejąca");
            Console.WriteLine("Rozmiar" + " " + "HeapSort" + " " + "coctailSort" + " " + "Insertsort"+ " " +"  Selectsort ");
            for (int j = 50000; j < 200000; j += 10000)
            {

                int[] tab1 = new int[j];
                int[] tab2 = new int[j];
                int[] tab3 = new int[j];
                int[] tab4 = new int[j];

                Malejace(tab1);
                Malejace(tab2);
                Malejace(tab3);
                Malejace(tab4);





                var czas = new System.Diagnostics.Stopwatch();
                czas.Start();

                Heap(tab1);
                czas.Stop();
                ulong czasroznica = (ulong)czas.ElapsedTicks;


                var czas1 = new System.Diagnostics.Stopwatch();
                czas1.Start();

                Cocktail(tab2);
                czas1.Stop();
                ulong czas1roznica = (ulong)czas1.ElapsedTicks;

                var czas2 = new System.Diagnostics.Stopwatch();
                czas2.Start();

                Insertion(tab3);
                czas2.Stop();
                ulong czas2roznica = (ulong)czas2.ElapsedTicks;

                var czas3 = new System.Diagnostics.Stopwatch();
                czas3.Start();

                Sort(tab4);
                czas3.Stop();
                ulong czas3roznica = (ulong)czas3.ElapsedTicks;


                Console.WriteLine(tab1.Length + "  " + czas.ElapsedTicks + "  " + czas1.ElapsedTicks + " " + czas2.ElapsedTicks + " " + czas3.ElapsedTicks);


            }
            Console.ReadKey();
        }

        static int[] Malejace(int[] tab)
        {
            int tab2 = tab.Length;
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = tab2;
                tab2 -= 1;
            }
            return tab;
        }
        private static void Heapify(int[] t, uint left, uint right)
        {
            uint i = left, j = 2 * i + 1;
            int buf = t[i];

            while (j <= right)
            {
                if (j < right)
                    if (t[j] < t[j + 1])
                        j++;
                if (buf >= t[j]) break;

                t[i] = t[j];
                i = j;
                j = 2 * i + 1;
            }

            t[i] = buf;
        }

        public static void Heap(int[] tab)
        {
            uint left = (uint)tab.Length / 2;
            uint right = (uint)tab.Length - 1;
            while (left > 0)
            {
                left--;
                Heapify(tab, left, right);
            }

            while (right > 0)
            {
                int buf = tab[left];
                tab[left] = tab[right];
                tab[right] = buf;
                right--;
                Heapify(tab, left, right);
            }

        }
        public static void Cocktail(int[] tab)
        {
            int left = 1, right = tab.Length - 1, k = tab.Length - 1;
            do
            {
                for (int j = right; j >= left; j--)
                    if (tab[j - 1] > tab[j])
                    {
                        int temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                        k = j;
                    }

                left = k + 1;

                for (int j = left; j <= right; j++)
                    if (tab[j - 1] > tab[j])
                    {
                        int temp = tab[j - 1];
                        tab[j - 1] = tab[j];
                        tab[j] = temp;
                        k = j;
                    }

                right = k - 1;
            } while
                (left <= right);
        }
        public static void Insertion(int[] tab)
        {
            for (uint i = 1; i < tab.Length; i++)
            {
                uint j = i;
                int temp = tab[j];

                while ((j > 0) && (tab[j - 1] > temp))
                {
                    tab[j] = tab[j - 1];
                    j--;
                }

                tab[j] = temp;
            }
        }
        public static void Sort(int[] tab)
        {
            uint k;
            for (uint i = 0; i < (tab.Length - 1); i++)
            {
                int temp = tab[i];
                k = i;
                for (uint j = i + 1; j < tab.Length; j++)
                    if (tab[j] < temp)
                    {
                        k = j;
                        temp = tab[j];
                    }

                tab[k] = tab[i];
                tab[i] = temp;
            }
        }
    }
}