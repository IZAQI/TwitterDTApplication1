using CoreTweet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using static CoreTweet.OAuth;

namespace TwitterDTApplication1
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var your_consumer_key = "";
            var your_consumer_secret = "";

            Session = OAuth.Authorize(your_consumer_key, your_consumer_secret);

            System.Diagnostics.Process.Start(Session.AuthorizeUri.AbsoluteUri);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var pin = Pin.Text;

            Tokens = OAuth.GetTokens(Session, pin);

            Tokens.Statuses.Update(status => "hello");
        }

        OAuthSession Session { get; set; }
        Tokens Tokens { get; set; }

    }
}
