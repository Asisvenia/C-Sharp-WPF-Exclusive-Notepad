using My_Exclusive_Notepad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Exclusive_Notepad.ViewModels
{
    public class MainViewModel
    {
        private DocumentModel _document;
        public FileViewModel File { get; set; }
        public EditorViewModel Editor { get; set; }

        public MainViewModel()
        {
            _document = new DocumentModel();
            File = new FileViewModel(_document);
            Editor = new EditorViewModel(_document);
        }
    }
}
