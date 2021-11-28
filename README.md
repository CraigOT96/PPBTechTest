This application was done using .NET Core 3.1.

The approach here was to play around with data types to see which ones worked best for the requirements here and then from there decide how best to manipulate the data.

I decided the best approach to this by making a class called SpeedBenchmarks. This uses 3 different data types, and then goes through each with an iterator and LINQ query to see which gets the results the fastest.

To call this, in Main you call it as follows:

SpeedBenchmarks s = new SpeedBenchmarks();

s.RunSpeedTests(10);
  
The only parameter here is how many loops you want to do and then gives you the average time. It is output as below:

HashSet Speed Iter Avg: 30.7ms
HashSet Speed Linq Avg: 25.5ms
LinkedList Iter Avg: 28.3ms
LinkedList Linq Avg: 25.4ms
List Iter Avg: 23.9ms
List Linq Avg: 20.8ms

From this, it looked with my approach that using a List and LINQ to manipulate it would yield the best results so this is the approach I took.

My approach here was to keep all of the functionality in classes and common functions in a Utilities file to keep the Main file as clean as possible.

On average my solution finishes running and outputs results in 58ms.
