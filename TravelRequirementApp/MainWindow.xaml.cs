using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
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
            //DestinationList.Text = CountriesList.Text + ", " + p2;
            //DestinationList.IsReadOnly = true;
            Country.Text = CountriesList.Text;
            Dictionary<string, string> Countries = repo.GetDestinationInfo(CountriesList.SelectedValue.ToString());
            PValidty.Text = Countries["Passport Validity"];
            CurrRestriction.Text = Countries["Currency Restriction"];
            Vaccine.Text = Countries["Vaccination"];
            Visa.Text = Countries["Travel Visa Requirement"];
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            TravelReqForm.Visibility = Visibility.Visible;
            TravelList.Visibility = Visibility.Hidden;
            this.countrieslist = CountriesList.Text;
            SubmitButton.IsEnabled = true;
            HideDestinationInfoElements();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TravelReqForm.Visibility = Visibility.Hidden;
            TravelList.Visibility = Visibility.Hidden;
            DestinationsLabel.Visibility = Visibility.Visible;
            CountriesList.Visibility = Visibility.Visible;
            SubmitButton.Visibility = Visibility.Visible;
            WorldMap.Visibility = Visibility.Visible;
        }

        
        //Simple poplulating Combobox
        private void PopulatedCombox()
        {
            CountriesList.ItemsSource = repo.countries;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> Countries = repo.GetDestinationInfo(CountriesList.SelectedValue.ToString());
            TravelList.Visibility = Visibility.Visible;
            TravelList.Items.Add(CountriesList.Text);
            //TravelList.Items.Add(Countries["Passport Validity"]);
        }

        }
     
 }

