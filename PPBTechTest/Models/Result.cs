using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace PPBTechTest.Models
{
    public class Results : IDisposable
    {
        public Results(List<Result> results)
        {
            try
            {
                this.ResultsData = results;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        private bool _disposedValue;
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        public List<Result> ResultsData { get; }
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


    public class Result
    {
        public Result(bool homeTeamWinner, bool awayTeamWinnner, int homeTeamPoints, int awayTeamPoints)
        {
            try
            {
                this.HomeTeamWinner = homeTeamWinner;
                this.AwayTeamWinner = awayTeamWinnner;
                this.HomeTeamPoints = homeTeamPoints;
                this.AwayTeamPoints = awayTeamPoints;
                this.TotalPoints = homeTeamPoints + awayTeamPoints;
                this.HomeWinningMargin = homeTeamPoints - awayTeamPoints;
                this.AwayWinningMargin = awayTeamPoints - homeTeamPoints;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        public Result(string simulationData)
        {
            try
            {
                string[] simulationValues = simulationData.Split(',');
                this.HomeTeamWinner = Int32.Parse(simulationValues[0]) != 0;
                this.AwayTeamWinner = Int32.Parse(simulationValues[1]) != 0;
                this.HomeTeamPoints = Int32.Parse(simulationValues[2]);
                this.AwayTeamPoints = Int32.Parse(simulationValues[3]);
                this.TotalPoints = this.HomeTeamPoints + this.AwayTeamPoints;
                this.HomeWinningMargin = this.HomeTeamPoints - this.AwayTeamPoints;
                this.AwayWinningMargin = this.AwayTeamPoints - this.HomeTeamPoints;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid file line");
                Console.WriteLine(simulationData);
                Console.WriteLine(ex.Message);
                throw new Exception();
            }
        }
        public bool HomeTeamWinner { get; }
        public bool AwayTeamWinner { get; }
        public int HomeTeamPoints { get; }
        public int AwayTeamPoints { get; }
        public int TotalPoints { get; }
        public int HomeWinningMargin { get; }
        public int AwayWinningMargin { get; }
    }
}
