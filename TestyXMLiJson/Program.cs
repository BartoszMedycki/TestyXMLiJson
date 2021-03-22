using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace TestyXMLiJson
{
    class Program
    {
        static void Main(string[] args)
        {
            // xml
            human czlowiek = new human("Bartosz","Medycki",22);
            StreamWriter wr = new StreamWriter("plikXmlTest.xml");
            XmlSerializer xml = new XmlSerializer(typeof(human));
            xml.Serialize(wr, czlowiek);
            wr.Flush();
            wr.Close();
            

            StreamReader read = new StreamReader("plikXmlTest.xml");
            human c = (human)xml.Deserialize(read);
            Console.WriteLine("XML : " + c);
         
            // json

            string test = JsonConvert.SerializeObject(czlowiek);
            File.WriteAllText(@"C:\Users\barme\OneDrive\Pulpit\Nowy folder\TestyXmliJson", test);

            string testRead = File.ReadAllText(@"C:\Users\barme\OneDrive\Pulpit\Nowy folder\TestyXmliJson");
            human SerializedHuman = JsonConvert.DeserializeObject<human>(testRead);
            Console.WriteLine("Json : "+SerializedHuman);
            Console.ReadLine();

        }
    }
}
public class human
{
    public String name;

 
    public int age { get; set; }
    public String Surename { get; set; }

    public human(String name, string surename, int age)
    {
        this.age = age;
        this.name = name;
        this.Surename = surename;
    
    }
    public human()
    { }

    public override string ToString()
    {
        return "imie : " + name + " Nazwisko : " + Surename +" wiek " + age ;
    }
}