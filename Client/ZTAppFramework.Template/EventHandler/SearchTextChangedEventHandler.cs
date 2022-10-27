using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZTAppFramework.Template
{
    public class SearchTextChangedEventArgs : RoutedEventArgs
    {
        public SearchTextChangedEventArgs(string text, RoutedEvent routedEvent) : base(routedEvent)
        {
            Text = text;
        }

        public string Text { get; set; }
    }

    public delegate void SearchTextChangedEventHandler(object sender, SearchTextChangedEventArgs e);
}
