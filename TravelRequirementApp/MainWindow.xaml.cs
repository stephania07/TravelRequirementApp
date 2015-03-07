using System.Collections.Generic;
using System.Data;
using System.Windows;
using TravelRequirementApp.Model;
using TravelRequirementApp.Repository;

namespace TravelRequirementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DestinyInfoRepository repo = new DestinyInfoRepository();
        private string countrieslist;
       
       

        public MainWindow()
        {
            InitializeComponent();
            SubmitButton.DataContext = repo.Context().Destinations.Local;
            PopulatedCombox();   
        }

        private void HideDestinationInfoElements()
        {
            DestinationsLabel.Visibility = Visibility.Hidden;
            CountriesList.Visibility = Visibility.Hidden;
            SubmitButton.Visibility = Visibility.Hidden;
            WorldMap.Visibility = Visibility.Hidden;
            Country.Text = CountriesList.Text;
            Dictionary<string, string> Countries = repo.GetDestinationInfo(CountriesList.SelectedValue.ToString());
            PValidty.Text = Countries["Passport Validity"];
            CurrRestriction.Text = Countries["Currency Restriction"];
            Vaccine.Text = Countries["Vaccination"];
            Visa.Text = Countries["Travel Visa Requirement"];
            Note.Text = Countries["Note"];
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            if (CountriesList.Text != "")
            {
                TravelReqForm.Visibility = Visibility.Visible;
                TravelList.Visibility = Visibility.Hidden;
                this.countrieslist = CountriesList.Text;
                SubmitButton.IsEnabled = true;
                HideDestinationInfoElements();
            }
            else
            {
                MessageBox.Show("Please select your destination", "Error", MessageBoxButton.OK);
                
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            TravelReqForm.Visibility = Visibility.Hidden;
            TravelList.Visibility = Visibility.Hidden;
            DestinationsLabel.Visibility = Visibility.Visible;
            CountriesList.Visibility = Visibility.Visible;
            SubmitButton.Visibility = Visibility.Visible;
            WorldMap.Visibility = Visibility.Visible;
            ReminderNote.Visibility = Visibility.Collapsed;
            loadlist.Visibility = Visibility.Hidden;
           
        }

        
        //Simple poplulating Combobox
        private void PopulatedCombox()
        {
            CountriesList.ItemsSource = repo.countries;
        }

        private void AddToList(object sender, RoutedEventArgs e)
         {
                Dictionary<string, string> Countries = repo.GetDestinationInfo(CountriesList.SelectedValue.ToString());
                TravelList.Visibility = Visibility.Visible;
                TravelList.Items.Add(CountriesList.Text);
                repo.Add(new DestinyInfo(CountriesList.Text, Countries["Passport Validity"], Countries["Currency Restriction"], Countries
                ["Vaccination"], Countries["Travel Visa Requirement"], Countries["Note"]));
                loadlist.Visibility = Visibility.Hidden;
                           
          }

        private void Delete(object sender, RoutedEventArgs e)
        { 
            var val = repo.GetByDestination(TravelList.SelectedValue.ToString());
            repo.Delete(val);
            TravelList.Items.Remove(TravelList.SelectedItem.ToString());
            loadlist.Visibility = Visibility.Hidden;
        }
        

        private void Edit(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> Countries = repo.GetDestinationInfo(CountriesList.SelectedValue.ToString());
            var reminder = TravelList.SelectedItem.ToString();
            ReminderNote.Visibility = Visibility.Visible;
            Note.Text = "Please add note here";
            loadlist.Visibility = Visibility.Hidden;
        }

        private void UpdateDB(object sender, RoutedEventArgs e)
        {
            var val = Note.Text.ToString();
            repo.UpDateDB(val, CountriesList.SelectedValue.ToString());
            ReminderNote.Visibility = Visibility.Collapsed;
            loadlist.Visibility = Visibility.Hidden;
        }

        

        private void ShowAllTravelList(object sender, RoutedEventArgs e)
        {
            loadlist.Visibility = Visibility.Visible;
            loadlist.ItemsSource = repo.Context().Destinations.Local;
            loadlist.Items.Refresh();
        }

        }
    
 }

