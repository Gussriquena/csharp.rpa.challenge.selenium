using csharp.rpa.challenge.selenium.constants;
using csharp.rpa.challenge.selenium.model;
using IronXL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace csharp.rpa.challenge.selenium.controller
{
    class ExcelController
    {
        // ironsoftware.com/csharp/excel/examples/read-xlsx-file

        private string fileExtension = ChallengeConstants.FILE_EXTENSION;

        public List<Person> loadExcelData()
        {
            string[] excelPath = Directory.GetFiles(ChallengeConstants.PATH_INPUT_EXCEL, "*" + fileExtension);
            string inputFile = excelPath[0];

            List<Person> personList = new List<Person>();

            WorkBook workbook = WorkBook.Load(inputFile);
            WorkSheet sheet = workbook.DefaultWorkSheet;

            string currentCell = "A1";
            for (var counter = 2; currentCell.Length != 0; counter++)
            {
                currentCell = sheet["A" + counter + ""].StringValue;

                if (currentCell.Length != 0)
                {
                    Person person = new Person();

                    person.firstName = sheet["A" + counter + ""].StringValue;
                    person.lastName = sheet["B" + counter + ""].StringValue;
                    person.companyName = sheet["C" + counter + ""].StringValue;
                    person.roleInCompany = sheet["D" + counter + ""].StringValue;
                    person.address = sheet["E" + counter + ""].StringValue;
                    person.email = sheet["F" + counter + ""].StringValue;
                    person.phoneNumber = sheet["G" + counter + ""].StringValue;

                    personList.Add(person);
                }
            }

            workbook.Close();
            string processingPath = ChallengeConstants.PATH_PROCESSING_EXCEL + @"\" + ChallengeConstants.FILE_NAME + fileExtension;
            File.Move(inputFile, processingPath);

            return personList;
        }

        public void writeExcel(List<Person> personList)
        {
            string fileName = @"\" + ChallengeConstants.FILE_NAME + fileExtension;
            string processingPath = ChallengeConstants.PATH_PROCESSING_EXCEL + fileName;

            WorkBook workbook = WorkBook.Load(processingPath);
            WorkSheet sheet = workbook.DefaultWorkSheet;

            int counter = 2;
            foreach (var person in personList)
            {
                sheet["A" + counter + ""].Value = person.firstName;
                sheet["B" + counter + ""].Value = person.lastName;
                sheet["C" + counter + ""].Value = person.companyName;
                sheet["C" + counter + ""].Value = person.companyName;
                sheet["D" + counter + ""].Value = person.roleInCompany;
                sheet["E" + counter + ""].Value = person.address;
                sheet["F" + counter + ""].Value = person.email;
                sheet["G" + counter + ""].Value = person.phoneNumber;
                sheet["H" + counter + ""].Value = person.isProcessed.ToString();

                counter++;
            }

            workbook.SaveAs(ChallengeConstants.PATH_PROCESSING_EXCEL + fileName);
            workbook.Close();

            string completeFileName = fileName.Replace(ChallengeConstants.FILE_NAME, ChallengeConstants.FILE_NAME 
                + "_" 
                +  DateTime.Now.ToString("yyyMMdd_HHmmss"));

            File.Move(processingPath, ChallengeConstants.PATH_OUTPUT_EXCEL + completeFileName);

        }
    }
}
