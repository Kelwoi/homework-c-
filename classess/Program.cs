class Web_site
{

    public string site_name { get; set; }
    public string site_url { get; set; }
    public string site_description { get; set; }
    public string site_ip { get; set; }
    public Web_site(string site_name, string site_url, string site_description, string ip)
    {
        this.site_name = site_name;
        this.site_url = site_url;
        this.site_description = site_description;
        this.site_ip = ip;
    }
    public void get_name()
    {
        Console.WriteLine(site_name);
    }
    public void get_url()
    {
        Console.WriteLine(site_url);
    }
    public void get_description()
    {
        Console.WriteLine(site_description);
    }
    public void get_ip()
    {
        Console.WriteLine(site_ip);
    }
    public void set_name(string name)
    {
        this.site_name = name;
    }
    public void set_url(string url)
    {
        this.site_url = url;
    }
    public void set_description(string description)
    {
        this.site_description = description;
    }
    public void set_ip(string ip)
    {
        this.site_ip = ip;
    }
    public void Print()
    {
        Console.WriteLine($"Site:: {site_name}\nUrl:: {site_url}\nDescription:: {site_description}\nIp:: {site_ip}");
    }
}
class Magazine
{
    public string name;
    public int start_year;
    public string description;
    public int phone_number;
    public string email;
    public Magazine(string name, int start_year, string description, int phone_number, string email)
    {
        this.name = name;
        this.start_year = start_year;
        this.description = description;
        this.phone_number = phone_number;
        this.email = email;
    }
    public void print()
    {
        Console.WriteLine($"Magazine:: {name}\nStarted:: {start_year}\nDescription:: {description}\nPhone number:: {phone_number}\nEmail:: {email}");
    }
    public void Get_name()
    {
        Console.WriteLine(name);
    }
    public void Get_start_year()
    {
        Console.WriteLine(start_year);
    }

    public void Get_description()
    {
        Console.WriteLine(description);
    }
    public void Get_phone_number()
    {
        Console.WriteLine(phone_number);
    }
    public void Get_email()
    {
        Console.WriteLine(email);
    }
    public void Set_name(string name)
    {
        this.name=name;
    }
    public void Set_start_year(int start_year)
    {
        this.start_year=start_year;
    }
    public void Set_description(string description)
    {
        this.description=description;
    }
    public void Set_phone_number(int phone_number)
    {
        this.phone_number=phone_number;
    }
    public void Set_email(string email)
    {
        this.email=email;
    }
}

    internal class Program
{
    private static void Main(string[] args)
    {
        Web_site web_site = new Web_site("Youtube", "YouTube.com", "Funny videos", "192.234.25");
        web_site.Print();
    }
}