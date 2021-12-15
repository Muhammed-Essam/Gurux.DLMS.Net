using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net
{
    public class MeterReader
    {

        public static IEGReader Intializer()
        {
            IEGReader eGReader = new IEGReader();

            eGReader.Initialize_Connection();
            
            return eGReader;
        }

        public static object Voltage(IEGReader eGReader)
        {
            object val = eGReader.Read_Object("1.0.32.7.0.255", 2);
            return val;

        }

        public static object Power(IEGReader eGReader)
        {
            object val = eGReader.Read_Object("1.0.1.9.0.255", 2);
            return val;

        }

        public static object Credit(IEGReader eGReader)
        {
            object val = eGReader.Read_Object("0.0.19.10.0.255", 2);
            return val;

        }

        public static void Write_object(IEGReader eGReader,String OBIS, int Index)
        {
            eGReader.Write_Object(OBIS, Index);
        }

        public static void Closer(IEGReader eGReader)
        {
            eGReader.Close_Connection();
        }

        
    }
}
