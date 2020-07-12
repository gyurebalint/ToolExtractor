using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ToolExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine( Extractor.CurrentAssembly.Location);
            try
            {
                foreach (string resource in Extractor.CurrentAssembly.GetManifestResourceNames())
                {
                    
                    string[] resourceName = resource.Split('.');
                    string resourceNameWithExtension = "";
                    
                    if (!resource.Contains("addin"))
                    {
                         resourceNameWithExtension = resourceName[resourceName.Length - 2] + "." + resourceName[resourceName.Length - 1];

                    }
                    else
                    {
                        resourceNameWithExtension = resourceName[resourceName.Length - 4] + "." + resourceName[resourceName.Length - 3] + "."+ resourceName[resourceName.Length - 2] + "." + resourceName[resourceName.Length - 1];
                        Console.WriteLine(resource);
                    }
                    Console.WriteLine(resourceNameWithExtension); 


                    if (resource.Contains(Extractor.DesignData))
                    {
                        Extractor.Extract(Extractor.DesignDataDestinationFolderPath, Extractor.DesignData, resourceNameWithExtension);
                    }
                    if (resource.Contains(Extractor.InventorAddins))
                    {
                        Extractor.Extract(Extractor.InventorAddinsDestinationFolderPath, Extractor.InventorAddins, resourceNameWithExtension);
                    }
                    if (resource.Contains(Extractor.Templates))
                    {
                        Extractor.Extract(Extractor.TemplatesDestinationFolderPath, Extractor.Templates, resourceNameWithExtension);
                    }
                    if (resource.Contains(Extractor.DesignAcceleratorModels))
                    {
                        Extractor.Extract(Extractor.DesignAcceleratorModelsDestinationFolderPath, Extractor.DesignAcceleratorModels, resourceNameWithExtension);
                    }

                }
                MessageBox.Show("Copying to the Inventor destination folders were SUCCESSFUL!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} \n Copying was unsuccessful! \n Make the files you want to copy as an 'Embedded Resource' ! \n " +
                    "You can do this by clicking on the file, right bottom side of the screen in the properties window, change the BUILD ACTION to " +
                    "'Embedded Resource', then build the project again");

                /*"Copying was unsuccessful! \n Make the files you want to copy as an 'Embedded Resource' ! \n " +
                    "You can do this by clicking on the file, right bottom side of the screen in the properties window, change the BUILD ACTION to " +
                    "'Embedded Resource', then build the project again");*/
            }
            //Console.WriteLine();
 

            //Console.ReadLine();
        }
    }
}
//BusbarTools
//C:\Users\Gyure Balint\AppData\Roaming\Autodesk\ApplicationPlugins\busbarTools

//Templates
//C:\Users\Public\Documents\Autodesk\Inventor 2018\Templates

//DesignData
//C:\Users\Public\Documents\Autodesk\Inventor 2018\Design Data

//Design Accelerator
//C:\Program Files\Autodesk\Inventor 2018\Design Accelerator\models
//C:\Program Files\Autodesk\Inventor 2018\Design Accelerator\defaults