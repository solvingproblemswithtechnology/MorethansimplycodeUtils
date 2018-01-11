﻿using Cartif.Logs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LAE
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //PresentationTraceSources.Refresh();
            //PresentationTraceSources.DataBindingSource.Listeners.Add(new ConsoleTraceListener());
            //PresentationTraceSources.DataBindingSource.Listeners.Add(new DebugTraceListener());
            //PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.All;

            CartifLogs.Configure();
            System.Windows.FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;
            base.OnStartup(e);
        }
    }

    public class DebugTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            { }
        }

        public override void WriteLine(string message)
        {
            { }
        }
    }
}
