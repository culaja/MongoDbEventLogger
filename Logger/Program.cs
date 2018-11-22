using System;

namespace Logger
{
    public class Person
    {
        public string Name { get; set; }
        
        public int Age { get; set; }

        public override string ToString() => $"Person, {Name}, {Age}";
    }

    public class Book
    {
        public string Name { get; set; }
        
        public int Pages { get; set; }
        
        public decimal ReadPercentage { get; set; }
        
        public override string ToString() => $"Book, {Name}, {Pages}, ReadPercentage";
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            var eventLogger = new EventLogger();
            
            eventLogger.Log(new Person() {Name = "Stanko", Age = 30});
            eventLogger.Log(new Book() {Name = "Novi Zavet", Pages = 300, ReadPercentage = 35.67m});
            eventLogger.Log(new Person() {Name = "Marko", Age = 29});
            
            var events = new EventReader().ReadAll();
            foreach (var @event in events)
            {
                Console.WriteLine(@event);
            }
            
            
        }
    }
}