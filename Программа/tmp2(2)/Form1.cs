using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tmp2_2_
{
    public partial class Form1 : Form
    {
        delegate double TheFunc(double x);
        delegate IntPtr FuncName();

        [DllImport(
        @"C:\Users\ygonnik\source\repos\tmp2(2)\bin\Debug\Plugins\Lib2-2-1.dll",
        EntryPoint = "TheFunc",
        CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc1(double x);

        [DllImport(
        @"C:\Users\ygonnik\source\repos\tmp2(2)\bin\Debug\Plugins\Lib2-2-2.dll",
        EntryPoint = "TheFunc",
        CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc2(double x);

        [DllImport(
        @"C:\Users\ygonnik\source\repos\tmp2(2)\bin\Debug\Plugins\Lib2-2-3.dll",
        EntryPoint = "TheFunc",
        CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc3(double x);

        [DllImport(
        @"C:\Users\ygonnik\source\repos\tmp2(2)\bin\Debug\Plugins\MyCppDll.dll",
        EntryPoint = "TheFunc",
        CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc4(double x);

        [DllImport(
        @"C:\Users\ygonnik\source\repos\tmp2(2)\bin\Debug\Plugins\MyCDll.dll",
        EntryPoint = "TheFunc",
        CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc5(double x, double a, double b, double c);

        [DllImport(
        @"C:\Users\ygonnik\source\repos\tmp2(2)\bin\Debug\Plugins\project1.dll",
        EntryPoint = "TheFunc",
        CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc6(double x);
        

        public Form1(int index, string FuncName)
        {
            InitializeComponent();

            TheFunc func;

            switch (index)
            {
                case 0:
                    func = TheFunc1;
                    break;
                case 1:
                    func = TheFunc2;
                    break;
                case 2:
                    func = TheFunc3;
                    break;
                case 3:
                    func = TheFunc4;
                    break;
                case 4:
                    func = TheFunc6;
                    break;
                default:
                    func = TheFunc1;
                    break;
            }

            double y;

            for (double x = 0; x <= 10; x++)
            {
                chart1.Series[0].Name = FuncName;
                y = func(x);
                chart1.Series[FuncName].Points.AddXY(x, y);
            }
        }

        public Form1(string FuncName, double a, double b, double c)
        {
            InitializeComponent();
            double y;

            for (double x = 0; x <= 10; x++)
            {
                chart1.Series[0].Name = FuncName;
                y = TheFunc5(x, a, b, c);
                chart1.Series[FuncName].Points.AddXY(x, y);
            }
        }
    }
}
