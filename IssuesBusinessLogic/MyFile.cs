using IssuesBusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IssuesBusinessLogic
{
    public static class MyFile
    {
        //static string path = "C://MyFile.txt";
        static string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string deskPathBackup = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string fileName = "MyFile.txt";
        static string fileNameBackup = "MyFileBACKUP.txt";
        static string filePath = Directory.GetCurrentDirectory();
        static string filePathBackup = Directory.GetCurrentDirectory();
        static string filePathFull;
        static string filePathBackupFull;
        //public string fileLocation = @"C:\Users\ianea\source\repos\C8_In4Hours\Tutorial\test.txt";
        //public string fileLocation = $"./";       // = Tutorial\bin\Debug\netcoreapp3.1\test.txt
        //public string fileLocation = $"../";      // = Tutorial\bin\Debug\test.txt
        //public string fileLocation = $"../../";   // = Tutorial\bin\test.txt
        //public string fileLocation = $"../../../";// = Tutorial\test.txt
        //if(File.Exist("./test.txt))

        static MyFile()
        {
            SetPath();
            Debug.WriteLine($"Const - filePath: {filePath}");
        }
        public static void SetPath()
        {
            // Change 
            //C:\Users\ianea\source\repos\C8_In4Hours\IssueTrackerApp\bin\Debug
            // Into
            //C:\Users\ianea\source\repos\C8_In4Hours\IssueTrackerApp
            // Then into
            //C:\Users\ianea\source\repos\C8_In4Hours\IssueTrackerApp\MyFile.txt
            try
            {
                filePath.Substring(filePath.Length - 10);
                //filePathBackup = filePath;
                filePathBackup.Substring(filePathBackup.Length - 10);
                filePathFull = filePath + "\\" + fileName;
                filePathBackupFull = filePath + "\\" + fileNameBackup;
                return;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
                //throw;
            }
            try
            {
                //deskPath += "\\" + fileName;
                //filePath = deskPath;
                //deskPathBackup += "\\" + fileNameBackup;
                //filePathBackup = deskPathBackup;

                filePathFull = deskPath + "\\" + fileName;
                filePathBackupFull = deskPathBackup + "\\" + fileNameBackup;
                return;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
                //throw;
            }

            Debug.WriteLine($"filePath: {filePath}");
        }

        //	System.io
        //	WriteToFile (line)
        //	Update and UpdateChanges (only update changes)
        // Save issues (as xml?)
        //public static void Save(String data) // IssueBase
        //{
        //    StreamWriter myFile = new StreamWriter(filePath);
        //    myFile.WriteLine(data);
        //    myFile.Close();
        //    myFile.Dispose();
        //}
        //	ReadFromFile 
        //public static string Load() // IssueBase?
        //{
        //    StreamReader myFile = new StreamReader(filePath);
        //    string data = myFile.ReadLine();
        //    myFile.Close();
        //    myFile.Dispose();
        //    Debug.WriteLine($"Load DATA: {data}");
        //    return data;
        //}
        public static void Save(List<IssueBase> allIssues) // IssueBase
        {
            SetPath();
            Debug.WriteLine("Save");

            List<String> allIssuesSAVE = new List<string>();

            // use seperators "," or XML
            foreach (IssueBase issue in allIssues)
            {
                allIssuesSAVE.Add(  $"{issueProp[0]}: {issue.IssueID} \t" +
                                    $"{issueProp[1]}: {issue.IssueTitle} \t" +
                                    $"{issueProp[2]}: {issue.IssueDescription} \t" +
                                    $"{issueProp[3]}: {issue.IssuePriority} \t" +
                                    $"{issueProp[4]}: {issue.IssueStatus} \t" +
                                    $"{issueProp[5]}: {issue.isIssueResolved} \t");
            }

            File.WriteAllLines(filePathFull, allIssuesSAVE);
        }
        //	ReadFromFile 
        public static List<IssueBase> Load()
        {
            SetPath();
            Debug.WriteLine("Load");
            List<IssueBase> allIssues = new List<IssueBase>();

            string[] myArray = File.ReadAllLines(filePathFull);
            foreach (var line in myArray)
            {
                int startAdd = 3;
                int endRemove = 1;
                int IDStart = line.IndexOf(issueProp[0]) + issueProp[0].Length + 1; // + 2?
                int IDEnd = line.IndexOf(issueProp[1]) - endRemove;
                int IDLength = IDEnd - IDStart;
                
                int TitleStart = line.IndexOf(issueProp[1]) + issueProp[1].Length + 1;
                int TitleEnd = line.IndexOf(issueProp[2]) - endRemove;
                int TitleLength = TitleEnd - TitleStart;
                
                int DescStart = line.IndexOf(issueProp[2]) + issueProp[2].Length + 1;
                int DescEnd = line.IndexOf(issueProp[3]) - endRemove;
                int DescLength = DescEnd - DescStart;

                int PrioStart = line.IndexOf(issueProp[3]) + issueProp[3].Length + 1;
                int PrioEnd = line.IndexOf(issueProp[4]) - endRemove;
                int PrioLength = PrioEnd - PrioStart;

                int StatusStart = line.IndexOf(issueProp[4]) + issueProp[4].Length + 1;
                int StatusEnd = line.IndexOf(issueProp[5]) - endRemove;
                int StatusLength = StatusEnd - StatusStart;

                int IsResStart = line.IndexOf(issueProp[5]) + issueProp[5].Length + 1;
                int IsResLength = line.Length - IsResStart;


                int issueID = int.Parse(line.Substring(IDStart, IDLength));
                string issueTitle = line.Substring(TitleStart, TitleLength);
                string issueDescription = line.Substring(DescStart, DescLength);
                issueTitle = issueTitle.Trim();
                issueDescription = issueDescription.Trim();
                Priority issuePriority = (Priority)Enum.Parse(typeof(Priority), line.Substring(PrioStart, PrioLength));
                Status issueStatus = (Status)Enum.Parse(typeof(Status), line.Substring(StatusStart, StatusLength));
                bool isissueResolved = Boolean.Parse(line.Substring(IsResStart, IsResLength));

                IssueBase newIssue = new EngineeringIssue()
                {
                    IssueID = issueID,
                    IssueTitle = issueTitle,
                    IssueDescription = issueDescription,
                    IssuePriority = issuePriority,
                    IssueStatus = issueStatus,
                    isIssueResolved = isissueResolved,

                };

                allIssues.Add(newIssue);
                Debug.WriteLine($"Issue Loaded: {newIssue.IssueID}");
            }
            return allIssues;
        }



        //myDataTable.WriteXml("myXmlPath.xml", XmlWriteMode.WriteSchema);
        //myDatatable.ReadXml("myXmlPath.xml");

        //var dataSet = new DataSet();
        //dataSet.AddTable(myDataTable);

        //// Write dataset to xml file or stream
        //dataSet.WriteXml("filename.xml");
        static string[] issueProp = new string[] { "ID", "TITLE", "DESCRIPTION", "PRIORITY", "STATUS", "ISRESOLVED" };
        public static void SaveBackup(List<IssueBase> allIssues) // IssueBase
        {
            SetPath();
            Debug.WriteLine("Save");

            StreamWriter myFile = new StreamWriter(filePathBackupFull);
            //myFile.WriteLine(data);
            // use seperators "," or XML
            foreach (IssueBase issue in allIssues)//ds.Tables[0].Rows)
            {
                myFile.Write($"{issueProp[0]}: {issue.IssueID} \t");
                myFile.Write($"{issueProp[1]}: {issue.IssueTitle} \t");
                myFile.Write($"{issueProp[2]}: {issue.IssueDescription} \t");
                myFile.Write($"{issueProp[3]}: {issue.IssuePriority} \t");
                myFile.Write($"{issueProp[4]}: {issue.IssueStatus} \t");
                myFile.Write($"{issueProp[5]}: {issue.isIssueResolved} \t");
                myFile.WriteLine();
                //foreach (var item in issue.)
                //{
                //    myStreamWriter.Write((string)item + "\t");
                //}
                //myStreamWriter.WriteLine();
            }

            
            myFile.Close();
            myFile.Dispose();
            //File.WriteAllText(filePathBackup, myFile.ToString());
        }
        //	ReadFromFile 
        public static List<IssueBase> LoadBackup() // IssueBase?
        {
            SetPath();
            Debug.WriteLine("Load");
            //StreamReader myFile = new StreamReader(filePathBackup);
            //foreach (string line in myFile)//ds.Tables[0].Rows)
            //{

            //}
            List<IssueBase> allIssues = new List<IssueBase>();
            //myFile.ReadLine();
            //System.Collections.Generic.IEnumerable<String> lines = File.ReadLines("c:\\file.txt");    
            string[] myArray = File.ReadAllLines(filePathBackupFull);//.Length;
            foreach (var line in myArray)//ds.Tables[0].Rows)
            {
                // On each line (issue)
                // Set index, start and end point of each element of issue (ID, Title)
                // Add new "engineering" issue to issue list
                // Move into own Method?
                int startAdd = 3;
                int endRemove = 1;
                int IDStart = line.IndexOf(issueProp[0]) + issueProp[0].Length + 1; // + 2?
                int IDEnd = line.IndexOf(issueProp[1]) - endRemove;
                int IDLength = IDEnd - IDStart;

                int TitleStart = line.IndexOf(issueProp[1]) + issueProp[1].Length + 1;
                int TitleEnd = line.IndexOf(issueProp[2]) - endRemove;
                int TitleLength = TitleEnd - TitleStart;

                int DescStart = line.IndexOf(issueProp[2]) + issueProp[2].Length + 1;
                int DescEnd = line.IndexOf(issueProp[3]) - endRemove;
                int DescLength = DescEnd - DescStart;

                int PrioStart = line.IndexOf(issueProp[3]) + issueProp[3].Length+1;//startAdd;
                int PrioEnd = line.IndexOf(issueProp[4]) - endRemove;
                int PrioLength= PrioEnd - PrioStart;

                int StatusStart = line.IndexOf(issueProp[4]) + issueProp[4].Length + 1;//startAdd;
                int StatusEnd = line.IndexOf(issueProp[5]) - endRemove;
                int StatusLength = StatusEnd - StatusStart;

                int IsResStart = line.IndexOf(issueProp[5]) + issueProp[5].Length + 1;
                //int IsResEnd = line.IndexOf(issueProp[5]) - endRemove;
                int IsResLength = line.Length - IsResStart;


                int issueID = int.Parse(line.Substring(IDStart, IDLength));
                string issueTitle = line.Substring(TitleStart, TitleLength);
                string issueDescription = line.Substring(DescStart, DescLength);
                Priority issuePriority = (Priority) Enum.Parse(typeof(Priority), line.Substring(PrioStart, PrioLength)); // Prioirty type?
                Status issueStatus = (Status)Enum.Parse(typeof(Status), line.Substring(StatusStart, StatusLength)); // Status type?
                bool isissueResolved = Boolean.Parse(line.Substring(IsResStart, IsResLength));

                // IssueID = 101
                // line = ID: 101   \tTITLE: mytitle    \t...
                //line.IndexOf("\t")
                //IssueDescription = line.IndexOf(issueProp[1]) // + 3 until \t


                //IssueBase newIssue = new IssueBase();
                IssueBase newIssue = new EngineeringIssue()
                {
                    //IssueID = int.Parse(line.Substring((line.IndexOf(issueProp[0]) + 3), (line.IndexOf(issueProp[1]) - 1))), // + 3 until \t
                    IssueID = issueID,
                    IssueTitle = issueTitle,
                    IssueDescription = issueDescription,
                    IssuePriority = issuePriority,
                    IssueStatus = issueStatus,
                    isIssueResolved = isissueResolved,
                    
                };
                
                allIssues.Add(newIssue);
                
                Debug.WriteLine($"Issue Loaded: {newIssue.IssueID}");
            }
            //Debug.WriteLine($"Load DATA: ID0 = {allIssues[0].IssueID}");
            return allIssues;
        }

        //IssueID = 101,
        //IssueTitle = "Browser Issue for Web portal",
        //IssueDescription = "User is unable to load web site on IE.",
        //IssuePriority = Priority.P3,
        //IssueStatus = Status.Verified
        //myFile.Write($"ID: {issue.IssueID} \t");
        //myFile.Write($"TITLE: {issue.IssueTitle} \t");
        //myFile.Write($"DESCRIPTION: {issue.IssueDescription} \t");
        //myFile.Write($"PRIORITY: {issue.IssuePriority} \t");
        //myFile.Write($"STATUS: {issue.IssueStatus} \t");
        //myFile.Write($"ISRESOLVED: {issue.isIssueResolved} \t");

        public static void Save2()
        {
            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "WriteLines.txt")))
            {
                //foreach (string line in lines)
                //    outputFile.WriteLine(line);
            }

        }
        public static void Load2()
        {
            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "WriteLines.txt"), true))
            {
                outputFile.WriteLine("Fourth Line");
            }

            //File.WriteAllText(Path.Combine(docPath, "WriteFile.txt"), text);
        }
    }
}
