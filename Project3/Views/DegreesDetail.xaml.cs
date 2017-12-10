using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Project3.Views
{
    public sealed partial class DegreesDetail : Page
    {
        public DegreesDetail()
        {
            DataContext = this;
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Wrappers.Program program = (Wrappers.Program)e.Parameter;
            NewsHeader.Text = program.getProgramType() + ": " + program.getDegreeName().ToUpper();

            if (program.getTitle() != null)
            {
                NewsHeader.Text += " - " + program.getTitle();
            }

            if (program.getDescription() != null)
            {
                NewsSubheader.Text = program.getDescription();
            }

            if (program.getConcentations() != null)
            {
                TextBlock headerBlock = new TextBlock();
                headerBlock.Text = "Concentrations:";
                FontWeight fw = new FontWeight();
                fw.Weight = 20;
                headerBlock.FontWeight = fw;
                headerBlock.Padding = new Thickness(15);
                TextBlock conBlock;
                DegreesDetailList.Items.Add(headerBlock);
                foreach (string con in program.getConcentations())
                {
                    if (con != null)
                    {
                        conBlock = new TextBlock();
                        conBlock.TextWrapping = TextWrapping.WrapWholeWords;
                        conBlock.Padding = new Thickness(10);
                        conBlock.Text = con;
                        DegreesDetailList.Items.Add(conBlock);
                    }
                }
            }

            if (program.getAvailableCertificates() != null)
            {
                NewsSubheader.Text += " Available Certificates are included below.";
                TextBlock headerBlock = new TextBlock();
                headerBlock.Text = "Available Certificates:";
                FontWeight fw = new FontWeight();
                fw.Weight = 20;
                headerBlock.FontWeight = fw;
                headerBlock.Padding = new Thickness(15);
                TextBlock conBlock;
                DegreesDetailList.Items.Add(headerBlock);
                foreach (string con in program.getAvailableCertificates())
                {
                    if (con != null)
                    {
                        conBlock = new TextBlock();
                        conBlock.TextWrapping = TextWrapping.WrapWholeWords;
                        conBlock.Padding = new Thickness(10);
                        conBlock.Text = con;
                        DegreesDetailList.Items.Add(conBlock);
                    }
                }
            }
        }
    }
}
