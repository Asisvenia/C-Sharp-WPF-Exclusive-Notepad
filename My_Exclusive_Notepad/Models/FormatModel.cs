using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Reflection;
using System.Windows.Input;
using System.Diagnostics;

namespace My_Exclusive_Notepad.Models
{
    public class FormatModel : ObservableObject
    {
        public List<FontFamily> fontCollection { get; private set; }
        public List<string> fontWeightsFixed { get; private set; }
        public List<FontStyle> fontStylesCollection { get; private set; }
        public List<double> fontSizeCollection { get; private set; }

        public FormatModel()
        {
            GetAvaibFonts();
        }

        private FontFamily _fontFamily;
        public FontFamily FontFamily
        {
            get { return _fontFamily; }
            set { OnPropertyChanged(ref _fontFamily, value); }
        }

        private FontWeight _fontWeight;
        public FontWeight FontWeight
        {
            get { return _fontWeight; }
            set { OnPropertyChanged(ref _fontWeight, value); }
        }

        private FontStyle _fontStyle;
        public FontStyle FontStyle
        {
            get { return _fontStyle; }
            set { OnPropertyChanged(ref _fontStyle, value); }
        }

        private double _fontSize;
        public double FontSize
        {
            get { return _fontSize; }
            set { OnPropertyChanged(ref _fontSize, value); }
        }

        private bool _isWrapping;
        public bool IsWrapping
        { get
            {
                return _isWrapping;
            }
          set
            {
                OnPropertyChanged(ref _isWrapping, value);
                TextWrapping = IsWrapping ? "Wrap" : "NoWrap";
            }
        }

        private string _textWrapping;
        public string TextWrapping
        {
          get
            {
                return _textWrapping;
            }
          set
            {
                OnPropertyChanged(ref _textWrapping, value);
            }
        }

        private string _fgColor;
        public string FGColor
        {
            get
            {
                if (string.IsNullOrEmpty(_fgColor))
                    return "#000000";

                return _fgColor;
            }
            set
            {
                OnPropertyChanged(ref _fgColor, value);
            }
        }

        private string _bgColor;
        public string BGColor
        {
            get
            {
                if (string.IsNullOrEmpty(_bgColor))
                    return "#ffffff";

                return _bgColor;
            }
            set
            {
                OnPropertyChanged(ref _bgColor, value);
            }
        }

        public void GetAvaibFonts()
        {
            /// Font family
            var fontFamilies = new InstalledFontCollection().Families;
            fontCollection = new List<FontFamily>();

            foreach (var fontFamily in fontFamilies)
            {
                var mfont = new FontFamily(fontFamily.Name);
                fontCollection.Add(mfont);
            }
            fontCollection = fontCollection.Where(x => x.ToString().Length > 0).ToList();

            /// Font weight
            PropertyInfo[] fontWeightsProps;

            fontWeightsProps = typeof(FontWeights).GetProperties(BindingFlags.Public | BindingFlags.Static);
            fontWeightsFixed = new List<string>();
            foreach (var weight in fontWeightsProps)
            {
                fontWeightsFixed.Add(weight.ToString());
            }
            fontWeightsFixed = fontWeightsFixed.Select(x => x.Split(' ')[1]).ToList();

            /// Font Style
            fontStylesCollection = new List<FontStyle>();
            fontStylesCollection.Add(FontStyles.Italic);
            fontStylesCollection.Add(FontStyles.Normal);
            fontStylesCollection.Add(FontStyles.Oblique);

            /// Font size
            fontSizeCollection = new List<double>()
            {
                8,9,10,11,12,14,16,18,20,22,24,26,28,30,32,36,38,42,46,48,52,56,64,72
            };
        }
    }
}
