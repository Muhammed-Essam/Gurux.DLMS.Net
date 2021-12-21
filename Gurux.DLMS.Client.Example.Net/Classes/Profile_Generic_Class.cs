using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Profile_Generic_Class
    {
        string OBIS;
        IEGReader eGReader;

        public Profile_Generic_Class(string OBIS, IEGReader eGReader)
        {
            this.eGReader = eGReader;
            this.OBIS = OBIS;
        }

        public object Get_Buffer()
        {
            object CapturedObjects = Get_Capture_Objects();
            return this.eGReader.Read_Object_Edited(this.OBIS, 2,null);
        }
        
        public object Get_Capture_Objects()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 3);
        }
        
        public object Get_Capture_Period()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 4);
        }
        
        public object Get_Sort_Method()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 5);
        }
        
        public object Get_Sort_Object()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 6);
        }
        
        public object Get_Entries_in_Use()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 7);
        }
        
        public object Get_Profile_Entries()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 8);
        }
    }

    class Credit_alarm_event_log : Profile_Generic_Class
    {
        public Credit_alarm_event_log (IEGReader eGReader) : base("0.0.99.98.11.255", eGReader) { }
    }
}
