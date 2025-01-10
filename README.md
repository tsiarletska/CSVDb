ASP.NET projects based on .NET 8.0 with following function: 
1) uploading the csv files (using the CsvHelper)
2) extracting the data from the provided file and storing data in the db

Used: 
   > CsvHelper                                     33.0.1      33.0.1  
   > Microsoft.EntityFrameworkCore                 7.0.2       7.0.2   
   > Microsoft.EntityFrameworkCore.Design          7.0.2       7.0.2   
   > Microsoft.EntityFrameworkCore.Relational      7.0.2       7.0.2   
   > Microsoft.EntityFrameworkCore.Tools           7.0.2       7.0.2   
   > Pomelo.EntityFrameworkCore.MySql              7.0.0       7.0.0   

Problems: 
1) decimal data format appearence ("salary" attribute)
2) date format (csv file must containe the value of the attribute "date" only in format YYYY-MM-DD, otherwise the error is raised).
3) Design :)
