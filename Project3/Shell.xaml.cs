using Project3.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Project3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            this.InitializeComponent();
        }

        private void toggleSplitViewPane()
        {
            if (this.SplitView.IsPaneOpen) {
                this.SplitView.IsPaneOpen = !this.SplitView.IsPaneOpen;
            }
        }

        private void BackRadioButton_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            if (frame?.CanGoBack == true)
            {
                frame.GoBack();
            }

            toggleSplitViewPane();
        }

        private void HamburgerRadioButton_Click(object sender, RoutedEventArgs e)
        {
            this.SplitView.IsPaneOpen = !this.SplitView.IsPaneOpen;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(Home))
            {
                frame.Navigate(typeof(Home));
            }

            toggleSplitViewPane();
        }

        private void Research_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(Research))
            {
                frame.Navigate(typeof(Research));
            }

            toggleSplitViewPane();
        }

        private void News_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(News))
            {
                frame.Navigate(typeof(News));
            }

            toggleSplitViewPane();
        }

        private void Degrees_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(Degrees))
            {
                frame.Navigate(typeof(Degrees));
            }

            toggleSplitViewPane();
        }

        private void Minors_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(Minors))
            {
                frame.Navigate(typeof(Minors));
            }

            toggleSplitViewPane();
        }

        private void Employment_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(Employment))
            {
                frame.Navigate(typeof(Employment));
            }

            toggleSplitViewPane();
        }

        private void People_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(People))
            {
                frame.Navigate(typeof(People));
            }

            toggleSplitViewPane();
        }

        private void Map_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(JobMap))
            {
                frame.Navigate(typeof(JobMap));
            }

            toggleSplitViewPane();
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(Contact))
            {
                frame.Navigate(typeof(Contact));
            }

            toggleSplitViewPane();
        }
    }
}
