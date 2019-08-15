using Microsoft.Win32;
using My_Exclusive_Notepad.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace My_Exclusive_Notepad.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; private set; }

        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand{ get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveAsCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        public FileViewModel(DocumentModel _document)
        {
            Document = _document;

            NewCommand = new CommandClick(NewFile);
            OpenCommand = new CommandClick(OpenFile);
            SaveCommand = new CommandClick(SaveFile);
            SaveAsCommand = new CommandClick(SaveFileAs);
            ExitCommand = new CommandClick(ExitProgram);
        }

        private void NewFile()
        {
            Document.Text = string.Empty;
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                GetFileNameAndPath(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveFile()
        {
            if (Document.FilePath != null)
                File.WriteAllText(Document.FilePath, Document.Text);
            else
                SaveFileAs();
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt";
            if(saveFileDialog.ShowDialog() == true)
            {
                GetFileNameAndPath(saveFileDialog);
                File.WriteAllText(Document.FilePath, Document.Text);
            }
        }

        private void GetFileNameAndPath(FileDialog dialog)
        {
            Document.FileName = Path.GetFileName(dialog.FileName);
            Document.FilePath = dialog.FileName;
        }

        private void ExitProgram()
        {
            Application.Current.Shutdown();
        }
    }
}
