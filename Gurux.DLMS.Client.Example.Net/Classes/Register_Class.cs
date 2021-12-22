using System;
using System.Collections.Generic;
using Gurux.DLMS.Objects;
using Gurux.DLMS.Secure;

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

        public void Reset()
        {
            GXReplyData reply = new GXReplyData();
            GXDLMSRegister register = new GXDLMSRegister();

            byte[][] result = register.Reset(this.eGReader.reader.Client);

            this.eGReader.Execute_Method(result, reply);
        }

    }



    class Battery_use_time_counter : Register_Class
    {
        public Battery_use_time_counter(IEGReader eGReader) : base("0.0.96.6.0.255", eGReader) { }
    }

    class Battery_estimated_remaining_use_time : Register_Class
    {
        public Battery_estimated_remaining_use_time(IEGReader eGReader) : base("0.0.96.6.6.255", eGReader) { }
    }

    class Duration_of_last_long_power_failure_All_phases : Register_Class
    {
        public Duration_of_last_long_power_failure_All_phases(IEGReader eGReader) : base("0.0.96.7.15.255", eGReader) { }
    }

    class Duration_of_last_long_power_failure_any_phase : Register_Class
    {
        public Duration_of_last_long_power_failure_any_phase (IEGReader eGReader) : base("0.0.96.7.19.255", eGReader) { }
    }

    class Time_threshold_for_long_power_failure : Register_Class
    {
        public Time_threshold_for_long_power_failure(IEGReader eGReader) : base("0.0.96.7.20.255", eGReader) { }
    }

    class Bad_voltage_percentage_last_L1 : Register_Class
    {
        public Bad_voltage_percentage_last_L1(IEGReader eGReader) : base("0.0.128.8.15.255", eGReader) { }
    }

    class Percentage_of_bad_magnitude_of_current_for_underlimit_L1 : Register_Class
    {
        public Percentage_of_bad_magnitude_of_current_for_underlimit_L1(IEGReader eGReader) : base("0.0.128.17.15.255", eGReader) { }
    }

    class Bad_underlimit_of_the_current_magnitude : Register_Class
    {
        public Bad_underlimit_of_the_current_magnitude(IEGReader eGReader) : base("0.0.128.17.90.255", eGReader) { }
    }

    class Signal_strength_monitor_lower_threshold : Register_Class
    {
        public Signal_strength_monitor_lower_threshold(IEGReader eGReader) : base("0.0.128.20.27.255", eGReader) { }
    }

    class Signal_strength_monitor_upper_threshold : Register_Class
    {
        public Signal_strength_monitor_upper_threshold(IEGReader eGReader) : base("0.0.128.20.28.255", eGReader) { }
    }

    class Signal_strength_monitor_time_threshold : Register_Class
    {
        public Signal_strength_monitor_time_threshold(IEGReader eGReader) : base("0.0.128.20.29.255", eGReader) { }
    }

    class No_connection_timeout : Register_Class
    {
        public No_connection_timeout(IEGReader eGReader) : base("0.0.128.20.30.255", eGReader) { }
    }

    class WAN_disable_timeout : Register_Class
    {
        public WAN_disable_timeout(IEGReader eGReader) : base("0.0.128.20.32.255", eGReader) { }
    }

    class Power_on_delay : Register_Class
    {
        public Power_on_delay(IEGReader eGReader) : base("0.0.128.30.2.255", eGReader) { }
    }

    class Switch_on_delay : Register_Class
    {
        public Switch_on_delay(IEGReader eGReader) : base("0.0.128.30.3.255", eGReader) { }
    }

    class Relay_Power_on_delay : Register_Class
    {
        public Relay_Power_on_delay (IEGReader eGReader) : base("0.0.128.30.12.255", eGReader) { }
    }

    class Relay_Switch_on_delay : Register_Class
    {
        public Relay_Switch_on_delay (IEGReader eGReader) : base("0.0.128.30.13.255", eGReader) { }
    }

    class Disconnect_control_manual_connect_period : Register_Class
    {
        public Disconnect_control_manual_connect_period(IEGReader eGReader) : base("0.0.128.30.24.255", eGReader) { }
    }

    class Breaker_Power_on_delay : Register_Class
    {
        public Breaker_Power_on_delay (IEGReader eGReader) : base("0.0.128.30.27.255", eGReader) { }
    }

    class Breaker_Switch_on_delay : Register_Class
    {
        public Breaker_Switch_on_delay(IEGReader eGReader) : base("0.0.128.30.28.255", eGReader) { }
    }

    class Test_mode_timeout : Register_Class
    {
        public Test_mode_timeout(IEGReader eGReader) : base("0.0.196.1.20.255", eGReader) { }
    }

    class Service_mode_timeout : Register_Class
    {
        public Service_mode_timeout(IEGReader eGReader) : base("0.0.196.1.23.255", eGReader) { }
    }

    class Active_power_limit_hysteresis : Register_Class
    {
        public Active_power_limit_hysteresis(IEGReader eGReader) : base("0.0.196.20.2.255", eGReader) { }
    }

    class Ignore_time_threshold_voltage : Register_Class
    {
        public Ignore_time_threshold_voltage (IEGReader eGReader) : base("0.0.196.21.0.255", eGReader) {}
    }

    class Ignore_time_threshold_power : Register_Class
    {
        public Ignore_time_threshold_power(IEGReader eGReader) : base("0.0.196.21.2.255", eGReader) { }
    }

    class Residual_current_limit_hysteresis : Register_Class
    {
        public Residual_current_limit_hysteresis(IEGReader eGReader) : base("0.0.196.22.0.255", eGReader) { }
    }

    class Residual_current_over_limit_threshold : Register_Class
    {
        public Residual_current_over_limit_threshold(IEGReader eGReader) : base("0.0.196.22.1.255", eGReader) { }
    }

    class Residual_current_over_limit_time_threshold : Register_Class
    {
        public Residual_current_over_limit_time_threshold(IEGReader eGReader) : base("0.0.196.22.2.255", eGReader) { }
    }

    class Residual_current_Ignore_time_threshold : Register_Class
    {
        public Residual_current_Ignore_time_threshold(IEGReader eGReader) : base("0.0.196.22.3.255", eGReader) { }
    }

    class Residual_current_over_limit_duration : Register_Class
    {
        public Residual_current_over_limit_duration(IEGReader eGReader) : base("0.0.196.22.5.255", eGReader) { }
    }

    class Residual_current_over_limit_magnitude : Register_Class
    {
        public Residual_current_over_limit_magnitude(IEGReader eGReader) : base("0.0.196.22.6.255", eGReader) { }
    }

    class Nominal_voltage : Register_Class
    {
        public Nominal_voltage(IEGReader eGReader) : base("1.0.0.6.0.255", eGReader) { }
    }

    class Measurement_period_3 : Register_Class
    {
        public Measurement_period_3(IEGReader eGReader) : base("1.0.0.8.2.255", eGReader) { }
    }

    class Clock_time_shift_limit : Register_Class
    {
        public Clock_time_shift_limit(IEGReader eGReader) : base("1.0.0.9.11.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A(IEGReader eGReader) : base("1.0.1.2.0.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_1 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_1(IEGReader eGReader) : base("1.0.1.2.1.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_2 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_2(IEGReader eGReader) : base("1.0.1.2.2.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_3 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_3(IEGReader eGReader) : base("1.0.1.2.3.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_4 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_4(IEGReader eGReader) : base("1.0.1.2.4.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_5 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_5(IEGReader eGReader) : base("1.0.1.2.5.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_6 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_6(IEGReader eGReader) : base("1.0.1.2.6.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_7 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_7(IEGReader eGReader) : base("1.0.1.2.7.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_8 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_import_pos_A_Rate_8(IEGReader eGReader) : base("1.0.1.2.8.255", eGReader) { }
    }

    class Instantaneous_active_import_power_pos_A : Register_Class
    {
        public Instantaneous_active_import_power_pos_A(IEGReader eGReader) : base("1.0.1.7.0.255", eGReader) { }
    }

    class Active_energy_import_pos_A : Register_Class
    {
        public Active_energy_import_pos_A(IEGReader eGReader) : base("1.0.1.8.0.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Rate_1 : Register_Class
    {
        public Active_energy_import_pos_A_Rate_1(IEGReader eGReader) : base("1.0.1.8.1.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Rate_2 : Register_Class
    {
        public Active_energy_import_pos_A_Rate_2(IEGReader eGReader) : base("1.0.1.8.2.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Rate_3 : Register_Class
    {
        public Active_energy_import_pos_A_Rate_3(IEGReader eGReader) : base("1.0.1.8.3.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Rate_4 : Register_Class
    {
        public Active_energy_import_pos_A_Rate_4(IEGReader eGReader) : base("1.0.1.8.4.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Rate_5 : Register_Class
    {
        public Active_energy_import_pos_A_Rate_5(IEGReader eGReader) : base("1.0.1.8.5.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Rate_6 : Register_Class
    {
        public Active_energy_import_pos_A_Rate_6(IEGReader eGReader) : base("1.0.1.8.6.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Rate_7 : Register_Class
    {
        public Active_energy_import_pos_A_Rate_7(IEGReader eGReader) : base("1.0.1.8.7.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Rate_8 : Register_Class
    {
        public Active_energy_import_pos_A_Rate_8(IEGReader eGReader) : base("1.0.1.8.8.255", eGReader) { }
    }

    class Active_energy_import_pos_A_Total_in_billing_period_1 : Register_Class
    {
        public Active_energy_import_pos_A_Total_in_billing_period_1(IEGReader eGReader) : base("1.0.1.9.0.255", eGReader) { }
    }

    class Active_power : Register_Class
    {
        public Active_power(IEGReader eGReader) : base("1.0.1.23.0.255", eGReader) { }
    }

    class Active_import_power_pos_A : Register_Class
    {
        public Active_import_power_pos_A(IEGReader eGReader) : base("1.0.1.24.0.255", eGReader) { }
    }

    class Active_power_last_avg_3 : Register_Class
    {
        public Active_power_last_avg_3(IEGReader eGReader) : base("1.0.1.25.0.255", eGReader) { }
    }

    class Active_power_Max_3 : Register_Class
    {
        public Active_power_Max_3(IEGReader eGReader) : base("1.0.1.26.0.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A(IEGReader eGReader) : base("1.0.2.2.0.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_1 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_1(IEGReader eGReader) : base("1.0.2.2.1.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_2 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_2(IEGReader eGReader) : base("1.0.2.2.2.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_3 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_3(IEGReader eGReader) : base("1.0.2.2.3.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_4 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_4(IEGReader eGReader) : base("1.0.2.2.4.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_5 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_5(IEGReader eGReader) : base("1.0.2.2.5.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_6 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_6(IEGReader eGReader) : base("1.0.2.2.6.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_7 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_7(IEGReader eGReader) : base("1.0.2.2.7.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_8 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_export_neg_A_Rate_8(IEGReader eGReader) : base("1.0.2.2.8.255", eGReader) { }
    }

    class Instantaneous_active_export_power_neg_A : Register_Class
    {
        public Instantaneous_active_export_power_neg_A(IEGReader eGReader) : base("1.0.2.7.0.255", eGReader) { }
    }

    class Active_energy_export_neg_A : Register_Class
    {
        public Active_energy_export_neg_A(IEGReader eGReader) : base("1.0.2.8.0.255", eGReader) { }
    }

    class Active_energy_export_neg_A_Rate_1 : Register_Class
    {
        public Active_energy_export_neg_A_Rate_1(IEGReader eGReader) : base("1.0.2.8.1.255", eGReader) { }
    }

    class Active_energy_export_neg_A_Rate_2 : Register_Class
    {
        public Active_energy_export_neg_A_Rate_2(IEGReader eGReader) : base("1.0.2.8.2.255", eGReader) { }
    }

    class Active_energy_export_neg_A_Rate_3 : Register_Class
    {
        public Active_energy_export_neg_A_Rate_3(IEGReader eGReader) : base("1.0.2.8.3.255", eGReader) { }
    }

    class Active_energy_export_neg_A_Rate_4 : Register_Class
    {
        public Active_energy_export_neg_A_Rate_4(IEGReader eGReader) : base("1.0.2.8.4.255", eGReader) { }
    }

    class Active_energy_export_neg_A_Rate_5 : Register_Class
    {
        public Active_energy_export_neg_A_Rate_5(IEGReader eGReader) : base("1.0.2.8.5.255", eGReader) { }
    }

    class Active_energy_export_neg_A_Rate_6 : Register_Class
    {
        public Active_energy_export_neg_A_Rate_6(IEGReader eGReader) : base("1.0.2.8.6.255", eGReader) { }
    }

    class Active_energy_export_neg_A_Rate_7 : Register_Class
    {
        public Active_energy_export_neg_A_Rate_7(IEGReader eGReader) : base("1.0.2.8.7.255", eGReader) { }
    }

    class Active_energy_export_neg_A_Rate_8 : Register_Class
    {
        public Active_energy_export_neg_A_Rate_8(IEGReader eGReader) : base("1.0.2.8.8.255", eGReader) { }
    }

    class Active_export_power_neg_A_overlimit_threshold : Register_Class
    {
        public Active_export_power_neg_A_overlimit_threshold(IEGReader eGReader) : base("1.0.2.35.0.255", eGReader) { }
    }

    class Active_export_power_neg_A_overlimit_time_threshold : Register_Class
    {
        public Active_export_power_neg_A_overlimit_time_threshold(IEGReader eGReader) : base("1.0.2.44.0.255", eGReader) { }
    }

    class Threshold_for_voltage_sag : Register_Class
    {
        public Threshold_for_voltage_sag(IEGReader eGReader) : base("1.0.12.31.0.255", eGReader) {}
    }

    class Threshold_for_voltage_swell : Register_Class
    {
        public Threshold_for_voltage_swell(IEGReader eGReader) : base("1.0.12.35.0.255", eGReader) { }
    }

    class Threshold_for_missing_voltage_voltage_cut : Register_Class
    {
        public Threshold_for_missing_voltage_voltage_cut(IEGReader eGReader) : base("1.0.12.39.0.255", eGReader) { }
    }

    class Time_threshold_for_voltage_sag : Register_Class
    {
        public Time_threshold_for_voltage_sag(IEGReader eGReader) : base("1.0.12.43.0.255", eGReader) { }
    }

    class Time_threshold_for_voltage_swell : Register_Class
    {
        public Time_threshold_for_voltage_swell(IEGReader eGReader) : base("1.0.12.44.0.255", eGReader) { }
    }

    class Time_threshold_for_voltage_cut : Register_Class
    {
        public Time_threshold_for_voltage_cut(IEGReader eGReader) : base("1.0.12.45.0.255", eGReader) { }
    }

    class Threshold_for_power_failure_on_all_phases : Register_Class
    {
        public Threshold_for_power_failure_on_all_phases(IEGReader eGReader) : base("1.0.12.128.0.255", eGReader) { }
    }

    class Instantaneous_power_factor_pos_apparent : Register_Class
    {
        public Instantaneous_power_factor_pos_apparent(IEGReader eGReader) : base("1.0.13.7.0.255", eGReader) { }
    }

    class Power_factor : Register_Class
    {
        public Power_factor(IEGReader eGReader) : base("1.0.13.23.0.255", eGReader) { }
    }

    class Power_factor_Avg_3 : Register_Class
    {
        public Power_factor_Avg_3(IEGReader eGReader) : base("1.0.13.24.0.255", eGReader) { }
    }

    class Power_factor_last_avg_3 : Register_Class
    {
        public Power_factor_last_avg_3 (IEGReader eGReader) : base("1.0.13.25.0.255", eGReader) { }
    }

    class Power_factor_Max_3 : Register_Class
    {
        public Power_factor_Max_3(IEGReader eGReader) : base("1.0.13.26.0.255", eGReader) { }
    }

    class Instantaneous_net_frequency_any_phase : Register_Class
    {
        public Instantaneous_net_frequency_any_phase(IEGReader eGReader) : base("1.0.14.7.0.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_neg_A : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_neg_A(IEGReader eGReader) : base("1.0.15.2.0.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_1 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_1(IEGReader eGReader) : base("1.0.15.2.1.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_2 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_2(IEGReader eGReader) : base("1.0.15.2.2.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_3 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_3(IEGReader eGReader) : base("1.0.15.2.3.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_4 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_4(IEGReader eGReader) : base("1.0.15.2.4.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_5 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_5(IEGReader eGReader) : base("1.0.15.2.5.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_6 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_6(IEGReader eGReader) : base("1.0.15.2.6.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_7 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_7(IEGReader eGReader) : base("1.0.15.2.7.255", eGReader) { }
    }

    class Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_8 : Register_Class
    {
        public Cumulative_maximum_demand_register_Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_8(IEGReader eGReader) : base("1.0.15.2.8.255", eGReader) { }
    }

    class Instantaneous_active_power_combined_Abs_A_plus_Abs_neg_A : Register_Class
    {
        public Instantaneous_active_power_combined_Abs_A_plus_Abs_neg_A(IEGReader eGReader) : base("1.0.15.7.0.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A(IEGReader eGReader) : base("1.0.15.8.0.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_1 : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_1(IEGReader eGReader) : base("1.0.15.8.1.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_2 : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_2(IEGReader eGReader) : base("1.0.15.8.2.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_3 : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_3(IEGReader eGReader) : base("1.0.15.8.3.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_4 : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_4(IEGReader eGReader) : base("1.0.15.8.4.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_5 : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_5(IEGReader eGReader) : base("1.0.15.8.5.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_6 : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_6(IEGReader eGReader) : base("1.0.15.8.6.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_7 : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_7(IEGReader eGReader) : base("1.0.15.8.7.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_8 : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Rate_8(IEGReader eGReader) : base("1.0.15.8.8.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_plus_Abs_neg_A_Current_billing_period : Register_Class
    {
        public Active_energy_combined_Abs_A_plus_Abs_neg_A_Current_billing_period(IEGReader eGReader) : base("1.0.15.9.0.255", eGReader) { }
    }

    class Instantaneous_active_power_combined_Abs_A_minus_Abs_neg_A : Register_Class
    {
        public Instantaneous_active_power_combined_Abs_A_minus_Abs_neg_A(IEGReader eGReader) : base("1.0.16.7.0.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A(IEGReader eGReader) : base("1.0.16.8.0.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_1 : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_1(IEGReader eGReader) : base("1.0.16.8.1.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_2 : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_2(IEGReader eGReader) : base("1.0.16.8.2.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_3 : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_3(IEGReader eGReader) : base("1.0.16.8.3.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_4 : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_4(IEGReader eGReader) : base("1.0.16.8.4.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_5 : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_5(IEGReader eGReader) : base("1.0.16.8.5.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_6 : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_6(IEGReader eGReader) : base("1.0.16.8.6.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_7 : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_7(IEGReader eGReader) : base("1.0.16.8.7.255", eGReader) { }
    }

    class Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_8 : Register_Class
    {
        public Active_energy_combined_Abs_A_minus_Abs_neg_A_Rate_8(IEGReader eGReader) : base("1.0.16.8.8.255", eGReader) { }
    }

    class Instantaneous_active_import_power_pos_A_L1 : Register_Class
    {
        public Instantaneous_active_import_power_pos_A_L1(IEGReader eGReader) : base("1.0.21.7.0.255", eGReader) { }
    }

    class Active_energy_import_pos_A_L1 : Register_Class
    {
        public Active_energy_import_pos_A_L1(IEGReader eGReader) : base("1.0.21.8.0.255", eGReader) { }
    }

    class Instantaneous_active_export_power_neg_A_L1 : Register_Class
    {
        public Instantaneous_active_export_power_neg_A_L1(IEGReader eGReader) : base("1.0.22.7.0.255", eGReader) { }
    }

    class Active_energy_export_neg_A_L1 : Register_Class
    {
        public Active_energy_export_neg_A_L1(IEGReader eGReader) : base("1.0.22.8.0.255", eGReader) { }
    }

    class Active_export_power_neg_A_L1_overlimit_duration : Register_Class
    {
        public Active_export_power_neg_A_L1_overlimit_duration(IEGReader eGReader) : base("1.0.22.37.0.255", eGReader) { }
    }

    class Active_export_power_neg_A_L1_overlimit_magnitude : Register_Class
    {
        public Active_export_power_neg_A_L1_overlimit_magnitude(IEGReader eGReader) : base("1.0.22.38.0.255", eGReader) { }
    }

    class Instantaneous_current_L1 : Register_Class
    {
        public Instantaneous_current_L1(IEGReader eGReader) : base("1.0.31.7.0.255", eGReader) { }
    }

    class L1_Current_Min_3 : Register_Class
    {
        public L1_Current_Min_3(IEGReader eGReader) : base("1.0.31.23.0.255", eGReader) { }
    }

    class L1_Current_Avg_3 : Register_Class
    {
        public L1_Current_Avg_3(IEGReader eGReader) : base("1.0.31.24.0.255", eGReader) { }
    }

    class L1_Current_Last_Avg_3 : Register_Class
    {
        public L1_Current_Last_Avg_3(IEGReader eGReader) : base("1.0.31.25.0.255", eGReader) { }
    }

    class L1_Current_Max_3 : Register_Class
    {
        public L1_Current_Max_3(IEGReader eGReader) : base("1.0.31.26.0.255", eGReader) { }
    }

    class Instantaneous_voltage_L1 : Register_Class
    {
        public Instantaneous_voltage_L1(IEGReader eGReader) : base("1.0.32.7.0.255", eGReader) { }
    }

    class L1_Voltage_Min_3 : Register_Class
    {
        public L1_Voltage_Min_3(IEGReader eGReader) : base("1.0.32.23.0.255", eGReader) { }
    }

    class L1_Voltage_Avg_3 : Register_Class
    {
        public L1_Voltage_Avg_3(IEGReader eGReader) : base("1.0.32.24.0.255", eGReader) { }
    }

    class L1_Voltage_Last_Avg_3 : Register_Class
    {
        public L1_Voltage_Last_Avg_3(IEGReader eGReader) : base("1.0.32.25.0.255", eGReader) { }
    }

    class L1_Voltage_Max_3 : Register_Class
    {
        public L1_Voltage_Max_3(IEGReader eGReader) : base("1.0.32.26.0.255", eGReader) { }
    }

    class Duration_of_last_voltage_sag_in_phase_L1 : Register_Class
    {
        public Duration_of_last_voltage_sag_in_phase_L1(IEGReader eGReader) : base("1.0.32.33.0.255", eGReader) { }
    }

    class Magnitude_of_last_voltage_sag_in_phase_L1 : Register_Class
    {
        public Magnitude_of_last_voltage_sag_in_phase_L1(IEGReader eGReader) : base("1.0.32.34.0.255", eGReader) { }
    }

    class Duration_of_last_voltage_swell_in_phase_L1 : Register_Class
    {
        public Duration_of_last_voltage_swell_in_phase_L1(IEGReader eGReader) : base("1.0.32.37.0.255", eGReader) { }
    }

    class Magnitude_of_last_voltage_swell_in_phase_L1 : Register_Class
    {
        public Magnitude_of_last_voltage_swell_in_phase_L1(IEGReader eGReader) : base("1.0.32.38.0.255", eGReader) { }
    }

    class Instantaneous_power_factor_pos_apparent_L1 : Register_Class
    {
        public Instantaneous_power_factor_pos_apparent_L1(IEGReader eGReader) : base("1.0.33.7.0.255", eGReader) { }
    }

    class Instantaneous_active_power_combined_Abs_A_plus_Abs_neg_A_L1 : Register_Class
    {
        public Instantaneous_active_power_combined_Abs_A_plus_Abs_neg_A_L1(IEGReader eGReader) : base("1.0.35.7.0.255", eGReader) { }
    }

    class Instantaneous_active_power_combined_Abs_A_minus_Abs_neg_A_L1 : Register_Class
    {
        public Instantaneous_active_power_combined_Abs_A_minus_Abs_neg_A_L1(IEGReader eGReader) : base("1.0.36.7.0.255", eGReader) { }
    }

    class Instantaneous_power_factor_negative_neg_apparent : Register_Class
    {
        public Instantaneous_power_factor_negative_neg_apparent(IEGReader eGReader) : base("1.0.84.7.0.255", eGReader) { }
    }

    class Total_Li_Power_factor_Min_3 : Register_Class
    {
        public Total_Li_Power_factor_Min_3 (IEGReader eGReader) : base("1.0.84.23.0.255", eGReader) { }
    }

    class Total_Li_Power_factor_Current_Avg_3 : Register_Class
    {
        public Total_Li_Power_factor_Current_Avg_3(IEGReader eGReader) : base("1.0.84.24.0.255", eGReader) { }
    }

    class Total_Li_Power_factor_Last_Avg_3 : Register_Class
    {
        public Total_Li_Power_factor_Last_Avg_3(IEGReader eGReader) : base("1.0.84.25.0.255", eGReader) { }
    }

    class Total_Li_Power_factor_Max_3 : Register_Class
    {
        public Total_Li_Power_factor_Max_3(IEGReader eGReader) : base("1.0.84.26.0.255", eGReader) { }
    }

    class Instantaneous_power_factor_negative_neg_apparent_L1 : Register_Class
    {
        public Instantaneous_power_factor_negative_neg_apparent_L1(IEGReader eGReader) : base("1.0.85.7.0.255", eGReader) { }
    }

    class Instantaneous_current_sum_over_all_phases : Register_Class
    {
        public Instantaneous_current_sum_over_all_phases(IEGReader eGReader) : base("1.0.90.7.0.255", eGReader) { }
    }

    class Instantaneous_current_neutral : Register_Class
    {
        public Instantaneous_current_neutral(IEGReader eGReader) : base("1.0.91.7.0.255", eGReader) { }
    }

    class RMS_filtered_current_neutral : Register_Class
    {
        public RMS_filtered_current_neutral(IEGReader eGReader) : base("1.0.91.128.0.255", eGReader) {}
    }

    class Instantaneous_current_residual : Register_Class
    {
        public Instantaneous_current_residual(IEGReader eGReader) : base("1.0.128.7.0.255", eGReader) { }
    }

    class RMS_filtered_current_residual : Register_Class
    {
        public RMS_filtered_current_residual(IEGReader eGReader) : base("1.0.128.128.0.255", eGReader) { }
    }

    class Active_energy_import_test_total_pos_A : Register_Class
    {
        public Active_energy_import_test_total_pos_A(IEGReader eGReader) : base("1.128.1.8.0.255", eGReader) { }
    }

    class Active_energy_export_test_total_neg_A : Register_Class
    {
        public Active_energy_export_test_total_neg_A(IEGReader eGReader) : base("1.128.2.8.0.255", eGReader) { }
    }



}
