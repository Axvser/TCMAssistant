global using MinimalisticWPF;
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
using TCMAssistant.Page;

namespace TCMAssistant
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NowPage.Navigate(typeof(ConfigPage));
        }

        private static TransitionBoard<Border> _noselected = Transition.CreateBoardFromType<Border>()
            .SetProperty(x => x.Background, Brushes.Gray)
            .SetProperty(x => x.Opacity, 0.6)
            .SetParams((x) =>
            {
                x.Duration = 0.2;
            });
        private static TransitionBoard<Border> _selected = Transition.CreateBoardFromType<Border>()
            .SetProperty(x => x.Background, Brushes.Cyan)
            .SetProperty(x => x.Opacity, 1)
            .SetParams((x) =>
            {
                x.Duration = 0.5;
            });

        private int _pagetype = 1;
        public int PageType//当前页面标号
        {
            get => _pagetype;
            set
            {
                if (value != _pagetype)
                {
                    PageLightChange(_pagetype, value);
                    _pagetype = value;
                }
            }
        }

        private void PageLightChange(int last, int next)
        {
            switch (last)
            {
                case 1:
                    B1.BeginTransition(_noselected);
                    break;
                case 2:
                    B2.BeginTransition(_noselected);
                    break;
                case 3:
                    B3.BeginTransition(_noselected);
                    break;
            }
            switch (next)
            {
                case 1:
                    B1.BeginTransition(_selected);
                    break;
                case 2:
                    B2.BeginTransition(_selected);
                    break;
                case 3:
                    B3.BeginTransition(_selected);
                    break;
            }
        }

        private void Config_Click(object sender, MouseButtonEventArgs e)
        {
            NowPage.Navigate(typeof(ConfigPage));
            PageType = 1;
        }
        private void HSV_Click(object sender, MouseButtonEventArgs e)
        {
            NowPage.Navigate(typeof(HSVPage));
            PageType = 2;
        }
        private void AI_Click(object sender, MouseButtonEventArgs e)
        {
            NowPage.Navigate(typeof(AIPage));
            PageType = 3;
        }
    }
}