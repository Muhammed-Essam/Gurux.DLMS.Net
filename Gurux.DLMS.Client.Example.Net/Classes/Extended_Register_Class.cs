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
    class Last_average_demand_register_Active_energy_import_pos_A : Extended_Register_Class
    {
        public Last_average_demand_register_Active_energy_import_pos_A(IEGReader eGReader) : base("1.0.1.5.0.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A(IEGReader eGReader) : base("1.0.1.6.0.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Rate_1 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Rate_1(IEGReader eGReader) : base("1.0.1.6.1.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Rate_2 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Rate_2(IEGReader eGReader) : base("1.0.1.6.2.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Rate_3 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Rate_3(IEGReader eGReader) : base("1.0.1.6.3.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Rate_4 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Rate_4(IEGReader eGReader) : base("1.0.1.6.4.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Rate_5 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Rate_5(IEGReader eGReader) : base("1.0.1.6.5.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Rate_6 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Rate_6(IEGReader eGReader) : base("1.0.1.6.6.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Rate_7 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Rate_7(IEGReader eGReader) : base("1.0.1.6.7.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Rate_8 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Rate_8(IEGReader eGReader) : base("1.0.1.6.8.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_pos_A_Periodic : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_pos_A_Periodic(IEGReader eGReader) : base("1.0.1.128.0.255", eGReader) { }
    }
    class Last_average_demand_register_Active_energy_export_neg_A : Extended_Register_Class
    {
        public Last_average_demand_register_Active_energy_export_neg_A(IEGReader eGReader) : base("1.0.2.5.0.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A(IEGReader eGReader) : base("1.0.2.6.0.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A_Rate_1 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A_Rate_1(IEGReader eGReader) : base("1.0.2.6.1.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A_Rate_2 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A_Rate_2(IEGReader eGReader) : base("1.0.2.6.2.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A_Rate_3 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A_Rate_3(IEGReader eGReader) : base("1.0.2.6.3.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A_Rate_4 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A_Rate_4(IEGReader eGReader) : base("1.0.2.6.4.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A_Rate_5 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A_Rate_5(IEGReader eGReader) : base("1.0.2.6.5.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A_Rate_6 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A_Rate_6(IEGReader eGReader) : base("1.0.2.6.6.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A_Rate_7 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A_Rate_7(IEGReader eGReader) : base("1.0.2.6.7.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_export_neg_A_Rate_8 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_export_neg_A_Rate_8(IEGReader eGReader) : base("1.0.2.6.8.255", eGReader) { }
    }
    class Minimum_power_factor_pos_A_or_pos_VA : Extended_Register_Class
    {
    public Minimum_power_factor_pos_A_or_pos_VA(IEGReader eGReader) : base("1.0.13.3.0.255", eGReader) { }
    }
    class Last_average_power_factor_pos_A_or_posVA : Extended_Register_Class
    {
        public Last_average_power_factor_pos_A_or_posVA(IEGReader eGReader) : base("1.0.13.5.0.255", eGReader) { }
    }
    class Active_demand_last_combined_Abs_pos_A_plus_Abs_neg_A : Extended_Register_Class
    {
        public Active_demand_last_combined_Abs_pos_A_plus_Abs_neg_A(IEGReader eGReader) : base("1.0.15.5.0.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A(IEGReader eGReader) : base("1.0.15.6.0.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_1 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_1(IEGReader eGReader) : base("1.0.15.6.1.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_2 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_2(IEGReader eGReader) : base("1.0.15.6.2.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_3 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_3(IEGReader eGReader) : base("1.0.15.6.3.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_4 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_4(IEGReader eGReader) : base("1.0.15.6.4.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_5 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_5(IEGReader eGReader) : base("1.0.15.6.5.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_6 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_6(IEGReader eGReader) : base("1.0.15.6.6.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_7 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_7(IEGReader eGReader) : base("1.0.15.6.7.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_8 : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_combined_Abs_pos_A_plus_Abs_neg_A_Rate_8(IEGReader eGReader) : base("1.0.15.6.8.255", eGReader) { }
    }
    class Maximum_demand_register_Active_energy_import_A_Periodic : Extended_Register_Class
    {
        public Maximum_demand_register_Active_energy_import_A_Periodic(IEGReader eGReader) : base("1.0.2.128.0.255", eGReader) { }
    }
    class L1_Current_Maximum_2 : Extended_Register_Class
    {
        public L1_Current_Maximum_2(IEGReader eGReader) : base("1.0.31.16.0.255", eGReader) { }
    }
    class L1_Voltage_Minimum_2 : Extended_Register_Class
    {
        public L1_Voltage_Minimum_2(IEGReader eGReader) : base("1.0.32.13.0.255", eGReader) { }
    }
    class L1_Voltage_Maximum_2 : Extended_Register_Class
    {
        public L1_Voltage_Maximum_2(IEGReader eGReader) : base("1.0.32.16.0.255", eGReader) { }
    }

}




