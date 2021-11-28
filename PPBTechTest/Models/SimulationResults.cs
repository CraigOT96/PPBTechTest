using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PPBTechTest.Models
{
    public class SimulationResults
    {
        private bool _disposedValue;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        public SimulationResults (int recordCount, double median)
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
        public void AddSimulationDataIterator(IEnumerator<ResultsData> data)
        {
            try
            {
                while (data.MoveNext())
                {
                    this.HomeWins += data.Current.HomeTeamWinner ? 1 : 0;
                    this.AwayWins += data.Current.AwayTeamWinner ? 1 : 0;
                    this.OverLine += data.Current.TotalPoints > this.Median ? 1 : 0;
                    this.UnderLine += data.Current.TotalPoints < this.Median ? 1 : 0;
                    this.HomeOverTenPoints += data.Current.HomeWinningMargin >= 11 ? 1 : 0;
                    this.HomeUnderTenPoints += (data.Current.HomeWinningMargin <= 10 && data.Current.HomeWinningMargin > -1) ? 1 : 0;
                    this.AwayOverTenPoints += data.Current.AwayWinningMargin >= 11 ? 1 : 0;
                    this.AwayUnderTenPoints += (data.Current.AwayWinningMargin <= 10 && data.Current.AwayWinningMargin > -1) ? 1 : 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        public void AddSimulationDataLinq(ICollection<ResultsData> data)
        {
            try
            {
                this.HomeWins = data.Where(x => x.HomeTeamWinner).Count();
                this.AwayWins = data.Where(x => x.AwayTeamWinner).Count();
                this.OverLine = data.Where(x => x.TotalPoints > this.Median).Count();
                this.UnderLine = data.Where(x => x.TotalPoints < this.Median).Count();
                this.HomeOverTenPoints = data.Where(x => x.HomeWinningMargin >= 11).Count();
                this.HomeUnderTenPoints = data.Where(x => x.HomeWinningMargin <= 10 && x.HomeWinningMargin > -1).Count();
                this.AwayOverTenPoints = data.Where(x => x.AwayWinningMargin >= 11).Count();
                this.AwayUnderTenPoints = data.Where(x => x.AwayWinningMargin <= 10 && x.AwayWinningMargin > -1).Count();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        private double CalculatePercent(int value, int total)
        {
            return (double)(1 * value) / total;
        }
        public void PrintResults()
        {
            Console.WriteLine("Total Home Wins: " + this.HomeWins);
            Console.WriteLine("Total Away Wins: " + this.AwayWins);
            Console.WriteLine("Home Win Probability: " + CalculatePercent(this.HomeWins, this.RecordCount));
            Console.WriteLine("Away Win Probability: " + CalculatePercent(this.AwayWins, this.RecordCount));
            Console.WriteLine();
            Console.WriteLine("Total Over Line: " + this.OverLine);
            Console.WriteLine("Total Under Line: " + this.UnderLine);
            Console.WriteLine("Over Line Probability: " + CalculatePercent(this.OverLine, this.RecordCount));
            Console.WriteLine("Under Line Probability: " + CalculatePercent(this.UnderLine, this.RecordCount));
            Console.WriteLine();
            Console.WriteLine("Home Over Ten Points Win: " + this.HomeOverTenPoints);
            Console.WriteLine("Home Under or On Ten Points Win: " + this.HomeUnderTenPoints);
            Console.WriteLine("Away Over Ten Points Win: " + this.AwayOverTenPoints);
            Console.WriteLine("Away Under or On Ten Points Win: " + this.AwayUnderTenPoints);
            Console.WriteLine("Home Over Ten Points Probability: " + CalculatePercent(this.HomeOverTenPoints, this.RecordCount));
            Console.WriteLine("Home Under or On Ten Points Probability: " + CalculatePercent(this.HomeUnderTenPoints, this.RecordCount));
            Console.WriteLine("Away Over Ten Points Probability: " + CalculatePercent(this.AwayOverTenPoints, this.RecordCount));
            Console.WriteLine("Away Under or On Ten Points Probability: " + CalculatePercent(this.AwayUnderTenPoints, this.RecordCount));
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
