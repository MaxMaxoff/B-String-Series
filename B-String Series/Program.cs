using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// http://ejudge.1gb.ru/cgi-bin/new-register?contest_id=9
/// B-String Series
/// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
/// В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100,
/// каждая из следующих N строк имеет следующий формат: 
/// ФАМИЛИЯ ИМЯ ОЦЕНКИ, где
/// ФАМИЛИЯ – строка, состоящая не более чем из 20 символов,
/// ИМЯ – строка, состоящая не более чем из 15 символов,
/// ОЦЕНКИ – через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
/// ФАМИЛИЯ и ИМЯ, а также ИМЯ и ОЦЕНКИ разделены одним пробелом.
/// Пример входной строки: 
/// Иванов Петр 4 5 3 
/// Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трех худших по среднему баллу учеников.
/// Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трех худших, то следует вывести и их фамилии и имена.
/// </summary>
namespace B_String_Series
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array of studients
            string[] students;

            // Arrays of mediana
            decimal[] m;

            //Prepare console
            Console.ForegroundColor = ConsoleColor.Green;

            // read line count
            int n = Int32.Parse(Console.ReadLine());

            // initialize empty array with studens name and lastname
            students = new string[n];

            // initialize empty array with average values
            m = new decimal[n];

            for (int i = 0; i < n; i++)
            { 
                // split line using space symbol to new string array
                string[] a = Console.ReadLine().Split(' ');

                // fill array with studens name and lastname
                students[i] = $"{a[0]} {a[1]}";

                // fill array with average values: (1 value + 2 value + 3 value) / 3D
                m[i] = ((Int32.Parse(a[2]) + Int32.Parse(a[3]) + Int32.Parse(a[4])) / 3M);
            }

            Console.WriteLine();

            // initialize index of 3 minimal values
            int m1 = 2;
            int m2 = 1;
            int m3 = 0;

            // find index of 3 minimal values
            for (int i = m1; i < n; i++)
            {
                if (m[i] < m[m1])
                {
                    if (m[m1] < m[m2])
                    {
                        if (m[m2] < m[m3]) m3 = m2;
                        m2 = m1;
                    }
                    else if (m[m1] < m[m3])
                    {
                        m3 = m1;
                    }
                    m1 = i;
                }
                if (m[i] < m[m2] && m1 != i)
                {
                    if (m[m2] < m[m3]) m3 = m2;
                    m2 = i;
                }
                if (m[i] < m[m3] && m1 != i && m2 != i)
                {
                    m3 = i;
                }

            }

            // print out all students who has minimal values like elements of array with index m1, m2 and m3
            for (int i = 0; i < n; i++)
            {
                if ((m[i] == m[m1]) || (m[i] == m[m2]) || (m[i] == m[m3]))
                {
                    Console.WriteLine($"{students[i]}");
                }
            }

            Console.ReadKey();
        }
    }
}
