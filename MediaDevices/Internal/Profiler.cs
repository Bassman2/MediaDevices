using System;
using System.Diagnostics;

namespace MediaDevices.Internal
{
    internal sealed class Profiler : IDisposable
    {
        private Stopwatch stopwatch;
        private string title;

        
        public Profiler(string title)
        {
            Start(title);
        }

        public void Dispose()
        {
            Stop();
        }

        [Conditional("PROFILING")]
        private void Start(string title)
        {
            this.title = title;
            //Trace.WriteLine($"Profiler {this.title} start");
            this.stopwatch = Stopwatch.StartNew();
        }

        [Conditional("PROFILING")]
        private void Stop()
        {
            this.stopwatch.Stop();
            //Trace.WriteLine($"Profiler {this.title} : {this.stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fffffff").Insert(12, ".")}");

            double milliseconds = ((double)this.stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1000;
            //double nanoseconds = (this.stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1000_000_000;
            Trace.WriteLine($"Profiler {this.title} : {milliseconds} ms");
        }
    }
}

