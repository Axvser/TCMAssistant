using Emgu.CV;
using FastHotKeyForWPF;
using Microsoft.Expression.Shapes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TCMAssistant.Service;

namespace TCMAssistant
{
    [Navigable]
    public partial class HSVAssistant : UserControl
    {
        public HSVAssistant()
        {
            InitializeComponent();
            LoadHotKey();
            LoadMButtonAnimation();
            Scan.Transition()
            .SetProperty(x => x.EndAngle, 360)
            .SetParams((p) =>
            {
                p.Duration = 2;
                p.LoopTime = int.MaxValue;
                p.Update = () =>
                {
                    Scan.StartAngle = Scan.EndAngle - 120;
                };
                p.Completed += () =>
                {
                    Scan.EndAngle = 0;
                };
            }).Start();
            Scan2.Transition()
            .SetProperty(x => x.EndAngle, -360)
            .SetParams((p) =>
            {
                p.Duration = 2;
                p.LoopTime = int.MaxValue;
                p.Update = () =>
                {
                    Scan2.StartAngle = Scan2.EndAngle + 300;
                };
                p.Completed += () =>
                {
                    Scan2.EndAngle = 0;
                };
            }).Start();
        }

        private string NowPath = string.Empty;

        private void LoadHotKey()
        {
            GlobalHotKey.Awake();
            GlobalHotKey.Add(0x0002, NormalKeys.F1, (s, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "选择文件";
                openFileDialog.Filter = "所有文件 (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // 显示对话框并检查用户是否选择了文件
                if (openFileDialog.ShowDialog() == true)
                {
                    // 获取选定文件的绝对路径
                    string filePath = openFileDialog.FileName;
                    // 创建 BitmapImage 对象
                    BitmapImage bitmapImage = new BitmapImage();

                    // 设置 BitmapImage 的 UriSource
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(filePath);
                    NowPath = filePath;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                    Photo.Source = bitmapImage;
                    HSV hSV = HSV.Parse(CvInvoke.Imread(NowPath));
                    string result = hSV.Assistant().ToString() ?? string.Empty;
                    LoadResultAniamtion(result);
                }
            });
        }
        private void LoadMButtonAnimation()
        {
            Select1.MouseEnter += (sender, e) =>
            {
                Select1.BeginTransition(MainWindow._selected);
            };
            Select1.MouseLeave += (sender, e) =>
            {
                Select1.BeginTransition(MainWindow._noselected);
            };
            Select2.MouseEnter += (sender, e) =>
            {
                Select2.BeginTransition(MainWindow._selected);
            };
            Select2.MouseLeave += (sender, e) =>
            {
                Select2.BeginTransition(MainWindow._noselected);
            };
            Select3.MouseEnter += (sender, e) =>
            {
                Select3.BeginTransition(MainWindow._selected);
            };
            Select3.MouseLeave += (sender, e) =>
            {
                Select3.BeginTransition(MainWindow._noselected);
            };
            Select4.MouseEnter += (sender, e) =>
            {
                Select4.BeginTransition(MainWindow._selected);
            };
            Select4.MouseLeave += (sender, e) =>
            {
                Select4.BeginTransition(MainWindow._noselected);
            };
            Select5.MouseEnter += (sender, e) =>
            {
                Select5.BeginTransition(MainWindow._selected);
            };
            Select5.MouseLeave += (sender, e) =>
            {
                Select5.BeginTransition(MainWindow._noselected);
            };
        }
        private void LoadResultAniamtion(string value)
        {
            Result.Transition()
                .SetProperty(x => x.Opacity, 1)
                .SetProperty(x => x.FontSize, 30)
                .SetParams((p) =>
                {
                    p.Duration = 1;
                    p.Start = () =>
                    {
                        Result.Opacity = 0;
                        Result.FontSize = 0.1;
                        Result.Text = $"测试结果 :\n\n{value}\n\n接下来 :\n\n";
                    };

                }).Start();
            Selectors.Transition()
                .SetProperty(x => x.Opacity, 1)
                .SetParams((p) =>
                {
                    p.Duration = 2;
                    p.Start = () =>
                    {
                        Selectors.Opacity = 0;
                    };

                }).Start();
        }
    }
}
