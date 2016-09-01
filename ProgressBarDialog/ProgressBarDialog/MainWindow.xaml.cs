using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgressBarDialog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBlockTraceListener traceListener;
        public MainWindow()
        {
            InitializeComponent();

            traceListener = new TextBlockTraceListener(logTextBlock);
            Trace.Listeners.Add(traceListener);
        }

        private void OnStartClicked(object sender, RoutedEventArgs evt)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            Progress<KeyValuePair<int, string>> progress = new Progress<KeyValuePair<int, string>>();

            // execute in other thread
            Task.Run<int>(() => {
                return Working(cancelTokenSource.Token, progress);
            });            
            
            // open progress dialog
            ProgressDialog dialog = new ProgressDialog(cancelTokenSource, progress);
            dialog.Owner = this;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.ShowDialog();

        }

        
        int Working(CancellationToken cancelToken, IProgress<KeyValuePair<int, string>> progress)
        {
            Trace.TraceInformation("Work started");
            Trace.Flush();

            int result = 0;
            for (int i = 0; i <= 200; i++)
            {
                result = i;
                // task cancelled
                if (cancelToken.IsCancellationRequested)
                {
                    Trace.TraceInformation("Work cancelled");
                    Trace.Flush();
                    return result;
                }

                Thread.Sleep(50);

                // update progress
                int percent = (int)Math.Round(100.0 * i / 200);
                progress.Report(new KeyValuePair<int, string>(percent, string.Format("Task {0} ", i)));
            }

            Trace.TraceInformation("Work finished");
            Trace.Flush();

            return result;
        }
    }
}
