using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cars
{
    public partial class CarQuery : Page
    {
        protected override void OnPreRenderComplete(EventArgs e)
        {
            base.OnPreRenderComplete(e);
            if (!this.IsPostBack)
            {
                this.radListEngine.DataSource =
                    new Engine[] { Engine.Diesel, Engine.Electric, Engine.Gasoline, Engine.Hybrid };

                this.dropProducer.DataSource = new Data().GetProducers();
                // this.dropProducer.DataBind();
                this.dropProducer.Items.Insert(0, new ListItem("All", "---"));
            }

            this.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected ICollection<CarModel> GetModelsFromProducer(string name)
        {
            List<CarModel> result = new List<CarModel>() { new CarModel() { Name = "All" } };
            Producer prod = new Data().GetProducers().FirstOrDefault(c => c.Name == name);
            if (prod == null)
            {
                return result;
            }

            foreach (CarModel model in prod.Models)
            {
                result.Add(model);
            }

            return result; 
        }

        protected void FilterCars_Click(object sender, EventArgs e)
        {
            IEnumerable<Car> results = Enumerable.Empty<Car>();
            ICollection<Car> cars = new Data().ProvideCars();

            ListItem radioBtnEngine = this.radListEngine.SelectedItem;
            if (radioBtnEngine != null)
            {
                results = cars
                    .Where(c => c.Engine.ToString() == radioBtnEngine.Text);
            }
            else
            {
                results = cars;
            }

            StringBuilder textResult = new StringBuilder();

            string producer = this.dropProducer.SelectedItem.Text;
            if (producer == "All")
            {
                foreach (Car car in results)
                {
                    textResult.AppendLine(car.ToString());
                }

                this.literal.Text = textResult.ToString();
                return;
            }

            string model = this.dropModel.SelectedItem.Text;
            results = (model == "All") ?
                results.Where(c => c.Producer.Name == producer) :
                results.Where(c => c.Producer.Name == producer && c.Model.Name == model);
            
            results
                .ToList()
                .ForEach(c => textResult.AppendLine(c.ToString()));

            this.literal.Text = results.Count() == 0 ? "No data on this criteria!" : textResult.ToString();
        }
    }
}