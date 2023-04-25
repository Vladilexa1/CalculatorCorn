using System;
using System.Globalization;
using Xamarin.Forms;


namespace CalculatorCorn
{
    public partial class MainPage : ContentPage
    {
        private int TextNumberLength = 4;
        public MainPage()
        {
            InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
           



        }
        
        private void ButtonOne_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (labelCalc.Text.Length != TextNumberLength && button.Text != ".") // ограничение длинны вводимого числа, проверка на .
            {
                if (labelCalc.Text == "0")
                    labelCalc.Text = button.Text;
                else
                    labelCalc.Text += button.Text;
            }
            else // обработка .
            {
                if (button.Text == "." && labelCalc.Text.Length == 2)
                        labelCalc.Text += button.Text;
            }
            
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            labelCalc.Text = "0";
        }

        private void Calcuation_Clicked(object sender, EventArgs e)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };
            double wlaga = double.Parse(labelCalc.Text, numberFormatInfo);
            if (wlaga > 100)
               Error();
            else if (wlaga < 15.45)
                SuhError();
            else
                printResult();
        }
        private async void printResult()
        {
            var calcLogic = new CalcLogic(labelCalc.Text);
            var Db = new DbCalculation();
            string result = calcLogic.logic();
            Db.DbCreate(result);
            
            await DisplayAlert
                ("Результат",
                result,
                "Выход"
                );
        }
        private async void Error()
        {
            await DisplayAlert("Ошибка", "Влага введена не коректно", "Выйти");
        }
        private async void SuhError()
        {
            await DisplayAlert("Ошибка", "Кукуруза сухая", "Выйти");
        }

        private void DbInfo_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new Page1();
        }
    }
}
