using System.Collections.Generic;

namespace Address.Objects
{
  public class Contact
  {
    private string _firstName;
    private string _lastName;
    private string _number;
    private string _address;
    private string _city;
    private string _state;
    private string _zip;
    private int _id;
    private static List<Contact> _instances = new List<Contact> {};

    public Contact (string firstName, string lastName, string number, string address, string city, string state, string zip)
    {
      _firstName = firstName;
      _lastName = lastName;
      _number = number;
      _address = address;
      _city = city;
      _state = state;
      _zip = zip;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetFirst()
    {
      return _firstName;
    }
    public string GetLast()
    {
      return _lastName;
    }
    public string GetNumber()
    {
      return _number;
    }
    public string GetAddress()
    {
      return _address;
    }
    public string GetCity()
    {
      return _city;
    }
    public string GetState()
    {
      return _state;
    }
    public string GetZip()
    {
      return _zip;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
        _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId -1];
    }
  }
}
