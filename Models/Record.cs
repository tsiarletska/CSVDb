namespace CsvDatabase.Models
{
    public class Record
    {

            public int RecordId { get; set; }
            public string? Name { get; set; } = string.Empty; // Ensure Name is not null
            public DateTime BirthDay { get; set; }
            public bool Married { get; set; }
            public string? PhoneNum { get; set; } = string.Empty; // Ensure PhoneNum is not null
            public decimal Salary { get; set; }
        }

    }


