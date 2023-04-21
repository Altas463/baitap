using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuan07
{
    class Menu
    {
        string mtitle;   // Lưu tiêu đề menu
        string[] itemList;  // Lưu các mục chọn
        public string Mtitle { get => mtitle; set => mtitle = value; }
        public string[] ItemList { get => itemList; set => itemList = value; }
        public Menu()
        { }
        public void ShowMenu(string title, string[] itemS)
        {
            // Tạo các mục chọn
            mtitle = title;
            itemList = new string[itemS.Length]; itemList = itemS;
            // Chiều rộng của mẫu báo cáo
            int width = title.Length + 75;
            // Top
            Console.Write("┌");
            Console.Write(new string('─', width));
            Console.WriteLine("┐");
            // Tiêu đề cột
            Console.Write("│");
            Console.Write((new string(' ', 25)) + mtitle + (new string(' ', 25)));
            Console.WriteLine("│");
            // Bottom của dòng tiêu đề cột
            Console.Write("├");
            Console.Write(new string('─', width));
            Console.WriteLine("┤");
            // Các mục chọn
            for(int i = 0; i < ItemList.Length; i++)
            {
                Console.Write("│");
                Console.Write((new string(' ', 15)) + itemList[i]);
                Console.WriteLine(new string(' ', count: Math.Max(0, width - (15 + itemList[i].Length))) + "│");
            }
            // Bottom của bảng
            Console.Write("└");
            Console.Write(new string('─', width));
            Console.WriteLine("┘");
        }
    }
}
