using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Extended_Register_Class : Register_Class
    {
        public Extended_Register_Class(string OBIS, IEGReader eGReader) : base(OBIS, eGReader) { }
        public object Get_Status()
        {
            return eGReader.Read_Object_Attribute(this.OBIS, 4);
        }

        public object Get_Capture_Time()
        {
            return eGReader.Read_Object_Attribute(this.OBIS, 5);
        }
    }

    class Last_average_demand_register_Active_energy_import_A_Pos : Extended_Register_Class
    {
        public Last_average_demand_register_Active_energy_import_A_Pos(IEGReader eGReader) : base("1.0.1.5.0.255", eGReader) {}
    }



}
