using My_Exclusive_Notepad.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace My_Exclusive_Notepad.ViewModels
{
    public class EditorViewModel
    {
        public DocumentModel Document { get; private set; }
        public FormatModel Format { get; private set; }
        public ICommand OpenFontDialogCommand { get; private set; }

        public EditorViewModel(DocumentModel _document)
        {
            Document = _document;
            Format = new FormatModel();
            OpenFontDialogCommand = new CommandClick(OpenFontDialog);
        }

        private void OpenFontDialog()
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.DataContext = Format;
            fontDialog.Show();
        }
    }
}
