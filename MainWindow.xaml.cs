using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Printing;
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

namespace CopyFolderStructureWithFilesOlderThanTheDate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string inputDir = "";
        private string outputDir = "";
        private string dateOlderThanString = "";
        private DateTime dateOlderThan;
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding cb = new CommandBinding(ApplicationCommands.Copy, CopyCmdExecuted, CopyCmdCanExecute);

            this.listBoxMsg.CommandBindings.Add(cb);
        }

        private void InputPathButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FolderPicker();
            if (dlg.ShowDialog() == true)
            {
                TxtBxInput.Text = dlg.ResultPath;
            }
        }

        private void OutputPathButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FolderPicker();
            if (dlg.ShowDialog() == true)
            {
                TxtBxOutput.Text = dlg.ResultPath;
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            inputDir = TxtBxInput.Text;
            outputDir = TxtBxOutput.Text;
            dateOlderThanString = DatePickerOlderThan.Text;
            if (inputDir == "" || outputDir == "" || dateOlderThanString == "")
            {
                return;
            }
            dateOlderThan = Convert.ToDateTime(dateOlderThanString);
            var allDirectories = Directory.GetDirectories(inputDir, "*", SearchOption.AllDirectories);
            if (allDirectories.Count() > 0)
            {
                listBoxMsg.Items.Clear();

                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;

                worker.RunWorkerAsync();
            }

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
            listBoxMsg.Items.Add(e.UserState);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var allDirectories = Directory.GetDirectories(inputDir, "*", SearchOption.AllDirectories);
            foreach (var dir in allDirectories)
            {
                var dirToCreate = dir.Replace(inputDir, outputDir);
                Directory.CreateDirectory(dirToCreate);
            }

            var allFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.AllDirectories);
            var allFilesCount = allFiles.Count();
            var counter = 0;
            foreach (var filePath in allFiles)
            {
                var file = new FileInfo(filePath);
                var dt = file.CreationTime;
                if (dt >= dateOlderThan)
                {
                    var fileOutput = filePath.Replace(inputDir, outputDir);
                    File.Copy(filePath, fileOutput, true);
                    counter++;
                    var progressBarPercent = counter * 100 / allFilesCount;
                    (sender as BackgroundWorker).ReportProgress(progressBarPercent, fileOutput);
                }
            }

            (sender as BackgroundWorker).ReportProgress(100, "Success!");
        }

        void CopyCmdExecuted(object target, ExecutedRoutedEventArgs e)
        {
            ListBox lb = e.OriginalSource as ListBox;
            string copyContent = String.Empty;

            foreach (var item in lb.SelectedItems)
            {
                copyContent += item.ToString();
                // Add a NewLine for carriage return   
                copyContent += Environment.NewLine;
            }
            Clipboard.SetText(copyContent);
        }
        void CopyCmdCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            ListBox lb = e.OriginalSource as ListBox;
            // CanExecute only if there is one or more selected Item.   
            if (lb.SelectedItems.Count > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }
    }


}
