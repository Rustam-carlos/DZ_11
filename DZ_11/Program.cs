using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_11
{
    
    class Program
    { //1.	Создать массив сотрудников. Длина массива задается пользователем, заполнение массива производится им же. Выполнить следующее: 
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("Введите колличество сотрудников компании");
            int count = int.Parse(Console.ReadLine());              
            Worker[] worker = new Worker[count];
                        
            for (int i = 0; i < count; i++)
            {
                if (i < 1)
                {
                    Console.WriteLine($"Введите фамилию начальника");                    
                    DateTime datebegin = new DateTime(rand.Next(2000, 2019), rand.Next(1, 12), rand.Next(1, 30));
                    worker[i].Name = Console.ReadLine();
                    worker[i].Position = "Руководитель";
                    worker[i].Salary = 300000;
                    worker[i].DateBeginWork = datebegin;
                }
                else
                {
                    Console.WriteLine($"Введите фамилию {i + 1}-го менеджера");
                    string nameM = Console.ReadLine();
                    DateTime datebeginM = new DateTime(rand.Next(2000, 2019), rand.Next(1, 12), rand.Next(1, 30));
                    worker[i].Name = nameM;
                    worker[i].Position = "менеджер";
                    worker[i].Salary = rand.Next(60000, 150000);
                    worker[i].DateBeginWork = datebeginM;
                }
            }
            Console.Clear();
            //  a.вывести полную информацию обо всех сотрудниках;
            Console.WriteLine("1)======================================================================================");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Имя\t\t\t\t" + worker[i].Name );
                Console.WriteLine($"Должность\t\t\t" + worker[i].Position);
                Console.WriteLine($"Зарплата\t\t\t" + worker[i].Salary + "\tтг.");                
                Console.WriteLine($"Дата начала работы\t\t" + worker[i].DateBeginWork);
                Console.WriteLine("---------------------------------------\n");
            }   
            Console.WriteLine();
            //  b.найти в массиве всех менеджеров, зарплата которых больше средней зарплаты всех клерков, вывести на экран полную информацию о 
            //    таких менеджерах отсортированной по их фамилии.
            Console.WriteLine("2)======================================================================================");
            int sum = 0;
            double average = 0;
            for (int i = 1; i < count; i++)
            {
                sum += worker[i].Salary;                
            }
            average = (double)(sum / count);
            var result = from Worker in worker
                         where Worker.Salary > average
                         orderby Worker.Name
                         select Worker;
            Console.WriteLine($"Список сотрудников, с заработком выше среднего");
            foreach (Worker w in result)
            {
                if (w.Position != "Руководитель")
                {
                    Console.WriteLine(w.Name);
                    Console.WriteLine(w.Position);
                    Console.WriteLine(w.Salary + "\tтг.");
                    Console.WriteLine(w.DateBeginWork);
                    Console.WriteLine("---------------------------------------\n");
                }
            }       
            Console.WriteLine();
            //  c.распечатать информацию обо всех сотрудниках, принятых на работу позже босса, отсортированную в алфавитном порядке по фамилии сотрудника.
            Console.WriteLine("3)-==================================");
            DateTime date = worker[0].DateBeginWork;
            var result2 = from Worker in worker
                          where Worker.DateBeginWork > date
                          orderby Worker.Name
                          select Worker;
            Console.WriteLine($"Список сотрудников, принятых на работу позже босса");
            foreach (Worker s in result2)
            {
                    Console.WriteLine(s.Name);
                    Console.WriteLine(s.Position);
                    Console.WriteLine(s.Salary + "\tтг.");
                    Console.WriteLine(s.DateBeginWork);
                    Console.WriteLine("---------------------------------------");               
            }            
            Console.ReadLine();
        }
    }
}
