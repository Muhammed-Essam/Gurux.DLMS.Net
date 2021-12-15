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
        Settings settings = new Settings();
        Reader.GXDLMSReader reader = null;


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
            settings.outputFile = myIcon;


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
            
            object val = reader.Read_Edited(settings.client.Objects.FindByLN(ObjectType.None, Cosem_Object), Att_Index);
            return val;
        }

        public void Write_Object(String OBIS, int position)
        {

            /*
            Objects.GXDLMSData prt = new Objects.GXDLMSData(OBIS);

            prt.SetDataType(position, DataType.Int32);

            prt.Value = 14;
            
            reader.Write(prt, position);
            */

    
            GXDLMSObject it = new GXDLMSObject();
            it.LogicalName = "0.0.19.50.2.255";
            reader.Write(it, 2);

        }
        public void Close_Connection()
        {
            reader.Close_Edited();
        }




        


    }
}
