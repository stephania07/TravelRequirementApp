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

            //repo.Add(new DestinyInfo("Australia", "six month visa", "must be declared", "None", "Yes"));
            //repo.Add(new DestinyInfo("Germany", "six month visa", "must be declared", "None", "Yes"));         
        }
        private void HideDestinationInfoElements(string p1, string p2, string p3, string p4, string p5)
        {
            DestinationsLabel.Visibility = Visibility.Hidden;
            CountriesList.Visibility = Visibility.Hidden;
            SubmitButton.Visibility = Visibility.Hidden;
            WorldMap.Visibility = Visibility.Hidden;
            DestinationList.Text = CountriesList.Text + ", " + p2;
            DestinationList.IsReadOnly = true;
            Country.Text = CountriesList.Text;
            PValidty.Text = repo.GetDestinationInfo(CountriesList.Text,"Passport Validity");
            CurrRestriction.Text = repo.Germany["Currency Restriction"];
            Vaccine.Text = repo.Germany["Vaccination"];
            Visa.Text = repo.Germany["Travel visa Requirement"];
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            TravelReqForm.Visibility = Visibility.Visible;
            DestinationList.Visibility = Visibility.Visible;
            this.countrieslist = CountriesList.Text;
            SubmitButton.IsEnabled = true;
            HideDestinationInfoElements(CountriesList.Text, "six month visa", "must be declared", "None", "Yes");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TravelReqForm.Visibility = Visibility.Hidden;
            DestinationsLabel.Visibility = Visibility.Visible;
            CountriesList.Visibility = Visibility.Visible;
            SubmitButton.Visibility = Visibility.Visible;
            WorldMap.Visibility = Visibility.Visible;
        }

        //private void SetAndToggleAccess(string _string)
        //{
        //    DestinationList.IsReadOnly = true;
        //    DestinationList.Items = _string;
        //    DestinationList.IsReadOnly = true;
        //}


        //private void submitButton_Click(object sender, RoutedEventArgs e)
        //{
        //    this.countrieslist = CountriesList.Text;
        //    repo.Add(new DestinyInfo("Australia", "six month visa"));
        //    SubmitButton.IsEnabled = false;
        //    SetAndToggleAccess("Go");
        //}
        
        //Sample poplulating Combobox
        private void PopulatedCombox()
        {
           // CountriesList.ItemsSource = DataContext.Table['DestinyInfo'];
           
            CountriesList.ItemsSource = repo.countries;
        }

        }
     
 }

