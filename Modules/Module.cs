using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoExp.Modules
{

    internal class Module
    {
        internal Host host;
#if DEBUG
        private CancellationTokenSource ts;
        CancellationToken ct;
#elif !DEBUG
        internal Thread thread;
#endif
        public virtual void Start(Host host)
        {
            this.host = host;
            try
            {
#if DEBUG
                ts = new CancellationTokenSource();
                ct = ts.Token;
                Task.Factory.StartNew(() =>
                {
                    Run(ct);
                }, ct);
#elif !DEBUG
                thread = new Thread(Run);
                thread.Start();
#endif
            }
            catch (Exception error)
            { Console.WriteLine(error.ToString()); }
        }

#if DEBUG
        public virtual void Run(CancellationToken ct)
#elif !DEBUG
        public virtual void Run()
#endif
        {
#if DEBUG
            ct.ThrowIfCancellationRequested();
#endif
        }

        public virtual void Stop()
        {
            try
            {
#if DEBUG
                ts.Cancel();
#elif !DEBUG
                if (thread != null)
                {
                    thread.Abort();
                    thread.Join(10000);
                    Console.WriteLine("Aborted!");
                }
#endif
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }
}
