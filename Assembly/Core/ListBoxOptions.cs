using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Core
{
    public static class ListBoxOptions
    {
        //Obtiene una lista de strings con las opciones que serán cargadas en el ListBox
        public static List<string> GetListBoxOptions()
        {
            var options = new List<string>();

            foreach (Enum.ListBoxOptions option in (Enum.ListBoxOptions[]) System.Enum.GetValues(typeof(Enum.ListBoxOptions)))
            {
                options.Add(Dictionary.Dictionary.dListBoxOptions[option]);
            }

            return options;
        }
    }
}
