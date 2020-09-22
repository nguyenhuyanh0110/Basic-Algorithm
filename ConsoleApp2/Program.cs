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
            Console.WriteLine("\nThời gian thực hiện thuật toán: {0}", st.Elapsed.ToString());
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
        public static void QuickSort(int[] A, int Trai, int Phai)
        {
            Stopwatch st = new Stopwatch();
            int temp, x;
            int Pttrai, Ptphai; //tạo 2 biến nằm ở vị trí 2 biên
            Pttrai = Trai;
            Ptphai = Phai;
            x = A[Trai]; // x lấy giá trị trái đầu tiên trong mảng
            do
            {
                while (Pttrai < Phai && A[Pttrai] < x) // biến nằm ở biên trái tăng dần nếu giá trị trong mảng nhỏ hơn X và giới hạn ở biên phải Phai
                    Pttrai++;
                while (Ptphai > Trai && A[Ptphai] > x) // biến nằm ở bên phải giảm dần nếu giá trị lớn trong mảng lớn hơn X và giới gạn ở biên Trai
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

        public static void Swap(int[] array, int Trai, int Giua, int Phai)
        {
            int Pttrai = Trai;
            int Ptphai = Giua + 1;
            int i = 0; //giá trị biến của mảng phụ
            int G = Phai - Trai + 1; //Xác định điểm giữa của mảng
            int[] B = new int[G];
            while ((Pttrai < Giua + 1) && (Ptphai < Phai + 1))
            {
                if (array[Pttrai] < array[Ptphai])
                {
                    B[i] = array[Pttrai];
                    Pttrai++; i++;
                }
                else
                {
                    B[i] = array[Ptphai];
                    Ptphai++; i++;
                }
            }
            while (Pttrai < Giua + 1)
            {
                B[i] = array[Pttrai];
                i++; Pttrai++;
            }
            while (Ptphai < Phai + 1)
            {
                B[i] = array[Ptphai];
                i++; Ptphai++;
            }
            Pttrai = Trai;
            for (i = 0; i < G; i++)
            {
                array[Pttrai] = B[i];
                Pttrai++;
            }
            
        }

        public static void Tron(int[] array, int Trai, int Phai)
        {
            int Giua;
            if (Phai <= Trai) //đệ quy đến khi 2 biên trái - phải gặp nhau thì dừng
                return;
            Giua = (Trai + Phai) / 2; //chia mảng lớn thành 2 mảng nhỏ
            Tron(array, Trai, Giua);
            Tron(array, Giua + 1, Phai);
            Swap(array, Trai, Giua, Phai);
        }
        private static void ListAlgorithm() //in danh sách các thuật toán
        {
            Stopwatch st = new Stopwatch();
            int Pttrai;
            int chon;
            int SoPt;
            int i = 1;
            bool test;
            Console.WriteLine("Danh sách cách thuật toán cơ bản");
            string[] Danhsach = { "Insert Sort", "Select Sort", "Buble Sort", "Quick Sort", "Merge Sort" };
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
                    Console.WriteLine("Nhập số phần từ trong mảng");
                    SoPt = Int32.Parse(Console.ReadLine());
                    int[] A = new int[SoPt];
                    Console.WriteLine("Mảng chưa được sắp xếp");
                    for (Pttrai = 0; Pttrai < A.Length; Pttrai++)
                    {
                        Random rd = new Random();
                        A[Pttrai] = rd.Next(0, 100);
                        Console.Write(" " + A[Pttrai]);
                    }
                    st.Start();
                    QuickSort(A, 0, A.Length - 1);
                    st.Stop();
                    Console.WriteLine("\nMảng đã được sắp xếp");
                    for (Pttrai = 0; Pttrai < A.Length; Pttrai++)
                    {
                        Console.Write(" " + A[Pttrai]);
                    }
                    Console.WriteLine("\nThời gian thực hiện thuật toán: {0}", st.Elapsed.ToString());
                    break;
                case 5:
                    Console.WriteLine("Nhập số phần từ trong mảng");
                    SoPt = Int32.Parse(Console.ReadLine());
                    int[] array = new int[SoPt];
                    Console.WriteLine("Mảng chưa được sắp xếp");
                    for (Pttrai = 0; Pttrai < array.Length; Pttrai++)
                    {
                        Random rd = new Random();
                        array[Pttrai] = rd.Next(0, 100);
                        Console.Write(" " + array[Pttrai]);
                    }
                    st.Start();
                    Tron(array, 0, array.Length - 1);
                    st.Stop();
                    Console.WriteLine("\nMảng đã được sắp xếp");
                    for (Pttrai = 0; Pttrai < array.Length; Pttrai++)
                    {
                        Console.Write(" " + array[Pttrai]);
                    }
                    Console.WriteLine("\nThời gian thực hiện thuật toán: {0}", st.Elapsed.ToString());
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
