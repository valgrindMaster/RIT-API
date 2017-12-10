using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Project3.Views
{
    public sealed partial class NewsDetail : Page
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }

        public NewsDetail()
        {
            DataContext = this;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Wrappers.Older param = (Wrappers.Older)e.Parameter;
            NewsTitle.Text = param.title;
            NewsDate.Text = param.date;
            NewsDescription.Text = param.description;
            setProperties(param);
        }

        private void setProperties(Wrappers.Older older)
        {
            Title = setEmptyIfBlank(older.title);
            Date = setEmptyIfBlank(older.date);
            Description = setEmptyIfBlank(older.description);
        }

        private string setEmptyIfBlank(string val)
        {
            if (val == null || val.Length == 0)
            {
                return "N/A";
            }

            return val;
        }
    }
}
