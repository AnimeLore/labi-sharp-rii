using System;

public class PostalAddress
{
    public string OrganizationName { get; private set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }

    public PostalAddress(string organizationName)
    {
        OrganizationName = organizationName;
    }

    public PostalAddress(string organizationName, string address)
    {
        OrganizationName = organizationName;
        Address = address;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Organization: {OrganizationName}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"City: {City}");
        Console.WriteLine($"Street: {Street}");
        Console.WriteLine($"Postal Code: {PostalCode}");
    }

    public bool IsInCity(string city)
    {
        return City.Equals(city, StringComparison.OrdinalIgnoreCase);
    }
}

class Program
{
    static void Main()
    {
        PostalAddress address1 = new PostalAddress("Tech Corp");
        PostalAddress address2 = new PostalAddress("Innovate Ltd", "1234 Elm Street");

        address1.City = "New York";
        address1.Street = "5th Avenue";
        address1.PostalCode = "10001";

        address2.City = "Los Angeles";
        address2.Street = "Sunset Blvd";
        address2.PostalCode = "90001";

        address1.DisplayInfo();
        Console.WriteLine();
        address2.DisplayInfo();

        Console.WriteLine();
        Console.WriteLine($"Is Tech Corp in New York? {address1.IsInCity("New York")}");
        Console.WriteLine($"Is Innovate Ltd in New York? {address2.IsInCity("New York")}");
    }
}
