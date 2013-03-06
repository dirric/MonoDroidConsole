using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EmulatedSTDStreams
{
    class STDStreamMonitor
    {
        Thread m_thread;
        STDOut m_outStream;
        ConsoleLinesAdapter m_activityList;
        bool _shouldStop = false;

        public STDStreamMonitor(STDOut outStream, ConsoleLinesAdapter activityList)
        {
            m_thread = new Thread(WorkMethod);
            m_outStream = outStream;
            m_activityList = activityList;
            m_activityList.SetNotifyOnChange(true);
        }

        public void WorkMethod()
        {
            while (!_shouldStop)
            {
                if (m_outStream.isAvailabile())
                {
                    m_activityList.Add(m_outStream.ReadLine());
                }
                Thread.Sleep(100);
            }
        }
        
        bool isRunning()
        {
            return !_shouldStop && m_thread.IsAlive;
        }

        void Stop()
        {
            _shouldStop = true;
        }

        void Start()
        {
            _shouldStop = false;
            m_thread.Start();
        }

    }
}