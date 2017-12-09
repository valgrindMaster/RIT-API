using Project3.Wrappers;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Project3.Views
{
    public sealed partial class PeopleDetail : Page
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Office { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Interest { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }

        public PeopleDetail()
        {
            DataContext = this;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Person param = (Person)e.Parameter;
            name.Text = param.getName();
            loadProfileImg(param.getImagePath());
            setProperties(param);
        }

        private void setProperties(Person person)
        {
            Username = setEmptyIfBlank(person.getUsername());
            Title = setEmptyIfBlank(person.getTitle());
            Tagline = setEmptyIfBlank(person.getTagline());
            Office = setEmptyIfBlank(person.getOffice());
            Email = setEmptyIfBlank(person.getEmail());
            Phone = setEmptyIfBlank(person.getPhone());
            Website = setEmptyIfBlank(person.getWebsite());
            Interest = setEmptyIfBlank(person.getInterestArea());
            Twitter = setEmptyIfBlank(person.getTwitter());
            Facebook = setEmptyIfBlank(person.getFacebook());
        }

        private string setEmptyIfBlank(string val)
        {
            if (val == null || val.Length == 0)
            {
                return "N/A";
            }

            return val;
        }

        private void loadProfileImg(string imgPath)
        {
            var src = new Image
            {
                Source = new BitmapImage(
                    new Uri(
                        imgPath))
            };

            Profile_Img.ImageSource = src.Source;
        }
    }
}
