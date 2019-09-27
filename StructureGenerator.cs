using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SeaSharp
{
    class StructureGenerator
    {
        string detectedProjectFileName;

        private void SpawnClassFile(string className, string nameSpace)
        {
            string fname = className + ".cs";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fname))
            {
                file.WriteLine("using System;");
                file.WriteLine("using System.Collections.Generic;");
                file.WriteLine("using System.Linq;");
                file.WriteLine("using System.Text;");
                file.WriteLine("using System.Threading.Tasks;");

                file.WriteLine("");

                file.WriteLine("namespace {0}", nameSpace);
                file.WriteLine("{");
                file.WriteLine("     class {0}",className);
                file.WriteLine("     {");
                file.WriteLine("          public {0}()", className);
                file.WriteLine("          {");
                file.WriteLine("          }");
                file.WriteLine("     }");
                file.WriteLine("}");

            }
        }

        private void SpawnStructureFile(string structureName, string nameSpace)
        {
            string fname = structureName + ".cs";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fname))
            {
                file.WriteLine("using System;");
                file.WriteLine("using System.Collections.Generic;");
                file.WriteLine("using System.Linq;");
                file.WriteLine("using System.Text;");
                file.WriteLine("using System.Threading.Tasks;");

                file.WriteLine("");

                file.WriteLine("namespace {0}", nameSpace);
                file.WriteLine("{");
                file.WriteLine("     struct {0}", structureName);
                file.WriteLine("     {");
                file.WriteLine("          static {0}()", structureName);
                file.WriteLine("          {");
                file.WriteLine("          }");
                file.WriteLine("     }");
                file.WriteLine("}");

            }
        }

        private string GetValueFromString(string inLine)
        {
            string res = "";

            if (inLine.Length > 0)
            {
                bool isHere = false;
                for (int a=0;a<inLine.Length;a++)
                {
                    if ((inLine[a] == '<') && (isHere)) break;
                    if (isHere) res = res + inLine[a];
                    if (inLine[a] == '>') isHere = true;                    
                }
            }

            return res;
        }

        private bool GetProjectName(out string name)
        {
            string fileName = "error";
            bool stat = false;          
            DirectoryInfo folder = new DirectoryInfo(Directory.GetCurrentDirectory());
            if (folder.Exists) // else: Invalid folder!
            {
                FileInfo[] files = folder.GetFiles("*.csproj");

                if (files.Length > 0)
                {
                    fileName = files[0].FullName;
                    stat = true;
                }
            }
            else Console.WriteLine("Error: Unable to find any C# project (*.CSPROJ) file!");
            name = fileName;
            detectedProjectFileName = Path.GetFileName(fileName);

            return stat;
        }

        private bool UpdateProjectFile(string name, out string nameSpaceName)
        {
            string nsName = "error";    // NameSpace name
            bool status = false;
            string projectFileName;

            if (GetProjectName(out projectFileName))
            {

                // 1. upravit include cast
                var lineToAdd = string.Format("    <Compile Include = \"{0}.cs\" />", name);
                var txtLines = File.ReadAllLines(projectFileName).ToList();   //Fill a list with the lines from the txt file.

                int indexNo = 0;
                foreach (string line in txtLines)
                {
                    if (line.Contains("RootNamespace"))
                    {
                        nsName = GetValueFromString(line);
                        status = true;                       
                    }

                    if ((line.Contains("Compile")) && (line.Contains("Include")))
                    {
                        break;
                    }
                    indexNo++;
                }

                txtLines.Insert(indexNo, lineToAdd);  //Insert the line you want to add last under the tag 'item1'.
                File.WriteAllLines(projectFileName, txtLines);                //Add the lines including the new one.
            }

            nameSpaceName = nsName;
            return status;
        }

        public bool AddClassToProject(string className)
        {
            bool res = false;
            string projectFileName;

            if (GetProjectName(out projectFileName))
            {
                string namespaceName = "error";

                // Upravit include cast v CSPROJ subore a zistime nazov namespace                
                if (UpdateProjectFile(className, out namespaceName))
                {
                    SpawnClassFile(className, namespaceName);
                    res = true;
                } else Console.WriteLine("Error: Unable to find <RootNamespace> variable in {0} file!", projectFileName);
            }
            else Console.WriteLine("Error: Unable to find any C# project (*.CSPROJ) file!");

            return res;
        }

        public bool AddStructureToProject(string structureName)
        {
            bool res = false;
            string projectFileName;

            if (GetProjectName(out projectFileName))
            {
                string namespaceName = "error";

                // Upravit include cast v CSPROJ subore a zistime nazov namespace                
                if (UpdateProjectFile(structureName, out namespaceName))
                {
                    SpawnStructureFile(structureName, namespaceName);
                    res = true;
                }
                else Console.WriteLine("Error: Unable to find <RootNamespace> variable in {0} file!", projectFileName);
            }
            else Console.WriteLine("Error: Unable to find any C# project (*.CSPROJ) file!");

            return res;
        }

        public string GetDetectedProjectFileName() => detectedProjectFileName;
        
    }

}
