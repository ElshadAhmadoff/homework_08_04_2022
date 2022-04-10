using homework_08_04_2022;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace homework_08_04_2022
{
    class Program
    {
        static void Main(string[] args)                                     
        {
            HttpClient httpClient = new HttpClient();
            Console.WriteLine("tarixi daxil edin:");
            string str1 = Console.ReadLine();
            string jsonStr = httpClient.GetStringAsync("https://www.cbar.az/currencies/"+str1+".xml").Result;
            StringReader stringReader = new StringReader(jsonStr);
            XmlSerializer xml = new XmlSerializer(typeof(ValCurs));
            ValCurs valCurs = (ValCurs)xml.Deserialize(stringReader);
            string str = JsonConvert.SerializeObject(valCurs);
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\Elshad\source\repos\homework_08_04_2022\homework_08_04_2022\jsconfig1.json");
            streamWriter.Write(str);
            streamWriter.Close();
            

        }

    }
}

