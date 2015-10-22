namespace SalesByRegionAndPeriod
{
    using System;

    public class CustomerOrder
    {
        public int EmployeeID { get; set; }

        public string CompanyName { get; set; }

        public DateTime? RequiredDate { get; set; }

        public string ShipRegion { get; set; }
    }
}
