using System;
using System.Collections.Generic;
using System.Threading;
using Gurux.DLMS.Enums;
using Gurux.DLMS.Objects;
using Gurux.DLMS.Client.Example.Net.Properties;
using System.Linq;
using System.Text;
using Gurux.DLMS.Reader;
using Gurux.Serial;

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
            _ = Resource1.JICAXMLFilePath;
            ////////////////////////////////////////
            //Handle command line parameters.
            String[] argsE = { "-S", "COM4:300:7Even1", "-i", "HdlcWithModeE", "-c", "1", "-s", "145", "-a", "Low", "-P", "12345678", "-d", "Idis", "-t", "Verbose" };
            _ = Settings.GetParameters(argsE, settings);

            ////////////////////////////////////////
            //Xml file path that contains all the meter COSEM objects.
            settings.outputFile = Resource1.JICAXMLFilePath;


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

        public void Initialize_Connection() 
        { 
            reader.InitializeConnection_Edited(); 
        }
        
        /// <summary>
        /// Reading a Val from an object by COSEM Logical Name (LN)
        /// </summary>
        /// <param name="OBIS_Code_LN">Logical name (LN) (Full) seperated by dots (.) OBIS Code like 1.1.1.1.255</param>
        /// <param name="Att_Index">The attribute idex to read from the OBIS Code</param>
        /// <returns>attribute value in format of object(general format)</returns>
        public object Read_Object_Attribute(String OBIS_Code_LN, int Att_Index)
        {
            GXDLMSObject myobject = settings.client.Objects.FindByLN(ObjectType.None, OBIS_Code_LN);

            object val = reader.Read_Edited(myobject, Att_Index);

            

            return val;
        }

        public object Read_Object_Attribute_Bytes(String OBIS_Code_LN, int Att_Index)
        {
            GXDLMSObject myobject = settings.client.Objects.FindByLN(ObjectType.None, OBIS_Code_LN);

            object val = reader.Read_Edited_Bytes(myobject, Att_Index);

            

            return val;
        }

        public object Read_Object_Edited(String OBIS_Code_LN, int Att_Index)
        {
            GXDLMSObject myobject = settings.client.Objects.FindByLN(ObjectType.None, OBIS_Code_LN);

            object val = null;// reader.Read_Edited(myobject, Att_Index);

            reader.GetProfileGenericColumns_By_OBIS(myobject);

            return val;
        }

        /// <summary>
        /// return the COSEM object refeernce by the OBIS CODE
        /// </summary>
        /// <param name="OBIS_Code_LN">Logical name (LN) (Full) seperated by dots (.) OBIS Code like 1.1.1.1.255</param>
        /// <returns>COSEM Object</returns>
        public GXDLMSObject Read_ObjectSelf(String OBIS_Code_LN)
        {
            GXDLMSObject myobject = settings.client.Objects.FindByLN(ObjectType.None, OBIS_Code_LN);

            return myobject;
        }

        /// <summary>
        /// update attribute value on a COSEM object by OBIS LN 
        /// </summary>
        /// <param name="OBIS_Code_LN">Logical name (LN) (Full) seperated by dots (.) OBIS Code like 1.1.1.1.255</param>
        /// <param name="Att_Index">attribute index</param>
        /// <param name="value">value to be set</param>
        public void Write_Value_Object_Attribute(String OBIS_Code_LN, int Att_Index, object value)
        {
            GXDLMSObject _ = Read_ObjectSelf(OBIS_Code_LN);
            reader.SetValue(_ ,Att_Index, value);

            
            Write_Object_On_Meter(_ , Att_Index);
        }

        /// <summary>
        /// Write a object to a meter
        /// </summary>
        /// <param name="Cosem_Object"></param>
        /// <param name="Att_Index"></param>
        public void Write_Object_On_Meter(GXDLMSObject Cosem_Object, int Att_Index)
        {
            reader.Write(Cosem_Object, Att_Index);
        }

        /// <summary>
        /// Execute Certain script fom script OBIS LN
        /// </summary>
        /// <param name="OBIS_Code_LN">Logical name (LN) (Full) seperated by dots (.) OBIS Code like 1.1.1.1.255</param>
        /// <param name="ScriptID">script ID on the cosem ex: 1</param>
        public void Execute_Script(String OBIS_Code_LN, int ScriptID)
        {
            reader.ExecuteScript(OBIS_Code_LN, ScriptID);
        }

        public void Execute_Method_Edited(byte[][] mymethod, GXReplyData reply)
        {
            reader.ReadDataBlock_Edited(mymethod, reply); 
        }

        public void Execute_Method_Without_Datatype(String OBIS_Code_LN,int methodIndex, object value)
        {
            GXDLMSObject myobject = settings.client.Objects.FindByLN(ObjectType.None, OBIS_Code_LN);            
            reader.Method_Without_Datatype(myobject, methodIndex, value);
        }

        public void Execute_Method(String OBIS_Code_LN, int methodIndex, int Att_Index, object value)
        {
            GXDLMSObject myobject = settings.client.Objects.FindByLN(ObjectType.None, OBIS_Code_LN);
            reader.Method(myobject, methodIndex, value, myobject.GetDataType(Att_Index));
        }

        public GXDLMSClient GetClient()
        {
            return reader.Client;
        }

        /// <summary>
        /// disconnecting breaker 
        /// </summary>
        public void BreakerDisconnect()
        {
            reader.BreakerDisconnect();
        }

        public void ChargeCredit(int value)
        {
            reader.ChargeCredit(value);
        }


        public void NonDisconnectPeriod(Boolean enable)
        {
            if (enable)
                Execute_Script("0.0.10.7.0.255", 1);
            else
                Execute_Script("0.0.10.7.0.255", 2);
        }
        public void Close_Connection()
        {
            reader.Close_Edited();
        }




        


    }
}
