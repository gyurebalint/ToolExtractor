using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ToolExtractor
{
    class Extractor
    {
        static public string UserName = Environment.UserName;
        static public string NameSpace = "ToolExtractor";
        static public string DesignData = "DesignData";
        static public string InventorAddins = "InventorAddins";
        static public string Templates = "Templates";
        static public string DesignAcceleratorModels = "DesignAcceleratorModels";

        static public string DesignDataDestinationFolderPath = @"C:\Users\Public\Documents\Autodesk\Inventor 2018\Design Data";
        static public string InventorAddinsDestinationFolderPath = $@"C:\Users\{UserName}\AppData\Roaming\Autodesk\ApplicationPlugins\busbarTools";
        static public string TemplatesDestinationFolderPath = @"C:\Users\Public\Documents\Autodesk\Inventor 2018\Templates";
        static public string DesignAcceleratorModelsDestinationFolderPath = @"C:\Program Files\Autodesk\Inventor 2018\Design Accelerator\models";

        public static Assembly CurrentAssembly = Assembly.GetCallingAssembly();
        public static void Extract( string outDirectory, string internalFilePath, string resourceName)
        {
            using (Stream s = CurrentAssembly.GetManifestResourceStream(NameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            {
                using(BinaryReader r = new BinaryReader(s))
                {
                    using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
                    {
                        using(BinaryWriter w = new BinaryWriter(fs))
                        {
                            w.Write(r.ReadBytes((int)s.Length));
                        }
                    }
                }
            }

        }
    }
}