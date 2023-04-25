using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CalculatorCorn
{
    public class DbCalculation
    {
        private static string[] DbCalc = new string[30];
        public int DbLength = DbCalc.Length;
        public void DbCreate(string data)
        {
            for (int i = 0; i < DbCalc.Length; i++)
            {
                if (DbCalc[i] == null)
                {
                    DbCalc[i] = data;
                    break;
                }
            }
        }
        public string DbRead(int index)
        {
            return DbCalc[index];
        }
        public void DbAllDelete()
        {
            for (int i = 0; i < DbCalc.Length; i++)
                DbCalc[i] = null;
        }
        public void DbDelete(int index)
        {
            DbCalc[index] = null;
        }
    }
}
