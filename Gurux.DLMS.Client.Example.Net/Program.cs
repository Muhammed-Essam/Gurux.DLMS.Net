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
        /*
        static int Main(string[] args)
        {
            Settings settings = new Settings();

            Reader.GXDLMSReader reader = null;
            try
            {
                ////////////////////////////////////////
                //Handle command line parameters.
                int ret = Settings.GetParameters(argsE, settings);
                if (ret != 0)
                {
                    return ret;
                }
                ////////////////////////////////////////
                //Initialize connection settings.
                if (settings.media is GXSerial)
                {
                }
                else if (settings.media is GXNet)
                {
                }
                else
                {
                    throw new Exception("Unknown media type.");
                }
                ////////////////////////////////////////
                reader = new Reader.GXDLMSReader(settings.client, settings.media, settings.trace, settings.invocationCounter);
                try
                {
                    settings.media.Open();
                }
                catch (System.IO.IOException ex)
                {
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Available ports:");
                    Console.WriteLine(string.Join(" ", GXSerial.GetPortNames()));
                    return 1;
                }
                //Some meters need a break here.
                Thread.Sleep(1000);
                //Export client and server certificates from the meter.
                if (!string.IsNullOrEmpty(settings.ExportSecuritySetupLN))
                {
                    reader.ExportMeterCertificates(settings.ExportSecuritySetupLN);
                }
                //Generate new client and server certificates and import them to the server.
                else if (!string.IsNullOrEmpty(settings.GenerateSecuritySetupLN))
                {
                    reader.GenerateCertificates(settings.GenerateSecuritySetupLN);
                }
                else if (settings.readObjects.Count != 0)
                {
                    bool read = false;
                    if (settings.outputFile != null)
                    {
                        try
                        {
                            settings.client.Objects.Clear();
                            settings.client.Objects.AddRange(GXDLMSObjectCollection.Load(settings.outputFile));
                            read = true;
                        }
                        catch (Exception)
                        {
                            //It's OK if this fails.
                        }
                    }
                    reader.InitializeConnection();
                    if (!read)
                    {
                        reader.GetAssociationView(settings.outputFile);
                    }
                    foreach (KeyValuePair<string, int> it in settings.readObjects)
                    {
                        object val = reader.Read(settings.client.Objects.FindByLN(ObjectType.None, it.Key), it.Value);
                        reader.ShowValue(val, it.Value);
                    }
                    if (settings.outputFile != null)
                    {
                        try
                        {
                            settings.client.Objects.Save(settings.outputFile, new GXXmlWriterSettings() { UseMeterTime = true, IgnoreDefaultValues = false });
                        }
                        catch (Exception)
                        {
                            //It's OK if this fails.
                        }
                    }
                }
                else
                {
                    reader.ReadAll(settings.outputFile);
                }
            }
            catch (GXDLMSException ex)
            {
                Console.WriteLine(ex.Message);
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.ReadKey();
                }
                return 1;
            }
            catch (GXDLMSExceptionResponse ex)
            {
                Console.WriteLine(ex.Message);
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.ReadKey();
                }
                return 1;
            }
            catch (GXDLMSConfirmedServiceError ex)
            {
                Console.WriteLine(ex.Message);
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.ReadKey();
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ToString());
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.ReadKey();
                }
                return 1;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Console.WriteLine("Ended. Press any key to continue.");
                    Console.ReadKey();
                }
            }
            return 0;
        }
        
        */
        
        static void Main()
        {
            IEGReader eGReader =  MeterReader.Intializer();
            /* object Voltage = MeterReader.Voltage(eGReader);
             object Credit = MeterReader.Credit(eGReader);
             object Power = MeterReader.Power(eGReader);
 */
            //MeterReader.Write_Credit(eGReader);

            /*Console.WriteLine("Vatage: "+Voltage+" Credit: "+Credit+" Power: "+Power);
            Console.WriteLine(watch.ElapsedMilliseconds);*/

            //
            // Gurux.DLMS.GXDateTime obj = (Gurux.DLMS.GXDateTime) eGReader.Read_Object("0.0.1.0.0.255",2 );
            try
            {
                Friendly_hours_activity_calendar myreg = new Friendly_hours_activity_calendar(eGReader);
                /*GXStructure _ = new GXStructure();
                _.Add(1);
                _.Add(3);
                myreg.account_status_Mode = _;*/


                object _ = myreg.Calendar_name_active;
                myreg.Day_profile_table_passive = 0;

                _ = myreg.Day_profile_table_active;
                _ = myreg.Day_profile_table_passive;
                _ = myreg.Week_profile_table_active;
                _ = myreg.Week_profile_table_passive;
                _ = myreg.Season_profile_active;
                _ = myreg.Season_profile_passive;
                _ = myreg.Activate_passive_calendar_time;
                MeterReader.Closer(eGReader);
                Console.ReadLine();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
                MeterReader.Closer(eGReader);
            }
            //MeterReader.BreakerDisconnect(eGReader);
            // MeterReader.ChargeCredit(eGReader,9876);

            //MeterReader.NonDisconnectPeriod(eGReader,false);
            //obj.DayOfWeek = ""

            //eGReader.Write_Object("0.0.1.0.0.255", 2, eGReader);
            // obj = eGReader.Read_Object("0.0.1.0.0.255", 2);

            //   ValueEventArgs e = new ValueEventArgs(obj, 2, 0, null);
            //e.setValue(Util.hex2ByteArray("07E307130507000015FF8880"));
            //obj.setValue(null, e);

            /*  Console.WriteLine("Press ESC to stop");*/
            /* do
               {
                   while (!Console.KeyAvailable)
                   {
                       Console.Clear();
                       object Credit = MeterReader.Credit(eGReader);
                       object Power = MeterReader.Power(eGReader);
                       Console.WriteLine("Power: " + Power + " \nCredit: " + Credit );
                       System.Threading.Thread.Sleep(5000);
                   }
               } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

               Console.ReadKey();*/
            MeterReader.Closer(eGReader);
        }

       



}
}
