using System;
using System.Globalization;
using System.Security.Cryptography;

namespace CalculatorCorn
{
    public class CalcLogic
    {
        private string wlaga;
        public CalcLogic(string wlaga)
        {
            this.wlaga = wlaga;
        }
        private int rnd()
        {
            Random random = new Random();
            return random.Next(6, 50);
        }
        private int rnddrob4()
        {
            Random random = new Random();
            return random.Next(1154, 9876);
        }
        private int rnddrob3()
        {
            Random random = new Random();
            return random.Next(333, 987);

        }
        public string logic()
        {
            
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
            };
            
            double m_naweski = 20.0 + (rnd() * 0.0001);  // 20,0023 m'
            double m_naweski2 = 20.0 + (rnd() * 0.0001);  //20,0023 m"

            double m_setki = 86.0 + (rnddrob4() * 0.0001);  // 86.5987 m'
            double m_setki2 = 86.0 + (rnddrob4() * 0.0001); // 86.5987 m"

            double m_naweski_suh = 5.0 + (rnd() * 0.0001);     // 5.0034 m'
            double m_naweski_suh2 = 5.0 + (rnd() * 0.0001);  //5.0027  m"

            double m_bux = 18.0 + (rnddrob4() * 0.0001);  // 18.5987 m'
            double m_bux2 = 18.0 + (rnddrob4() * 0.0001); // 18.5987 m"

            double m_result = 4.5 + (rnddrob3() * 0.0001);  // 4.5987 m'
            double m_result2 = 4.5 + (rnddrob3() * 0.0001); // 4.5987 m"



            double wlaga = double.Parse(this.wlaga, numberFormatInfo); // парсим влагу
            var random = new Random();

            int drob_wlaga1 = 5 - random.Next(9);
            int drob_wlaga2 = 5 - random.Next(9);

            if (drob_wlaga1 == drob_wlaga2)
            {
                if (drob_wlaga2 == 5)
                {
                    drob_wlaga2 += 2;
                }
                if (drob_wlaga2 == -4)
                {
                    drob_wlaga2 += 2;
                }
            }

            double wlaga1 = wlaga - ((drob_wlaga1) * 0.01);
            double wlaga2 = wlaga - ((drob_wlaga2) * 0.01);

            if (wlaga1 == wlaga2)
                wlaga2 += 0.01;
            
                

            



            double m_strih = (100 - wlaga1) / m_result;
            double m_strih2 = (100 - wlaga2) / m_result2;

            double m_setki_suh = m_naweski - m_setki - m_strih;
            double m_setki_suh2 = m_naweski2 - m_setki2 - m_strih2;

            double m_bux_suh = m_naweski_suh - m_bux - m_result;
            double m_bux_suh2 = m_naweski_suh2 - m_bux2 - m_result2;
            
          
           string l1 = ("m1\' =  " + string.Format("{0:0.0000}", m_naweski) + " -(" + string.Format("{0:0.0000}", m_setki) + " " + string.Format("{0:0.0000}", Math.Round(m_setki_suh, 4)) + ") = " + string.Format("{0:0.0000}", Math.Round(m_strih, 4)));
           string l2 = ("m2\" = " + string.Format("{0:0.0000}", m_naweski2) + " -(" + string.Format("{0:0.0000}", m_setki2) + "" + string.Format("{0:0.0000}", Math.Round(m_setki_suh2, 4)) + ") = " + string.Format("{0:0.0000}", Math.Round(m_strih2, 4)));

           string l3 = ("m1\' =  " + string.Format("{0:0.0000}", m_naweski_suh) + " -(" + string.Format("{0:0.0000}", m_bux) + string.Format("{0:0.0000}", Math.Round(m_bux_suh, 4)) + ") = " + string.Format("{0:0.0000}", m_result));
           string l4 = ("m2\" = " + string.Format("{0:0.0000}", m_naweski_suh2) + " -(" + string.Format("{0:0.0000}", m_bux2) + string.Format("{0:0.0000}", Math.Round(m_bux_suh2, 4)) + ") = " + string.Format("{0:0.0000}", m_result2));

           string l5 = ("W1 =  " + 100 + " - " + string.Format("{0:0.0000}", Math.Round(m_strih, 4)) + " * " + string.Format("{0:0.0000}", m_result) + " = " + string.Format("{0:0.00}", wlaga1));
           string l6 = ("W2 = " + 100 + " - " + string.Format("{0:0.0000}", Math.Round(m_strih2, 4)) + " * " + string.Format("{0:0.0000}", m_result2) + " = " + string.Format("{0:0.00}", wlaga2));

           return (l1 + "\n" + l2 + "\n" + "\n" + l3 + "\n" + l4 + "\n" + "\n" + l5 + "\n" + l6);
        }
       
    }
    
}
