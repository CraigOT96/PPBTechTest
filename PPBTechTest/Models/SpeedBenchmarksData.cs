using System;
using System.Collections.Generic;
using System.Text;

namespace PPBTechTest.Models
{
    public class SpeedBenchmarksData
    {
        public SpeedBenchmarksData(int loops)
        {
            this.Loops = loops;
        }
        private int Loops { get; set; }
        private double HashSpeedIterAverage { get; set; }
        private double HashSpeedLinqAverage { get; set; }
        private double LinkedListIterAverage { get; set; }
        private double LinkedListLinqAverage { get; set; }
        private double ListIterAverage { get; set; }
        private double ListLinqAverage { get; set; }
        public void RunTests()
        {
            for (int i = 0; i < this.Loops; i++)
            {
                this.HashSpeedIterAverage += Utilities.RunTest("Hash Set Iterator", "HashSet", true);
                this.HashSpeedLinqAverage += Utilities.RunTest("Hash Set Linq", "HashSet", false);
                this.LinkedListIterAverage += Utilities.RunTest("Linked List Iterator", "LinkedList", true);
                this.LinkedListLinqAverage += Utilities.RunTest("Linked List Linq", "LinkedList", false);
                this.ListIterAverage += Utilities.RunTest("List Iterator", "List", true);
                this.ListLinqAverage += Utilities.RunTest("List Linq", "List", false);
            }
        }
        public void PrintResults()
        {
            Console.WriteLine();
            Console.WriteLine("Hash Speed Iter Avg: " + (double)(this.HashSpeedIterAverage / this.Loops));
            Console.WriteLine("Hash Speed Linq Avg: " + (double)(this.HashSpeedLinqAverage / this.Loops));
            Console.WriteLine("Linked List Iter Avg: " + (double)(this.LinkedListIterAverage / this.Loops));
            Console.WriteLine("Linked List Linq Avg: " + (double)(this.LinkedListLinqAverage / this.Loops));
            Console.WriteLine("List Iter Avg: " + (double)(this.ListIterAverage / this.Loops));
            Console.WriteLine("List Linq Avg: " + (double)(this.ListLinqAverage / this.Loops));
        }
    }
}
