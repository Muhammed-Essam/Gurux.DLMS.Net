using System;
using System.Collections.Generic;
using Gurux.Serial;
using Gurux.Net;
using System.Threading;
using Gurux.DLMS.Enums;
using Gurux.DLMS.Objects;
using Gurux.DLMS.Client.Example.Net.Properties;
using System.Linq;
using Gurux.DLMS.Reader;

namespace Gurux.DLMS.Client.Example.Net
{
    public class IEGReader
    {
        public Settings settings = new Settings();
        public Reader.GXDLMSReader reader = null;


        /// <summary>
        /// Constructor 
        /// Takes Initial Connection Parameters and Parse it 
        /// </summary>
        /// <param name="args">Connection parameters</param>
        public IEGReader()
        {

            var myIcon = Resource1.JICAXMLFilePath;
            ////////////////////////////////////////
            //Handle command line parameters.
            String[] argsE = { "-S", "COM5:300:7Even1", "-i", "HdlcWithModeE", "-c", "1", "-s", "145", "-a", "Low", "-P", "12345678", "-d", "Idis", "-t", "Verbose" };
            int ret = Settings.GetParameters(argsE, settings);

            ////////////////////////////////////////
            //Xml file path that contains all the meter COSEM objects.
            settings.outputFile = "D:/Iskra/Projects/Smart Meter Reader/Gurux.DLMS.Client.Example.Net/JICA_Classes.xml";


            reader = new Reader.GXDLMSReader(settings.client, settings.media, settings.trace, settings.invocationCounter);

            try
            {
                settings.media.Open();
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Available ports:");
                Console.WriteLine(string.Join(" ", GXSerial.GetPortNames()));
            }


            //Some meters need a break here.
            Thread.Sleep(1000);

            if (settings.outputFile != null)
            {
                try
                {
                    settings.client.Objects.Clear();

                    settings.client.Objects.AddRange(GXDLMSObjectCollection.Load(settings.outputFile));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        Console.ReadKey();
                    }
                }
            }


        }

        public void Initialize_Connection() { reader.InitializeConnection_Edited(); }
        
        public object Read_Object(String Cosem_Object, int Att_Index)
        {
            GXDLMSObject myobject = settings.client.Objects.FindByLN(ObjectType.None, Cosem_Object);


            object val = reader.Read_Edited(myobject, Att_Index);

            myobject = settings.client.Objects.FindByLN(ObjectType.None, Cosem_Object);

            return val;
        }

        public void Close_Connection()
        {
            reader.Close_Edited();
        }




        


    }
}
