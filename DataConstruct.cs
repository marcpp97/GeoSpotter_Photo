using System.Runtime.Serialization;

[DataContract]
public class Address
{
    [DataMember]
    public string village { get; set; }
    [DataMember]
    public string county { get; set; }
    [DataMember]
    public string city { get; set; }
    [DataMember]
    public string state { get; set; }
    [DataMember]
    public string country { get; set; }
}

[DataContract]
public class RootObject
{
    [DataMember]
    public string lat { get; set; }
    [DataMember]
    public string lon { get; set; }
    [DataMember]
    public string display_name { get; set; }
    [DataMember]
    public Address address { get; set; }
    [DataMember]
    public string error { get; set; }
}