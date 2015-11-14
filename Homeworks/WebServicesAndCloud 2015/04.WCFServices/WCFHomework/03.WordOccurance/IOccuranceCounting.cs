namespace WordOccurance
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IOccuranceCounting
    {
        [OperationContract]
        int Occurances(string searchTerm, string text);
    
        [OperationContract]
        Person GetPerson();
    }
}
