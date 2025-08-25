using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroToDONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if STING_OPERATIONS
            //Console.WriteLine("\t\t\t\tHello .NET");
            //Console.WriteLine("\t\t\t\tПривет");

            Console.Write("Введите Ваше имя: ");
            string first_name = Console.ReadLine();

            Console.Write("Введите Вашу фамилию: ");
            string last_name = Console.ReadLine();

            Console.Write("Введите Ваш возраст: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(first_name + " " + last_name + " " + age);         //Конкатенация строк
            Console.WriteLine(String.Format("{0} {1} {2}", first_name, last_name, age));        //Форматирование строk
            Console.WriteLine($"{first_name} {last_name} {age}");     //Интерполяция строк
#endif

//if DATA_TYPES
            Console.WriteLine("Информация о числовых типах данных:");
            Console.WriteLine("---------------------------------------");

            //bool
            Console.WriteLine($"{typeof(bool).Name} занимает {sizeof(bool)} байт.  MinValue: {bool.FalseString}, MaxValue: {bool.TrueString}");

            //byte
            Console.WriteLine($"{typeof(byte).Name} занимает {sizeof(byte)} байт. MinValue: {byte.MinValue}, MaxValue: {byte.MaxValue}");

            //sbyte
            Console.WriteLine($"{typeof(sbyte).Name} занимает {sizeof(sbyte)} байт. MinValue: {sbyte.MinValue}, MaxValue: {sbyte.MaxValue}");

            //char
            Console.WriteLine($"{typeof(char).Name} занимает {sizeof(char)} байт. MinValue: {(int)char.MinValue}, MaxValue: {(int)char.MaxValue}"); // Cast to int to see numeric representation

            //short (Int16)
            Console.WriteLine($"{typeof(short).Name} занимает {sizeof(short)} байт. MinValue: {short.MinValue}, MaxValue: {short.MaxValue}");

            //ushort (UInt16)
            Console.WriteLine($"{typeof(ushort).Name} занимает {sizeof(ushort)} байт. MinValue: {ushort.MinValue}, MaxValue: {ushort.MaxValue}");

            //int (Int32)
            Console.WriteLine($"{typeof(int).Name} занимает {sizeof(int)} байт. MinValue: {int.MinValue}, MaxValue: {int.MaxValue}");

            //uint (UInt32)
            Console.WriteLine($"{typeof(uint).Name} занимает {sizeof(uint)} байт. MinValue: {uint.MinValue}, MaxValue: {uint.MaxValue}");

            //long (Int64)
            Console.WriteLine($"{typeof(long).Name} занимает {sizeof(long)} байт. MinValue: {long.MinValue}, MaxValue: {long.MaxValue}");

            //ulong (UInt64)
            Console.WriteLine($"{typeof(ulong).Name} занимает {sizeof(ulong)} байт. MinValue: {ulong.MinValue}, MaxValue: {ulong.MaxValue}");

            //float
            Console.WriteLine($"{typeof(float).Name} занимает {sizeof(float)} байт. MinValue: {float.MinValue}, MaxValue: {float.MaxValue}");

            //double
            Console.WriteLine($"{typeof(double).Name} занимает {sizeof(double)} байт. MinValue: {double.MinValue}, MaxValue: {double.MaxValue}");

            //decimal
            Console.WriteLine($"{typeof(decimal).Name} занимает {sizeof(decimal)} байт. MinValue: {decimal.MinValue}, MaxValue: {decimal.MaxValue}");
//#endif

            Console.ReadKey();
        }
    }
}