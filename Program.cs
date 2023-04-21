using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tuan07
{
    class Program
    {
        static void Main(string[] args)
        {
            // Xuất text theo Unicode (có dấu tiếng Việt)
            Console.OutputEncoding = Encoding.Unicode;
            // Nhập text theo Unicode (có dấu tiếng Việt)
            Console.InputEncoding = Encoding.Unicode;

            /* Tạo menu */
            Menu menu = new Menu();
            string title = "ĐƯỜNG ĐI NGẮN NHẤT";   // Tiêu đề menu
            // Danh sách các mục chọn
            string[] ms = { "1. Bài 0: Tìm đường đi ngắn nhất từ một đỉnh đến các đỉnh còn lại",
                "2. Bài 1: Tìm đường đi từ đỉnh x đến y",
                "3. Bài 2: Tìm đường đi ngắn nhất qua đỉnh trung gian",
                "4. Bài 3: Đường đi ngắn nhất giữa các cặp đỉnh",
                "0. Thoát" };
            int chon;
            do
            {
                Console.Clear();
                // Xuất menu
                menu.ShowMenu(title, ms);
                Console.Write("     Chọn : ");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            // Tìm đường ngắn nhất từ một đỉnh đến các đỉnh còn lại
                            string filePath = "../../../TextFile/WeightMatrix.txt";
                            WeightMatrix g = new WeightMatrix();
                            g.FileToWeightMatrix(filePath); g.Output();
                            Console.WriteLine();
                            Console.Write(" Nhập đỉnh xuất phát : ");
                            int s = int.Parse(Console.ReadLine());
                            Console.WriteLine();
                            g.Dijkstra(s);
                            g.PrintDijkstra(s);
                            break;
                        }
                    case 2:
                        {
                            // Bài 1 : Tìm đường ngắn nhất từ x đến y
                            string filePath = "../../../TextFile/MatrixBai1.txt";
                            WeightMatrix g = new WeightMatrix();
                            g.FileToWeightMatrix(filePath); g.Output();
                            Console.WriteLine();
                            Console.Write(" Nhập đỉnh xuất phát x = ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write(" Nhập đỉnh đích y = ");
                            int y = int.Parse(Console.ReadLine());
                            g.MinRouteXY(x, y);
                            break;
                        }
                    case 3:
                        {
                            // Bài 2: Đường đi ngắn nhất qua đỉnh trung gian
                            string filePath = "../../../TextFile/MatrixBai1.txt";
                            WeightMatrix g = new WeightMatrix();
                            g.FileToWeightMatrix(filePath); g.Output();
                            Console.WriteLine();
                            Console.Write(" Nhập đỉnh xuất phát x = ");
                            int x = int.Parse(Console.ReadLine());
                            Console.Write(" Nhập đỉnh trung gian y = ");
                            int y = int.Parse(Console.ReadLine());
                            Console.Write(" Nhập đỉnh đích z = ");
                            int z = int.Parse(Console.ReadLine());
                            g.MinRouteXYZ(x, y, z);	// Xuất đường đi
                            break;
                        }
                    case 4:
                        {
                            // Bài 3: Đường đi ngắn nhất giữa các cặp đỉnh - thuật toán Floyd
                            string filePath = "../../../TextFile/MatrixBai3.txt";
                            WeightMatrix g = new WeightMatrix();
                            g.FileToWeightMatrix(filePath); g.Output();
                            Console.WriteLine();
                            g.Floyd();
                            for (int i = 0; i < g.N - 1; i++)
                                for (int j = 0; j < g.N; j++)
                                    if (i != j) g.Floyd_RouteXY(i, j);
                            break;
                        }
                }
                Console.ReadKey();
            } while (chon != 0);
        }
    }
}
