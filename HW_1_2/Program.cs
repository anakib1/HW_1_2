using System;
using System.Collections.Generic;

namespace HW_1_2
{
    abstract class Worker
    {
        public string Name;
        public string Position;
        public string WorkDay;

        public Worker(string name)
        {
            Name = name;
            FillWorkDay();
        }
        public void Call() { WorkDay = WorkDay + "Call "; }
        public void WriteCode() { WorkDay = WorkDay + "WriteCoce "; }
        public void Relax() { WorkDay = WorkDay + "Relax "; }

        public abstract void FillWorkDay();
    }
    class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            this.Position = "Developer";
        }
        public override void FillWorkDay()
        {
            WriteCode(); Call(); Relax(); WriteCode();
        }

    }
    class Manager : Worker
    {
        Random rnd = new Random();
        public Manager(string name) : base(name)
        {
            this.Position = "Manager";
        }
        public override void FillWorkDay()
        {
            for (int i = 0; i < rnd.Next(1, 11); i++)
                Call();
            Relax();
            for (int i = 0; i < rnd.Next(1, 6); i++)
                Call();
        }

    }
    class Team
    {
        string name;
        List<Worker> workers;
        public Team(string name)
        {
            workers = new List<Worker>();
            this.name = name;
        }
        public void AddWorker(Worker worker)
        {
            workers.Add(worker);
        }
        public void DisplayBrief()
        {
            Console.WriteLine("Team \"{0}\" contains {1} workers:", this.name, this.workers.Count);
            foreach (Worker w in workers)
            {
                Console.WriteLine(w.Name);
            }
        }
        public void DisplayDetail()
        {
            Console.WriteLine("Team \"{0}\" contains {1} workers:", this.name, this.workers.Count);
            foreach (Worker w in workers)
            {
                Console.WriteLine("{0} - {1} - {2}", w.Name, w.Position, w.WorkDay);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input current team name (or -1 for termination)");
                string name = Console.ReadLine();
                if (name == "-1") break;
                Team team = new Team(name);

                Console.WriteLine("Input commands in format\n [+ 1 name] - add developer\n [+ 2 name] - add manager\n [?] - output brief information\n [!] - output detailed information\n [.] - terminate");

                while (true)
                {
                    string cur = Console.ReadLine();
                    if (cur == ".") break;
                    else if (cur == "?") team.DisplayBrief();
                    else if (cur == "!") team.DisplayDetail();
                    else if (cur[0] == '+')
                    {
                        var curs = cur.Split(' ');
                        if (curs.Length != 3 || (curs[1] != "1" && curs[1] != "2"))
                            Console.WriteLine("Wrong format!");
                        else
                        {
                            if (curs[1] == "1")
                                team.AddWorker(new Developer(curs[2]));
                            else
                                team.AddWorker(new Manager(curs[2]));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong format!");
                    }
                }
            }
        }
    }
}
