using System;
using System.Windows;
using System.Windows.Controls;


namespace todo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            SelectedDates(Calendar);


        }

        void SelectedDates(Calendar calendar)
        {
            using (var contex = new MyDbContex())
            {
                var Case = contex.Cases;
                foreach (Case c in Case) { 
                
                    calendar.SelectedDates.Add(c.DateCreat);
                 
                }
            }

            }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            using (var contex = new MyDbContex())
            {
                var Case = new Case(Time, Name_Textbox, Data, Prime);
                Case @case = new Case(Time, Name_Textbox, Data, Prime);
                @case.Writer();
                contex.Cases.Add(Case);
                contex.SaveChanges();

            }
            SelectedDates(Calendar);
        }

       
      
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Case @case = new Case();
            DateTime select = (DateTime)Calendar.SelectedDate;
            string selectnew = select.ToShortDateString();
            //@case.Reader(Read_Textblock, selectnew);

            using (var contex = new MyDbContex())
            {

                var Case = contex.Cases;

                foreach (Case c in Case)
                {
                    if (select == c.DateCreat)
                    {
                            Read_Textblock.Text += $"Название дела:{c.Name}\n" +
                            $"Дата планирования:{c.DateCreat.ToShortDateString()}\n" +
                            $"Время планирования:{c.time}\n" +
                            $"Важность:{c.importance}\n";

                    }
                   
                }
            }
            SelectedDates(Calendar);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
