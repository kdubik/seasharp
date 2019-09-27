# SeaSharp
Some usefull tools for working with C# language. It is primary intended as tool for programmers working under Linux/Unix environment using Mono platform.

## Source codes
*Program.cs* - main file
*PRojectGenerator* - here are methods for creating CSPROJ files and project folder structures
*StructureGenerator.cs* - contains methods for creating new class/struct files and their integration into the CSPROJ file

## How to compile

### Windows platform
Just open SLN or CSPROJ file and compile using Visual Studio.
(project has pretty simple structure, so it is very basic procedure)

### Linux platform

## How to use SeaSharp
command line commands:

seasharp s  project_name    => Spawn CSPROJ + basic file/folder structure
    - Generate CSPROJ file and project folder structure
        - Structure contains Program.cs, app.config, properties.cs, assembly.cs files + folders

seasharp sp project_name    => Spawn only CSPROJ file
    - Creates CSPROJ file in current directory
    - Created CSPROJ File contains default namespace (derived from 'projectname'), assembly name, generates new project GUID
    - Program.cs file is not created
    
seasharp ac class_name      => Add C# class file
    - Creates new cs file with new class definition and integrate it with CSRPOJ file in current folder

seasharp as structure_name  => Add C# structure with CS file
    - Creates new cs file with new structure definition and integrate it with CSRPOJ file in current folder