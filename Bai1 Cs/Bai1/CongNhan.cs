using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    public class CongNhan
    {
        private string id;
        private string ten;
        private double dientich;
        public enum MucBaoHiem
        {
            Cao,
            TrungBinh,
            Thap
        }
        private MucBaoHiem mucbaohiem;
        private bool vehuu;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Ten
        {
            get
            {
                return ten;
            }
            set
            {
                ten = value;
            }
        }
                

        public double Dientich { 
            get {
                return dientich;
            }
            set {
                dientich = value;
            }
        }
        public MucBaoHiem Mucbaohiem
        {
            get
            {
                return mucbaohiem; 
            }
            set
            {
                mucbaohiem = value;
            }
        }
        public bool Vehuu
        {
            get
            {
                return vehuu;
            }
            set
            {
                vehuu = value;
            }
        }
        public CongNhan() { }
        public CongNhan(string id,string ten, double dientich, MucBaoHiem mucbaohiem, bool vehuu)
        {
            Id = id;
            Ten = ten;
            Dientich = dientich;
            Mucbaohiem = mucbaohiem;
            Vehuu = vehuu;
            this.next = null;
            this.prev = null;
        }
        public CongNhan next;
        public CongNhan prev;
        public void EnterCongNhan()
        {
            Console.WriteLine("Nhap Id:");
            string idd = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap ten:");
            string name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Nhap dien tich (ha):");
            double dt = Convert.ToDouble(Console.ReadLine());

            int n = 0;
            while (n != 1 && n != 3 && n != 2)
            {
                Console.WriteLine("Nhap muc bao hiem:(nhap 1 neu la muc cao,2 neu la trung binh,3 neu la thap");
                n = Convert.ToInt16(Console.ReadLine());

            }

            int i = 2;
            while (i != 1 && i != 0)
            {
                Console.WriteLine("Nhap thong tin ve huu(1 neu da ve huu,0 neu chua ve huu)");
                i = Convert.ToInt16(Console.ReadLine());
            }
            this.id = idd;
            this.ten = name;
            this.dientich = dt;
            this.mucbaohiem = (n == 1?MucBaoHiem.Cao: n==2? MucBaoHiem.TrungBinh:MucBaoHiem.Thap);
            this.vehuu = (i == 1 ? true : false);
        }
        public void InThongTin()
        {
            Console.WriteLine("ID:{0} \t Ten:{1} \t Dien tich:{2}ha \t Muc bao hiem:{3} Ve Huu:{4} \t ",
                    this.Id, this.Ten, this.Dientich, this.Mucbaohiem==MucBaoHiem.Cao?"Cao":this.Mucbaohiem==MucBaoHiem.Thap?"Thap":"Trung Binh", this.Vehuu ? "Da ve huu" : "Chua ve huu");
        }
    }
}
