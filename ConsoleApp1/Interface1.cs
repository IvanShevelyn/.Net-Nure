using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IEmployee
    {
        void Change_JobTitle(Job_Title job);
        void Change_department(string DepartmentName);
        string Input_Initials();
        string Input_department();
        Job_Title Input_Job_Title();
        void SalaryIncrease();
        void SalaryIncrease(int mounth_count);
        void SearchJob_Ttile();
    }
}
