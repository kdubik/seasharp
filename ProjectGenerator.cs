/*
    This class contains methods, for creating default CPROJ file. 
 
  
  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaSharp
{
    class ProjectGenerator
    {

        string projectFileName = "UnnamedProject.csproj";
        string projectName = "UnnamedProject";
        string defaultNamespace = "UnnamedProject";
        string assemblyName = "UnnamedProject";
        string newGuid = Guid.NewGuid().ToString();

        public ProjectGenerator(string projectName)
        {
            this.projectName = projectName;
            defaultNamespace = projectName.ToLower() ;
            projectFileName = projectName + ".csproj";
            assemblyName = projectName;           
        }

        public void CreateProjectFile(bool onlyProjectFile)
        {
            string tmp;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(projectFileName))
            {
                file.WriteLine("<? xml version=\"1.0\" encoding = \"utf - 8\" ?>");
                file.WriteLine("<Project ToolsVersion=\"15.0\" xmlns = \"http://schemas.microsoft.com/developer/msbuild/2003\" >");
                file.WriteLine("  <Import Project=\"$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props\" Condition=\"Exists('$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')\" />");
                file.WriteLine("  <PropertyGroup>");
                file.WriteLine("    <Configuration Condition= \" '$(Configuration)' == '' \" >Debug</Configuration>");
                file.WriteLine("    <Platform Condition=\" '$(Platform)' == '' \" >AnyCPU</Platform>");

                tmp = string.Format("    <ProjectGuid>{0}</ProjectGuid>", newGuid);
                file.WriteLine(tmp);
                //file.WriteLine("    <ProjectGuid>{26441437-133E-4FC4-91C3-613F305BB22D}</ProjectGuid>");

                file.WriteLine("    <OutputType>Exe</OutputType>");

                tmp = string.Format("    <RootNamespace>{0}</RootNamespace>", defaultNamespace);
                file.WriteLine(tmp);
                //file.WriteLine("    <RootNamespace>studio</RootNamespace>");

                tmp = string.Format("    <AssemblyName>{0}</AssemblyName>", assemblyName);
                file.WriteLine(tmp);
                //file.WriteLine("    <AssemblyName>studio</AssemblyName>");

                file.WriteLine("    <TargetFrameworkVersion>v4.6.1</TargetFrameworkVersion>");
                file.WriteLine("    <FileAlignment>512</FileAlignment>");
                file.WriteLine("    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>");
                file.WriteLine("    <Deterministic>true</Deterministic>");
                file.WriteLine("    <FileAlignment>512</FileAlignment>");
                file.WriteLine("  </PropertyGroup>");

                file.WriteLine("");

                file.WriteLine("  <PropertyGroup Condition = \" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">");
                file.WriteLine("    <PlatformTarget>AnyCPU</PlatformTarget>");
                file.WriteLine("    <DebugSymbols>true</DebugSymbols>");
                file.WriteLine("    <DebugType>full</DebugType>");
                file.WriteLine("    <Optimize>false</Optimize>");
                file.WriteLine("    <OutputPath>bin\\Debug\\</OutputPath>");
                file.WriteLine("    <DefineConstants>DEBUG;TRACE</DefineConstants>");
                file.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                file.WriteLine("    <WarningLevel>4</WarningLevel>");
                file.WriteLine("  </PropertyGroup>");

                file.WriteLine("");

                file.WriteLine("  <PropertyGroup Condition = \" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">");
                file.WriteLine("    <PlatformTarget>AnyCPU</PlatformTarget>");
                file.WriteLine("    <DebugSymbols>true</DebugSymbols>");
                file.WriteLine("    <DebugType>pdbonly</DebugType>");
                file.WriteLine("    <Optimize>true</Optimize>");
                file.WriteLine("    <OutputPath>bin\\Release\\</OutputPath>");
                file.WriteLine("    <DefineConstants>TRACE</DefineConstants>");
                file.WriteLine("    <ErrorReport>prompt</ErrorReport>");
                file.WriteLine("    <WarningLevel>4</WarningLevel>");
                file.WriteLine("  </PropertyGroup>");

                file.WriteLine("");

                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <Reference Include=\"System\" />");
                file.WriteLine("    <Reference Include=\"System.Core\" />");
                file.WriteLine("    <Reference Include=\"System.Xml.Linq\" />");
                file.WriteLine("    <Reference Include=\"System.Data.DataSetExtensions\" />");
                file.WriteLine("    <Reference Include=\"Microsoft.CSharp\" />");
                file.WriteLine("    <Reference Include=\"System.Data\" />");
                file.WriteLine("    <Reference Include=\"System.Nte.Http\" />");
                file.WriteLine("    <Reference Include=\"System.Xml\" />");
                file.WriteLine("  </ItemGroup>");

                file.WriteLine("");

                file.WriteLine("  <ItemGroup>");
                file.WriteLine("    <Compile Include = \"Program.cs\" />");
                if (!onlyProjectFile) file.WriteLine("    <Compile Include = \"Properties\\AssemblyInfo.cs\" />");
                file.WriteLine("  </ItemGroup>");

                if (!onlyProjectFile)
                {
                    file.WriteLine("  <ItemGroup>");
                    file.WriteLine("    <None Include = \"App.config\" />");
                    file.WriteLine("  </ItemGroup>");
                }

                file.WriteLine("  <Import Project = \"$(MSBuildToolsPath)\\Microsoft.CSharp.targets\" />");
                file.WriteLine("</Project>");

            }
        }

        public void CreateAppConfigFile()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(projectName+"\\App.config"))
            {
                file.WriteLine("<? xml version=\"1.0\" encoding = \"utf - 8\" ?>");
                file.WriteLine("  <configuration>");
                file.WriteLine("    <startup>");
                file.WriteLine("      <supportedRuntime version=\"v4.0\" sku=\".NETFramework, Version = v4.6.1\" />>");
                file.WriteLine("    </startup>");
                file.WriteLine("  </configuration>");
            }
        }

        public void CreateAssemblyInfoFile()
        {
            string tmp;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(projectName + "\\Properties\\AssemblyInfo.cs"))
            {
                file.WriteLine("using System.Reflection;");
                file.WriteLine("using System.Runtime.CompilerServices;");
                file.WriteLine("using System.Runtime.InteropServices;");

                file.WriteLine("");

                file.WriteLine("// General Information about an assembly is controlled through the following");
                file.WriteLine("// set of attributes. Change these attribute values to modify the information");
                file.WriteLine("// associated with an assembly.");

                tmp = string.Format("[assembly: AssemblyTitle(\"{0}\")]", assemblyName);
                file.WriteLine(tmp);
                //file.WriteLine("[assembly: AssemblyTitle(\"SeaSharp\")]");

                file.WriteLine("[assembly: AssemblyDescription(\"\")]");
                file.WriteLine("[assembly: AssemblyConfiguration(\"\")]");
                file.WriteLine("[assembly: AssemblyCompany(\"\")]");
                file.WriteLine("[assembly: AssemblyProduct(\"\")]");

                tmp = string.Format("[assembly: AssemblyCopyright(\"Copyright ©  {0}\")]", DateTime.Today.Year.ToString());
                file.WriteLine(tmp);
                //file.WriteLine("[assembly: AssemblyCopyright(\"Copyright ©  2019\")]");

                file.WriteLine("[assembly: AssemblyTrademark(\"\")]");
                file.WriteLine("[assembly: AssemblyCulture(\"\")]");

                file.WriteLine("");

                file.WriteLine("// Setting ComVisible to false makes the types in this assembly not visible");
                file.WriteLine("// to COM components.  If you need to access a type in this assembly from");
                file.WriteLine("// COM, set the ComVisible attribute to true on that type.");
                file.WriteLine("[assembly: ComVisible(false)]");

                file.WriteLine("");

                file.WriteLine("// The following GUID is for the ID of the typelib if this project is exposed to COM");

                tmp = string.Format("[assembly: Guid(\"{0}\")]", newGuid);
                file.WriteLine(tmp);
                //file.WriteLine("[assembly: Guid(\"a5e8aa1a - 32b9 - 470c - b00e - 81a84fc40692\")]");

                file.WriteLine("");

                file.WriteLine("// Version information for an assembly consists of the following four values:");
                file.WriteLine("//");
                file.WriteLine("//      Major Version");
                file.WriteLine("//      Minor Version");
                file.WriteLine("//      Build number");
                file.WriteLine("//      Revision");
                file.WriteLine("//");
                file.WriteLine("// You can specify all the values or you can default the Build and Revision Numbers");
                file.WriteLine("// [assembly: AssemblyVersion(\"1.0.* \")]");
                file.WriteLine("[assembly: AssemblyVersion(\"1.0.0.0\")]");
                file.WriteLine("[assembly: AssemblyFileVersion(\"1.0.0.0\")]");
            }
        }

        public void CreateProgramCsFile()
        {
            string tmp;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(projectName + "\\Program.cs"))
            {
                file.WriteLine("using System;");
                file.WriteLine("using System.Collections.Generic;");
                file.WriteLine("using System.Linq;");
                file.WriteLine("using System.Text;");
                file.WriteLine("using System.Threading.Tasks;");

                file.WriteLine("");

                file.WriteLine("namespace {0}", defaultNamespace);
                file.WriteLine("{");
                file.WriteLine("     class Program");
                file.WriteLine("     {");
                file.WriteLine("          static void Main(string[] args)");
                file.WriteLine("          {");
                file.WriteLine("          }");
                file.WriteLine("     }");
                file.WriteLine("}");

            }
        }

        public bool CreateFolderStructure()
        {
            bool res = false;
            if (!System.IO.Directory.Exists(projectName))
            {
                System.IO.Directory.CreateDirectory(projectName);
                System.IO.Directory.CreateDirectory(projectName + "\\Properties");
                System.IO.Directory.CreateDirectory(projectName + "\\bin");
                System.IO.Directory.CreateDirectory(projectName + "\\bin\\Release");
                System.IO.Directory.CreateDirectory(projectName + "\\bin\\Debug");
                res = true;
            }
            return res;
        }

        public bool CreateCompleteProject()
        {
            bool res = false;

            if (CreateFolderStructure())
            {
                projectFileName = projectName + "\\" + projectFileName;
                CreateProjectFile(false);
                CreateAppConfigFile();
                CreateAssemblyInfoFile();
                CreateProgramCsFile();

                res = true;
            }
            else
                Console.WriteLine("Error: Unable to create folder structure. It already exists.");

            return res;
        }
    }
}
