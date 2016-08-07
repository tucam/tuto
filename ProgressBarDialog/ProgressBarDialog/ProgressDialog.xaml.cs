using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProgressBarDialog
{
    /// <summary>
    /// Interaction logic for ProgressDialog.xaml
    /// </summary>
    public partial class ProgressDialog : Window
    {
        private CancellationTokenSource cancelTokenSource;

        public ProgressDialog(CancellationTokenSource cancelTokenSource, Progress<KeyValuePair<int, string>> progress)
        {
            InitializeComponent();
            this.cancelTokenSource = cancelTokenSource;

            // listen progress report
            progress.ProgressChanged += OnProgressChanged;
        }

        private void OnProgressChanged(object sender, KeyValuePair<int, string> progressReport)
        {
            // update progress
            progressTextBlock.Text = progressReport.Value;
            progressBar.Value = progressReport.Key;

            if (progressReport.Key == 100)
                Close();
        }

        private void OnCancelClicked(object sender, RoutedEventArgs evt)
        {
            this.cancelTokenSource.Cancel();
            Close();
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (progressBar.Value != 100)
                this.cancelTokenSource.Cancel();
        }
    }
}
