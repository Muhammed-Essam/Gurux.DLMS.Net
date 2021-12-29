using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Special_Days_Table_Class
    {
        readonly string OBIS;
        IEGReader eGReader;

        public Special_Days_Table_Class(string OBIS, IEGReader eGReader)
        {
            this.eGReader = eGReader;
            this.OBIS = OBIS;
        }

        public object Entries 
        { 
            get => this.eGReader.Read_Object_Attribute(this.OBIS, 2);
        }

        public void Insert(ushort Index, byte[] Date , uint Day_ID)
        {
            
            this.eGReader.Execute_Method_Without_Datatype_And_AttIndex(this.OBIS, 1, (object)new GXArray { new GXStructure { Index, Date, (byte)Day_ID } });
        }

        public void Delete(ushort Index)
        {
            this.eGReader.Execute_Method_Without_Datatype_And_AttIndex(this.OBIS, 2, (object) Index);
        }
       
    }

    class Holidays : Special_Days_Table_Class
    {
        public Holidays(IEGReader eGReader) : base("0.0.11.0.0.255", eGReader) { }
    }

    class Friendly_Hours_Special_Days : Special_Days_Table_Class
    {
        public Friendly_Hours_Special_Days(IEGReader eGReader) : base("0.0.11.0.3.255", eGReader) { }
    }
    
    class Breaker_Managment_Special_Days : Special_Days_Table_Class
    {
        public Breaker_Managment_Special_Days(IEGReader eGReader) : base("0.0.11.0.1.255", eGReader) { }
    }
    
    class Relay_Managment_Special_Days : Special_Days_Table_Class
    {
        public Relay_Managment_Special_Days(IEGReader eGReader) : base("0.0.11.0.2.255", eGReader) { }
    }

}