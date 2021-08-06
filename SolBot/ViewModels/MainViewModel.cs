using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolBot.ViewModels
{
    public class MainViewModel 
    {
        public MainViewModel()
        {
            ObservableCollection<Objects.Rune> output = new ObservableCollection<Objects.Rune>();
            output.Add(new Objects.Rune("SD", "SD", "adori vita vis", 880,900,5));
            output.Add(new Objects.Rune("GFB", "GFB", "adori gran flam", 480, 485, 2));
           // output.Add(new Objects.Rune("UH", "UH", "adura vita"));
            RuneList = output;
          
        }

        private ObservableCollection<Objects.Rune> _RuneList;
        public ObservableCollection<Objects.Rune> RuneList
        {
            get 
            {
                return _RuneList;
            }
            set 
            { 
                _RuneList = value; 
            }
        }
    }
}
