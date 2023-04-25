using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculatorCorn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
           var Db = new DbCalculation();
            for (int i = 0; i < Db.DbLength; i++)
            {
                if (Db.DbRead(i) != null)
                    HistoryLabel.Text += Db.DbRead(i) + "\n" + "---------------------------------" + "\n";
                else
                    continue;
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }

        private void HitoryClear_Clicked(object sender, EventArgs e)
        {
            var Db = new DbCalculation();
            Db.DbAllDelete();
            HistoryLabel.Text = "";
        }
    }
}