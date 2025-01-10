namespace CsvDatabase.Models
{
    public class Record
    {

            public int RecordId { get; set; }
            public string? Name { get; set; } = string.Empty; 
            public DateTime BirthDay { get; set; }
            public bool Married { get; set; }
            public string? PhoneNum { get; set; } = string.Empty;
            public decimal Salary { get; set; }
        }

    }


