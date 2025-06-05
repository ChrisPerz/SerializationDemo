using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Person
{
    public string UserName { get; set; }
    public int UserAge { get; set; }
}

public class Program{
    public static void Main(string[] args){
        Person testPerson = new Person{
            UserName = "John Doe",
            UserAge = 30
        };

        using( FileStream fs = new FileStream("person.dat", FileMode.Create))
        {
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(testPerson.UserName);
            writer.Write(testPerson.UserAge);
            Console.WriteLine("Finished Serialization to binary");
        }   
        
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
        using( StreamWriter streamWriter = new StreamWriter("person.xml"))
        {
            xmlSerializer.Serialize(streamWriter, testPerson);
            Console.WriteLine("Finished Serialization to XML");
        }

        using( FileStream fs = new FileStream("person.json", FileMode.Create))
        {
            JsonSerializer.Serialize(fs, testPerson);
            Console.WriteLine("Finished Serialization to JSON");
        }
        
        // string jsonString = JsonSerializer.Serialize(samplePerson);

        // File.WriteAllText("person.json", jsonString);

        // Console.WriteLine("JSON serialization complete.");
    }
}
