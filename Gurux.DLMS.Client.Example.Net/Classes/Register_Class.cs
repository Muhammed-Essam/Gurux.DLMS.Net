using System;
using System.Collections.Generic;
namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Register_Class
    {
        public IEGReader eGReader;
        public String OBIS;
        public Register_Class() { }
        public Register_Class(String OBIS_LN, IEGReader eGReader)
        {
            this.OBIS = OBIS_LN;
            this.eGReader = eGReader;
        }

        public object Get_Value()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 2);
        }

        public object Get_Scaler()
        {
            List<object> struc = (List<object>)this.eGReader.Read_Object_Attribute(this.OBIS, 3);
            return (struc[0]);
        }
        
        public object Get_Unit()
        {
            List<object> struc = (List<object>)this.eGReader.Read_Object_Attribute(this.OBIS, 3);
            return (struc[1]);
        }

    }
    class Instantanous_L1 : Register_Class
    {
        public Instantanous_L1(IEGReader eGReader) : base("1.0.31.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Current_Sum : Register_Class
    {
        public Instantanous_Current_Sum(IEGReader eGReader) : base("1.0.90.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Current_Neutral : Register_Class
    {
        public Instantanous_Current_Neutral(IEGReader eGReader) : base("1.0.91.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class RMS_filtered_current_Neutral : Register_Class
    {
        public RMS_filtered_current_Neutral(IEGReader eGReader) : base("1.0.91.128.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Current_Residual : Register_Class
    {
        public Instantanous_Current_Residual(IEGReader eGReader) : base("1.0.128.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class RMS_filtered_current_Residual : Register_Class
    {
        public RMS_filtered_current_Residual(IEGReader eGReader) : base("1.0.128.128.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Net_Frequency_anyPhase : Register_Class
    {
        public Instantanous_Net_Frequency_anyPhase(IEGReader eGReader) : base("1.0.14.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantaneous_active_import_power_A_pos : Register_Class
    {
        public Instantaneous_active_import_power_A_pos(IEGReader eGReader) : base("1.0.1.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantaneous_active_import_power_A_neg : Register_Class
    {
        public Instantaneous_active_import_power_A_neg(IEGReader eGReader) : base("1.0.2.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Active_Power_Combined : Register_Class
    {
        public Instantanous_Active_Power_Combined(IEGReader eGReader) : base("1.0.15.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Active_Power_Combined_diff : Register_Class
    {
        public Instantanous_Active_Power_Combined_diff(IEGReader eGReader) : base("1.0.16.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Active_Import_Power_A : Register_Class
    {
        public Instantanous_Active_Import_Power_A(IEGReader eGReader) : base("1.0.21.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Active_export_Power_A : Register_Class
    {
        public Instantanous_Active_export_Power_A(IEGReader eGReader) : base("1.0.22.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Active_Power_combined_sum : Register_Class
    {
        public Instantanous_Active_Power_combined_sum(IEGReader eGReader) : base("1.0.35.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Active_Power_combined_diff : Register_Class
    {
        public Instantanous_Active_Power_combined_diff(IEGReader eGReader) : base("1.0.36.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Power_Factor : Register_Class
    {
        public Instantanous_Power_Factor(IEGReader eGReader) : base("1.0.13.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Power_Factor_L1 : Register_Class
    {
        public Instantanous_Power_Factor_L1(IEGReader eGReader) : base("1.0.33.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Power_Factor_Negative : Register_Class
    {
        public Instantanous_Power_Factor_Negative(IEGReader eGReader) : base("1.0.84.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Power_Factor_Negative_L1 : Register_Class
    {
        public Instantanous_Power_Factor_Negative_L1(IEGReader eGReader) : base("1.0.85.7.0.255", eGReader) { this.eGReader = eGReader; }
    }
    class Instantanous_Voltage_L1 : Register_Class
    {
        public Instantanous_Voltage_L1(IEGReader eGReader) : base("1.0.32.7.0.255", eGReader) {
            this.eGReader = eGReader;
        }
    }
    class Disconnect_control_manual_connect_period : Register_Class
    {
        public Disconnect_control_manual_connect_period(IEGReader eGReader) : base("0.0.128.30.24.255", eGReader) { this.eGReader = eGReader; }
    }
    class Power_On_Delay : Register_Class
    {
        public Power_On_Delay(IEGReader eGReader) : base("0.0.128.30.27.255", eGReader) { this.eGReader = eGReader; }
    }
    class Switch_On_Delay : Register_Class
    {
        public Switch_On_Delay(IEGReader eGReader) : base("0.0.128.30.28.255", eGReader) { this.eGReader = eGReader; }
    }
  
}
