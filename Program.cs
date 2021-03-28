using System;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            Team t1 = new Team("Org1", 11);
            Team t2 = new Team("Org1", 11);
            if (t1 == t2) Console.WriteLine("Равенство по значению: true");
            else Console.WriteLine("Равенство по значению: false");
            object tt1 = t1;
            object tt2 = t2;
            if (tt1 == tt2) Console.WriteLine("Равенство по ссылке: true");
            else Console.WriteLine("Равенство по ссылке: false");
            Console.WriteLine("Хэш-код первого объекта: " + t1.GetHashCode());
            Console.WriteLine("Хэш-код второго объекта: " + t2.GetHashCode());
            Console.WriteLine();
            Console.WriteLine("Cообщение об ошибке:");
            try
            {
                t1.RegNum = -100;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            ResearchTeam resT = new ResearchTeam("MyTopic", "NewOrg", 897, TimeFrame.TwoYears);           
            Person masha = new Person("Maria", "Lapshina", new DateTime(1998, 12, 2));
            Person andrey = new Person("Andrey", "Gorshkov", new DateTime(1988, 5, 12));
            Person oleg = new Person("Oleg", "Ivanov", new DateTime(1995, 9, 13));
            Paper p1 = new Paper("Bags", andrey, new DateTime(2008, 8, 1));
            Paper p2 = new Paper("Norilsk city", masha, new DateTime(2012, 2, 18));
            Paper p3 = new Paper("Modern", andrey, new DateTime(2019, 8, 5));
            resT.AddMembers(oleg, masha, andrey);
            resT.AddPapers(p1, p2, p3);
            Console.WriteLine("    Созданный объект ResearchTeam:");
            Console.WriteLine(resT.ToString());
            Console.WriteLine("    Свойство типа Team:");
            Console.WriteLine(resT.ToBaseTeam.ToString());
            Console.WriteLine();
            ResearchTeam resTCopy = (ResearchTeam)resT.DeepCopy();
            (resT.PapersList[0] as Paper).Author = masha;
            resT.OrgName = "OtherOrg";
            resT.Topic = "OtherTopic";
            Console.WriteLine("        Скопированный объект");
            Console.WriteLine(resTCopy.ToString());
            Console.WriteLine("        Исходный объект (изменен)");
            Console.WriteLine(resT.ToString());
            Console.WriteLine("      Не имеют публикаций:");
            foreach (Person x in resT.GetMemsNoPaps())
                Console.WriteLine(x);
            Console.WriteLine("      Публикации за последние 10 лет:");
            foreach (Paper x in resT.GetPapForYears(10))
                Console.WriteLine(x);
            Console.WriteLine("      Публикации за последний год:");
            foreach (Paper x in resT.GetLastPaps())
                Console.WriteLine(x);
            Console.WriteLine("      Имеют более одной публикации:");
            foreach (Person x in resT.GetMemsMuchPaps())
                Console.WriteLine(x);
            Console.WriteLine("      Имеют публикации:");
            foreach (Person x in resT)
                Console.WriteLine(x);
        }
    }
}
