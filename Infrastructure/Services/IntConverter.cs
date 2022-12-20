using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Services
{
    public class IntConverter
    {
      static public int ConvertToInt(string priceText)
        {
            string result = new String(priceText.Where(Char.IsDigit).ToArray());
            return Convert.ToInt32(result);
        }
    }
}
