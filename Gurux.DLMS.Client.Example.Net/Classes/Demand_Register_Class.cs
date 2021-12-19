using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Demand_Register_Class
    {
        public IEGReader eGReader;
        public String OBIS;

        public Demand_Register_Class(String OBIS_LN, IEGReader eGReader)
        {
            this.OBIS = OBIS_LN;
            this.eGReader = eGReader;
        }

        public object Get_current_average_value()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 2);
        }

        public object Get_last_average_value()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 3);
        }

        public object Get_Scaler()
        {
            List<object> struc = (List<object>)this.eGReader.Read_Object_Attribute(this.OBIS, 4);
            return (struc[0]);
        }

        public object Get_Unit()
        {
            List<object> struc = (List<object>)this.eGReader.Read_Object_Attribute(this.OBIS, 4);
            return (struc[1]);
        }
        public object Get_Status()
        {
            return eGReader.Read_Object_Attribute(this.OBIS, 5);
        }

        public object Get_Capture_Time()
        {
            return eGReader.Read_Object_Attribute(this.OBIS, 6);
        }

        public object Get_start_time_current()
        {
            return eGReader.Read_Object_Attribute(this.OBIS, 7);
        }

        public object Get_period()
        {
            return eGReader.Read_Object_Attribute(this.OBIS, 8);
        }

        public object Get_number_of_periods()
        {
            return eGReader.Read_Object_Attribute(this.OBIS, 9);
        }
    }

    class Demand_register_Active_energy_import_A_Pos : Demand_Register_Class
    {
        public Demand_register_Active_energy_import_A_Pos(IEGReader eGReader) : base("1.0.1.4.0.255", eGReader) { }
    }

}
