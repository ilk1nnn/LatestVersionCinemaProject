using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using System.Net;
using System.Net.Mail;
using System;

namespace WPF_LoginForm
{
    /// <summary>
    /// Interaction logic for TicketsUC.xaml
    /// </summary>
    public partial class TicketsUC : UserControl, INotifyPropertyChanged
    {

        private string _poster;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Poster
        {
            get { return this._poster; }
            set
            {
                if (!string.Equals(this._poster, value))
                {
                    this._poster = value;
                    this.OnPropertyChanged();
                }
            }
        }
        public TicketsUC()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        int count = 0;
        private void searchbtn_Click(object sender, RoutedEventArgs e)
        {
            SendRequest sendRequest = new SendRequest();
            if (searchedtxtb.Text.Length > 0)
            {
                Poster = sendRequest.GetPoster(searchedtxtb.Text);
                Title.Text = sendRequest.GetTitle(searchedtxtb.Text);
            }
            buyticket.Visibility = Visibility.Visible;

        }

        private void buyticket_Click(object sender, RoutedEventArgs e)
        {
            ButtonGrid.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count++;
            var button = sender as Button;
            button.IsEnabled = false;
            EmailGrid.Visibility = Visibility.Visible;
            button.Background = Brushes.Red;
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var button = sender as Button;
            button.IsEnabled = true;
        }

        private void confirmbtn_Click(object sender, RoutedEventArgs e)
        {

            //    try
            //    {

            //        string from = "fbes3212.az@gmail.com";
            //        string password = "fbes3212";

            //        MailMessage msg = new MailMessage();
            //        msg.Subject = "Test Email";
            //        msg.Body = "Hello World";
            //        msg.From = new MailAddress(from);
            //        msg.To.Add(new MailAddress(emailtxtb.Text));


            //        SmtpClient smtpClient = new SmtpClient();
            //        smtpClient.Host = "smtp.gmail.com";
            //        smtpClient.Port = 587;
            //        smtpClient.UseDefaultCredentials = false;
            //        smtpClient.EnableSsl = true;

            //        NetworkCredential nc = new NetworkCredential();
            //        smtpClient.Credentials = nc;

            //        smtpClient.Send(msg);

            //        MessageBox.Show("Email Sent!");


            //    }
            //    catch (System.Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }

            //}


            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("fbes3212.az@gmail.com");
                    mail.To.Add(emailtxtb.Text);
                    mail.Subject = "Cinema Ticket";
                    mail.Body = $"<h1>Confirmed! You Buy {count} tickets to the ({Title.Text.ToString()}) Movie. Date When you buy it => {DateTime.Now.ToString()}!</h1>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("fbes3212.az@gmail.com", "yheqyrwzhsrpwufx");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                MessageBox.Show("Email Sent!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
