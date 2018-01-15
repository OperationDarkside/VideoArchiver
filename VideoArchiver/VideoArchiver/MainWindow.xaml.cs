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
        string ffmpeg_path;

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
                tbTargetPath.Text = fbd.SelectedPath;
            }
        }

        private async void btnArchive_Click(object sender, RoutedEventArgs e) {
            if (filenames == null) {
                MessageBox.Show("No filenames!");
            }
            if (tbTargetPath.Text == null) {
                MessageBox.Show("No target path!");
            }
            if (ffmpeg_path == null) {
                MessageBox.Show("No ffmpeg path!");
            }

            string targetpath = tbTargetPath.Text;

             await Task.Run(() => {
                foreach (string fullFilename in filenames) {
                    string filename = Path.GetFileName(fullFilename);

                    Process process = new Process {
                        StartInfo = new ProcessStartInfo {
                            FileName = ffmpeg_path,
                            Arguments = "-i \"" + fullFilename + "\" \"" + targetpath + Path.DirectorySeparatorChar + filename + "\""
                        }
                    };
                    process.Start();
                    process.WaitForExit();
                }
            }
            );
        }

        private void btnFFMPEG_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog().Value) {
                ffmpeg_path = ofd.FileName;
                label.Content = ffmpeg_path;
            }
        }
    }
}
