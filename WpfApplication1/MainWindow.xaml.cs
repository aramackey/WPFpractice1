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
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApplication1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Values Values;
        public MainWindow()
        {
            InitializeComponent();
            // class declaration and initirization.
            Values = new Values() { ValueLeft=0, ValueRight=0};
            // Data binding
            TextBox1.DataContext = Values;
            TextBox2.DataContext = Values;
            TextBox3.DataContext = Values;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = (RadioButton)sender;
            this.textBlockSelected.Text = radioButton.Content.ToString();
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
          //  var value1 = (Slider)sender;
            var value1 = (Slider)sender;
            Values.ValueLeft = value1.Value;
            //Values.ans = Values.ValueLeft.ToString()+" x "+Values.ValueRight.ToString();
            //Values.ans = (Values.ValueRight * Values.ValueLeft).ToString();
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var value2 = (Slider)sender;
            Values.ValueRight = value2.Value;
            //Values.ans = Values.ValueLeft.ToString()+" x "+Values.ValueRight.ToString();
            //Values.ans = (Values.ValueRight * Values.ValueLeft).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
//            Values.ans=(String)Values.ValueLeft+"x"+(String)Values.ValueRight;
//            double mult_answer = Values.ValueLeft * Values.ValueRight;
            Values.ans = (Values.ValueRight * Values.ValueLeft).ToString();
        }
    }

    /// <summary>
    /// class for detecting status change of two values (slide bar) and answer.
    /// </summary>
    class Values : INotifyPropertyChanged
    {
        double _ValueLeft;
        double _ValueRight;
        string _ans="Unset the values;";

        public double ValueLeft { get { return _ValueLeft; } set { _ValueLeft = value; NotifyPropertyChanged("ValueLeft"); } }
        public double ValueRight { get { return _ValueRight; } set { _ValueRight = value; NotifyPropertyChanged("ValueRight"); } }
        public string ans { get { return _ans; } set { _ans = value; NotifyPropertyChanged("ans"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}