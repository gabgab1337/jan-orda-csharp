using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ToDoApp.Convertes
{
    public class BoolToTextDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture )
        {
            if(value is bool isDone && isDone == true) 
            { 
                return TextDecorations.Strikethrough; 
            }
            return TextDecorations.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // if (value is TextDecorations decorations && decorations == TextDecorations.Strikethrough)
            // {
            //    return true;
            // }
            // return false;

            // Skrócona, lepsza metoda:
            return value is TextDecorations decorations && decorations == TextDecorations.Strikethrough;
        }
    }
}