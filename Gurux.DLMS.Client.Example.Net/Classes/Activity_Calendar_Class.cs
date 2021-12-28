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

            this.Week_profile_table_passive = myProfileList;
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

            this.Week_profile_table_passive = myProfileList;


            return myProfileList;
        }
        
        public GXStructure Create_Day_Action(int hour, int minute, int second, int millisecond, string ScriptLogicalName, ushort scriptSelector)
        {
            GXStructure _ = new GXStructure();

            byte[] startTime = new byte[4] { (byte) hour, (byte) minute, (byte) second, (byte) millisecond};
            _.Add(startTime);
            
            byte[] script = GXDLMSConverter.LogicalNameToBytes(ScriptLogicalName);
            _.Add(script);
            
            _.Add((object)scriptSelector);
            return _;
        }
        
        public GXStructure Create_Day_Profile (int Day_ID, int hour, int minute, int second, int millisecond, string ScriptLogicalName, ushort scriptSelector)
        {
            

            GXStructure day = new GXStructure();

            byte dayID = (byte) Day_ID;

            GXArray actions = new GXArray();
            //5, 20, 0, 0,"0.0.10.7.0.255", 1
            actions.Add(this.Create_Day_Action(hour, minute, second, millisecond, ScriptLogicalName, scriptSelector));

            day.Add(dayID);
            day.Add(actions);

            return day;
        }

        public void ReplaceAll_Day_profiles(int Day_ID, int hour, int minute, int second, int millisecond, string ScriptLogicalName, ushort scriptSelector)
        {
            GXArray new_day = new GXArray { this.Create_Day_Profile(Day_ID, hour, minute, second, millisecond, ScriptLogicalName, scriptSelector) };
            this.eGReader.Write_Value_Object_Attribute(this.OBIS, 9, new_day);
        }

        public void Add_New_Day_to_Exciting_Profile(int Day_ID, int hour, int minute, int second, int millisecond, string ScriptLogicalName, ushort scriptSelector)
        {
            GXDLMSDayProfile[] exciting_profile = (GXDLMSDayProfile[])this.Day_profile_table_passive;

            GXArray myDays = new GXArray();

            foreach (GXDLMSDayProfile dayProfile in exciting_profile)
            {
             
                int my_day_ID = dayProfile.DayId;
                
                GXDLMSDayProfileAction[] actions = dayProfile.DaySchedules;
                GXArray myactions = new GXArray();
                foreach (GXDLMSDayProfileAction action in actions)
                {
                    int day_hour = action.StartTime.Value.Hour;
                    int day_minute = action.StartTime.Value.Minute;
                    int day_second = action.StartTime.Value.Second;
                    int day_millisecond = action.StartTime.Value.Second;
                    string day_ScriptLogicalName = action.ScriptLogicalName;
                    ushort day_scriptSelector = (ushort)action.ScriptSelector;

                    myactions.Add(this.Create_Day_Action(day_hour, day_minute, day_second, day_millisecond, day_ScriptLogicalName, day_scriptSelector));
                }

                GXStructure current_day = new GXStructure { my_day_ID, myactions };
                myDays.Add(current_day);
            }

            GXStructure new_day = Create_Day_Profile(Day_ID, hour, minute, second, millisecond, ScriptLogicalName, scriptSelector);
            myDays.Add(new_day);

            this.eGReader.Write_Value_Object_Attribute(this.OBIS, 9, myDays);

        }

        public void Add_New_Action_to_Exicting_Day_Actions(int Desired_Day_ID, int hour, int minute, int second, int millisecond, string ScriptLogicalName, ushort scriptSelector)
        {
            GXDLMSDayProfile[] exciting_profile = (GXDLMSDayProfile[])this.Day_profile_table_passive;

            GXArray myDays = new GXArray();

            foreach (GXDLMSDayProfile dayProfile in exciting_profile)
            {

                if (dayProfile.DayId == Desired_Day_ID)
                {
                    GXDLMSDayProfileAction[] actions = dayProfile.DaySchedules;
                    GXArray myactions = new GXArray();
                    
                    foreach (GXDLMSDayProfileAction action in actions)
                    {
                        int day_hour = action.StartTime.Value.Hour;
                        int day_minute = action.StartTime.Value.Minute;
                        int day_second = action.StartTime.Value.Second;
                        int day_millisecond = action.StartTime.Value.Second;
                        string day_ScriptLogicalName = action.ScriptLogicalName;
                        ushort day_scriptSelector = (ushort)action.ScriptSelector;

                        myactions.Add(this.Create_Day_Action(day_hour, day_minute, day_second, day_millisecond, day_ScriptLogicalName, day_scriptSelector));
                    }
                    myactions.Add(this.Create_Day_Action(hour, minute, second, millisecond, ScriptLogicalName, scriptSelector));
                    
                    GXStructure current_day = new GXStructure { Desired_Day_ID, myactions };
                    myDays.Add(current_day);
                }
                else
                {
                    int my_day_ID = dayProfile.DayId;

                    GXDLMSDayProfileAction[] actions = dayProfile.DaySchedules;
                    GXArray myactions = new GXArray();
                    foreach (GXDLMSDayProfileAction action in actions)
                    {
                        int day_hour = action.StartTime.Value.Hour;
                        int day_minute = action.StartTime.Value.Minute;
                        int day_second = action.StartTime.Value.Second;
                        int day_millisecond = action.StartTime.Value.Second;
                        string day_ScriptLogicalName = action.ScriptLogicalName;
                        ushort day_scriptSelector = (ushort)action.ScriptSelector;

                        myactions.Add(this.Create_Day_Action(day_hour, day_minute, day_second, day_millisecond, day_ScriptLogicalName, day_scriptSelector));
                    }

                    GXStructure current_day = new GXStructure { my_day_ID, myactions };
                    myDays.Add(current_day);
                }

            }

            this.eGReader.Write_Value_Object_Attribute(this.OBIS, 9, myDays);
        }
        
        
        
        public byte[] CreateSeason_NotDefined()
        {
            byte[] result = new byte[12];
            result[0] = (byte)255;
            result[1] = (byte)255;
            result[2] = (byte)255;
            result[3] = (byte)255;
            result[4] = (byte)255;
            result[5] = (byte)255;
            result[6] = (byte)255;
            result[7] = (byte)255;
            result[8] = (byte)255;
            result[9] = (byte)128;
            result[10] = (byte)0;
            result[11] = (byte)255;

            return result;
        }
        public byte[] CreateSeason_Single(int hour, int minute, int seconds, int day, int month, int year)
        {

            ulong number = (ulong)year;
            byte upper = (byte)(number >> 8);
            byte lower = (byte)(number & 0xff);

           



          

            DateTime dateTime = new DateTime(year, month, day, hour, minute, seconds);
            int myDayofWeek = (int)dateTime.DayOfWeek;

            if (myDayofWeek == 0)
                myDayofWeek = 7;

                byte[] result = new byte[12];
            result[0] = upper;
            result[1] = lower;
            result[2] = (byte)month;
            result[3] = (byte)day;
            result[4] = (byte)myDayofWeek;
            result[5] = (byte)hour;
            result[6] = (byte)minute;
            result[7] = (byte)seconds;
            result[8] = (byte)0;
            result[9] = (byte)128;
            result[10] = (byte)0;
            result[11] = (byte)255;

            return result;

        }
        public byte[] CreateSeason_EveryDay(int hour, int minute, int seconds)
        {
         
            byte[] result = new byte[12];
            result[0] = (byte)255;
            result[1] = (byte)255;
            result[2] = (byte)255;
            result[3] = (byte)255;
            result[4] = (byte)255;
            result[5] = (byte)hour;
            result[6] = (byte)minute;
            result[7] = (byte)seconds;
            result[8] = (byte)0;
            result[9] = (byte)128;
            result[10] = (byte)0;
            result[11] = (byte)255;

            return result;
        }
        public enum DaysOfWeek { Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday};

        public enum EveryMonthEnum
        {
            OnDay,
            SecondLastDay = 253,
            LastDay
        };
         public enum EveryYearEnum
        {
            OnDay,
            first=1,
            second=8,
            third=15,
            fourth=22,
            last,
            secondLast=253,
            LastDay=254
        };

        public byte[] CreateSeason_EveryWeek(DaysOfWeek dayOfWeek, int hour, int minute, int seconds)
        {
            
            byte[] result = new byte[12];
            result[0] = (byte)255;
            result[1] = (byte)255;
            result[2] = (byte)255;
            result[3] = (byte)255;
            result[4] = (byte)dayOfWeek;
            result[5] = (byte)hour;
            result[6] = (byte)minute;
            result[7] = (byte)seconds;
            result[8] = (byte)0;
            result[9] = (byte)128;
            result[10] = (byte)0;
            result[11] = (byte)255;

            return result;
        }

        public byte[] CreateSeason_EveryMonth(EveryMonthEnum option, int Day, int hour, int minute, int seconds )
        {


            byte[] result = new byte[12];
            result[0] = (byte)255;
            result[1] = (byte)255;
            result[2] = (byte)255;

            if (option == EveryMonthEnum.OnDay)
                result[3] = (byte)Day;
            else
                result[3] = (byte)option;

            result[4] = (byte)255;
            result[5] = (byte)hour;
            result[6] = (byte)minute;
            result[7] = (byte)seconds;
            result[8] = (byte)0;
            result[9] = (byte)128;
            result[10] = (byte)0;
            result[11] = (byte)255;

            return result;
        }
        public byte[] CreateSeason_EveryYear(EveryYearEnum option, int hour, int minute, int seconds, DaysOfWeek daysOfWeek, int Day, int month, int year)
        {
            int myDayofWeek = 0;
            try {
                DateTime dateTime = new DateTime(year, month, Day, hour, minute, seconds);
                 myDayofWeek = (int)dateTime.DayOfWeek;

                if (myDayofWeek == 0)
                    myDayofWeek = 7;
            }
            catch { }
            

            byte[] result = new byte[12];
            result[0] = (byte)255;
            result[1] = (byte)255;
            result[2] = (byte)month;
            if (option == EveryYearEnum.OnDay)
            {
                result[3] = (byte)Day;
            }
            else if (option == EveryYearEnum.last)
                result[3] = (byte)254;
            else
                result[3] = (byte)option;




           
           
            if(option == EveryYearEnum.secondLast || option == EveryYearEnum.LastDay || option == EveryYearEnum.OnDay)
            {
                result[4] = (byte)255;
            }
            else 
            {
                result[4] = (byte)daysOfWeek;
            }



            result[5] = (byte)hour;
            result[6] = (byte)minute;
            result[7] = (byte)seconds;
            result[8] = (byte)0;
            result[9] = (byte)128;
            result[10] = (byte)0;
            result[11] = (byte)255;

            return result;
        }

        public void CreateSeasonProfile()
        {
 

            byte[] season_name = new byte[] { (byte)5 };

            byte[] week_name = new byte[] { (byte)5 };

            this.eGReader.Write_Value_Object_Attribute(this.OBIS, 7, new GXArray {
            new GXStructure { season_name, CreateSeason_EveryMonth(EveryMonthEnum.SecondLastDay,2,16,21,28), new byte[] { (byte)5 } },
            new GXStructure { season_name, CreateSeason_EveryYear(EveryYearEnum.first,17,52,6,DaysOfWeek.Thursday,28,4,2023), new byte[] { (byte)5 } },
            new GXStructure { season_name, CreateSeason_EveryYear(EveryYearEnum.second,17,52,6,DaysOfWeek.Thursday,28,4,2023), new byte[] { (byte)5 } },
            new GXStructure { season_name, CreateSeason_EveryYear(EveryYearEnum.third,17,52,6,DaysOfWeek.Thursday,28,4,2023), new byte[] { (byte)5 } }

            });
        }
        public byte[] DateTimeByte(DateTime myDate)
        {
            int year = myDate.Year;
            int Month = myDate.Month;
            int Day = myDate.Day;

            float temp1 = (((float)year - 7) / 255);
            float temp2 = temp1 - (int) temp1;
            float temp3 = temp2 * 255 + (float)0.1;

            


            byte[] result = new byte[] { 
            (byte)(int) temp1,
            (byte)(int) temp3

            };


            return null;
        }
        
        
        
        public void Activate_passive_calendar()
        {
            this.eGReader.Execute_Method_Without_Datatype(this.OBIS, 1, (sbyte)0);
        }

        public void Set_season_profile()
        {
            GXDateTimeOS starttime = new GXDateTimeOS(DateTime.Now);
            
            GXDLMSSeasonProfile seasonProfile = new GXDLMSSeasonProfile("6", starttime, "6");

            GXDLMSActivityCalendar activityCalendar = new GXDLMSActivityCalendar(this.OBIS);

            activityCalendar.SeasonProfilePassive = new GXDLMSSeasonProfile[] { seasonProfile };

            this.eGReader.Write_Value_Object_Attribute(this.OBIS, 7, new GXDLMSSeasonProfile[] { seasonProfile });
        }

        public static byte[] Combine(byte[][] arrays)
        {
            byte[] bytes = new byte[0];

            foreach (byte[] b in arrays)
            {
                bytes.Concat(b);
            }

            return bytes.ToArray();
        }
        public void Create_Season_Profile_Struct()
        {
            byte[] season_name = new byte[] { (byte)5 };

            GXDateTime f = DateTime.Now;
            //DateTime f = new DateTime();

            byte hiYear = BitConverter.GetBytes(f.Value.Year)[0];
            byte loYear = BitConverter.GetBytes(f.Value.Year)[1];
            byte month = BitConverter.GetBytes(f.Value.Month)[0];
            byte DayOfmonth = BitConverter.GetBytes(f.Value.Day)[0];
            byte DayOfWeek = BitConverter.GetBytes((int)f.Value.DayOfWeek)[0];
            byte Hour = BitConverter.GetBytes(f.Value.Hour)[0];
            byte Minute = BitConverter.GetBytes(f.Value.Minute)[0];
            byte Second = BitConverter.GetBytes(f.Value.Second)[0];
            byte Millisecond = BitConverter.GetBytes(f.Value.Millisecond)[1];
            byte hiDeviation = (byte)0x80;
            byte loDeviation = (byte)0x00;
            byte clock = 0xFF;
            byte[] starttime = new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek, Hour, Minute, Second, Millisecond, hiDeviation, loDeviation, clock };




            //byte [] starttime = Encoding.ASCII.GetBytes(f.ToHex(false, false));
            byte[] week_name = new byte[] { (byte)5 };

            //byte[] starttime = new byte[] { (byte)255,(byte)255,(byte)1,(byte)1,(byte)1,(byte)0,(byte)0,(byte)0,(byte)0,(byte)128,(byte)0,(byte)255};
            
            

            GXStructure ___ = new GXStructure { season_name, starttime, week_name };

            GXArray ff = new GXArray { ___ };

            this.eGReader.Write_Value_Object_Attribute(this.OBIS, 7, ff);

            
        }
    }

    class Activity_Calendar_Tariff : Activity_Calendar_Class
    {
        public Activity_Calendar_Tariff(IEGReader eGReader) : base("0.0.13.0.0.255", eGReader) { }
    }
    
    class Activity_Calendar_Breaker : Activity_Calendar_Class
    {
        public Activity_Calendar_Breaker(IEGReader eGReader) : base("0.0.13.0.1.255", eGReader) { }
    }

    class Activity_Calendar_Relay : Activity_Calendar_Class
    {
        public Activity_Calendar_Relay(IEGReader eGReader) : base("0.0.13.0.2.255", eGReader) { }
    }

    class Friendly_hours_activity_calendar : Activity_Calendar_Class
    {
        public Friendly_hours_activity_calendar(IEGReader eGReader) : base("0.0.13.0.3.255", eGReader) { }
    }
}

