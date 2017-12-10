using Project3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Controls;

namespace Project3
{
    public sealed partial class Degrees : Page
    {
        private const string API_DEGREES = "http://ist.rit.edu/api/degrees/";
        static HttpClient client = new HttpClient();
        Wrappers.Degrees degrees;

        public Degrees()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (GraduateList.Items.Count == 0 && UndergraduateList.Items.Count == 0)
            {
                populateResearchAsync(sender);
            }
        }

        private async void populateResearchAsync(object sender)
        {
            HttpResponseMessage response = await client.GetAsync(API_DEGREES);
            if (response.IsSuccessStatusCode)
            {
                degrees = await response.Content.ReadAsAsync<Wrappers.Degrees>();

                TextBlock gradItem;
                foreach (Wrappers.Graduate entry in degrees.graduate)
                {
                    gradItem = new TextBlock();
                    gradItem.Padding = new Windows.UI.Xaml.Thickness(10);
                    gradItem.Text = setTitle(entry);
                    gradItem.TextWrapping = Windows.UI.Xaml.TextWrapping.WrapWholeWords;
                    GraduateList.Items.Add(gradItem);
                    GraduateList.SelectionChanged += GradList_SelectionChangedAsync;
                }

                TextBlock undergradItem;
                foreach (Wrappers.Undergraduate entry in degrees.undergraduate)
                {
                    undergradItem = new TextBlock();
                    undergradItem.Padding = new Windows.UI.Xaml.Thickness(10);
                    undergradItem.Text = setTitle(entry);
                    undergradItem.TextWrapping = Windows.UI.Xaml.TextWrapping.WrapWholeWords;
                    UndergraduateList.Items.Add(undergradItem);
                    UndergraduateList.SelectionChanged += UndergradList_SelectionChangedAsync;
                }
            }
        }

        private void GradList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            Wrappers.Program program = degrees.graduate.ElementAt(((ListView)sender).SelectedIndex);
            if (program != null)
            {
                Frame.Navigate(typeof(DegreesDetail), program);
            }
        }

        private void UndergradList_SelectionChangedAsync(object sender, SelectionChangedEventArgs e)
        {
            Wrappers.Program program = degrees.undergraduate.ElementAt(((ListView)sender).SelectedIndex);
            if (program != null)
            {
                Frame.Navigate(typeof(DegreesDetail), program);
            }
        }

        private string setTitle(Wrappers.Program program)
        {
            string degreeProgram = program.getDegreeName();
            string degreeTitle = program.getTitle();
            string fullTitle = "";

            Regex reg = new Regex("^[\x20+]?[A-Za-z0-9]+[\x20+]?$");
            if (reg.IsMatch(program.getDegreeName()))
            {
                fullTitle += degreeProgram.ToUpper();
            }
            else
            {
                fullTitle += new string(CharsToTitleCase(degreeProgram).ToArray());
            }

            if (degreeTitle != null)
            {
                fullTitle += " - " + degreeTitle;
            }

            return fullTitle;
        }

        IEnumerable<char> CharsToTitleCase(string s)
        {
            bool newWord = true;
            foreach (char c in s)
            {
                if (newWord) { yield return Char.ToUpper(c); newWord = false; }
                else yield return Char.ToLower(c);
                if (c == ' ') newWord = true;
            }
        }
    }
}
