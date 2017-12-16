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
            this.title = title;
            Trace.WriteLine($"Profiler {this.title} start");
            this.stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            this.stopwatch.Stop();
            Trace.WriteLine($"Profiler {this.title} stop: {this.stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fffffff").Insert(12, ".")}");
        }

        public int Res
        {
            get { return 0; }
        }
    }
}

