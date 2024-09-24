using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Helpers
{
    public class Converter   //$100 -> 100, €100 -> 99, ₪100 -> 29
    {
        public static string ConvertFromStringWithComma(string textWithComma)  //"11,13" -> "11.13"
        {
            string temp = "";
            for (int i = 0; i < textWithComma.Length; i++)
            {
                if (textWithComma[i] == ',')
                {
                    temp += '.';
                }
                else
                {
                    temp += textWithComma[i];
                }
            }
            return temp;  
        }

        public double Convert(string price)
        {
            double num_price;
            string price_without_symbol = price.Remove(0, 1);
            num_price = Double.Parse(price_without_symbol);

            switch (price[0])
            {
                case '$':
                    {
                        break;
                    }
                case '₪':
                    {
                        num_price = 0.29 * num_price;
                        break;
                    }
                case '€':
                    {
                        num_price = 0.99 * num_price;
                        break;
                    }


                default:
                    {

                        break;
                    }

            }

            return num_price;
        }
    }
}



