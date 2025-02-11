﻿using Gurux.DLMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Credit_Class
    {
        readonly string OBIS;
        IEGReader eGReader;

        public Credit_Class(string OBIS, IEGReader eGReader)
        {
            this.OBIS = OBIS;
            this.eGReader = eGReader;
        }

        public object Current_Credit_Amount
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 2);
            }

        }

        public object Credit_type
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 3);
            }

        }

        public object Priority
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 4);
            }

        }

        public object Warning_threshold
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 5);
            }

        }

        public object Limit
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

        public object Credit_configuration
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 7);
            }

        }

        public object Credit_status
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 8);
            }

        }

        public object Preset_credit_amount
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 9);
            }

        }

        public object Credit_available_threshold
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 10);
            }

        }

        public object Period
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 11);
            }

        }

        public IEGReader EGReader { get => eGReader; set => eGReader = value; }

        public void Set_amount_to_value_edited(int value )
        {
            GXReplyData reply = new GXReplyData();
            GXDLMSCredit CreditRegister = new GXDLMSCredit();

            byte[][] mymethod = CreditRegister.SetAmountToValue(this.eGReader.reader.Client,value);

            this.eGReader.Execute_Method_Edited(mymethod, reply);
        }

        public void Set_amount_to_value(int value )
        {
            this.eGReader.Execute_Method(this.OBIS, 2, 2, value);
        }

        public void UpdateAmount(Int32 value)
        {
            this.eGReader.Execute_Method(this.OBIS, 1, 2, value);
        }
    }

    class Import_Credit : Credit_Class
    {
        public Import_Credit(IEGReader eGReader) : base("0.0.19.10.0.255", eGReader) { }
    }
}

