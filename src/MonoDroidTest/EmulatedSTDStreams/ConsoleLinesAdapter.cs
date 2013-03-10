using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EmulatedSTDStreams
{
    public class ConsoleLinesAdapter : ArrayAdapter<String>
    {
        List<string> m_lstConsoleLines;
        int m_intTextViewResourceID;
        int m_intLayoutResourceID;
        STDStreamMonitor m_stdMonitor;

        public ConsoleLinesAdapter(Context context, int intLayoutID, int txtResourceID, List<string> adapter)
            : base(context, intLayoutID, adapter)
        {
            m_lstConsoleLines = adapter;
            m_intTextViewResourceID = txtResourceID;
            m_intLayoutResourceID = intLayoutID;
            m_stdMonitor = new STDStreamMonitor(this);
            m_stdMonitor.Start();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View v = convertView;
            if (v == null)
            {
                LayoutInflater vi = (LayoutInflater)this.Context.GetSystemService(Context.LayoutInflaterService);
                v = vi.Inflate(m_intLayoutResourceID, null);
            }

            string o = m_lstConsoleLines[position];

            if (o != null)
            {
                TextView consoleViewLine = (TextView)v.FindViewById(m_intTextViewResourceID);

                consoleViewLine.Text = o;
            }
            else
            {
                v.Visibility = ViewStates.Gone;
            }
            return v;
        }

        public void AddString(string str)
        {
            m_lstConsoleLines.Add(str);
            //NotifyDataSetChanged();
        }
    }
}