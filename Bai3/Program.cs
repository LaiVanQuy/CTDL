using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bai3
{
    class Program
    {
        public static HashTable hashTable = new HashTable();
        public static void Converter(HashTable A)
        {
            string[] text = File.ReadAllLines("tudien.txt");
            for(int i=0;i<=text.Length-3;i+=3)
            {
                Word w = new Word();
                w.chu = text[i].Trim();
                w.loai = text[i + 1].Trim();
                w.nghia = text[i + 2].Trim();
                A.AddItem(w);
            }
        }
        public static void PrintMenu()
        {
            Console.WriteLine("\n\t\t\t\t\t ____________ Từ điển  __________");
            Console.WriteLine("\t\t\t\t\t|                                |");
            Console.WriteLine("\t\t\t\t\t| 1. Tra từ trong từ điển        |");
            Console.WriteLine("\t\t\t\t\t|                                |");
            Console.WriteLine("\t\t\t\t\t| 2. Thêm từ vào từ điển         |");
            Console.WriteLine("\t\t\t\t\t|                                |");
            Console.WriteLine("\t\t\t\t\t| 3. In ra từ điển               |");
            Console.WriteLine("\t\t\t\t\t|                                |");
            Console.WriteLine("\t\t\t\t\t| 0. Thoát chương trình          |");
            Console.WriteLine("\t\t\t\t\t|________________________________|");

        }
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            Converter(hashTable); // truyền dữ liệu từ file text vào 

            PrintMenu();
            int option;
            do
            {
                Console.Write(" Nhập lựa chọn của bạn: ");
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            int ascii; string str;
                            do
                            {
                                Console.Write(" Mời bạn nhập từ muốn tra: ");
                                str = Console.ReadLine();
                                ascii = (int)str[0];
                                if (ascii < 65 || ascii > 90) // kiểm tra kí tự đầu có phải viết hoa không?
                                {
                                    Console.WriteLine(" *Chữ cái đầu phải viết hoa*");
                                }
                            } while (ascii < 65 || ascii > 90);

                            hashTable.SearchItem(str); // tìm tiếm từ
                            break;
                        }
                    case 2:
                        {
                            Word x = new Word(); int ascii;
                            
                            do
                            {
                                Console.Write(" Nhập từ bạn cần thêm: ");
                                x.chu = Console.ReadLine(); 
                                ascii = (int)x.chu[0];
                                if (ascii < 65 || ascii > 90) // kiểm tra kí tự đầu có phải viết hoa không?
                                {
                                    Console.WriteLine(" *Chữ cái đầu phải viết hoa*");
                                }
                            } while (ascii < 65 || ascii > 90);
                            Console.Write(" Nhập loại từ (n: Danh từ, adj: Tính từ, adv: Trạng từ): ");
                            x.loai = Console.ReadLine();
                            Console.Write(" Nhập nghĩa Tiếng Việt:  ");
                            x.nghia = Console.ReadLine();
                            hashTable.AddItem(x); // them tu bao tu dien;
                            Console.WriteLine("           - Thêm từ vào thành công -");
                            break;
                        }
                    case 3:
                        {
                            Console.OutputEncoding = Encoding.UTF8;
                            Console.Write("\n-----------------------------------------\n");
                            hashTable.PrintHashTable();
                            Console.Write("\n-----------------------------------------\n");
                            break;
                        }
                }
            } while (option != 0);

            Console.WriteLine("\n\t\t\t\t   - Cảm ơn vì đã sử dụng từ điển của chúng tôi -");
            Console.ReadKey();
        }
    }
}
