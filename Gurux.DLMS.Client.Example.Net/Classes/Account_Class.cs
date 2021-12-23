using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gurux.DLMS.Client.Example.Net.Classes
{
    class Account_Class
    {
        string OBIS;
        IEGReader eGReader;

        public Account_Class(string OBIS, IEGReader eGReader)
        {
            this.eGReader = eGReader;
            this.OBIS = OBIS;
        }

        public object account_mode()
        {
            object[] _ = (object[]) this.eGReader.Read_Object_Attribute(this.OBIS, 2);
            return _[0];
        }

        public object account_status()
        {
            object[] _ = (object[]) this.eGReader.Read_Object_Attribute(this.OBIS, 2);
            return _[1];
        }

        public object current_credit_in_use()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 3);
        }

        public object current_credit_status()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 4);
        }

        public object available_credit()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 5);
        }

        public object amount_to_clear()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 6);
        }

        public object clearance_threshold()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 7);
        }

        public object aggregated_debt()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 8);
        }

        public object credit_reference_list()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 9);
        }

        public object charge_reference_list()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 10);
        }

        public object credit_charge_configuration()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 11);
        }

        public object token_gateway_configuration()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 12);
        }

        public object account_activation_time()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 13);
        }

        public object account_closure_time()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 14);
        }

        public object currency
        {
            get 
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 15);
            }

            set
            {
                currency = value;
            }
        }
        public object low_credit_threshold
        {
            get
            {
                return this.eGReader.Read_Object_Attribute(this.OBIS, 16);
            }
        }

        public object next_credit_available_threshold()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 17);
        }

        public object max_provision()
        {
            return this.eGReader.Read_Object_Attribute(this.OBIS, 18);
        }

        public object max_provision_period() => this.eGReader.Read_Object_Attribute(this.OBIS, 19);

        public void activate_account()
        {
            this.eGReader.Execute_Method(this.OBIS, 1, 2, 0);
        }

        public void close_account()
        {
            object value = 0;
            this.eGReader.Execute_Method(this.OBIS, 2, 2, value);
        }

        public void reset_account()
        {
            this.eGReader.Execute_Method(this.OBIS, 3, 2, 0);
        }
    }

    class Import_Account : Account_Class
    {
        public Import_Account(IEGReader eGReader) : base("0.0.19.0.0.255", eGReader) { }
    }
}

