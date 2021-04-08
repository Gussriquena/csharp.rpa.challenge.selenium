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

        public List<Person> loadExcelData()
        {
            string[] excelPath = Directory.GetFiles(constants.ChallengeConstants.PATH_INPUT_EXCEL, "*.xlsx");

            List<Person> personList = new List<Person>();

            WorkBook workbook = WorkBook.Load(excelPath[0]);
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

            return personList;
        }
    }
}
