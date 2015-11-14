namespace DayOfWeek
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeekService
    {
        [OperationContract]
        string DayOfWeekInBulgarian(DateTime date);
    }
}
