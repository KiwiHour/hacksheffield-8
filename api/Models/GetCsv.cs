using System.ComponentModel;

namespace HackSheffield.Models;

public class GetCsv
{
    public static List<CsvData> get()
    {
        List<CsvData> listA = new List<CsvData>();
        using(var reader = new StreamReader(@"custData.csv"))
        {
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                
                if (values[0] == "793")
                {
                    CsvData vcd = new CsvData();
                    vcd.dt = DateTime.Parse(values[1]);
                    vcd.wattage = Double.Parse(values[2]);
                    listA.Add(vcd);
                }
                
            }
            
        }

        return listA;
    }
}

public class CsvData
{
    public DateTime dt{ get; set; }
    public double wattage{ get; set; }
}