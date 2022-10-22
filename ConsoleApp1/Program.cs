using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    enum Job_Title
    {
        DIRECTOR = 50000,
        MANAGER = 20000,
        ENGINEER = 10000,
        HANDYMAN = 5000,
        NONE = 0
    }
   
    class Employees : IEmployee
    {
        private string _Initials;
        private Job_Title _JobTitle;
        private int _salary;
        private int _total_salary = 0;
        private string _department;
        private List<string> _history = new List<string>();

        public Employees() //конструктор
        {
            _Initials = Input_Initials();
            _JobTitle = Input_Job_Title();
            _salary = (int)_JobTitle;
            _department = Input_department();
            _history.Add(_JobTitle.ToString());
        }
        public void Change_JobTitle(Job_Title job) // метод зміни посади
        {
            _JobTitle = job;
            _salary = (int)job;
            _history.Add(job.ToString());
        }
        public void Change_department(string DepartmentName) //метод зміни відділу
        {
            bool letter = false;
            bool number = false;
            for (int i = 0; i < DepartmentName.Length; i++)
            {
                if (Char.IsNumber(DepartmentName[i]))
                {
                    number = true;
                }
                else if (Char.IsLetter(DepartmentName[i]))
                {
                    letter = true;
                }
            }
            if (number && letter)
                _department = DepartmentName;
            else
                Console.WriteLine("Incorrect name of the department!");
        }
        public string Input_Initials() //установка ПІБ
        {
            bool flag = false;
            bool number;
            string value = "";
            while (flag == false)
            {
                number = false;
                value = "";
                while (value.Length == 0)
                {
                    Console.WriteLine("Enter employee name:");
                    value = Console.ReadLine();
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (Char.IsNumber(value[i]))
                    {
                        number = true;
                    }
                }
                if (number)
                    Console.WriteLine("Name can't have numbers!");
                else
                    flag = true;
            }
            return value;
        }
        public string Input_department() //установка відділу
        {
            bool letter = false;
            bool number = false;
            string value = "";
            while (number == false || letter == false)
            {
                number = false;
                letter = false;
                Console.WriteLine("Write the name of the department:");
                value = Console.ReadLine();
                for (int i = 0; i < value.Length; i++)
                {
                    if (Char.IsNumber(value[i]))
                    {
                        number = true;
                    }
                    else if (Char.IsLetter(value[i]))
                    {
                        letter = true;
                    }
                }
            }
            return value;
        }
        public Job_Title Input_Job_Title() //установка посади
        {
            Console.WriteLine("Write the Job title:");
            string JobTitle = Console.ReadLine();
            Job_Title job;
            switch (JobTitle.ToUpper())
            {
                case "DIRECTOR":
                    job = Job_Title.DIRECTOR;
                    break;
                case "MANAGER":
                    job = Job_Title.MANAGER;
                    break;
                case "ENGINEER":
                    job = Job_Title.ENGINEER;
                    break;
                case "HANDYMAN":
                    job = Job_Title.HANDYMAN;
                    break;
                default:
                    job = Job_Title.NONE;
                    break;
            }
            return job;
        }
        public void SalaryIncrease() //нарахування заробітної плати 
        {
            _total_salary += _salary;
        }
        public void SalaryIncrease(int mounth_count) //нарахування заробітної плати за декілька місяців
        {
            _total_salary += _salary * mounth_count;
        }
        public void SearchJob_Ttile() //пошук посади у історії посад робітника 
        {
            Console.WriteLine("Enter name of job title:");
            string value = Console.ReadLine();
            for (int i = 0; i < _history.Count; i++)
            {
                if (value.ToUpper() == _history[i])
                {
                    Console.WriteLine($"The employer had job title {value.ToUpper()}");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{_Initials}'s history of job titles:");
            for (int i = 0; i < _history.Count; i++)
            {
                Console.WriteLine(_history[i]);
            }
        }
        public override string ToString() //поліморфна реалізація методу ToString();
        {
            return "Employer: " + _Initials + "\nJob Title: " + _JobTitle + "\nSalary: " + _salary + "\nDepartment: " + _department + "\n";
        }
        public override bool Equals(object obj) //метод порівняння співробітників за вказаною посадою
        {
            var item = obj as Employees;
            if (item == null)
            {
                return false;
            }
            return this._JobTitle.Equals(item._JobTitle);
        }
        public override int GetHashCode()
        {
            return this._JobTitle.GetHashCode();
        }
    }

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


