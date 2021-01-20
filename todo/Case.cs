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
using System.IO;

namespace todo
{
   public class Case
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public int importance { get; set;}
        public DateTime DateCreat { get; set; }
        public string time { get; set; }


        public const string Path = @"C:\Users\Федор\source\repos\todo\todo\case.txt";



        public Case(TextBox Time,TextBox Name, DatePicker date,ComboBox importance)
        {

            this.Name = Name.Text;
       
            this.DateCreat = (DateTime)date.SelectedDate;
            this.time =Time.Text;
            this.importance = importance.SelectedIndex+1;
           
         }
        public Case() { 
        
        
        }
        public void Writer()
        {
            using (FileStream file=new FileStream(Path,FileMode.OpenOrCreate))
            {

            }

            using (StreamWriter write = new StreamWriter(Path,true, System.Text.Encoding.Default))
            {

                write.Write($"Название дела: {Name}\n");
                write.Write($"Дата планирование: \n{DateCreat}\n");
                write.Write($"Время планирование: {time}\n");
                write.Write($"Приорете:{importance}\n");
                write.Write($" \n");
            }
        }
        public List<int> Selectindex(string select)
        {
            List<int>Cout=new List<int>();
 
            int cout = 0;
            using (StreamReader reader = new StreamReader(Path, System.Text.Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    cout++;
                    if (temp.StartsWith(select))
                    {
                        Cout.Add(cout-3);

                    }

                }
            }

            return Cout;
        }
        
        public void Reader(TextBlock textBlock,string select) 
        {
            
                List<int> Cout = Selectindex(select);
                int i = 0;
                int h = 0;
             textBlock.Text = $"Сегодня дел запланирована {Cout.Count()}\n";
            for (int s = 0; s < Cout.Count(); s++) 
            { 
                    using (FileStream File= new FileStream(Path, FileMode.OpenOrCreate))
                    {

                    File.Seek(0, SeekOrigin.Begin);

                    }

                    using (StreamReader reader = new StreamReader(Path, System.Text.Encoding.UTF8))
                    {
                        
                        int debag = reader.Peek();
              
                      
                    for (; i != Cout[h]; i++)
                        {
                            reader.ReadLine();

                        }
                       h++;
                    
                    for (int j = 0; j != 4; j++)
                        {
                            textBlock.Text += reader.ReadLine() + "\n";
                        }

                    }

                }
            
        }
        public virtual ICollection<Case> Cases { get; set; }
    }



}
