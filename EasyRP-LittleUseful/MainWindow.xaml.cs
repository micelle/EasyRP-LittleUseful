using System;
using System.IO;
using System.Windows;
using System.Diagnostics;

namespace EasyRP_LittleUseful
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string currentDirectory;
        private readonly string settingDirectory;
        private readonly string easyrpPath;
        private readonly string configPath;
        private readonly string settingConfigPath;
        private string settingSelectPath;
        public MainWindow()
        {
            InitializeComponent();
            // ディレクトリとパスを取得
            currentDirectory = Directory.GetCurrentDirectory();
            settingDirectory = currentDirectory + @"\setting";
            easyrpPath = currentDirectory + @"\easyrp.exe";
            configPath = currentDirectory + @"\config.ini";
            settingConfigPath = currentDirectory + @"\setting\config.ini";
            settingSelectPath = currentDirectory + @"\setting\config.ini";
            // 各種チェック
            CheckFileAndDirectory();
            UpdateFileListBox();
            // 起動オプション
            var commandLineArgs = Environment.GetCommandLineArgs();
            var commandLine = new CommandLine(commandLineArgs);
            FileListBox.SelectedItem = commandLine.GetFileName().Replace("_", "__");
            StartTimestamp.IsChecked = !commandLine.IsStartTimestampe();
            AutoClose.IsChecked = !commandLine.IsAutoClose();
            NoAlert.IsChecked = commandLine.IsNoAlert();
            if (commandLine.IsStart()) StartEasyRP();
        }
        private void ReloadButtonClick(object sender, RoutedEventArgs e)
        {
            CheckFileAndDirectory();
            UpdateFileListBox();
        }
        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            CheckFileAndDirectory();
            StartEasyRP();
        }
        private void CheckFileAndDirectory()
        {
            if (!File.Exists(easyrpPath))
            {
                MessageBox.Show("easyrp.exeが存在しないため、終了します。");
                this.Close();
                return;
            }
            if (!Directory.Exists(settingDirectory))
            {
                Directory.CreateDirectory(settingDirectory);
            }
            if (!File.Exists(settingConfigPath))
            {
                try
                {
                    File.Copy(configPath, settingConfigPath, true);
                }
                catch (IOException copyError)
                {
                    MessageBox.Show(copyError.Message);
                }
            }
        }
        private void UpdateFileListBox()
        {
            FileListBox.Items.Clear();
            var iniFilePaths = Directory.GetFileSystemEntries(settingDirectory, "*.ini");
            foreach (string iniFilePath in iniFilePaths)
            {
                var iniFileName = Path.GetFileName(iniFilePath).Replace("_", "__"); // _が1つだと消えてしまう為の置換
                FileListBox.Items.Add(iniFileName);
            }
        }
        private void StartEasyRP()
        {
            var selectFileNames = FileListBox.SelectedItem;
            if (selectFileNames == null)
            {
                MessageBox.Show("ファイルを選択してください。");
                return;
            }
            // ファイルをコピー
            var selectFileName = selectFileNames.ToString().Replace("__", "_"); // _が2つになっている為の置換
            settingSelectPath = currentDirectory + @"\setting\" + selectFileName;
            try
            {
                File.Copy(settingSelectPath, configPath, true);
            }
            catch (IOException copyError)
            {
                MessageBox.Show(copyError.Message);
                return;
            }
            // iniの書き換え
            IniFile ini = new IniFile(configPath);
            if (StartTimestamp.IsChecked == true)
            {
                var unixtime = (DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                var unixtimeStr = unixtime.ToString();
                ini["State", "StartTimestamp"] = unixtimeStr;
            }
            // EasyRPの起動
            var proc = new Process();
            proc.StartInfo.FileName = easyrpPath;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            proc.Start();
            if (NoAlert.IsChecked == false) MessageBox.Show("easyrp.exeを起動しました。");
            if (AutoClose.IsChecked == true) this.Close();
        }
    }
}
