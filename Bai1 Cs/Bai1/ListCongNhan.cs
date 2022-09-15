using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class ListCongNhan
    {
        public CongNhan Head;
        public CongNhan Tail;
        public ListCongNhan()
        {
            this.Head = null;
            this.Tail = null;
        }
        public bool IsEmpty()
        {
            if (this.Head == null)
                return true;
            else return false;
        }
        public int lenghthList()
        {
            int i = 0;
            CongNhan q = this.Head;
            while (q!=null){
               
                q = q.next;
                i++;
            }
            return i;
        }
        public void AddLastNV(CongNhan A)
        {
            if (IsEmpty())
            {
                this.Head = A;
                this.Tail = A;
            }
            else
            {
                this.Tail.next = A;
                A.prev = this.Tail;
                this.Tail = A;
            }
        }
        public void AddFirstCongNhan(CongNhan A)
        {
            if (IsEmpty())
            {
                this.Head = A;
                this.Tail = A;
            }
            else
            {
                this.Head.prev = A;
                A.next = this.Head;
                this.Head = A;
            }
        }
        public void AddAfterCongNhan(CongNhan A, CongNhan B)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Danh sach trong, ban co the su dung chuc nang them vao cuoi danh sach.");
            }
            else
            {
                if (this.Tail == B)
                {
                    this.Tail.next = A;
                    A.prev = this.Tail;
                    this.Tail = A;
                }
                else
                {
                    A.next = B.next;
                    A.prev = B;
                    B.next = A;

                }

            }
        }
        public void RemoveFirstCongNhan()
        {
            if (IsEmpty())
                Console.WriteLine("Danh sach trong, khong the xoa!");
            else
            {
                if (this.Head == this.Tail)
                {
                    this.Head = this.Tail = null;
                }
                else
                {
                    this.Head = this.Head.next;
                    Head.prev = null;
                }
            }
        }
        public void ReMoveLastCongNhan()
        {
            if (IsEmpty())
                Console.WriteLine("Danh sach trong, khong the xoa!");
            else
            {
                if (this.Head == this.Tail)
                {
                    this.Head = this.Tail = null;
                }
                else
                {
                    this.Tail = this.Tail.prev;
                    this.Tail.next = null;
                }
            }

        }
        public void RemoveCongNhanAfter(CongNhan A)
        {
            if (IsEmpty())
                Console.WriteLine("Danh sach trong, khong the xoa!");
            else
            {
                if (A.next == this.Tail)
                {
                    this.Tail = this.Tail.prev;
                    this.Tail.next = null;
                }
                else
                {
                    A.next.next.prev = A;
                    A.next = A.next.next;
                    
                }
            }
        }
        public CongNhan SearchCongNhan(string idd)
        {
            CongNhan B = new CongNhan();
            CongNhan A = new CongNhan();
            for (B = this.Head; B != null; B = B.next)
            {
                if (B.Id==idd)
                {
                    A = B;
                  
                    break;
                }
            }
            if (A.Id == null)
                return null;
            return A;
        }
        public void PrintList()
        {
            CongNhan B = new CongNhan();
            Console.WriteLine("-----------Danh sach cong nhan-----------\n");
            for(B=this.Head;B!=null;B=B.next)
            {
                B.InThongTin();
            }
        }
        public void PrintList2()
        {
            Console.WriteLine("----------------Danh sach cong nhan-------------\n");
            CongNhan B = new CongNhan();
            for (B = this.Tail; B != null; B= B.prev)
            {
                B.InThongTin();
            }
        }
        public void TimCongNhanDaVeHuu()
        {
            ListCongNhan Ds = new ListCongNhan();
            CongNhan B = new CongNhan();
            for (B = this.Head; B != null; B = B.next)
            {
                if (B.Vehuu)
                {
                    Ds.AddLastNV(B);
                }
            }
                Ds.PrintList();
           
        }
        public void RemoveAllCongNhan()
        {
            while (this.Head != null)
            {
                this.ReMoveLastCongNhan();
            }
        }
        public void RemoveCongNhan(CongNhan A)
        {
            if (A == this.Head)
            {
                this.RemoveFirstCongNhan();
            }
            else
            {
                if(A==this.Tail)
                {
                    ReMoveLastCongNhan();
                }
                else
                {
                    A.next.prev = A.prev;
                    A.prev.next = A.next;
                }
            }
        }
        public void SelectionSort()
        {
            ListCongNhan ds2 = new ListCongNhan();
            int i = 0;
            CongNhan min = new CongNhan();
            CongNhan B = new CongNhan();
            while(i<this.lenghthList())
            {
                min = this.Head;
                B = min.next;
                while (B != null)
                {
                    if (B.Dientich < min.Dientich)
                        min = B;
                    B = B.next;
                }
                this.RemoveCongNhan(min);
                ds2.AddLastNV(min);
                
            }
            this.Head = ds2.Head;
            this.Tail = ds2.Tail;
            this.Head.prev = null;
            i++;
               
        }
        public void QuickSort()
        {
            ListCongNhan ds1 = new ListCongNhan();
            ListCongNhan ds2 = new ListCongNhan();
            CongNhan pivot = new CongNhan();
            CongNhan p = new CongNhan();
            if (this.Head == this.Tail)
            {
                return;
            }
            pivot = this.Head;
            p = this.Head.next;
            while (p != null)
            {
                CongNhan q = new CongNhan();
                q = p;
                p = p.next;
                q.next = null;
                q.prev = null;
                if (q.Dientich < pivot.Dientich)
                    ds1.AddLastNV(q);
                else
                    ds2.AddLastNV(q);
            }
            ds1.QuickSort();
            ds2.QuickSort();
            if (!ds1.IsEmpty())
            {
                this.Head = ds1.Head;
                ds1.Tail.next = pivot;
                pivot.prev = ds1.Tail;
               
            }
            else
                this.Head = pivot;
            pivot.next = ds2.Head;
            if (!ds2.IsEmpty())
            {
                
                ds2.Head.prev = pivot;
                this.Tail = ds2.Tail;
            }
            else
            {
                this.Tail = pivot;
            }
        }
        public void MergeList(ListCongNhan A)
        {
            this.Tail.next = A.Head;
            A.Head.prev = this.Tail;
            this.Tail = A.Tail;
        }
        public void EnterDs()
        {
            int i = 1;
            int e = 1;
            do
            {
                Console.WriteLine("Neu muon ket thuc qua trinh nhap nay hay nhan so am bat ki,muon tiep tuc an so duong bat ki");
                i = Convert.ToInt16(Console.ReadLine());
                if (i < 0) break;
                Console.WriteLine("Cong nhan thu {0}", e);

                CongNhan x = new CongNhan();
                x.EnterCongNhan();

                this.AddLastNV(x);
                e++;
            }
            while (i >= 0);
           
            return;
        }
    }
}

