using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPPSimulator
{
    class DelayTask : Task
    {
        private class DelayAction
        {
            private int delay;

            private DelayAction(int milliseconds)
            {
                delay = milliseconds;
            }

            private void Delay()
            {
                Thread.Sleep(delay);
            }

            public static Action GetAction(int milliseconds)
            {
                return new Action(new DelayAction(milliseconds).Delay);
            }
        }

        public DelayTask(int milliseconds)
            : base(new Action(DelayAction.GetAction(milliseconds)))
        {
        }
    }
}
