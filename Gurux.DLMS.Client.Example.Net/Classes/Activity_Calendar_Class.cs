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
                //object daysProfiles = this.Create_Day_Profile(5, 5, 20, 0, 0, 1) ;

                //daysProfiles = daysProfiles.Concat( new GXDLMSDayProfile[] { this.Create_Day_Profile(5, 5, 20, 0, 0, 1) }).ToArray();

                /*GXDLMSDayProfile[] daysProfiless = new GXDLMSDayProfile[3];
                foreach (GXDLMSDayProfile dayprofile in daysProfiles)
                {
                    daysProfiless.
                }*/

          
                _ = value;
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 9, this.create_Day());
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

        public GXStructure ConvertWeekToGXStructure(GXDLMSWeekProfile SingleWeek)
        {
            GXStructure structure = new GXStructure();
            structure.Add(SingleWeek.Name);//(byte[])item[0];
            structure.Add(SingleWeek.Monday);//Convert.ToInt32(item[1]);
            structure.Add(SingleWeek.Tuesday);//Convert.ToInt32(item[2]);
            structure.Add(SingleWeek.Wednesday);//Convert.ToInt32(item[3]);
            structure.Add(SingleWeek.Thursday);//Convert.ToInt32(item[4]);
            structure.Add(SingleWeek.Friday);//Convert.ToInt32(item[5]);
            structure.Add(SingleWeek.Saturday);//Convert.ToInt32(item[6]);
            structure.Add(SingleWeek.Sunday);//Convert.ToInt32(item[7]);
            return structure;

        }

        public GXArray ConvertWeekProfileToGXArray(GXDLMSWeekProfile[] WeekProfile)
        {
            GXArray WeekArray = new GXArray();
            foreach(GXDLMSWeekProfile week in WeekProfile)
            {
                WeekArray.Add(ConvertWeekToGXStructure(week));
            }
            return WeekArray;
        }

        public GXArray Replace_Week_Profile(int Name, int Saturday, int Sunday, int Monday, int Tuesday, int Wednesday, int Thursday, int Friday)
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

            GXStructure structure = ConvertWeekToGXStructure(myProfile);
            GXArray myProfileList = new GXArray();
            myProfileList.Add(structure);


            return myProfileList;
        }

        public GXArray Add_Week_Profile(int Name, int Saturday, int Sunday, int Monday, int Tuesday, int Wednesday, int Thursday, int Friday)
        {

            object CurrentWeekProfile = Week_profile_table_passive;

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




            GXStructure structure = ConvertWeekToGXStructure(myProfile);

            GXArray myProfileList = ConvertWeekProfileToGXArray((GXDLMSWeekProfile[])CurrentWeekProfile);
            myProfileList.Add(structure);


            return myProfileList;
        }


        public List<object> Create_Day_Profile(int dayID, int hour, int minute, int second, int millisecond, ushort scriptSelector)
        {

            GXTime startTime = new GXTime(hour, minute, second, millisecond);
            GXDLMSDayProfileAction dayAction = new GXDLMSDayProfileAction(startTime, this.OBIS, scriptSelector);

            GXDLMSDayProfileAction[] dayProfileActions = new GXDLMSDayProfileAction[]
            {
                dayAction
            };

            GXDLMSDayProfile dayProfile = new GXDLMSDayProfile(dayID, dayProfileActions);

            List<object> _ = new List<object> { (object) dayProfile };
            return _;

        }
        
        public GXStructure dayaction(int hour, int minute, int second, int millisecond, ushort scriptSelector)
        {
            GXStructure _ = new GXStructure();

            GXTime startTime = new GXTime(hour, minute, second, millisecond);

            _.Add(BitConverter.GetBytes((int)startTime.Value.Ticks));

            _.Add(GXDLMSConverter.LogicalNameToBytes("0.0.10.7.0.255"));

            _.Add((object)scriptSelector);

            return _;
        }
        public GXArray create_Day ()
        {
            //int DayID, int hour, int minute, int second, int millisecond, ushort scriptSelector
            GXArray _ = new GXArray();

            GXStructure day_ = new GXStructure();
            byte dayID = (byte) 5;
            GXArray actions = new GXArray();
            actions.Add(this.dayaction(5, 20, 0, 0, 1));

            day_.Add(dayID);
            day_.Add(actions);

            _.Add(day_);
            return _;
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

