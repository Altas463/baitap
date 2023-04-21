using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Tuan07
{
    class WeightMatrix
    {
        public int n;
        public int[,] a;
        // Các array là biến toàn cục chỉ phục vụ cho giải thuật
        int[] pre;
        int[] dist;
        bool[] visited;
        int[,] p;
        int[,] d;
        // propeties
        public int N { get => n; set => n = value; }
        public int[,] A { get => a; set => a = value; }
        // constructor không đối số
        public WeightMatrix() { }
        // constructor có đối số
        public WeightMatrix(int k)
        {
            n = k;
            a = new int[n, n];
        }
        public void FileToWeightMatrix(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            n = int.Parse(sr.ReadLine());
            a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] s = sr.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    if (i == j) a[i, j] = 0;
                    else
                        a[i, j] = int.Parse(s[j]) > 0 ? int.Parse(s[j]) : int.MaxValue;
            }
            sr.Close();
        }
        public void Output()
        {
            Console.WriteLine("Đồ thị ma trận kề - số đỉnh : " + n);
            Console.WriteLine();
            Console.Write(" Đỉnh |");
            for (int i = 0; i < n; i++) Console.Write("    {0}", i);
            Console.WriteLine(); Console.WriteLine("  " + new string('-', 6 * n));
            for (int i = 0; i < n; i++)
            {
                Console.Write("    {0} |", i);
                for (int j = 0; j < n; j++)
                    if (a[i, j] < int.MaxValue) Console.Write("  {0, 3}", a[i, j]);
                    else Console.Write("  {0, 3}", "_");
                Console.WriteLine();
            }
        }
        public void Dijkstra(int s)
        {
            // Khởi tạo pre : Lưu đỉnh nằm trước trên đường từ s đi qua
            pre = new int[n];
            // Khởi tạo dist : Lưu độ dài ngán nhất từ s đến các đỉnh còn lại
            dist = new int[n];
            // Khởi tạo visited : Đánh dấu đỉnh đã đi qua
            visited = new bool[n];
            // Khởi gán giá trị ban đầu cho dist[], pre[], visited[]
            for(int i= 0; i < n; i++)
            {
                pre[i] = s;
                dist[i] = int.MaxValue;
                visited[i] = false;
            }
            // cho : dist[s] = 0;
            dist[s] = 0;
            // Duyệt các đỉnh của đồ thị
            for (int l = 0; l < n; l++)
            {
                // Gọi u là đỉnh sao cho dist[u] nhỏ nhất (u = dmin())}
                int i = dmin();
                // Đánh dấu u
                visited[i] = true;
                // Duyệt các đỉnh v thuộc Kề(u) (tồn tại cạnh (u, v) )
                for (int u = 0; u < n; u++)
                {
                    // Nếu (v chưa đánh dấu) và (tồn tại cạnh (u,v))
                    // Nếu (dist[u] đã xác định) và (dist[u] + a[u, v] < dist[v])
                     if (!visited[u] && a[i, u] != int.MaxValue && dist[u] > dist[i] + a[i, u])
                        {
                        // Đặt dist[v] = dist[u] + a[u, v];
                        // Đặt đỉnh u trước v trên đường đi
                        dist[u] = dist[i] + a[i, u];
                        pre[u] = i;
                    }
                }
            }
            // Kết quả : xác định giá trị các phần tử của dist[] và pre[]  xuất lên màn hình
        }
        // Tìm đỉnh minIndex có dist[minIndex] là nhỏ nhất
        public int dmin()
        {
            int minIndex = 0;   // Giá trị trả về
            int min = int.MaxValue;
            // Tìm min tại các đỉnh chưa xét
            for (int i = 0; i < n; i++)
            {
                if (!visited[i] && dist[i] < min) 
                {
                    minIndex = i;
                    min = dist[i];
                }
            }
            return minIndex;
        }
        // Xuất kết quả dist[] và pre[]
        public void PrintDijkstra(int s)
        {
            Console.WriteLine("Đường đi ngắn nhất từ " + s + " đến các đỉnh còn lại : ");
            // Xuất số hiệu các đỉnh
            Console.Write("  Đỉnh : ");
            for (int i = 0; i < n; i++)
                Console.Write("  " + i);
            Console.WriteLine();
            Console.WriteLine("          " + new string('-', 3 * n));
            // Xuất array pre[]
            Console.Write("   pre : ");
            for (int i = 0; i < n; i++)
                Console.Write("{0, 3}", pre[i]);
            Console.WriteLine();
            // Xuất array dist[]
            Console.Write("  dist : ");
            for (int i = 0; i < n; i++)
                if (dist[i] < int.MaxValue) Console.Write("{0, 3}", dist[i]);
                else Console.Write("{0, 3}", "x");
        }
        // Bài 1 : Tìm đường ngắn nhất từ x đến y
        public void MinRouteXY(int x, int y)
        {
            // Chọn x là đỉnh xuất phát
            Dijkstra(x);

            // Kết quả : 2 array pre[] và dist[] có giá trị
            // Dựa vào 2 array pre và dist  xuất đường đi như đã làm trong buổi 3  6
            Stack<int> path = new Stack<int>();
            int current = y;
            while (current != x)
            {
                path.Push(current);
                current = pre[current];
            }
            path.Push(x);

            // Xuất ra đường đi từ x đến y
            Console.Write("Đường đi từ " + x + " đến " + y + " là: ");
            while (path.Count > 1)
            {
                Console.Write(path.Pop() + " -> ");
            }
            Console.Write(path.Pop() + "\n");
            Console.WriteLine("Độ dài đường đi từ " + x + " đến " + y + " là: " + dist[y]);
        }
        // Bài 2: Đường đi ngắn nhất từ x đến z qua đỉnh trung gian y
        public void MinRouteXYZ(int x, int y, int z)
        {
            Dijkstra(x);
            int d1 = dist[y];
            MinRouteXY(x, y);
            MinRouteXY(y, z);
            Dijkstra(y);
            int d2 = dist[z];
            int d = d1 + d2;
            Console.WriteLine("Độ dài đường đi từ " + x + " đến " + z + " là: {0} ", d);
        }
        // Bài 3 : Đường đi ngắn nhất giữa các cặp đỉnh : giải thuật Floyd
        public void Floyd()
        {
            // Bước 1 : khởi tạo giá trị cho d[,], p[,]
            d = new int[n, n];
            p = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    d[i, j] = a[i, j];
                    p[i, j] = i;
                }
            // Bước 2 : ?
            for (int k = 0; k < n; k++)
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (d[i, j] > d[i, k] + d[k, j])
                        {
                            d[i, j] = d[i, k] + d[k, j];
                            p[i, j] = p[k, j];
                        }

           
        }
        //Xuất ma trận d và p
        public void Outdp()
        {

        }
        // Sử dụng 2 ma trận d và p để xuất đường đi ngắn nhất từ x đến y
        public void Floyd_RouteXY(int x, int y)
        {
        }

    }
}