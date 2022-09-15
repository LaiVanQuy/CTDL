using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CongNhan A = new CongNhan("001","Lai Van Quy", 1, CongNhan.MucBaoHiem.Cao, false);
            CongNhan B = new CongNhan("002","Tran The Vy", 2, CongNhan.MucBaoHiem.TrungBinh, true);
            CongNhan C = new CongNhan("003","Nguyen Thi Thu", 2.5, CongNhan.MucBaoHiem.Thap, true);
            CongNhan D = new CongNhan("004","Obama Philaden", 5, CongNhan.MucBaoHiem.Cao, true);
            CongNhan E = new CongNhan("005","Nguyen Van Phuong", 3, CongNhan.MucBaoHiem.Cao, false);
            CongNhan F = new CongNhan("006","Bui Thi Dinh", 1.5, CongNhan.MucBaoHiem.TrungBinh, false);
           


            ListCongNhan DSCongNhan = new ListCongNhan();
            ListCongNhan Ds2 = new ListCongNhan();
            DSCongNhan.AddLastNV(C);
            DSCongNhan.AddLastNV(A);
            DSCongNhan.AddLastNV(B);
            DSCongNhan.AddLastNV(D);
            DSCongNhan.PrintList();
           
            Console.WriteLine("-------------------Ung dung quan li danh sach cong nhan cua cong ty ca phe---------------\n");
   
            Console.WriteLine("Chon tinh nang ban muon su dung") ;
            Console.WriteLine(
                "1.Tao thong tin 1 cong nhan\n" +
                "2.Them cong nhan vao dau danh sach\n" +
                "3.Them cong nhan vao cuoi danh sach\n" +
                "4.Them cong nhan vao sau 1 cong nhan trong danh sach\n" +
                "5.Xoa cong nhan dau tien trong danh sach\n" +
                "6.Xoa cong nhan cuoi cung trong danh sach\n" +
                "7.Xoa cong nhan dung sau 1 cong nhan trong danh sach\n" +
                "8.Tim kiem cong nhan theo Id trong dach sach\n" +
                "9.Tim kiem nhung cong nhan da ve huu\n" +
                "10.Sap xep xep danh sach cong nhan tang dan theo dien tich theo SelectionSort\n" +
                "11.Sap xep danh sach cong nhan tang dan theo dien tich QuickSort\n" +
                "12.Ghep 2 danh sach\n" +
                "13.In danh sach theo chieu thuan\n" +
                "14.In danh sach theo chieu nghich\n" +
                "15.Xoa danh sach\n" +
                "16.Tao 1 danh sach moi\n" +
                "17.Thoat chuong trinh");
            void ChonThaoTacTiepTheo()
            {
                Console.WriteLine("Moi ban chon thao tac tiep theo");
            }
            int i;
            
            while (true)
            {
                i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        {
                            //Tao thong tin 1 cong nhan
                            CongNhan G = new CongNhan();
                            G.EnterCongNhan();
                            Console.WriteLine("----Ket qua-----");
                            G.InThongTin();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Tao thong tin cong nhan can them\n");
                            //Them cong nhan vao dau danh sach
                            CongNhan x = new CongNhan();
                            x.EnterCongNhan();
                            DSCongNhan.AddFirstCongNhan(x);
                            Console.WriteLine("----Ket qua----\n");
                            DSCongNhan.PrintList();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 3:
                        {
                            //Them cong nha vao cuoi danh sach
                            Console.WriteLine("Tao thong tin cong nhan can them\n");
                            CongNhan x = new CongNhan();
                            x.EnterCongNhan();
                            DSCongNhan.AddLastNV(x);
                            Console.WriteLine("----Ket qua----\n");
                            DSCongNhan.PrintList();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 4:
                        {
                            //Them cong nhan vao sau 1 cong nhan trong danh sach
                            Console.WriteLine("Tao thong tin cong nhan can them\n");
                            CongNhan x = new CongNhan();
                            x.EnterCongNhan();
                            Console.WriteLine("Nhap Id cong nhan ma muon them vao sau no");
                            string z = Convert.ToString(Console.ReadLine());
                            CongNhan y = DSCongNhan.SearchCongNhan(z);
                            if (y == null)
                            {
                                Console.WriteLine("Khong tim thay cong nhan vua nhap trong danh sach");
                            }
                            else
                            {
                                DSCongNhan.AddAfterCongNhan(x, y);
                                Console.WriteLine("-----Ket qua----");
                                DSCongNhan.PrintList();
                            }
                            break;

                        }
                    case 5:
                        {
                            //xoa cong nhan dau tien
                            DSCongNhan.RemoveFirstCongNhan();
                            Console.WriteLine("----Ket qua----");
                            DSCongNhan.PrintList();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 6:
                        {
                            //xoa cong nhan cuoi cung
                            DSCongNhan.ReMoveLastCongNhan();
                            Console.WriteLine("----Ket qua----");
                            DSCongNhan.PrintList();
                            break;
                        }
                    case 7:
                        {
                            //xoa cong nhan sau 1 cong nhan
                            Console.WriteLine("Nhap Id cong nhan ma ban muon xoa cong nhan dung sau cong nhan do");
                            string z = Convert.ToString(Console.ReadLine());
                            CongNhan x = new CongNhan();
                            x = DSCongNhan.SearchCongNhan(z);
                            if(x==null)
                            {
                                Console.WriteLine("Khong tim thay cong nhan co Id ban vua nhap");
                                ChonThaoTacTiepTheo();
                            }
                            else
                            {
                                DSCongNhan.RemoveCongNhanAfter(x);
                                Console.WriteLine("----Ket qua----");
                                DSCongNhan.PrintList();
                                ChonThaoTacTiepTheo();
                            }
                            break;
                        }
                    case 8:
                        {
                            //Tim cong nhan theo id trong danh sach
                            Console.WriteLine("Nhap Id cong nhan ban muon tim");
                            string z = Convert.ToString(Console.ReadLine());
                            CongNhan x = new CongNhan();
                            x = DSCongNhan.SearchCongNhan(z);
                            if (x == null)
                            {
                                Console.WriteLine("Khong tim thay cong nhan co id {0}", z);
                                ChonThaoTacTiepTheo();
                            }

                            else
                            {
                                Console.WriteLine("Tim thay cong nhan co Id {0}\n", z);
                                x.InThongTin();
                                ChonThaoTacTiepTheo();
                            }
                            break;
                        }
                    case 9:
                        {
                            //Tim kiem nhung cong nhan da ve huu
                            DSCongNhan.TimCongNhanDaVeHuu();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 10:
                        {
                            //SelectionSort
                            DSCongNhan.SelectionSort();
                            Console.WriteLine("----Ket qua----");
                            DSCongNhan.PrintList();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 11:
                        {
                            //QuickSort
                            DSCongNhan.QuickSort();
                            DSCongNhan.QuickSort();
                            Console.WriteLine("----Ket qua----");
                            DSCongNhan.PrintList();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 12:
                        {
                            //ghep 2 danh sach
                            Console.WriteLine("Nhap danh sach moi:");
                            Ds2.EnterDs();
                            DSCongNhan.MergeList(Ds2);
                            Console.WriteLine("-----Ket qua-----");
                            DSCongNhan.PrintList();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 13:

                        {
                            //in danh sach theo chieu thuan
                            DSCongNhan.PrintList();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 14:

                        {
                            //in danh sach theo chieu nghich
                            DSCongNhan.PrintList2();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 15:
                        {
                            //xoa danh sach
                            DSCongNhan.RemoveAllCongNhan();
                            DSCongNhan.PrintList();
                            Console.WriteLine("Danh sach rong");
                            ChonThaoTacTiepTheo();
                            break;
                        }
                    case 16:
                        {
                            Console.WriteLine("Nhap danh sach moi:");
                            Ds2.EnterDs();
                            Console.WriteLine("-----Ket qua-----");
                            Ds2.PrintList();
                            ChonThaoTacTiepTheo();
                            break;
                        }
                        case 17:
                        {
                            
                            return;

                        }
                    default:
                        {
                            Console.WriteLine("Tuy chon khong hop le");
                            break;
                        }
                }
            }

          
            Console.ReadKey();
        }
    }
}
