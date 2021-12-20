using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gurux.DLMS.Objects;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Register_Activation_Class
    {
        public IEGReader eGReader;
        public String OBIS;

        public Register_Activation_Class(String OBIS, IEGReader eGReader)
        {
            this.eGReader = eGReader;
            this.OBIS = OBIS;
        }

        public object Get_Active_Mask()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 4);
        }

        public List<GXDLMSObjectDefinition> Get_register_Assignment()
        {
            GXDLMSObjectDefinition[] _ = (GXDLMSObjectDefinition[])this.eGReader.Read_Object_Attribute(this.OBIS, 2);
            List<GXDLMSObjectDefinition> __ = new List<GXDLMSObjectDefinition>();
            foreach (GXDLMSObjectDefinition element in _)
            {
                __.Add(element);
            }
            return __;
        }

        public object Get_Mask_List()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 3);
        }
    }

    class Register_Activation_Energy : Register_Activation_Class
    {
        public Register_Activation_Energy(IEGReader eGReader) : base("0.0.14.0.1.255", eGReader) { }
    }



}
