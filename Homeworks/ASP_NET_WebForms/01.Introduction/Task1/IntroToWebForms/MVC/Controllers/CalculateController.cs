namespace MVC.Controllers
{
    using System;
    using System.Web.Mvc;
    using MVC.Models;

    public class CalculateController : Controller
    {
        // Post: /Calculate/Sum
        [HttpPost]
        public ActionResult Sum(CalculateModel modelForCalulte)
        {
            ResultModel resultFromSum = new ResultModel()
            {
                Operator = "+",
                FirstNumber = modelForCalulte.FirstNumber,
                SecondNunmber = modelForCalulte.SecondNumber
            };

            decimal temporarySum;
            try
            {
                temporarySum = modelForCalulte.FirstNumber + modelForCalulte.SecondNumber;
                resultFromSum.Result = temporarySum;
                return View(resultFromSum);
            }
            catch (FormatException ex)
            {
                return View("Error");
            }
        }

        // GET: /Calculate/Form
        public ActionResult Form()
        {
            return View();
        }
    }
}