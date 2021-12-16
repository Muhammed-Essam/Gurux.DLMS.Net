using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gurux.DLMS.Enums;
using Gurux.DLMS.Client.Example.Net;
namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Register_Class
    {
        IEGReader eGReader = new IEGReader();
        String OBIS;
        public Register_Class(String OBIS_LN)
        {
            this.OBIS = OBIS_LN;
        }

        public UInt32 Get_Value()
        {
            return (UInt32)eGReader.Read_Object_Attribute(this.OBIS, 2);
        }

        public double Get_Scaler()
        {
            List<object> struc = (List<object>)eGReader.Read_Object_Attribute(this.OBIS, 3);
            return (double)(struc[0]);
        }
        
        public int Get_Unit()
        {
            List<object> struc = (List<object>)eGReader.Read_Object_Attribute(this.OBIS, 3);
            return (int)(struc[1]);
        }

    }

    
}
