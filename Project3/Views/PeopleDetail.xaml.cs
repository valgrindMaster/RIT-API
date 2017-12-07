using Project3.Wrappers;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Project3.Views
{
    public sealed partial class PeopleDetail : Page
    {
        public PeopleDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Person param = (Person)e.Parameter;
            name.Text = param.getName();
            loadProfileImg(param.getImagePath());
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
