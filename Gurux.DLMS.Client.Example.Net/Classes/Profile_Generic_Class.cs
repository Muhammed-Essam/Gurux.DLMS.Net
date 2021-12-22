using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gurux.DLMS.Objects;
namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Profile_Generic_Class
    {
        string OBIS;
        IEGReader eGReader;
        GXDLMSProfileGeneric GuruxObject;

        public Profile_Generic_Class(string OBIS, IEGReader eGReader)
        {
            this.eGReader = eGReader;
            this.OBIS = OBIS;
            this.GuruxObject = new GXDLMSProfileGeneric(OBIS);
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

        public void Reset()
        {
            GXReplyData reply = new GXReplyData();
            byte[][] mymethod = GuruxObject.Reset(this.eGReader.reader.Client);
            this.eGReader.Execute_Method(mymethod, reply);
        }
    }

    class Credit_alarm_event_log : Profile_Generic_Class
    {
        public Credit_alarm_event_log (IEGReader eGReader) : base("0.0.99.98.11.255", eGReader) { }
    }
    class General_display_readout : Profile_Generic_Class
    {
        public General_display_readout(IEGReader eGReader) : base("0.0.21.0.1.255", eGReader) { }
    }
    class Alternate_display_readout : Profile_Generic_Class
    {
        public Alternate_display_readout(IEGReader eGReader) : base("0.0.21.0.2.255", eGReader) { }
    }
    class Test_display_readout : Profile_Generic_Class
    {
        public Test_display_readout(IEGReader eGReader) : base("0.0.21.0.4.255", eGReader) { }
    }
    class Data_of_billing_period_1 : Profile_Generic_Class
    {
        public Data_of_billing_period_1(IEGReader eGReader) : base("0.0.98.1.0.255", eGReader) { }
    }
    class Data_of_billing_period_2 : Profile_Generic_Class
    {
        public Data_of_billing_period_2(IEGReader eGReader) : base("0.0.98.2.0.255", eGReader) { }
    }
    class Standard_event_log : Profile_Generic_Class
    {
        public Standard_event_log(IEGReader eGReader) : base("0.0.99.98.0.255", eGReader) { }
    }
    class Fraud_detection_log : Profile_Generic_Class
    {
        public Fraud_detection_log(IEGReader eGReader) : base("0.0.99.98.1.255", eGReader) { }
    }
    class Disconnector_control_log : Profile_Generic_Class
    {
        public Disconnector_control_log(IEGReader eGReader) : base("0.0.99.98.2.255", eGReader) { }
    }
    class Power_quality_log : Profile_Generic_Class
    {
        public Power_quality_log(IEGReader eGReader) : base("0.0.99.98.4.255", eGReader) { }
    }
    class Communication_event_log : Profile_Generic_Class
    {
        public Communication_event_log(IEGReader eGReader) : base("0.0.99.98.5.255", eGReader) { }
    }
    class Communication_details_log : Profile_Generic_Class
    {
        public Communication_details_log(IEGReader eGReader) : base("0.0.99.98.6.255", eGReader) { }
    }
    class Security_event_log : Profile_Generic_Class
    {
        public Security_event_log(IEGReader eGReader) : base("0.0.99.98.7.255", eGReader) { }
    }
    class Image_activation_log : Profile_Generic_Class
    {
        public Image_activation_log(IEGReader eGReader) : base("0.0.99.98.8.255", eGReader) { }
    }
    class Grid_monitor_event_log : Profile_Generic_Class
    {
        public Grid_monitor_event_log(IEGReader eGReader) : base("0.0.99.98.9.255", eGReader) { }
    }

    class Tamper_detection_event_log : Profile_Generic_Class
    {
        public Tamper_detection_event_log(IEGReader eGReader) : base("0.0.99.98.12.255", eGReader) { }
    }

    class Load_profile_with_period_1 : Profile_Generic_Class
    {
        public Load_profile_with_period_1(IEGReader eGReader) : base("1.0.99.1.0.255", eGReader) { }
    }

    class Load_profile_with_period_2 : Profile_Generic_Class
    {
        public Load_profile_with_period_2(IEGReader eGReader) : base("1.0.99.2.0.255", eGReader) { }
    }

    class Power_Quality_Profile : Profile_Generic_Class
    {
        public Power_Quality_Profile(IEGReader eGReader) : base("1.0.99.14.0.255", eGReader) { }
    }

    class Power_failure_event_log : Profile_Generic_Class
    {
        public Power_failure_event_log(IEGReader eGReader) : base("1.0.99.97.0.255", eGReader) { }
    }

    class Certification_data_log : Profile_Generic_Class
    {
        public Certification_data_log(IEGReader eGReader) : base("1.0.99.99.0.255", eGReader) { }
    }


}
