using System;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace ConsoleApp2
{
    class BasicAlgorithm
    {
        protected int Pttrai;
        protected int Ptphai;
        protected int temp;
        protected int[] array;
        private int Sophantu;
        private Stopwatch st = new Stopwatch();

        public void NotArrange()
        {
            Console.WriteLine("Mời bạn nhập số phần từ");
            Sophantu = Int32.Parse(Console.ReadLine());
            array = new int[Sophantu];
            Random rd = new Random();
            Console.WriteLine("Dãy số chưa được sẵp xếp");
            for (Pttrai = 0; Pttrai < array.Length; Pttrai++)
            {
                array[Pttrai] = rd.Next(0, 100);
                Console.Write(" " + array[Pttrai]);
            }
            st.Start();
        }

        public void Arranged()
        {
            st.Stop();
            Console.WriteLine("\nIn ra dãy số đã sắp xếp");
            for (Pttrai = 0; Pttrai < array.Length; Pttrai++)
            {
                Console.Write(" " + array[Pttrai]);
            }
            Console.WriteLine("\nThời gian thực hiện thuật toán: {0}miliSecond", st.Elapsed.Milliseconds);
        }
    }
    class Select : BasicAlgorithm
    {
        public void Selection()
        {
            Console.WriteLine("Sắp xếp chọn");
            base.NotArrange();
            for (Pttrai = 0; Pttrai < array.Length; Pttrai++)
            {
                for (Ptphai = Pttrai + 1; Ptphai < array.Length; Ptphai++)
                {
                    if (array[Pttrai] > array[Ptphai])
                    {
                        temp = array[Ptphai];
                        array[Ptphai] = array[Pttrai];
                        array[Pttrai] = temp;
                    }
                }
            }
            base.Arranged();
        }
    }

    class Insert : BasicAlgorithm
    {
        public void Chen()
        {
            Console.WriteLine("\nSắp xếp chèn");
            base.NotArrange();
            for (Pttrai = 1; Pttrai < array.Length;Pttrai++)
            {
                temp = array[Pttrai];
                Ptphai = Pttrai - 1;
                while ((Ptphai >= 0) && (temp < array[Ptphai]))
                {
                    array[Ptphai + 1] = array[Ptphai];
                    Ptphai--;
                }
                array[Ptphai + 1] = temp;
            }
            base.Arranged();
        }
    }

    class Bubble : BasicAlgorithm
    {
        public void NoiBot()
        {
            base.NotArrange();
            for (Pttrai = 0; Ptphai < array.Length - 1; Pttrai++)
            {
                for (Ptphai = array.Length - 1; Ptphai > Pttrai; Ptphai--) //so sánh bắt đầu vị trí array.length - 1
                {
                    if (array[Ptphai] > array[Ptphai - 1])
                    {
                        temp = array[Ptphai];
                        array[Ptphai] = array[Ptphai - 1];
                        array[Ptphai - 1] = temp;
                    }
                }
            }
            base.Arranged();
        }
    }


    class Program
    {
        private static void QuickSort(int[] A, int Trai, int Phai)
        {
            int temp, x;
            int Pttrai, Ptphai;
            Pttrai = Trai;
            Ptphai = Phai;
            x = A[Trai];
            do
            {
                while (Pttrai < Phai && A[Pttrai] < x)
                    Pttrai++;
                while (Ptphai > Trai && A[Ptphai] > x)
                    Ptphai--;
                if (Pttrai <= Ptphai)
                {
                    temp = A[Pttrai];
                    A[Pttrai] = A[Ptphai];
                    A[Ptphai] = temp;
                    Pttrai++;
                    Ptphai--;
                }
            }
            while (Pttrai <= Ptphai);
            {
                if (Trai < Ptphai) QuickSort(A, Trai, Ptphai);
                if (Pttrai < Phai) QuickSort(A, Pttrai, Phai);
            }
        }
        private static void ListAlgorithm() //in danh sách các thuật toán
        {
            int chon;
            int i = 1;
            bool test;
            Console.WriteLine("Danh sách cách thuật toán cơ bản");
            string[] Danhsach = { "Insert Sort", "Select Sort", "Buble Sort", "Quick Sort" };
            foreach (var item in Danhsach)
            {
                Console.WriteLine("{0}: " + item, i++);
            }
            Console.WriteLine("Chọn thuật toán bạn muốn thực hiện");
            test = int.TryParse(Console.ReadLine(), out chon);
            while (test == false) // Kiểm tra thông tin nhập vào
            {
                Console.WriteLine("Nhập sai thông tin. Vui Lòng nhập lại");
                test = int.TryParse(Console.ReadLine(), out chon);
                if (test == true)
                {
                    break;
                }
            }
            switch (chon)
            {
                case 1:
                    Select select = new Select();
                    select.Selection();
                    break;
                case 2:
                    Insert chen = new Insert();
                    chen.Chen();
                    break;
                case 3:
                    Bubble BB = new Bubble();
                    BB.NoiBot();
                    break;
                case 4:
                    int Pttrai;
                    Random rd = new Random();
                    Console.WriteLine("Nhập số phần từ trong mảng");
                    int Sophantu = Int32.Parse(Console.ReadLine());
                    int[] A = new int[Sophantu];
                    Console.WriteLine("Mảng chưa được sắp xếp");
                    for (Pttrai = 0; Pttrai < A.Length; Pttrai++)
                    {
                        A[Pttrai] = rd.Next(0, 100);
                        Console.Write(" " + A[Pttrai]);
                    }
                    QuickSort(A, 0, A.Length - 1);
                    Console.WriteLine("\nMảng đã được sắp xếp");
                    for (Pttrai = 0; Pttrai < A.Length; Pttrai++)
                    {
                        Console.Write(" " + A[Pttrai]);
                    }
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ListAlgorithm();
            int tieptuc;
            for (tieptuc = 0; ; tieptuc++) //Vòng lập tiếp tực sử dụng thuật toán mới
            {
                Console.WriteLine("\nBạn có muốn tiếp tục thực hiện thuật toán không?: 1 (Yes) - 2 (No)");
                tieptuc = Int32.Parse(Console.ReadLine());
                if (tieptuc == 1)
                {
                    ListAlgorithm();
                }
                else
                {
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
