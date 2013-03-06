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
        int m_intResourceID;
        STDStreamMonitor m_stdMonitor;
        STDOut m_out = new STDOut();
        public ConsoleLinesAdapter(Context context, int resourceID, List<string> adapter):base(context, resourceID, adapter)
        {
            m_lstConsoleLines = adapter;
            m_intResourceID = resourceID;
            m_stdMonitor = new STDStreamMonitor(m_out, this);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View v = convertView;
            if (v == null)
            {
                LayoutInflater vi = (LayoutInflater)this.Context.GetSystemService(Context.LayoutInflaterService);
                v = vi.Inflate(m_intResourceID, null);
            }

            string o = m_lstConsoleLines[position];

            if (o != null)
            {
                TextView consoleViewLine = (TextView)v.FindViewById(m_intResourceID);

                consoleViewLine.Text = o;
            }
            else
            {
                v.Visibility = ViewStates.Gone;
            }
            return v;
        }
    }
}