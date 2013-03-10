using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EmulatedSTDStreams
{
    public class STDStreamMonitor
    {
        Thread m_thread;
        ConsoleLinesAdapter m_activityList;
        bool _shouldStop = false;

        public STDStreamMonitor(ConsoleLinesAdapter activityList)
        {
            m_activityList = activityList;
            m_activityList.SetNotifyOnChange(true);
            m_thread = new Thread(WorkMethod);
        }

        public void WorkMethod()
        {
            while (!_shouldStop)
            {
                if (STDOut.isAvailabile())
                {
                    string readstring = STDOut.ReadLine();
                    if (readstring != null)
                    {
                        m_activityList.AddString(readstring);
                        m_activityList.NotifyDataSetChanged();
                    }
                }
                Thread.Sleep(100);

            }
        }

        public bool isRunning()
        {
            return !_shouldStop && m_thread.IsAlive;
        }

        public void Stop()
        {
            _shouldStop = true;
        }

        public void Start()
        {
            _shouldStop = false;
            m_thread.Start();
        }

    }
}