using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PPBTechTest.Models
{
    public class SimulationResult : IDisposable
    {
        private bool _disposedValue;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        public SimulationResult (int recordCount, double median)
        {
            this.RecordCount = recordCount;
            this.Median = median;
        }
        private int RecordCount { get; set; }
        private double Median { get; set; }
        private int HomeWins { get; set; }
        private int AwayWins { get; set; }
        private int OverLine { get; set; }
        private int UnderLine { get; set; }
        private int HomeOverTenPoints { get; set; }
        private int HomeUnderTenPoints { get; set; }
        private int AwayOverTenPoints { get; set; }
        private int AwayUnderTenPoints { get; set; }
        public void AddSimulationDataIterator(IEnumerator<Result> results)
        {
            try
            {
                while (results.MoveNext())
                {
                    this.HomeWins += results.Current.HomeTeamWinner ? 1 : 0;
                    this.AwayWins += results.Current.AwayTeamWinner ? 1 : 0;
                    this.OverLine += results.Current.TotalPoints > this.Median ? 1 : 0;
                    this.UnderLine += results.Current.TotalPoints < this.Median ? 1 : 0;
                    this.HomeOverTenPoints += results.Current.HomeWinningMargin >= 11 ? 1 : 0;
                    this.HomeUnderTenPoints += (results.Current.HomeWinningMargin <= 10 && results.Current.HomeWinningMargin > -1) ? 1 : 0;
                    this.AwayOverTenPoints += results.Current.AwayWinningMargin >= 11 ? 1 : 0;
                    this.AwayUnderTenPoints += (results.Current.AwayWinningMargin <= 10 && results.Current.AwayWinningMargin > -1) ? 1 : 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        public void AddSimulationDataLinq(ICollection<Result> results)
        {
            try
            {
                this.HomeWins = results.Where(x => x.HomeTeamWinner).Count();
                this.AwayWins = results.Where(x => x.AwayTeamWinner).Count();
                this.OverLine = results.Where(x => x.TotalPoints > this.Median).Count();
                this.UnderLine = results.Where(x => x.TotalPoints < this.Median).Count();
                this.HomeOverTenPoints = results.Where(x => x.HomeWinningMargin >= 11).Count();
                this.HomeUnderTenPoints = results.Where(x => x.HomeWinningMargin <= 10 && x.HomeWinningMargin > -1).Count();
                this.AwayOverTenPoints = results.Where(x => x.AwayWinningMargin >= 11).Count();
                this.AwayUnderTenPoints = results.Where(x => x.AwayWinningMargin <= 10 && x.AwayWinningMargin > -1).Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        private double CalculateProbability(int value, int totalRecords)
        {
            return (double) value / totalRecords;
        }
        public void PrintResults()
        {
            Console.WriteLine("Total Home Team Wins: " + this.HomeWins);
            Console.WriteLine("Total Away Team Wins: " + this.AwayWins);
            Console.WriteLine("Home Team Win Probability: " + CalculateProbability(this.HomeWins, this.RecordCount));
            Console.WriteLine("Away Team Win Probability: " + CalculateProbability(this.AwayWins, this.RecordCount));
            Console.WriteLine();
            Console.WriteLine("Total Games Over Half-Point Line: " + this.OverLine);
            Console.WriteLine("Total Games Under Half-Point Line: " + this.UnderLine);
            Console.WriteLine("Over Half-Point Line Probability: " + CalculateProbability(this.OverLine, this.RecordCount));
            Console.WriteLine("Under Half-Point Line Probability: " + CalculateProbability(this.UnderLine, this.RecordCount));
            Console.WriteLine();
            Console.WriteLine("Home Team Over Ten Points Win: " + this.HomeOverTenPoints);
            Console.WriteLine("Home Team Under or On Ten Points Win: " + this.HomeUnderTenPoints);
            Console.WriteLine("Away Team Over Ten Points Win: " + this.AwayOverTenPoints);
            Console.WriteLine("Away Team Under or On Ten Points Win: " + this.AwayUnderTenPoints);
            Console.WriteLine("Home Team Over Ten Points Probability: " + CalculateProbability(this.HomeOverTenPoints, this.RecordCount));
            Console.WriteLine("Home Team Under or On Ten Points Probability: " + CalculateProbability(this.HomeUnderTenPoints, this.RecordCount));
            Console.WriteLine("Away Team Over Ten Points Probability: " + CalculateProbability(this.AwayOverTenPoints, this.RecordCount));
            Console.WriteLine("Away Team Under or On Ten Points Probability: " + CalculateProbability(this.AwayUnderTenPoints, this.RecordCount));
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _safeHandle.Dispose();
                }
                _disposedValue = true;
            }
        }
    }
}
