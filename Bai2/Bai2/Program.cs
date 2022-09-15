using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Bai2
{
    class Program
    {
        public static int Chuyendoi(char s)
        {
            return s - 48;
        }

        public static int DoUuTien(char s)
        {
            if (s == '^')
                return 3;
            if (s == '*' || s == '/')

                return 2;
            if (s == '+' || s == '-')
                return 1;
            return 0;
        }
        private static bool KTToanTu(char s)
        {
            if (s == '+' || s == '-' || s == '*' || s == '/'|| s=='^' )
                return true;
            else return false;
        }
        public static bool KTToanHang(char s)
        {
            if (s == '0' || s == '1' || s == '2' || s == '3' || s == '4' || s == '5' || s == '6' || s == '7' || s == '8' || s == '9')
                return true;
            else return false;
        }
        public static Queue<char> ChuyenSangHauTo(string infix)
        {
            Stack<char> stack = new Stack<char>();
            Queue<char> queue = new Queue<char>();
            
            foreach (char s in infix)
            {
                if (KTToanHang(s))
                    queue.EnQueue(s);
                else if (s == '(')
                    stack.Push(s);
                else if (s == ')')
                {
                    char x = stack.Pop();
                    while (x != '(')
                    {
                        queue.EnQueue(x);
                        x = stack.Pop();
                    }
                }
                else
                {
                    while (stack.Count() > 0 && DoUuTien(s) <= DoUuTien(stack.Top()))
                    {
                        queue.EnQueue(stack.Pop());
                    }
                    stack.Push(s);
                }
            }
            while (stack.Count() > 0)
            {
                queue.EnQueue(stack.Pop());
            }
            return queue;
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------Máy tính mini-----\n");
            Console.WriteLine("1.Tinh gia tri bieu thuc\n" +
                "2.Thoat ung dung");
            int i = 3;
            while (true)
            {
                i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        {
                            Console.WriteLine("Nhập biểu thức toán học cần tính ( chỉ nhập số có 1 chữ số và các phép toán + - * / ^ và không chứa dấu cách ) \n");
                            string infix = Convert.ToString(Console.ReadLine());
                            Queue<char> myqueue = new Queue<char>();
                            myqueue = ChuyenSangHauTo(infix);
                            Stack<double> mystack = new Stack<double>();
                            while (!myqueue.IsEmpty())
                            {
                                char x = myqueue.Peek();
                                if (!KTToanTu(x))
                                {
                                    double c = Chuyendoi(x);
                                    mystack.Push(c);
                                    myqueue.DeQueue();
                                }
                                if (KTToanTu(x))
                                {
                                    double s = mystack.Pop();
                                    double a = mystack.Pop();
                                    if (x == '+')
                                    {
                                        double kq = s + a;

                                        mystack.Push(kq);
                                        myqueue.DeQueue();
                                    }
                                    if (x == '-')
                                    {

                                        double kq = a - s;

                                        mystack.Push(kq);
                                        myqueue.DeQueue();
                                    }
                                    if (x == '*')
                                    {

                                        double kq = s * a;

                                        mystack.Push(kq);
                                        myqueue.DeQueue();
                                    }
                                    if (x == '/')
                                    {

                                        double kq = a / s;

                                        mystack.Push(kq);
                                        myqueue.DeQueue();
                                    }
                                    if (x == '^')
                                    {
                                        double kq = Math.Pow(a, s);
                                        mystack.Push(kq);
                                        myqueue.DeQueue();
                                    }
                                }
                            }
                            double result = mystack.Pop();

                            Console.WriteLine("Ket qua:{0}", result);
                            break;
                        }
                    case 2:
                        {
                            return;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            

            Console.ReadKey();

        }
    }
}
