global using MinimalisticWPF;
using FastHotKeyForWPF;
using Microsoft.Win32;
using OpenCVSharpDemo;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
    public partial class MainWindow : Window
    {
        public static TransitionBoard<TButton> _selected = Transition.CreateBoardFromType<TButton>()
            .SetProperty(x => x.Height, 50)
            .SetProperty(x => x.FontSize, 50)
            .SetProperty(x => x.Foreground, Brushes.Violet)
            .SetProperty(x => x.CornerRadius, new CornerRadius(5))
            .SetParams((x) =>
            {
                x.Duration = 0.3;
                x.FrameRate = 120;
            });
        public static TransitionBoard<TButton> _noselected = Transition.CreateBoardFromType<TButton>()
            .SetProperty(x => x.Height, 30)
            .SetProperty(x => x.FontSize, 30)
            .SetProperty(x => x.Foreground, "#1e1e1e".ToBrush())
            .SetProperty(x => x.CornerRadius, new CornerRadius(0))
            .SetParams((x) =>
            {
                x.Duration = 0.2;
                x.FrameRate = 120;
            });
        public MainWindow()
        {
            InitializeComponent();
            LoadStartAnimation();
            LoadMButtonAnimation();
        }

        private void LoadStartAnimation()
        {
            TB1.Transition()
            .SetProperty(x => x.Opacity, 1)
            .SetProperty(x => x.FontSize, 30)
            .SetParams((p) =>
            {
                p.Duration = 0.8;
            })
            .Start();
            Selectors.Transition()
                .SetProperty(x => x.Opacity, 1)
                .SetProperty(x => x.Height, 300)
                .SetParams((p) =>
                {
                    p.Duration = 0.8;
                })
                .Start();
        }
        private void LoadMButtonAnimation()
        {
            Select1.MouseEnter += (sender, e) =>
            {
                Select1.BeginTransition(_selected);
            };
            Select1.MouseLeave += (sender, e) =>
            {
                Select1.BeginTransition(_noselected);
            };
            Select2.MouseEnter += (sender, e) =>
            {
                Select2.BeginTransition(_selected);
            };
            Select2.MouseLeave += (sender, e) =>
            {
                Select2.BeginTransition(_noselected);
            };
            Select3.MouseEnter += (sender, e) =>
            {
                Select3.BeginTransition(_selected);
            };
            Select3.MouseLeave += (sender, e) =>
            {
                Select3.BeginTransition(_noselected);
            };
            Select4.MouseEnter += (sender, e) =>
            {
                Select4.BeginTransition(_selected);
            };
            Select4.MouseLeave += (sender, e) =>
            {
                Select4.BeginTransition(_noselected);
            };
            Select5.MouseEnter += (sender, e) =>
            {
                Select5.BeginTransition(_selected);
            };
            Select5.MouseLeave += (sender, e) =>
            {
                Select5.BeginTransition(_noselected);
            };
            Select6.MouseEnter += (sender, e) =>
            {
                Select6.BeginTransition(_selected);
            };
            Select6.MouseLeave += (sender, e) =>
            {
                Select6.BeginTransition(_noselected);
            };
            Select7.MouseEnter += (sender, e) =>
            {
                Select7.BeginTransition(_selected);
            };
            Select7.MouseLeave += (sender, e) =>
            {
                Select7.BeginTransition(_noselected);
            };
        }

        private void Select2_Click(object sender, RoutedEventArgs e)
        {
            Pages.Width = 540;
            Pages.Navigate(typeof(HSVAssistant));
        }

        private void TButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.Width = 0; ;
        }
    }
}