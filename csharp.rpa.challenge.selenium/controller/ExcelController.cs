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
        public string resultMessage { get; set; }

        public List<Person> LoadExcelData()
        {
            List<Person> personList = new List<Person>();
            string[] files = Directory.GetFiles(ChallengeConstants.PATH_INPUT_EXCEL, "*" + fileExtension);

            if (files.Length != 0)
            {
                string inputFile = files[0];

                WorkBook workbook = WorkBook.Load(inputFile);
                WorkSheet sheet = workbook.DefaultWorkSheet;

                string currentCell = "A1";
                for (int counter = 2; currentCell.Length != 0; counter++)
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
                //verificar e remover arquivo se existir
                File.Move(inputFile, processingPath);
            }

            return personList;
        }

        public void WriteExcel(List<Person> personList)
        {
            string fullFileName = @"\" + ChallengeConstants.FILE_NAME + fileExtension;
            string fullProcessingPath = ChallengeConstants.PATH_PROCESSING_EXCEL + fullFileName;

            WorkBook workbook = WorkBook.Load(fullProcessingPath);
            WorkSheet sheet = workbook.DefaultWorkSheet;

            int counter = 2;
            foreach (Person person in personList)
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

            sheet["A" + counter + ""].Value = resultMessage;

            workbook.SaveAs(ChallengeConstants.PATH_PROCESSING_EXCEL + fullFileName);
            workbook.Close();

            string completeFileName = fullFileName.Replace(ChallengeConstants.FILE_NAME, ChallengeConstants.FILE_NAME + "_" +  DateTime.Now.ToString("yyyMMdd_HHmmss"));
            File.Move(fullProcessingPath, ChallengeConstants.PATH_OUTPUT_EXCEL + completeFileName);

        }
    }
}
