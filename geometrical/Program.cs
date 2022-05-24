using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu;

namespace geometrical
{
    interface IPart
    {
        void PrintFigure(int x, int y,ConsoleColor cc);
    }
    class Rectangle:IPart
    {
        public void PrintFigure(int x,int y, ConsoleColor cc)
        {
            ConsoleColor qq = Console.ForegroundColor;
            for (int l = 0; l < 10; l++)
            {
                Console.ForegroundColor = cc;
                Console.SetCursorPosition(x, y++);
                for (int p = 0; p < 10; p++)
                {
                    Console.Write("* ");
                }
                Console.Write('\n');
            }
            Console.ForegroundColor = qq;
        }
    }

    class Triangle : IPart
    {
        public void PrintFigure(int x, int y, ConsoleColor cc)
        {
            ConsoleColor qq = Console.ForegroundColor;
            Console.ForegroundColor = cc;
            int w = 11;
            for (int i = 1; i < w; i++)
            {
                Console.SetCursorPosition(x, y++);
                for (int j = 0; j < w - i; j++)
                {
                    Console.Write(' ');
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = qq;
        }
    }

    class Rhombus : IPart
    { 
        public void PrintFigure(int x, int y, ConsoleColor cc)
        {
            ConsoleColor qq = Console.ForegroundColor;
            Console.ForegroundColor = cc;
            int w = 10;
            for (int i = 1; i < w; i++)
            {
                Console.SetCursorPosition(x, y++);
                for (int j = 0; j < w - i; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            for (int i = w - 1; i >= 1; i--)
            {
                Console.SetCursorPosition(x, y++);
                for (int j = 0; j < w - i + 1; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < i - 1; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = qq;
        }
    }

    class FigureCollection:IEnumerable<IPart>
    {
        private IPart[] figures;
        public FigureCollection()
        {
            figures = new IPart[3];
            figures[0] = new Rectangle();
            figures[1] = new Triangle();
            figures[2] = new Rhombus();
        }

        public IEnumerator<IPart> GetEnumerator()
        {
            return ((IEnumerable<IPart>)figures).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return figures.GetEnumerator();
        }
        public IPart[] GetParts() { return figures; }
    }
    class App
    {
        private FigureCollection figures=new FigureCollection();
        private void Choose(int x,int y,ConsoleColor cc)
        {
            while(true)
            {
                Console.Clear();
                int c = Menu.ConsoleMenu.SelectVertical(HorizontalAlignment.Center,VerticalAlignment.Center,new string[] {"Прямокутник","Трикутник","Ромб"});
                switch(c)
                {
                    case 0: Array.Find<IPart>(figures.GetParts(), e => e is Rectangle).PrintFigure(x,y,cc); Console.ReadLine(); return;break;
                    case 1: Array.Find<IPart>(figures.GetParts(), e => e is Triangle).PrintFigure(x, y, cc); Console.ReadLine(); return;break;
                    case 3: Array.Find<IPart>(figures.GetParts(), e => e is Rhombus).PrintFigure(x, y, cc); Console.ReadLine(); return; break;
                }
            }
        }
        public void Start()
        {
            
            while (true)
            {
                Console.Clear();
                int c = Menu.ConsoleMenu.SelectVertical(HorizontalAlignment.Center, VerticalAlignment.Center, new string[] { "Обрати фігуру","Надрукувати усі фігури" });
                switch(c)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Введіть координати лівого верхнього кута фігури(x,y)");
                        int x = Convert.ToInt32(Console.ReadLine());
                        int y = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Оберіть колір фігури");
                        ConsoleColor q = (ConsoleColor)Menu.ConsoleMenu.SelectVertical(HorizontalAlignment.Center, VerticalAlignment.Center, Enum.GetNames(typeof(ConsoleColor)));
                        Choose(x, y, q);
                        break;
                    case 1: 
                        Console.Clear();
                        int i = 0;
                        foreach (IPart item in figures)
                        {
                            item.PrintFigure(0, i+=10, ConsoleColor.Red);
                        }
                        Console.ReadLine();
                        break;
                }
               
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            App a=new App();
            a.Start();
        }
    }
}
