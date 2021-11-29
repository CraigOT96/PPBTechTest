using System;

namespace PPBTechTest.Models
{
    public class SpeedBenchmarksData
    {
        public SpeedBenchmarksData(int numberOfRuns)
        {
            this.NumberOfRuns = numberOfRuns;
        }
        private int NumberOfRuns { get; set; }
        private double HashSetSpeedIteratorAverage { get; set; }
        private double HashSetSpeedLinqAverage { get; set; }
        private double LinkedListIteratorAverage { get; set; }
        private double LinkedListLinqAverage { get; set; }
        private double ListIteratorAverage { get; set; }
        private double ListLinqAverage { get; set; }
        public void RunSpeedBenchmarks()
        {
            for (int i = 0; i < this.NumberOfRuns; i++)
            {
                this.HashSetSpeedIteratorAverage += Utilities.RunBenchmark("Hash Set Iterator", "HashSet", true);
                this.HashSetSpeedLinqAverage += Utilities.RunBenchmark("Hash Set Linq", "HashSet", false);
                this.LinkedListIteratorAverage += Utilities.RunBenchmark("Linked List Iterator", "LinkedList", true);
                this.LinkedListLinqAverage += Utilities.RunBenchmark("Linked List Linq", "LinkedList", false);
                this.ListIteratorAverage += Utilities.RunBenchmark("List Iterator", "List", true);
                this.ListLinqAverage += Utilities.RunBenchmark("List Linq", "List", false);
            }
        }
        public void PrintResults()
        {
            Console.WriteLine("HashSet Speed Iter Avg: " + (double)(this.HashSetSpeedIteratorAverage / this.NumberOfRuns) + "ms");
            Console.WriteLine("HashSet Speed Linq Avg: " + (double)(this.HashSetSpeedLinqAverage / this.NumberOfRuns) + "ms");
            Console.WriteLine("LinkedList Iter Avg: " + (double)(this.LinkedListIteratorAverage / this.NumberOfRuns) + "ms");
            Console.WriteLine("LinkedList Linq Avg: " + (double)(this.LinkedListLinqAverage / this.NumberOfRuns) + "ms");
            Console.WriteLine("List Iter Avg: " + (double)(this.ListIteratorAverage / this.NumberOfRuns) + "ms");
            Console.WriteLine("List Linq Avg: " + (double)(this.ListLinqAverage / this.NumberOfRuns) + "ms");
        }
    }
}
