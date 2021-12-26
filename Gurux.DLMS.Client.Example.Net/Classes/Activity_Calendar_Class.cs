using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gurux.DLMS.Objects;

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
                GXDLMSDayProfile[] daysProfiles = (GXDLMSDayProfile[])this.Day_profile_table_passive;

                daysProfiles = daysProfiles.Concat( new GXDLMSDayProfile[] { this.Create_Day_Profile(5, 5, 20, 0, 0, "0.0.10.7.0.255", 1) }).ToArray();
                

          
                _ = value;
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 9, daysProfiles);
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

<<<<<<< HEAD
        public GXDLMSWeekProfile[] Create_Week_Profile(int Name, int Saturday, int Sunday, int Monday, int Tuesday, int Wednesday, int Thursday, int Friday)
        {
            byte ByteName = (byte)Name;
            byte[] ByteNameArray = new byte[1];
            ByteNameArray[0] = ByteName;

            GXDLMSWeekProfile myProfile = new GXDLMSWeekProfile();
            myProfile.Name = ByteNameArray;
            myProfile.Saturday = Saturday;
            myProfile.Sunday = Sunday;
            myProfile.Monday = Monday;
            myProfile.Tuesday = Tuesday;
            myProfile.Wednesday = Wednesday;
            myProfile.Thursday = Thursday;
            myProfile.Friday = Friday;


            GXDLMSWeekProfile[] myProfileArray = new GXDLMSWeekProfile[]
                {
                myProfile
                };
           

            return myProfileArray;
=======
        public GXDLMSDayProfile Create_Day_Profile(int dayID, int hour, int minute, int second, int millisecond, string scriptLogicalName_OBIS, ushort scriptSelector)
        {

            GXTime startTime = new GXTime(hour, minute, second, millisecond);
            GXDLMSDayProfileAction dayAction = new GXDLMSDayProfileAction(startTime, scriptLogicalName_OBIS, scriptSelector);

            GXDLMSDayProfileAction[] dayProfileActions = new GXDLMSDayProfileAction[]
            {
                dayAction
            };

            GXDLMSDayProfile dayProfile = new GXDLMSDayProfile(dayID, dayProfileActions);

            return dayProfile;
>>>>>>> 953e3ece00934e84bbd5c9e1eb78382ab8871c9d
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

