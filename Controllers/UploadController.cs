using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvDatabase.Models;
using System;
using CsvDatabase.Data;
using Microsoft.EntityFrameworkCore;

public class RecordsController : Controller
{
    private readonly ApplicationDbContext _context;

    public RecordsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            ModelState.AddModelError("", "Seems like there is no file.");
            return View();
        }

        using (var stream = new StreamReader(file.OpenReadStream(), Encoding.UTF8))
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true 
            };

            using (var csv = new CsvReader(stream, config))
            {
                try
                {
                    // check if the columsn are OK
                    csv.Read();
                    csv.ReadHeader();
                    var header = csv.HeaderRecord;


                    var requiredColumns = new[] { "name", "birthday", "married", "phonenum", "salary" };
                    if (!requiredColumns.All(c => header.Contains(c, StringComparer.OrdinalIgnoreCase)))
                    {
                        ModelState.AddModelError("", "Columns are not matching required.");
                        return View();
                    }

                    var records = new List<Record>();

                    // check the records - "read" values
                    while (csv.Read())
                    {
                        var record = new Record
                        {
                            Name = csv.GetField<string>("name"),
                            BirthDay = csv.GetField<DateTime>("birthday"),
                            Married = csv.GetField<bool>("married"),
                            PhoneNum = csv.GetField<string>("phonenum"),
                            Salary = csv.GetField<decimal>("salary")
                        };

                        // raise the error if file is empty (values)
                        if (string.IsNullOrWhiteSpace(record.Name) ||
                            string.IsNullOrWhiteSpace(record.PhoneNum) ||
                            record.BirthDay == default ||
                            record.Salary <= 0)
                        {
                            ModelState.AddModelError("", "The file's values are empty or invalid.");
                            return View();
                        }

                        records.Add(record);
                    }

                    _context.Record.AddRange(records);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error processing file: {ex.Message}");
                    return View();
                }
            }
        }
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var records = await _context.Record.ToListAsync();
        return View(records); 
    }
}
