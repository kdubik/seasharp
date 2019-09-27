using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaSharp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("SeaSharp v0.1, by Kamil Dubik (c) 2019");

            if (args.Length == 0)
            {
                Console.WriteLine("Error: Missing arguments");
            }
            else
            {
                if (args[0] == "sp")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Error: Missing project name");
                        Console.WriteLine("Usage: # seasharp sp project_name");
                    }
                    else
                    {
                        ProjectGenerator pg = new ProjectGenerator(args[1]);
                        pg.CreateProjectFile(true); // Create only project file
                    }
                }

                if (args[0] == "s")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Error: Missing project name");
                        Console.WriteLine("Usage: # seasharp s project_name");
                    }
                    else
                    {
                        ProjectGenerator pg = new ProjectGenerator(args[1]);
                        if (!pg.CreateCompleteProject())
                        {
                            Console.WriteLine("Error: Error creating project '{0}'.",args[1]);
                        }
                        else
                            Console.WriteLine("Project '{0}' successfully created.", args[1]);
                    }
                }

                if (args[0] == "ac")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Error: Missing class name");
                        Console.WriteLine("Usage: # seasharp ac class_name");
                    }
                    else
                    {
                        StructureGenerator sg = new StructureGenerator();
                        //sg.AddClassToProject(args[1]);

                        if (!sg.AddClassToProject(args[1]))
                        {
                            Console.WriteLine("Error: Error adding class '{0}' to project.", args[1]);
                        }
                        else
                            Console.WriteLine("Class '{0}' successfully added to '{1}' project.", args[1], sg.GetDetectedProjectFileName());

                    }
                }

                if (args[0] == "as")
                {
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Error: Missing structure name");
                        Console.WriteLine("Usage: # seasharp as structure_name");
                    }
                    else
                    {
                        StructureGenerator sg = new StructureGenerator();
  
                        if (!sg.AddStructureToProject(args[1]))
                        {
                            Console.WriteLine("Error: Error adding structure '{0}' to project.", args[1]);
                        }
                        else
                            Console.WriteLine("Structure '{0}' successfully added to '{1}' project.", args[1], sg.GetDetectedProjectFileName());

                    }
                }
            }
        }
    }
}
