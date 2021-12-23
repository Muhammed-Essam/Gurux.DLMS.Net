using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gurux.DLMS.Client;
using Gurux.DLMS.Objects;

namespace Gurux.DLMS.Client.Example.Net
{
    public class MeterReader
    {

        public static IEGReader Intializer(String com)
        {
            IEGReader eGReader = new IEGReader(com);

            eGReader.Initialize_Connection();
            
            return eGReader;
        }

        public static double Voltage(IEGReader eGReader)
        {
            object val = eGReader.Read_Object_Attribute("1.0.32.7.0.255", 2);
            return (double)val;

        }

        public static uint Power(IEGReader eGReader)
        {
            object val = eGReader.Read_Object_Attribute("1.0.1.9.0.255", 2);
            return (uint)val;

        }

        public static int Credit(IEGReader eGReader)
        {
            object val = eGReader.Read_Object_Attribute("0.0.19.10.0.255", 2);
            return (int)val;

        }

        public static void Closer(IEGReader eGReader)
        {
            eGReader.Close_Connection();
        }

        public static void BreakerDisconnect(IEGReader eGReader)
        {
            eGReader.BreakerDisconnect();
        }

        public static void ChargeCredit(IEGReader eGReader, int value)
        {
            eGReader.ChargeCredit(value);
        }

        public static void NonDisconnectPeriod(IEGReader eGReader, Boolean enable)
        {
            eGReader.NonDisconnectPeriod(enable);
        }

        public static void WriteBacklight(IEGReader eGReader, UInt16 value)
        {
            eGReader.Write_Value_Object_Attribute("0.0.196.1.8.255", 2, value);
        }


        public static void ReadBacklight(IEGReader eGReader)
        {
            GXDLMSObject myobject = eGReader.Read_ObjectSelf("0.0.196.1.8.255");
            //return (int)val;
        }


    }
}
