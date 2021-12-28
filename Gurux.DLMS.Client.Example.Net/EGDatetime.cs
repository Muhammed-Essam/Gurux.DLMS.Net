using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net
{
    class EGDatetime : GXDateTime 
    {
        public enum DaysOfWeek
        {
            Monday = 1,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        };

        public enum EveryMonthEnum
        {
            OnDay,
            SecondLastDay = 253,
            LastDay
        };

        public byte[] Single_DateTime_as_Byte(int Year, int Month, int Day, int Hour, int Minute, int Second, int Millisecond, bool Discard_Date, bool Discard_Time)

        {
            byte hiYear = BitConverter.GetBytes(Year)[0];
            byte loYear = BitConverter.GetBytes(Year)[1];
            byte month = BitConverter.GetBytes(Month)[0];
            byte DayOfmonth = BitConverter.GetBytes(Day)[0];
            byte DayOfWeek = BitConverter.GetBytes((int)dateTime.Value.DayOfWeek)[0];
            byte Hour_ = BitConverter.GetBytes(Hour)[0];
            byte Minute_ = BitConverter.GetBytes(Minute)[0];
            byte Second_ = BitConverter.GetBytes(Second)[0];
            byte Millisecond_ = BitConverter.GetBytes(Millisecond)[1];
            byte hiDeviation = (byte)0x80;
            byte loDeviation = (byte)0x00;
            byte clock = 0xFF;
     
            if (Discard_Time == true)
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek };
            }

            else if (Discard_Date == true)
            {
                return new byte[] { Hour_, Minute_, Second_, Millisecond_ };
            }

            else
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek, Hour_, Minute_, Second_, Millisecond_, hiDeviation, loDeviation, clock };
            }
        }

        public byte[] Every_Day_DateTime_as_Byte(int Hour, int Minute, int Second, int Millisecond, bool Discard_Date, bool Discard_Time)

        {
            byte hiYear = 0xFF; 
            byte loYear = 0xFF;
            byte month = 0xFF;
            byte DayOfmonth = 0xFF;
            byte DayOfWeek = 0xFF;
            byte Hour_ = BitConverter.GetBytes(Hour)[0];
            byte Minute_ = BitConverter.GetBytes(Minute)[0];
            byte Second_ = BitConverter.GetBytes(Second)[0];
            byte Millisecond_ = BitConverter.GetBytes(Millisecond)[1];
            byte hiDeviation = (byte)0x80;
            byte loDeviation = (byte)0x00;
            byte clock = 0xFF;

            if (Discard_Time == true)
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek };
            }

            else if (Discard_Date == true)
            {
                return new byte[] { Hour_, Minute_, Second_, Millisecond_ };
            }

            else
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek, Hour_, Minute_, Second_, Millisecond_, hiDeviation, loDeviation, clock };
            }
        }

        public byte[] Every_Week_DateTime_as_Byte(DaysOfWeek dayOfWeek, int Hour, int Minute, int Second, int Millisecond, bool Discard_Date, bool Discard_Time)

        {
            byte hiYear = 0xFF;
            byte loYear = 0xFF;
            byte month = 0xFF;
            byte DayOfmonth = 0xFF;
            byte DayOfWeek = BitConverter.GetBytes((int)dayOfWeek)[0];
            byte Hour_ = BitConverter.GetBytes(Hour)[0];
            byte Minute_ = BitConverter.GetBytes(Minute)[0];
            byte Second_ = BitConverter.GetBytes(Second)[0];
            byte Millisecond_ = BitConverter.GetBytes(Millisecond)[1];
            byte hiDeviation = (byte)0x80;
            byte loDeviation = (byte)0x00;
            byte clock = 0xFF;

            if (Discard_Time == true)
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek };
            }

            else if (Discard_Date == true)
            {
                return new byte[] { Hour_, Minute_, Second_, Millisecond_ };
            }

            else
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek, Hour_, Minute_, Second_, Millisecond_, hiDeviation, loDeviation, clock };
            }
        }//.................. not finished

        public byte[] Every_Month_DateTime_as_Byte(int Day, int Hour, int Minute, int Second, int Millisecond, bool Discard_Date, bool Discard_Time)

        {
            byte hiYear = 0xFF;
            byte loYear = 0xFF;
            byte month = 0xFF;
            byte DayOfmonth = BitConverter.GetBytes(Day)[0];
            byte DayOfWeek = 0xFF;
            byte Hour_ = BitConverter.GetBytes(Hour)[0];
            byte Minute_ = BitConverter.GetBytes(Minute)[0];
            byte Second_ = BitConverter.GetBytes(Second)[0];
            byte Millisecond_ = BitConverter.GetBytes(Millisecond)[1];
            byte hiDeviation = (byte)0x80;
            byte loDeviation = (byte)0x00;
            byte clock = 0xFF;

            if (Discard_Time == true)
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek };
            }

            else if (Discard_Date == true)
            {
                return new byte[] { Hour_, Minute_, Second_, Millisecond_ };
            }

            else
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek, Hour_, Minute_, Second_, Millisecond_, hiDeviation, loDeviation, clock };
            }
        }

        public byte[] Every_Year_DateTime_as_Byte(int Month, int Day, DaysOfWeek dayOfWeek, int Hour, int Minute, int Second, int Millisecond, bool Discard_Date, bool Discard_Time)

        {
            byte hiYear = 0xFF;
            byte loYear = 0xFF;
            byte month = BitConverter.GetBytes(Month)[0];
            byte DayOfmonth = BitConverter.GetBytes(Day)[0];
            byte DayOfWeek = BitConverter.GetBytes((int)dayOfWeek)[0];
            byte Hour_ = BitConverter.GetBytes(Hour)[0];
            byte Minute_ = BitConverter.GetBytes(Minute)[0];
            byte Second_ = BitConverter.GetBytes(Second)[0];
            byte Millisecond_ = BitConverter.GetBytes(Millisecond)[1];
            byte hiDeviation = (byte)0x80;
            byte loDeviation = (byte)0x00;
            byte clock = 0xFF;

            if (Discard_Time == true)
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek };
            }

            else if (Discard_Date == true)
            {
                return new byte[] { Hour_, Minute_, Second_, Millisecond_ };
            }

            else
            {
                return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek, Hour_, Minute_, Second_, Millisecond_, hiDeviation, loDeviation, clock };
            }
        }

        public byte[] GXDateTime_as_Byte(GXDateTime xDateTime)

        {
            byte hiYear = BitConverter.GetBytes(xDateTime.Value.Year)[0];
            byte loYear = BitConverter.GetBytes(xDateTime.Value.Year)[1];
            byte month = BitConverter.GetBytes(xDateTime.Value.Month)[0];
            byte DayOfmonth = BitConverter.GetBytes(xDateTime.Value.Day)[0];
            byte DayOfWeek = BitConverter.GetBytes((int)xDateTime.DayOfWeek)[0];
            byte Hour_ = BitConverter.GetBytes(xDateTime.Value.Hour)[0];
            byte Minute_ = BitConverter.GetBytes(xDateTime.Value.Minute)[0];
            byte Second_ = BitConverter.GetBytes(xDateTime.Value.Second)[0];
            byte Millisecond_ = BitConverter.GetBytes(xDateTime.Value.Millisecond)[1];
            byte hiDeviation = (byte)0x80;
            byte loDeviation = (byte)0x00;
            byte clock = 0xFF;

            return new byte[] { loYear, hiYear, month, DayOfmonth, DayOfWeek, Hour_, Minute_, Second_, Millisecond_, hiDeviation, loDeviation, clock };

        }

    }
}
