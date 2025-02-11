//
// --------------------------------------------------------------------------
//  Gurux Ltd
//
//
//
// Filename:        $HeadURL$
//
// Version:         $Revision$,
//                  $Date$
//                  $Author$
//
// Copyright (c) Gurux Ltd
//
//---------------------------------------------------------------------------
//
//  DESCRIPTION
//
// This file is a part of Gurux Device Framework.
//
// Gurux Device Framework is Open Source software; you can redistribute it
// and/or modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; version 2 of the License.
// Gurux Device Framework is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
// See the GNU General Public License for more details.
//
// More information of Gurux products: http://www.gurux.org
//
// This code is licensed under the GNU General Public License v2.
// Full text may be retrieved at http://www.gnu.org/licenses/gpl-2.0.txt
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Gurux.Serial;
using Gurux.Net;
using Gurux.DLMS.Enums;
using System.Threading;
using Gurux.DLMS.Objects;
using Gurux.DLMS.Client.Example.Net.Classes;

namespace Gurux.DLMS.Client.Example.Net
{
    public class Program
    {
       
        
        static void Main()
        {
            IEGReader eGReader =  MeterReader.Intializer();
            
            try
            {
                //Friendly_Hours_Special_Days myreg = new Friendly_Hours_Special_Days(eGReader);

                // object aaa = myreg.Season_profile_passive;

                //myreg.Replace_Week_Profile(3, 7, 5, 4, 5, 6, 7, 8);
                // myreg.Add_Week_Profile(4, 7, 5, 4, 5, 6, 7, 8);
                // myreg.Add_Week_Profile(5, 7, 5, 4, 5, 6, 7, 8);
                // myreg.Add_Week_Profile(6, 7, 5, 4, 5, 6, 7, 8);

                //object aaa = myreg.Entries;
                //myreg.Insert(5, new EGDatetime().Every_Day_DateTime_as_Byte(10, 10, 0, false, true), 1);

                Import_Credit merna = new Import_Credit(eGReader);
                object _ = merna.Current_Credit_Amount;
                Console.WriteLine(_);


                MeterReader.Closer(eGReader);
                Console.ReadLine();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
                
                Console.ReadLine();
                MeterReader.Closer(eGReader);
            }
           
            MeterReader.Closer(eGReader);
        }

       



}
}
