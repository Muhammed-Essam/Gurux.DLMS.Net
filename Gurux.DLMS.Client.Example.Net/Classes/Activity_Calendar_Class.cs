using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Activity_Calendar_Class
    {
        readonly string OBIS;
        IEGReader eGReader;

        public Activity_Calendar_Class(string OBIS, IEGReader eGReader)
        {
            this.eGReader = eGReader;
            this.OBIS = OBIS;
        }

        public object Calendar_name_active
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 2);
            }
        }
        public object Season_profile_active
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 3);
            }
        }

        public object Week_profile_table_active
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 4);
            }
        }

        public object Day_profile_table_active
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 5);
            }
        }

        public object Calendar_name_passive 
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 6);
            }

            set
            {
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 6, value);
            } 
        }

        public object Season_profile_passive
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 7);
            }

            set
            {
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 7, value);
            }
        }

        public object Week_profile_table_passive
        {
            get => this.eGReader.Read_Object_Attribute(this.OBIS, 8);

            set
            {
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 8, value);
            }
        }

        public object Day_profile_table_passive
        {
            get => this.eGReader.Read_Object_Attribute(this.OBIS, 9);

            set
            {
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 9, value);
            }
        }

        public object Activate_passive_calendar_time
        {
            get => this.eGReader.Read_Object_Attribute(this.OBIS, 10);

            set
            {
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 10, value);
            }
        }

        public object Create_Day_Profile()
        {
            GXDLMSDay
        }

        public void Activate_passive_calendar()
        {
            
        }
    }

    class Activity_Calendar_Tariff : Activity_Calendar_Class
    {
        public Activity_Calendar_Tariff(IEGReader eGReader) : base("0.0.13.0.0.255", eGReader) { }
    }

    class Friendly_hours_activity_calendar : Activity_Calendar_Class
    {
        public Friendly_hours_activity_calendar(IEGReader eGReader) : base("0.0.13.0.3.255", eGReader) { }
    }
}

