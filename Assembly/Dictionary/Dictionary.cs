using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assembly.Enum;

namespace Assembly.Dictionary
{
    public static class Dictionary
    {
        //Asocia el texto de cada opción con el respectivo elemento de la enumeración
        public static Dictionary<ListBoxOptions, string> dListBoxOptions = new Dictionary<ListBoxOptions, string>()
        {
            { ListBoxOptions.Option1, Text.Text.OPTION1 },
            { ListBoxOptions.Option2, Text.Text.OPTION2 },
            { ListBoxOptions.Option3, Text.Text.OPTION3 }
        };
    }
}
