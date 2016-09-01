using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgressBarDialog
{
    class TextBlockTraceListener : TraceListener
    {
        private TextBlock textBlock;
        public TextBlockTraceListener(TextBlock textBlock)
        {
            this.textBlock = textBlock;
        }

        public override void Write(string message)
        {
            // execute on UI thread
            this.textBlock.Dispatcher.Invoke(() => {
                this.textBlock.Text += message;
            });
        }

        public override void WriteLine(string message)
        {
            // execute on UI thread
            this.textBlock.Dispatcher.Invoke(() => {
                this.textBlock.Text += message;
                this.textBlock.Text += "\n";
            });
        }
    }
}
