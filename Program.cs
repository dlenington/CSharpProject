using System;
using System.IO;
using System.Collections.Generic;

namespace CSProject
{


    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
            }

        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;



        }

        public virtual void CalculatePay()
        {

            //?add setter call to set basic pay?
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;

        }

        public override string ToString()
        {
            Console.WriteLine("Total Pay: " + TotalPay + "\nBasic Pay: " + BasicPay + "\nNameOfStaff: " + NameOfStaff + "\nHours Worked: " + HoursWorked);
        }
    }

    class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Allowance { get; private set; }
        public Manager(string name) : base(name, managerHourlyRate)
        {
        }
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;

            if (HoursWorked > 160)
                TotalPay += 1000;
        }

        public override string ToString()
        {
            Console.WriteLine("Manager Hourly Rate: " + managerHourlyRate + "\nAllowance: " + Allowance);
        }
    }


    class Admin : Staff
    {
        private const float overtimeRate = 15.5f;
        private const float adminHourlyRate = 30;

        public float Overtime
        {
            get;

            private set;
        }
        public Admin(string name) : base(name, adminHourlyRate)
        {
        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
                TotalPay += Overtime;
        }
    }

    class FileReader
    {

        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))

                    while (!sr.EndOfStream)
                    {
                        string st = sr.ReadLine();
                        result = st.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    }
                if (result[1].Contains("Admin"))
                {
                    myStaff.add(Staff result[1] = new Admin(result[1]));

                }
                else if (result[1].Contains("Manager"))
                    myStaff.Add(Manager result[1] = new Manager(result[1]);

            }
            else
                Console.WriteLine("File does not exist");

            //sr.Close();
            return myStaff;
        }
    }

    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            Jan, Feb, Mar, April, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";

                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                sw.WriteLine("===================");
                sw.WriteLine("Name Of Staff: {0}", f.NameOfStaff);
                sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);

                if (f.GetType() == typeof(Manager))
                    sw.WriteLine("Allowance: {0:C}", ((Manager)f).Allowance);
                else if (f.GetType() == typeof(Admin))
                    sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);

                sw.WriteLine("");
                sw.WriteLine("================");
                sw.WriteLine("Total Pay: " + f.TotalPay);
                sw.WriteLine("========================");

                sw.Close();
            }
        }
        public void GenerateSummary(List<Staff> staffList)
        {
            var result =
            from staff in staffList
            where staff.HoursWorked < 10
            orderby staff.NameOfStaff
            select new { staff.NameOfStaff, staff.HoursWorked };

            string path = "summary.txt";

            StreamWriter sw = new StreamWriter(path);

            sw.WriteLine("Staff with less than 10 working hours");
            sw.Write("");

            foreach (Staff staff in result)
                sw.WriteLine("Name Of Staff: {0}", staff.NameOfStaff);


                        public override string ToString()
        {

            Console.ReadLine((Console.WriteLine("Month: {0}" + "\nYear: {1}", month, year)));
            return Console.ReadLine();
        }


    }
    class Program
    {

        public static void Main(string[] args)
        {
            int year = 0;
            int month = 0;
            while (year == 0)
            {
                Console.Write("\nPlease enter the year: ");


                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Error message: {0}", e.Message);
                }

            }

            while (month == 0)
            {
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Error: Input not in range from 1 - 12");
                        month = 0;
                    }
                }

                catch (FormatException e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }


            }
            FileReader fr = new FileReader();
            //!!
            fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.WriteLine("Enter hours worked for {0}", myStaff[i].NameOfStaff);
                    myStaff[i].HoursWorked.set(Convert.ToInt32(Console.ReadLine()));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //so that the iteration performs again for current Staff object
                    i--;
                }
            }

            PaySlip pr = new PaySlip(month, year);

            pr.GeneratePaySlip(myStaff);
            pr.GenerateSummary(myStaff);

            Console.Read();



        }
    }
}

    }
}

                           

