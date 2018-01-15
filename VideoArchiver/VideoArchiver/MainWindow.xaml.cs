using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace VideoArchiver {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        string[] filenames;
        string targetpath;

        public MainWindow() {
            InitializeComponent();
        }

        private void btnSelectFiles_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog().Value) {
                filenames = ofd.FileNames;

                if (filenames != null && filenames.Length > 0) {
                    foreach (string filename in filenames) {
                        listBox.Items.Add(filename);
                    }
                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                targetpath = fbd.SelectedPath;
                tbTargetPath.Text = targetpath;
            }
        }

        private void btnArchive_Click(object sender, RoutedEventArgs e) {
            foreach (string fullFilename in filenames) {
                string filename = Path.GetFileName(fullFilename);

                Process process = new Process {
                    StartInfo = new ProcessStartInfo {
                        FileName = "ffmpeg.exe -i \"" + fullFilename + "\" \"" + targetpath + Path.DirectorySeparatorChar + filename + "\""
                    }
                };
                process.Start();
                process.WaitForExit();
            }
        }
    }
}
