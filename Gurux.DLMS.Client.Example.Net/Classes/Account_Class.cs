using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Account_Class
    {
        readonly string OBIS;
        IEGReader eGReader;

        public Account_Class(string OBIS, IEGReader eGReader)
        {
            this.eGReader = eGReader;
            this.OBIS = OBIS;
        }

        public object Account_mode()
        {
            object[] _ = (object[]) this.eGReader.Read_Object_Attribute(this.OBIS, 2);
            return _[0];
        }

        public object Account_status()
        {
            object[] _ = (object[]) this.eGReader.Read_Object_Attribute(this.OBIS, 2);
            return _[1];
        }
        public object Account_status_Mode
        {
            set
            {
                
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 2, value);
            }
        }

        public object Current_credit_in_use()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 3);
        }

        public object Current_credit_status => this.eGReader.Read_Object_Attribute(this.OBIS, 4);

        public object Available_credit
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 5);
            }
        }

        public object Amount_to_clear => this.eGReader.Read_Object_Attribute(this.OBIS, 6);

        public object Clearance_threshold => this.eGReader.Read_Object_Attribute(this.OBIS, 7);

        public object Aggregated_debt => this.eGReader.Read_Object_Attribute(this.OBIS, 8);

        public object Credit_reference_list => this.eGReader.Read_Object_Attribute(this.OBIS, 9);

        public object Charge_reference_list => this.eGReader.Read_Object_Attribute(this.OBIS, 10);

        public object Credit_charge_configuration => this.eGReader.Read_Object_Attribute(this.OBIS, 11);

        public object Token_gateway_configuration => this.eGReader.Read_Object_Attribute(this.OBIS, 12);

        public object Account_activation_time
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 13);
            }

            set
            {
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 13, value);
            }
            
        }

        public object Account_closure_time
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 14);
            }

            set
            {
                this.eGReader.Write_Value_Object_Attribute(this.OBIS, 14, value);
            }
        }

        public object Currency
        {
            get 
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 15);
            }

            set
            {
                Currency = value;
            }
        }
        public object Low_credit_threshold
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 16);
            }
        }

        public IEGReader EGReader { get => eGReader; set => eGReader = value; }

        public object Next_credit_available_threshold()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 17);
        }

        public object Max_provision()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 18);
        }

        public object Max_provision_period() => this.eGReader.Read_Object_Attribute(this.OBIS, 19);

        public void Activate_account() => this.Account_activation_time = (object)DateTime.UtcNow;

        public void Close_account()
        {
            /*//GXStructure value = new GXStructure
            {
                1,
                3
            };

            //this.eGReader.Execute_Method_Without_Datatype(this.OBIS, 2,(object)value);
            //this.eGReader.Write_Value_Object_Attribute(this.OBIS, 2, value);*/

            this.Account_closure_time = (object) DateTime.UtcNow;
        }

        public void Reset_account()
        {
            this.eGReader.Execute_Method_Edited(new Objects.GXDLMSAccount(OBIS).Reset(this.eGReader.reader.Client), new GXReplyData());
        }
    }

    class Import_Account : Account_Class
    {
        public Import_Account(IEGReader eGReader) : base("0.0.19.0.0.255", eGReader) { }
    }
}

