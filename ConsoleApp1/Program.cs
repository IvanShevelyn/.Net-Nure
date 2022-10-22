using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Salary_count(Employees Employer)
        {
            Console.WriteLine("Input month count:");
            int count = int.Parse(Console.ReadLine());
            if (count == 1)
                Employer.SalaryIncrease();
            else
                Employer.SalaryIncrease(count);
        }
        static void Compare_2_employers(Employees Employer1)
        {
            Console.WriteLine($"First employer:\n{Employer1}");
            Console.WriteLine("Create second employer:");
            Employees Employer2 = new Employees();
            Console.WriteLine($"Second employer:\n{Employer2}");
            if (Employer1.Equals(Employer2))
                Console.WriteLine("Employers have equals job titles");
            else
                Console.WriteLine("Employers have not equals job titles");
        }
        static void Main(string[] args)
        {
            int i = 0;
            Employees Employer = null;
            bool created = false;
            while (true)
            {
                Console.WriteLine("To clear CMD: input 0");
                Console.WriteLine("Create employer: input 1");
                Console.WriteLine("Change job title: input 2");
                Console.WriteLine("Change department: input 3");
                Console.WriteLine("Count salary: input 4");
                Console.WriteLine("Show employer: input 5");
                Console.WriteLine("Compare 2 employers: input 6");
                Console.WriteLine("Search job title in history: input 7");
                i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        Employer = new Employees();
                        created = true;
                        break;
                    case 2:
                        if (created)
                            Employer.Change_JobTitle(Employer.Input_Job_Title());
                        else
                        {
                            Employer = new Employees();
                            created = true;
                            Employer.Change_JobTitle(Employer.Input_Job_Title());
                        }
                        break;
                    case 3:
                        if (created)
                        {
                            Console.WriteLine("Write new name of the department:");
                            Employer.Change_department(Console.ReadLine());
                        }
                        else
                        {
                            Employer = new Employees();
                            created = true;
                            Console.WriteLine("Write new name of the department:");
                            Employer.Change_department(Console.ReadLine());
                        }
                        break;
                    case 4:
                        if (created)
                            Salary_count(Employer);
                        else
                        {
                            Employer = new Employees();
                            created = true;
                            Salary_count(Employer);
                        }
                        break;
                    case 5:
                        if (created)
                            Console.WriteLine(Employer);
                        else
                        {
                            Employer = new Employees();
                            created = true;
                            Console.WriteLine(Employer);
                        }
                        break;
                    case 6:
                        if (created)
                            Compare_2_employers(Employer);
                        else
                        {
                            Console.WriteLine("Create first employer:");
                            Employer = new Employees();
                            created = true;
                            Compare_2_employers(Employer);
                        }
                        break;
                    case 7:
                        if (created)
                            Employer.SearchJob_Ttile();
                        else
                        {
                            Employer = new Employees();
                            created = true;
                            Employer.SearchJob_Ttile();
                        }
                        break;
                }
            }
        }
    }
}


