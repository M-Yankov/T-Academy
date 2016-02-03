using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BitCalculator.Models;

namespace _02.BitCalculator.Controllers
{
    public class HomeController : Controller
    {
        private Size[] sizes = new Size[] { Size.Byte, Size.KByte, Size.MByte, Size.GByte };
        private const double DefaultValueCalculation = 1024.0;
        private const int BitByteDifferance = 8;

        public ActionResult Index(BitsModel bits)
        {
            if (bits.Value != 0)
            {
                bits.Result = this.MakeResults(bits);
            }

            return View(bits);
        }

        private IDictionary<string, string> MakeResults(BitsModel bit)
        {
            int index = Array.IndexOf(this.sizes, bit.TypeSize);
            double[] result = new double[this.sizes.Length];
            result[index] = bit.Value;
            this.CalculateToLeft(result, index - 1);
            this.CalculateToRight(result, index + 1);

            IDictionary<string, string> pairs = new Dictionary<string, string>();

            for (int i = 0; i < result.Length; i++)
            {
                string keyByte = this.sizes[i].ToString();
                string keyBit = keyByte.Replace("Byte", "bit");

                string valueByte = result[i].ToString();
                string valuebite = (result[i] * BitByteDifferance).ToString();

                pairs[keyBit] = valuebite;
                pairs[keyByte] = valueByte;
            }

            return pairs;
        }

        private void CalculateToLeft(double[] result, int startIndex)
        {
            for (int i = startIndex; i >= 0; i--)
            {
                result[i] = (result[i + 1] * DefaultValueCalculation);
            }
        }

        private void CalculateToRight(double[] result, int startIndex)
        {
            for (int i = startIndex; i < result.Length; i++)
            {
                result[i] = (result[i - 1] / DefaultValueCalculation);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}