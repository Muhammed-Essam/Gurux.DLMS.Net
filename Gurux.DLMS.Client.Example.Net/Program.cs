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
using Gurux.DLMS.Enums;
using System.Threading;
using Gurux.DLMS.Objects;
using Gurux.DLMS.Client.Example.Net.Classes;
using Gurux.DLMS;

namespace Gurux.DLMS.Client.Example.Net
{
    public class Program
    {
       
        
        static void Main()
        {
            IEGReader eGReader =  MeterReader.Intializer();
            
            try
            {
                Friendly_hours_activity_calendar myreg = new Friendly_hours_activity_calendar(eGReader);
                Object ss = myreg.Create_Week_Profile(3, 1, 0, 1, 0, 1, 0, 1);

                object sss = myreg.Week_profile_table_passive;
                myreg.Week_profile_table_passive = ss;

                //

               // myreg.Week_profile_table_passive = sss;



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
