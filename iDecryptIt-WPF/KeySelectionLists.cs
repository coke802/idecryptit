﻿/* =============================================================================
 * File:   KeySelectionLists.cs
 * Author: Cole Johnson
 * =============================================================================
 * Copyright (c) 2014-2015 Cole Johnson
 * 
 * This file is part of iDecryptIt
 * 
 * iDecryptIt is free software: you can redistribute it and/or modify it under
 *   the terms of the GNU General Public License as published by the Free
 *   Software Foundation, either version 3 of the License, or (at your option)
 *   any later version.
 * 
 * iDecryptIt is distributed in the hope that it will be useful, but WITHOUT
 *   ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 *   FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
 *   more details.
 * 
 * You should have received a copy of the GNU General Public License along with
 *   iDecryptIt. If not, see <http://www.gnu.org/licenses/>.
 * =============================================================================
 */
using System.Collections.Generic;

namespace Hexware.Programs.iDecryptIt
{
    // TODO: For another time (as in ASAP)
    // This is going to become too large to maintain if kept this way;
    //   especially when beta firmwares are added back (case-in-point:
    //   `InitIPad` and `InitIPhone`). It'll be best to throw these into
    //   a file that we parse at runtime. That file should be generated
    //   by the key grabber.
    internal static class KeySelectionLists
    {
        internal static List<ComboBoxEntry> Products;
        internal static Dictionary<string, List<ComboBoxEntry>> ProductsHelper;

        private static List<ComboBoxEntry> AppleTV;
        private static List<ComboBoxEntry> iPad;
        private static List<ComboBoxEntry> iPadMini;
        private static List<ComboBoxEntry> iPhone;
        private static List<ComboBoxEntry> iPodTouch;
        internal static Dictionary<string, List<ComboBoxEntry>> ModelsHelper;

        // Apple TV
        private static List<ComboBoxEntry> AppleTV21;
        private static List<ComboBoxEntry> AppleTV31;
        private static List<ComboBoxEntry> AppleTV32;
        // Don't add Apple TV 4G (AppleTV5,3) until there's a /public/ firmware

        // iPad
        private static List<ComboBoxEntry> iPad11;
        private static List<ComboBoxEntry> iPad21;
        private static List<ComboBoxEntry> iPad22;
        private static List<ComboBoxEntry> iPad23;
        private static List<ComboBoxEntry> iPad24;
        private static List<ComboBoxEntry> iPad31;
        private static List<ComboBoxEntry> iPad32;
        private static List<ComboBoxEntry> iPad33;
        private static List<ComboBoxEntry> iPad34;
        private static List<ComboBoxEntry> iPad35;
        private static List<ComboBoxEntry> iPad36;
        private static List<ComboBoxEntry> iPad41;
        private static List<ComboBoxEntry> iPad42;
        private static List<ComboBoxEntry> iPad43;
        private static List<ComboBoxEntry> iPad53;
        private static List<ComboBoxEntry> iPad54;

        // iPad mini
        private static List<ComboBoxEntry> iPad25;
        private static List<ComboBoxEntry> iPad26;
        private static List<ComboBoxEntry> iPad27;
        private static List<ComboBoxEntry> iPad44;
        private static List<ComboBoxEntry> iPad45;
        private static List<ComboBoxEntry> iPad46;
        private static List<ComboBoxEntry> iPad47;
        private static List<ComboBoxEntry> iPad48;
        private static List<ComboBoxEntry> iPad49;
        private static List<ComboBoxEntry> iPad51;
        private static List<ComboBoxEntry> iPad52;

        // iPhone
        private static List<ComboBoxEntry> iPhone11;
        private static List<ComboBoxEntry> iPhone12;
        private static List<ComboBoxEntry> iPhone21;
        private static List<ComboBoxEntry> iPhone31;
        private static List<ComboBoxEntry> iPhone32;
        private static List<ComboBoxEntry> iPhone33;
        private static List<ComboBoxEntry> iPhone41;
        private static List<ComboBoxEntry> iPhone51;
        private static List<ComboBoxEntry> iPhone52;
        private static List<ComboBoxEntry> iPhone53;
        private static List<ComboBoxEntry> iPhone54;
        private static List<ComboBoxEntry> iPhone61;
        private static List<ComboBoxEntry> iPhone62;
        private static List<ComboBoxEntry> iPhone71;
        private static List<ComboBoxEntry> iPhone72;
        private static List<ComboBoxEntry> iPhone81;
        private static List<ComboBoxEntry> iPhone82;

        // iPod touch
        private static List<ComboBoxEntry> iPod11;
        private static List<ComboBoxEntry> iPod21;
        private static List<ComboBoxEntry> iPod31;
        private static List<ComboBoxEntry> iPod41;
        private static List<ComboBoxEntry> iPod51;
        private static List<ComboBoxEntry> iPod71;

        internal static void Init()
        {
            Products = new List<ComboBoxEntry>();
            Products.Add(new ComboBoxEntry("AppleTV", "Apple TV"));
            Products.Add(new ComboBoxEntry("iPad", "iPad"));
            Products.Add(new ComboBoxEntry("iPadMini", "iPad mini"));
            Products.Add(new ComboBoxEntry("iPhone", "iPhone"));
            Products.Add(new ComboBoxEntry("iPodTouch", "iPod touch"));

            InitModels();

            InitAppleTV();
            InitIPad();
            InitIPadMini();
            InitIPhone();
            InitIPodTouch();

            InitDeprecatedAppleTV();
            InitDeprecatedIPad();
            InitDeprecatedIPhone();
            InitDeprecatedIPodTouch();

            // MUST BE LAST
            InitHelpers();
        }
        private static void InitHelpers()
        {
            ProductsHelper = new Dictionary<string, List<ComboBoxEntry>>();
            ProductsHelper.Add("AppleTV", AppleTV);
            ProductsHelper.Add("iPad", iPad);
            ProductsHelper.Add("iPadMini", iPadMini);
            ProductsHelper.Add("iPhone", iPhone);
            ProductsHelper.Add("iPodTouch", iPodTouch);

            ModelsHelper = new Dictionary<string, List<ComboBoxEntry>>();
            ModelsHelper.Add("AppleTV2,1", AppleTV21); // Apple TV 2G
            ModelsHelper.Add("AppleTV3,1", AppleTV31); // Apple TV 3G
            ModelsHelper.Add("AppleTV3,2", AppleTV32);
            ModelsHelper.Add("iPad1,1", iPad11); // iPad 1G
            ModelsHelper.Add("iPad2,1", iPad21); // iPad 2
            ModelsHelper.Add("iPad2,2", iPad22);
            ModelsHelper.Add("iPad2,3", iPad23);
            ModelsHelper.Add("iPad2,4", iPad24);
            ModelsHelper.Add("iPad2,5", iPad25); // iPad mini 1G
            ModelsHelper.Add("iPad2,6", iPad26);
            ModelsHelper.Add("iPad2,7", iPad27);
            ModelsHelper.Add("iPad3,1", iPad31); // iPad 3
            ModelsHelper.Add("iPad3,2", iPad32);
            ModelsHelper.Add("iPad3,3", iPad33);
            ModelsHelper.Add("iPad3,4", iPad34); // iPad 4
            ModelsHelper.Add("iPad3,5", iPad35);
            ModelsHelper.Add("iPad3,6", iPad36);
            ModelsHelper.Add("iPad4,1", iPad41); // iPad Air
            ModelsHelper.Add("iPad4,2", iPad42);
            ModelsHelper.Add("iPad4,3", iPad43);
            ModelsHelper.Add("iPad4,4", iPad44); // iPad mini 2
            ModelsHelper.Add("iPad4,5", iPad45);
            ModelsHelper.Add("iPad4,6", iPad46);
            ModelsHelper.Add("iPad4,7", iPad47); // iPad mini 3
            ModelsHelper.Add("iPad4,8", iPad48);
            ModelsHelper.Add("iPad4,9", iPad49);
            ModelsHelper.Add("iPad5,1", iPad51); // iPad mini 4
            ModelsHelper.Add("iPad5,2", iPad52);
            ModelsHelper.Add("iPad5,3", iPad53); // iPad Air 2
            ModelsHelper.Add("iPad5,4", iPad54);
            ModelsHelper.Add("iPhone1,1", iPhone11); // iPhone 2G
            ModelsHelper.Add("iPhone1,2", iPhone12); // iPhone 3G
            ModelsHelper.Add("iPhone2,1", iPhone21); // iPhone 3GS
            ModelsHelper.Add("iPhone3,1", iPhone31); // iPhone 4
            ModelsHelper.Add("iPhone3,2", iPhone32);
            ModelsHelper.Add("iPhone3,3", iPhone33);
            ModelsHelper.Add("iPhone4,1", iPhone41); // iPhone 4S
            ModelsHelper.Add("iPhone5,1", iPhone51); // iPhone 5
            ModelsHelper.Add("iPhone5,2", iPhone52);
            ModelsHelper.Add("iPhone5,3", iPhone53); // iPhone 5c
            ModelsHelper.Add("iPhone5,4", iPhone54);
            ModelsHelper.Add("iPhone6,1", iPhone61); // iPhone 5s
            ModelsHelper.Add("iPhone6,2", iPhone62);
            ModelsHelper.Add("iPhone7,1", iPhone71); // iPhone 6+
            ModelsHelper.Add("iPhone7,2", iPhone72); // iPhone 6
            ModelsHelper.Add("iPhone8,1", iPhone81); // iPhone 6s
            ModelsHelper.Add("iPhone8,2", iPhone82); // iPhone 6s+
            ModelsHelper.Add("iPod1,1", iPod11); // iPod 1G
            ModelsHelper.Add("iPod2,1", iPod21); // iPod 2G
            ModelsHelper.Add("iPod3,1", iPod31); // iPod 3G
            ModelsHelper.Add("iPod4,1", iPod41); // iPod 4G
            ModelsHelper.Add("iPod5,1", iPod51); // iPod 5G
            ModelsHelper.Add("iPod7,1", iPod71); // iPod 6G
        }
        private static void InitModels()
        {
            AppleTV = new List<ComboBoxEntry>();
            AppleTV.Add(new ComboBoxEntry("AppleTV2,1", "2G (AppleTV2,1)"));
            AppleTV.Add(new ComboBoxEntry("AppleTV3,1", "3G (AppleTV3,1)"));
            AppleTV.Add(new ComboBoxEntry("AppleTV3,2", "3G Rev A (AppleTV3,2)"));

            iPad = new List<ComboBoxEntry>();
            iPad.Add(new ComboBoxEntry("iPad1,1", "1G (iPad1,1)"));
            iPad.Add(new ComboBoxEntry("iPad2,1", "2 Wi-Fi (iPad2,1)"));
            iPad.Add(new ComboBoxEntry("iPad2,2", "2 GSM (iPad2,2)"));
            iPad.Add(new ComboBoxEntry("iPad2,3", "2 CDMA (iPad2,3)"));
            iPad.Add(new ComboBoxEntry("iPad2,4", "2 Wi-Fi Rev A (iPad2,4)"));
            iPad.Add(new ComboBoxEntry("iPad3,1", "3 Wi-Fi (iPad3,1)"));
            iPad.Add(new ComboBoxEntry("iPad3,2", "3 CDMA (iPad3,2)"));
            iPad.Add(new ComboBoxEntry("iPad3,3", "3 Global (iPad3,3)"));
            iPad.Add(new ComboBoxEntry("iPad3,4", "4 Wi-Fi (iPad3,4)"));
            iPad.Add(new ComboBoxEntry("iPad3,5", "4 GSM (iPad3,5)"));
            iPad.Add(new ComboBoxEntry("iPad3,6", "4 Global (iPad3,6)"));
            iPad.Add(new ComboBoxEntry("iPad4,1", "Air Wi-Fi (iPad4,1)"));
            iPad.Add(new ComboBoxEntry("iPad4,2", "Air Cellular (iPad4,2)"));
            iPad.Add(new ComboBoxEntry("iPad4,3", "Air Cellular China (iPad4,3)"));
            iPad.Add(new ComboBoxEntry("iPad5,3", "Air 2 Wi-Fi (iPad5,3)"));
            iPad.Add(new ComboBoxEntry("iPad5,4", "Air 2 Cellular (iPad5,4)"));

            iPadMini = new List<ComboBoxEntry>();
            iPadMini.Add(new ComboBoxEntry("iPad2,5", "1G Wi-Fi (iPad2,5)"));
            iPadMini.Add(new ComboBoxEntry("iPad2,5", "1G GSM (iPad2,5)"));
            iPadMini.Add(new ComboBoxEntry("iPad2,5", "1G Global (iPad2,5)"));
            iPadMini.Add(new ComboBoxEntry("iPad4,4", "2 Wi-Fi (iPad4,4)"));
            iPadMini.Add(new ComboBoxEntry("iPad4,5", "2 Cellular (iPad4,5)"));
            iPadMini.Add(new ComboBoxEntry("iPad4,6", "2 Cellular China (iPad4,6)"));
            iPadMini.Add(new ComboBoxEntry("iPad4,7", "3 Wi-Fi (iPad4,7)"));
            iPadMini.Add(new ComboBoxEntry("iPad4,8", "3 Cellular (iPad4,8)"));
            iPadMini.Add(new ComboBoxEntry("iPad4,9", "3 Cellular China (iPad4,9)"));
            iPadMini.Add(new ComboBoxEntry("iPad5,1", "4 Wi-Fi (iPad5,1)"));
            iPadMini.Add(new ComboBoxEntry("iPad5,2", "4 Cellular (iPad5,2)"));

            iPhone = new List<ComboBoxEntry>();
            iPhone.Add(new ComboBoxEntry("iPhone1,1", "2G (iPhone1,1)"));
            iPhone.Add(new ComboBoxEntry("iPhone1,2", "3G (iPhone1,2)"));
            iPhone.Add(new ComboBoxEntry("iPhone2,1", "3GS (iPhone2,1)"));
            iPhone.Add(new ComboBoxEntry("iPhone3,1", "4 GSM (iPhone3,1)"));
            iPhone.Add(new ComboBoxEntry("iPhone3,2", "4 CDMA (iPhone3,2)"));
            iPhone.Add(new ComboBoxEntry("iPhone3,3", "4 GSM Rev A (iPhone3,3)"));
            iPhone.Add(new ComboBoxEntry("iPhone4,1", "4S (iPhone4,1)"));
            iPhone.Add(new ComboBoxEntry("iPhone5,1", "5 GSM (iPhone5,1)"));
            iPhone.Add(new ComboBoxEntry("iPhone5,2", "5 CDMA (iPhone5,2)"));
            iPhone.Add(new ComboBoxEntry("iPhone5,3", "5c GSM (iPhone5,3)"));
            iPhone.Add(new ComboBoxEntry("iPhone5,4", "5c Global (iPhone5,4)"));
            iPhone.Add(new ComboBoxEntry("iPhone6,1", "5s GSM (iPhone6,1)"));
            iPhone.Add(new ComboBoxEntry("iPhone6,2", "5s Global (iPhone6,2)"));
            iPhone.Add(new ComboBoxEntry("iPhone7,1", "6 Plus (iPhone7,1)"));
            iPhone.Add(new ComboBoxEntry("iPhone7,2", "6 (iPhone7,2)"));
            iPhone.Add(new ComboBoxEntry("iPhone8,1", "6s (iPhone8,1)"));
            iPhone.Add(new ComboBoxEntry("iPhone8,2", "6s Plus (iPhone8,2)"));

            iPodTouch = new List<ComboBoxEntry>();
            iPodTouch.Add(new ComboBoxEntry("iPod1,1", "1G (iPod1,1)"));
            iPodTouch.Add(new ComboBoxEntry("iPod2,1", "2G (iPod2,1)"));
            iPodTouch.Add(new ComboBoxEntry("iPod3,1", "3G (iPod3,1)"));
            iPodTouch.Add(new ComboBoxEntry("iPod4,1", "4G (iPod4,1)"));
            iPodTouch.Add(new ComboBoxEntry("iPod5,1", "5G (iPod5,1)"));
            iPodTouch.Add(new ComboBoxEntry("iPod7,1", "6G (iPod7,1)"));
        }
        private static void InitAppleTV()
        {
            AppleTV31 = new List<ComboBoxEntry>();
            AppleTV31.Add(new ComboBoxEntry("9B179b", "5.0/5.1 (9B179b)"));
            AppleTV31.Add(new ComboBoxEntry("9B206f", "5.0.1/5.1.1 (9B206f)"));
            AppleTV31.Add(new ComboBoxEntry("9B830", "5.0.2/5.1.1 (9B830)"));
            AppleTV31.Add(new ComboBoxEntry("10A406e", "5.1/6.0 (10A406e)"));
            AppleTV31.Add(new ComboBoxEntry("10B144b", "5.2/6.1 (10B144b)"));
            AppleTV31.Add(new ComboBoxEntry("10B329a", "5.2.1/6.1.3 (10B329a)"));
            AppleTV31.Add(new ComboBoxEntry("10B809", "5.3/6.1.4 (10B809)"));
            AppleTV31.Add(new ComboBoxEntry("11A470e", "6.0/7.0.1 (11A470e)"));
            AppleTV31.Add(new ComboBoxEntry("11A502", "6.0/7.0.2 (11A502)"));
            AppleTV31.Add(new ComboBoxEntry("11B511d", "6.0.1/7.0.3 (11B511d)"));
            AppleTV31.Add(new ComboBoxEntry("11B554a", "6.0.2/7.0.4 (11B554a)"));
            AppleTV31.Add(new ComboBoxEntry("11B651", "6.0.2/7.0.6 (11B651)"));
            AppleTV31.Add(new ComboBoxEntry("11D169b", "6.1/7.1 (11D169b)"));
            AppleTV31.Add(new ComboBoxEntry("11D201c", "6.1.1/7.1.1 (11D201c)"));
            AppleTV31.Add(new ComboBoxEntry("11D257c", "6.2/7.1.2 (11D257c)"));
            AppleTV31.Add(new ComboBoxEntry("12A365b", "7.0/8.0 (12A365b)"));
            AppleTV31.Add(new ComboBoxEntry("12B410a", "7.0.1/8.1 (12B410a)"));
            AppleTV31.Add(new ComboBoxEntry("12B435", "7.0.2/8.1.1 (12B435)"));
            AppleTV31.Add(new ComboBoxEntry("12B466", "7.0.3/8.1.3 (12B466)"));
            AppleTV31.Add(new ComboBoxEntry("12D508", "7.1/8.2 (12D508)"));
            AppleTV31.Add(new ComboBoxEntry("12F69", "7.2/8.3 (12F69)"));

            AppleTV32 = new List<ComboBoxEntry>();
            AppleTV32.Add(new ComboBoxEntry("10B144b", "5.2/6.1 (10B144b)"));
            AppleTV32.Add(new ComboBoxEntry("10B329a", "5.2.1/6.1.3 (10B329a)"));
            AppleTV32.Add(new ComboBoxEntry("10B809", "5.3/6.1.4 (10B809)"));
            AppleTV32.Add(new ComboBoxEntry("11A470e", "6.0/7.0.1 (11A470e)"));
            AppleTV32.Add(new ComboBoxEntry("11A502", "6.0/7.0.2 (11A502)"));
            AppleTV32.Add(new ComboBoxEntry("11B511d", "6.0.1/7.0.3 (11B511d)"));
            AppleTV32.Add(new ComboBoxEntry("11B554a", "6.0.2/7.0.4 (11B554a)"));
            AppleTV32.Add(new ComboBoxEntry("11B651", "6.0.2/7.0.6 (11B651)"));
            AppleTV32.Add(new ComboBoxEntry("11D169b", "6.1/7.1 (11D169b)"));
            AppleTV32.Add(new ComboBoxEntry("11D201c", "6.1.1/7.1.1 (11D201c)"));
            AppleTV32.Add(new ComboBoxEntry("11D257c", "6.2/7.1.2 (11D257c)"));
            AppleTV32.Add(new ComboBoxEntry("12A365b", "7.0/8.0 (12A365b)"));
            AppleTV32.Add(new ComboBoxEntry("12B410a", "7.0.1/8.1 (12B410a)"));
            AppleTV32.Add(new ComboBoxEntry("12B435", "7.0.2/8.1.1 (12B435)"));
            AppleTV32.Add(new ComboBoxEntry("12B466", "7.0.3/8.1.3 (12B466)"));
            AppleTV32.Add(new ComboBoxEntry("12D508", "7.1/8.2 (12D508)"));
            AppleTV32.Add(new ComboBoxEntry("12F69", "7.2/8.3 (12F69)"));
        }
        private static void InitIPad()
        {
            iPad21 = new List<ComboBoxEntry>();
            iPad21.Add(new ComboBoxEntry("8F191", "4.3 (8F191)"));
            iPad21.Add(new ComboBoxEntry("8G4", "4.3.1 (8G4)"));
            iPad21.Add(new ComboBoxEntry("8H7", "4.3.2 (8H7)"));
            iPad21.Add(new ComboBoxEntry("8J2", "4.3.3 (8J2)"));
            iPad21.Add(new ComboBoxEntry("8K2", "4.3.4 (8K2)"));
            iPad21.Add(new ComboBoxEntry("8L1", "4.3.5 (8L1)"));
            iPad21.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPad21.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPad21.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPad21.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPad21.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPad21.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad21.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad21.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad21.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad21.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad21.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad21.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad21.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad21.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad21.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad21.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad21.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad21.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad21.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad21.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad21.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad21.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad21.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad21.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad21.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad21.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad21.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad21.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad21.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad21.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad22 = new List<ComboBoxEntry>();
            iPad22.Add(new ComboBoxEntry("8F191", "4.3 (8F191)"));
            iPad22.Add(new ComboBoxEntry("8G4", "4.3.1 (8G4)"));
            iPad22.Add(new ComboBoxEntry("8H7", "4.3.2 (8H7)"));
            iPad22.Add(new ComboBoxEntry("8J2", "4.3.3 (8J2)"));
            iPad22.Add(new ComboBoxEntry("8K2", "4.3.4 (8K2)"));
            iPad22.Add(new ComboBoxEntry("8L1", "4.3.5 (8L1)"));
            iPad22.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPad22.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPad22.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPad22.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPad22.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPad22.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad22.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad22.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad22.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad22.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad22.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad22.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad22.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad22.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad22.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad22.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad22.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad22.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad22.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad22.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad22.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad22.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad22.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad22.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad22.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad22.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad22.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad22.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad22.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad22.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad23 = new List<ComboBoxEntry>();
            iPad23.Add(new ComboBoxEntry("8F191", "4.3 (8F191)"));
            iPad23.Add(new ComboBoxEntry("8G4", "4.3.1 (8G4)"));
            iPad23.Add(new ComboBoxEntry("8H8", "4.3.2 (8H8)"));
            iPad23.Add(new ComboBoxEntry("8J2", "4.3.3 (8J2)"));
            iPad23.Add(new ComboBoxEntry("8K2", "4.3.4 (8K2)"));
            iPad23.Add(new ComboBoxEntry("8L1", "4.3.5 (8L1)"));
            iPad23.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPad23.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPad23.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPad23.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPad23.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPad23.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad23.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad23.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad23.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad23.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad23.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad23.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad23.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad23.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad23.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad23.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad23.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad23.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad23.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad23.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad23.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad23.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad23.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad23.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad23.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad23.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad23.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad23.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad23.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad23.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad24 = new List<ComboBoxEntry>();
            iPad24.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPad24.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPad24.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPad24.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad24.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad24.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad24.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad24.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad24.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad24.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad24.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad24.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad24.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad24.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad24.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad24.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad24.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad24.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad24.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad24.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad24.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad24.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad24.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad24.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad24.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad24.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad24.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad24.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad31 = new List<ComboBoxEntry>();
            iPad31.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPad31.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPad31.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPad31.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad31.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad31.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad31.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad31.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad31.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad31.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad31.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad31.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad31.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad31.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad31.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad31.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad31.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad31.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad31.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad31.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad31.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad31.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad31.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad31.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad31.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad31.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad31.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad31.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad32 = new List<ComboBoxEntry>();
            iPad32.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPad32.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPad32.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPad32.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad32.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad32.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad32.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad32.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad32.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad32.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad32.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad32.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad32.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad32.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad32.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad32.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad32.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad32.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad32.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad32.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad32.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad32.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad32.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad32.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad32.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad32.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad32.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad32.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad33 = new List<ComboBoxEntry>();
            iPad33.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPad33.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPad33.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPad33.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad33.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad33.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad33.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad33.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad33.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad33.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad33.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad33.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad33.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad33.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad33.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad33.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad33.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad33.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad33.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad33.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad33.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad33.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad33.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad33.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad33.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad33.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad33.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad33.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad34 = new List<ComboBoxEntry>();
            iPad34.Add(new ComboBoxEntry("10A407", "6.0 (10A407)"));
            iPad34.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad34.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad34.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad34.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad34.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad34.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad34.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad34.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad34.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad34.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad34.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad34.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad34.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad34.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad34.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad34.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad34.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad34.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad34.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad34.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad34.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad34.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad34.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad34.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad34.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad35 = new List<ComboBoxEntry>();
            iPad35.Add(new ComboBoxEntry("10A8426", "6.0.1 (10A8426)"));
            iPad35.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad35.Add(new ComboBoxEntry("10B147", "6.1.2 (10B147)"));
            iPad35.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad35.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad35.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad35.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad35.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad35.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad35.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad35.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad35.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad35.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad35.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad35.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad35.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad35.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad35.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad35.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad35.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad35.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad35.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad35.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad35.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad35.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad36 = new List<ComboBoxEntry>();
            iPad36.Add(new ComboBoxEntry("10A8426", "6.0.1 (10A8426)"));
            iPad36.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad36.Add(new ComboBoxEntry("10B147", "6.1.2 (10B147)"));
            iPad36.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad36.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad36.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad36.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad36.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad36.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad36.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad36.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad36.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad36.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad36.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad36.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad36.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad36.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad36.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad36.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad36.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad36.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad36.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad36.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad36.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad36.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad41 = new List<ComboBoxEntry>();
            iPad41.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad41.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad41.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad41.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad41.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad41.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad41.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad41.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad41.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad41.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad41.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad41.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad41.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad41.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad41.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad41.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad41.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad41.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad41.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad42 = new List<ComboBoxEntry>();
            iPad42.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad42.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad42.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad42.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad42.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad42.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad42.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad42.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad42.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad42.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad42.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad42.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad42.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad42.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad42.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad42.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad42.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad42.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad42.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad43 = new List<ComboBoxEntry>();
            iPad43.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad43.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad43.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad43.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad43.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad43.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad43.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad43.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad43.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad43.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad43.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad43.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad43.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad43.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad43.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad43.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad53 = new List<ComboBoxEntry>();
            iPad53.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad53.Add(new ComboBoxEntry("12B436", "8.1.1 (12B436)"));
            iPad53.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad53.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad53.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad53.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad53.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad53.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad53.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad53.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad54 = new List<ComboBoxEntry>();
            iPad54.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad54.Add(new ComboBoxEntry("12B436", "8.1.1 (12B436)"));
            iPad54.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad54.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad54.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad54.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad54.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad54.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad54.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad54.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));
        }
        private static void InitIPadMini()
        {
            iPad25 = new List<ComboBoxEntry>();
            iPad25.Add(new ComboBoxEntry("10A406", "6.0 (10A406)"));
            iPad25.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPad25.Add(new ComboBoxEntry("10A550", "6.0.2 (10A550)"));
            iPad25.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad25.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPad25.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad25.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad25.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad25.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad25.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad25.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad25.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad25.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad25.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad25.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad25.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad25.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad25.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad25.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad25.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad25.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad25.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad25.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad25.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad25.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad25.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad25.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad26 = new List<ComboBoxEntry>();
            iPad26.Add(new ComboBoxEntry("10A8426", "6.0.1 (10A8426)"));
            iPad26.Add(new ComboBoxEntry("10A8550", "6.0.2 (10A8550)"));
            iPad26.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad26.Add(new ComboBoxEntry("10B147", "6.1.2 (10B147)"));
            iPad26.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad26.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad26.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad26.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad26.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad26.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad26.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad26.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad26.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad26.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad26.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad26.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad26.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad26.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad26.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad26.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad26.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad26.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad26.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad26.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad26.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad26.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad27 = new List<ComboBoxEntry>();
            iPad27.Add(new ComboBoxEntry("10A8426", "6.0.1 (10A8426)"));
            iPad27.Add(new ComboBoxEntry("10A8550", "6.0.2 (10A8550)"));
            iPad27.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPad27.Add(new ComboBoxEntry("10B147", "6.1.2 (10B147)"));
            iPad27.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPad27.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPad27.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPad27.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad27.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad27.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad27.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad27.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad27.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad27.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad27.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad27.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad27.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad27.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad27.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad27.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad27.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad27.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad27.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad27.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad27.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad27.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad44 = new List<ComboBoxEntry>();
            iPad44.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad44.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad44.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad44.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad44.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad44.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad44.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad44.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad44.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad44.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad44.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad44.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad44.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad44.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad44.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad44.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad44.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad44.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad44.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad45 = new List<ComboBoxEntry>();
            iPad45.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPad45.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPad45.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPad45.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad45.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad45.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad45.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad45.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad45.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad45.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad45.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad45.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad45.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad45.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad45.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad45.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad45.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad45.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad45.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad46 = new List<ComboBoxEntry>();
            iPad46.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPad46.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPad46.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPad46.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPad46.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPad46.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPad46.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad46.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPad46.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad46.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad46.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad46.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad46.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad46.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad46.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad46.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad47 = new List<ComboBoxEntry>();
            iPad47.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad47.Add(new ComboBoxEntry("12B436", "8.1.1 (12B436)"));
            iPad47.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad47.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad47.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad47.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad47.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad47.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad47.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad47.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad48 = new List<ComboBoxEntry>();
            iPad48.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad48.Add(new ComboBoxEntry("12B436", "8.1.1 (12B436)"));
            iPad48.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad48.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad48.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad48.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad48.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad48.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad48.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad48.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad49 = new List<ComboBoxEntry>();
            iPad49.Add(new ComboBoxEntry("12B410", "8.1 (12B410)"));
            iPad49.Add(new ComboBoxEntry("12B436", "8.1.1 (12B436)"));
            iPad49.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPad49.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPad49.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPad49.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPad49.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPad49.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPad49.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPad49.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad51 = new List<ComboBoxEntry>();
            iPad51.Add(new ComboBoxEntry("13A340", "9.0 (13A340)"));
            iPad51.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPad52 = new List<ComboBoxEntry>();
            iPad52.Add(new ComboBoxEntry("13A340", "9.0 (13A340)"));
            iPad52.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));
        }
        private static void InitIPhone()
        {
            iPhone41 = new List<ComboBoxEntry>();
            iPhone41.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPhone41.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPhone41.Add(new ComboBoxEntry("9A406", "5.0.1 (9A406)"));
            iPhone41.Add(new ComboBoxEntry("9B179", "5.1 (9B179)"));
            iPhone41.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPhone41.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPhone41.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPhone41.Add(new ComboBoxEntry("10B142", "6.1 (10B142)"));
            iPhone41.Add(new ComboBoxEntry("10B145", "6.1.1 (10B145)"));
            iPhone41.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPhone41.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPhone41.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPhone41.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone41.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone41.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone41.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone41.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPhone41.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone41.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPhone41.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPhone41.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone41.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone41.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone41.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPhone41.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone41.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone41.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone41.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone41.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone41.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone41.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone41.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone51 = new List<ComboBoxEntry>();
            iPhone51.Add(new ComboBoxEntry("10A405", "6.0 (10A405)"));
            iPhone51.Add(new ComboBoxEntry("10A525", "6.0.1 (10A525)"));
            iPhone51.Add(new ComboBoxEntry("10A551", "6.0.2 (10A551)"));
            iPhone51.Add(new ComboBoxEntry("10B143", "6.1 (10B143)"));
            iPhone51.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPhone51.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPhone51.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPhone51.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone51.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone51.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone51.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone51.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPhone51.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone51.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPhone51.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPhone51.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone51.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone51.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone51.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPhone51.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone51.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone51.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone51.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone51.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone51.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone51.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone51.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone52 = new List<ComboBoxEntry>();
            iPhone52.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPhone52.Add(new ComboBoxEntry("10A525", "6.0.1 (10A525)"));
            iPhone52.Add(new ComboBoxEntry("10A551", "6.0.2 (10A551)"));
            iPhone52.Add(new ComboBoxEntry("10B143", "6.1 (10B143)"));
            iPhone52.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPhone52.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPhone52.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPhone52.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone52.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone52.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone52.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone52.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPhone52.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone52.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPhone52.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPhone52.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone52.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone52.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone52.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPhone52.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone52.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone52.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone52.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone52.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone52.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone52.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone52.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone53 = new List<ComboBoxEntry>();
            iPhone53.Add(new ComboBoxEntry("11A466", "7.0 (11A466)"));
            iPhone53.Add(new ComboBoxEntry("11A470a", "7.0.1 (11A470a)"));
            iPhone53.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone53.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone53.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone53.Add(new ComboBoxEntry("11B601", "7.0.5 (11B601)"));
            iPhone53.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone53.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPhone53.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone53.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPhone53.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPhone53.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone53.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone53.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone53.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPhone53.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone53.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone53.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone53.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone53.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone53.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone53.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone53.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone54 = new List<ComboBoxEntry>();
            iPhone54.Add(new ComboBoxEntry("11A466", "7.0 (11A466)"));
            iPhone54.Add(new ComboBoxEntry("11A470a", "7.0.1 (11A470a)"));
            iPhone54.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone54.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone54.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone54.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone54.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPhone54.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone54.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPhone54.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPhone54.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone54.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone54.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone54.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPhone54.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone54.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone54.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone54.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone54.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone54.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone54.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone54.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone61 = new List<ComboBoxEntry>();
            iPhone61.Add(new ComboBoxEntry("11A466", "7.0 (11A466)"));
            iPhone61.Add(new ComboBoxEntry("11A470a", "7.0.1 (11A470a)"));
            iPhone61.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone61.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone61.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone61.Add(new ComboBoxEntry("11B601", "7.0.5 (11B601)"));
            iPhone61.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone61.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPhone61.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone61.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPhone61.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPhone61.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone61.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone61.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone61.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPhone61.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone61.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone61.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone61.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone61.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone61.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone61.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone61.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone62 = new List<ComboBoxEntry>();
            iPhone62.Add(new ComboBoxEntry("11A466", "7.0 (11A466)"));
            iPhone62.Add(new ComboBoxEntry("11A470a", "7.0.1 (11A470a)"));
            iPhone62.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone62.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone62.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone62.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone62.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPhone62.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone62.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPhone62.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPhone62.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone62.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone62.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone62.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPhone62.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone62.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone62.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone62.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone62.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone62.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone62.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone62.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone71 = new List<ComboBoxEntry>();
            iPhone71.Add(new ComboBoxEntry("12A366", "8.0 (12A366)"));
            iPhone71.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone71.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone71.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone71.Add(new ComboBoxEntry("12B436", "8.1.1 (12B436)"));
            iPhone71.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone71.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone71.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone71.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone71.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone71.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone71.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone71.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone72 = new List<ComboBoxEntry>();
            iPhone72.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPhone72.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPhone72.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPhone72.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPhone72.Add(new ComboBoxEntry("12B436", "8.1.1 (12B436)"));
            iPhone72.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPhone72.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPhone72.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPhone72.Add(new ComboBoxEntry("12F70", "8.3 (12F70)"));
            iPhone72.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPhone72.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPhone72.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPhone72.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPhone81 = new List<ComboBoxEntry>();
            iPhone81.Add(new ComboBoxEntry("13A342", "9.0 (13A342)"));
            iPhone81.Add(new ComboBoxEntry("13A405", "9.0.1 (13A405)"));

            iPhone82 = new List<ComboBoxEntry>();
            iPhone82.Add(new ComboBoxEntry("13A343", "9.0 (13A343)"));
            iPhone82.Add(new ComboBoxEntry("13A405", "9.0.1 (13A405)"));
        }
        private static void InitIPodTouch()
        {
            iPod51 = new List<ComboBoxEntry>();
            iPod51.Add(new ComboBoxEntry("10A406", "6.0 (10A406)"));
            iPod51.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPod51.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPod51.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPod51.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPod51.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPod51.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPod51.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPod51.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPod51.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPod51.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPod51.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPod51.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
            iPod51.Add(new ComboBoxEntry("12A365", "8.0 (12A365)"));
            iPod51.Add(new ComboBoxEntry("12A402", "8.0.1 (12A402)"));
            iPod51.Add(new ComboBoxEntry("12A405", "8.0.2 (12A405)"));
            iPod51.Add(new ComboBoxEntry("12B411", "8.1 (12B411)"));
            iPod51.Add(new ComboBoxEntry("12B435", "8.1.1 (12B435)"));
            iPod51.Add(new ComboBoxEntry("12B440", "8.1.2 (12B440)"));
            iPod51.Add(new ComboBoxEntry("12B466", "8.1.3 (12B466)"));
            iPod51.Add(new ComboBoxEntry("12D508", "8.2 (12D508)"));
            iPod51.Add(new ComboBoxEntry("12F69", "8.3 (12F69)"));
            iPod51.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPod51.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPod51.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPod51.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));

            iPod71 = new List<ComboBoxEntry>();
            iPod71.Add(new ComboBoxEntry("12H143", "8.4 (12H143)"));
            iPod71.Add(new ComboBoxEntry("12H321", "8.4.1 (12H321)"));
            iPod71.Add(new ComboBoxEntry("13A344", "9.0 (13A344)"));
            iPod71.Add(new ComboBoxEntry("13A404", "9.0.1 (13A404)"));
        }
        private static void InitDeprecatedAppleTV()
        {
            AppleTV21 = new List<ComboBoxEntry>();
            AppleTV21.Add(new ComboBoxEntry("8M89", "4.0/4.1 (8M89)"));
            AppleTV21.Add(new ComboBoxEntry("8C150", "4.1/4.2 (8C150)"));
            AppleTV21.Add(new ComboBoxEntry("8C154", "4.1.1/4.2.1 (8C154)"));
            AppleTV21.Add(new ComboBoxEntry("8F191m", "4.2/4.3 (8F191m)"));
            AppleTV21.Add(new ComboBoxEntry("8F202", "4.2.1/4.3 (8F202)"));
            AppleTV21.Add(new ComboBoxEntry("8F305", "4.2.2/4.3 (8F305)"));
            AppleTV21.Add(new ComboBoxEntry("8F455", "4.3 (8F455)"));
            AppleTV21.Add(new ComboBoxEntry("9A334v", "4.4/5.0 (9A334v)"));
            AppleTV21.Add(new ComboBoxEntry("9A335a", "4.4.1/5.0 (9A335a)"));
            AppleTV21.Add(new ComboBoxEntry("9A336a", "4.4.2/5.0 (9A336a)"));
            AppleTV21.Add(new ComboBoxEntry("9A405l", "4.4.3/5.0.1 (9A405l)"));
            AppleTV21.Add(new ComboBoxEntry("9A406a", "4.4.4/5.0.1 (9A406a)"));
            AppleTV21.Add(new ComboBoxEntry("9B179b", "5.0/5.1 (9B179b)"));
            AppleTV21.Add(new ComboBoxEntry("9B206f", "5.0.1/5.1 (9B206f)"));
            AppleTV21.Add(new ComboBoxEntry("9B830", "5.0.2/5.1 (9B830)"));
            AppleTV21.Add(new ComboBoxEntry("10A406e", "5.1/6.0 (10A406e)"));
            AppleTV21.Add(new ComboBoxEntry("10B144b", "5.2/6.1 (10B144b)"));
            AppleTV21.Add(new ComboBoxEntry("10B329a", "5.2.1/6.1.3 (10B329a)"));
            AppleTV21.Add(new ComboBoxEntry("10B809", "5.3/6.1.4 (10B809)"));
            AppleTV21.Add(new ComboBoxEntry("11A470e", "6.0/7.0.1 (11A470e)"));
            AppleTV21.Add(new ComboBoxEntry("11A502", "6.0/7.0.2 (11A502)"));
            AppleTV21.Add(new ComboBoxEntry("11B511d", "6.0.1/7.0.3 (11B511d)"));
            AppleTV21.Add(new ComboBoxEntry("11B554a", "6.0.2/7.0.4 (11B554a)"));
            AppleTV21.Add(new ComboBoxEntry("11B651", "6.0.2/7.0.6 (11B651)"));
            AppleTV21.Add(new ComboBoxEntry("11D169b", "6.1/7.1 (11D169b)"));
            AppleTV21.Add(new ComboBoxEntry("11D201c", "6.1.1/7.1.1 (11D201c)"));
            AppleTV21.Add(new ComboBoxEntry("11D257c", "6.2/7.1.2 (11D257c)"));
            AppleTV21.Add(new ComboBoxEntry("11D258", "6.2.1/7.1.2 (11D258)"));
        }
        private static void InitDeprecatedIPad()
        {
            iPad11 = new List<ComboBoxEntry>();
            iPad11.Add(new ComboBoxEntry("7B367", "3.2 (7B367)"));
            iPad11.Add(new ComboBoxEntry("7B405", "3.2.1 (7B405)"));
            iPad11.Add(new ComboBoxEntry("7B500", "3.2.2 (7B500)"));
            iPad11.Add(new ComboBoxEntry("8C148", "4.2.1 (8C148)"));
            iPad11.Add(new ComboBoxEntry("8F190", "4.3 (8F190)"));
            iPad11.Add(new ComboBoxEntry("8G4", "4.3.1 (8G4)"));
            iPad11.Add(new ComboBoxEntry("8H7", "4.3.2 (8H7)"));
            iPad11.Add(new ComboBoxEntry("8J3", "4.3.3 (8J3)"));
            iPad11.Add(new ComboBoxEntry("8K2", "4.3.4 (8K2)"));
            iPad11.Add(new ComboBoxEntry("8L1", "4.3.5 (8L1)"));
            iPad11.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPad11.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPad11.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPad11.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
        }
        private static void InitDeprecatedIPhone()
        {
            iPhone11 = new List<ComboBoxEntry>();
            iPhone11.Add(new ComboBoxEntry("1A420", "1.0 proto (1A420)"));
            iPhone11.Add(new ComboBoxEntry("1A543a", "1.0 (1A543a)"));
            iPhone11.Add(new ComboBoxEntry("1C25", "1.0.1 (1C25)"));
            iPhone11.Add(new ComboBoxEntry("1C28", "1.0.2 (1C28)"));
            iPhone11.Add(new ComboBoxEntry("3A109a", "1.1.1 (3A109a)"));
            iPhone11.Add(new ComboBoxEntry("3B48b", "1.1.2 (3B48b)"));
            iPhone11.Add(new ComboBoxEntry("4A93", "1.1.3 (4A93)"));
            iPhone11.Add(new ComboBoxEntry("4A102", "1.1.4 (4A102)"));
            iPhone11.Add(new ComboBoxEntry("5A347", "2.0 (5A347)"));
            iPhone11.Add(new ComboBoxEntry("5B108", "2.0.1 (5B108)"));
            iPhone11.Add(new ComboBoxEntry("5C1", "2.0.2 (5C1)"));
            iPhone11.Add(new ComboBoxEntry("5F136", "2.1 (5F136)"));
            iPhone11.Add(new ComboBoxEntry("5G77", "2.2 (5G77)"));
            iPhone11.Add(new ComboBoxEntry("5H11", "2.2.1 (5H11)"));
            iPhone11.Add(new ComboBoxEntry("7A341", "3.0 (7A341)"));
            iPhone11.Add(new ComboBoxEntry("7A400", "3.0.1 (7A400)"));
            iPhone11.Add(new ComboBoxEntry("7C144", "3.1 (7C144)"));
            iPhone11.Add(new ComboBoxEntry("7D11", "3.1.2 (7D11)"));
            iPhone11.Add(new ComboBoxEntry("7E18", "3.1.3 (7E18)"));

            iPhone12 = new List<ComboBoxEntry>();
            iPhone12.Add(new ComboBoxEntry("5A345", "2.0 (5A345)"));
            iPhone12.Add(new ComboBoxEntry("5A347", "2.0 (5A347)"));
            iPhone12.Add(new ComboBoxEntry("5B108", "2.0.1 (5B108)"));
            iPhone12.Add(new ComboBoxEntry("5C1", "2.0.2 (5C1)"));
            iPhone12.Add(new ComboBoxEntry("5F136", "2.1 (5F136)"));
            iPhone12.Add(new ComboBoxEntry("5G77", "2.2 (5G77)"));
            iPhone12.Add(new ComboBoxEntry("5H11", "2.2.1 (5H11)"));
            iPhone12.Add(new ComboBoxEntry("7A341", "3.0 (7A341)"));
            iPhone12.Add(new ComboBoxEntry("7A400", "3.0.1 (7A400)"));
            iPhone12.Add(new ComboBoxEntry("7C144", "3.1 (7C144)"));
            iPhone12.Add(new ComboBoxEntry("7D11", "3.1.2 (7D11)"));
            iPhone12.Add(new ComboBoxEntry("7E18", "3.1.3 (7E18)"));
            iPhone12.Add(new ComboBoxEntry("8A293", "4.0 (8A293)"));
            iPhone12.Add(new ComboBoxEntry("8A306", "4.0.1 (8A306)"));
            iPhone12.Add(new ComboBoxEntry("8A400", "4.0.2 (8A400)"));
            iPhone12.Add(new ComboBoxEntry("8B117", "4.1 (8B117)"));
            iPhone12.Add(new ComboBoxEntry("8C148", "4.2.1 (8C148)"));

            iPhone21 = new List<ComboBoxEntry>();
            iPhone21.Add(new ComboBoxEntry("7A341", "3.0 (7A341)"));
            iPhone21.Add(new ComboBoxEntry("7A400", "3.0.1 (7A400)"));
            iPhone21.Add(new ComboBoxEntry("7C144", "3.1 (7C144)"));
            iPhone21.Add(new ComboBoxEntry("7D11", "3.1.2 (7D11)"));
            iPhone21.Add(new ComboBoxEntry("7E18", "3.1.3 (7E18)"));
            iPhone21.Add(new ComboBoxEntry("8A293", "4.0 (8A293)"));
            iPhone21.Add(new ComboBoxEntry("8A306", "4.0.1 (8A306)"));
            iPhone21.Add(new ComboBoxEntry("8A400", "4.0.2 (8A400)"));
            iPhone21.Add(new ComboBoxEntry("8B117", "4.1 (8B117)"));
            iPhone21.Add(new ComboBoxEntry("8C148a", "4.2.1 (8C148a)"));
            iPhone21.Add(new ComboBoxEntry("8F190", "4.3 (8F190)"));
            iPhone21.Add(new ComboBoxEntry("8G4", "4.3.1 (8G4)"));
            iPhone21.Add(new ComboBoxEntry("8H7", "4.3.2 (8H7)"));
            iPhone21.Add(new ComboBoxEntry("8J2", "4.3.3 (8J2)"));
            iPhone21.Add(new ComboBoxEntry("8K2", "4.3.4 (8K2)"));
            iPhone21.Add(new ComboBoxEntry("8L1", "4.3.5 (8L1)"));
            iPhone21.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPhone21.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPhone21.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPhone21.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPhone21.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPhone21.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPhone21.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPhone21.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPhone21.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));

            iPhone31 = new List<ComboBoxEntry>();
            iPhone31.Add(new ComboBoxEntry("8A293", "4.0 (8A293)"));
            iPhone31.Add(new ComboBoxEntry("8A306", "4.0.1 (8A306)"));
            iPhone31.Add(new ComboBoxEntry("8A400", "4.0.2 (8A400)"));
            iPhone31.Add(new ComboBoxEntry("8B117", "4.1 (8B117)"));
            iPhone31.Add(new ComboBoxEntry("8C148", "4.2.1 (8C148)"));
            iPhone31.Add(new ComboBoxEntry("8F190", "4.3 (8F190)"));
            iPhone31.Add(new ComboBoxEntry("8G4", "4.3.1 (8G4)"));
            iPhone31.Add(new ComboBoxEntry("8H7", "4.3.2 (8H7)"));
            iPhone31.Add(new ComboBoxEntry("8J2", "4.3.3 (8J2)"));
            iPhone31.Add(new ComboBoxEntry("8K2", "4.3.4 (8K2)"));
            iPhone31.Add(new ComboBoxEntry("8L1", "4.3.5 (8L1)"));
            iPhone31.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPhone31.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPhone31.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPhone31.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPhone31.Add(new ComboBoxEntry("9B208", "5.1.1 (9B208)"));
            iPhone31.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPhone31.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPhone31.Add(new ComboBoxEntry("10B144", "6.1 (10B144)"));
            iPhone31.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPhone31.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPhone31.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPhone31.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone31.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone31.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone31.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone31.Add(new ComboBoxEntry("11D169", "7.1 (11D169)"));
            iPhone31.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone31.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));

            iPhone32 = new List<ComboBoxEntry>();
            iPhone32.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPhone32.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPhone32.Add(new ComboBoxEntry("10B144", "6.1 (10B144)"));
            iPhone32.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPhone32.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPhone32.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPhone32.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone32.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone32.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone32.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone32.Add(new ComboBoxEntry("11D169", "7.1 (11D169)"));
            iPhone32.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone32.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));

            iPhone33 = new List<ComboBoxEntry>();
            iPhone33.Add(new ComboBoxEntry("8E218", "4.2.5 (8E218)"));
            iPhone33.Add(new ComboBoxEntry("8E200", "4.2.6 (8E200)"));
            iPhone33.Add(new ComboBoxEntry("8E303", "4.2.7 (8E303)"));
            iPhone33.Add(new ComboBoxEntry("8E401", "4.2.8 (8E401)"));
            iPhone33.Add(new ComboBoxEntry("8E501", "4.2.9 (8E501)"));
            iPhone33.Add(new ComboBoxEntry("8E600", "4.2.10 (8E600)"));
            iPhone33.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPhone33.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPhone33.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPhone33.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPhone33.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPhone33.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPhone33.Add(new ComboBoxEntry("10B141", "6.1 (10B141)"));
            iPhone33.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPhone33.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPhone33.Add(new ComboBoxEntry("11A465", "7.0 (11A465)"));
            iPhone33.Add(new ComboBoxEntry("11A501", "7.0.2 (11A501)"));
            iPhone33.Add(new ComboBoxEntry("11B511", "7.0.3 (11B511)"));
            iPhone33.Add(new ComboBoxEntry("11B554a", "7.0.4 (11B554a)"));
            iPhone33.Add(new ComboBoxEntry("11B651", "7.0.6 (11B651)"));
            iPhone33.Add(new ComboBoxEntry("11D167", "7.1 (11D167)"));
            iPhone33.Add(new ComboBoxEntry("11D201", "7.1.1 (11D201)"));
            iPhone33.Add(new ComboBoxEntry("11D257", "7.1.2 (11D257)"));
        }
        private static void InitDeprecatedIPodTouch()
        {
            iPod11 = new List<ComboBoxEntry>();
            iPod11.Add(new ComboBoxEntry("3A100a", "1.1 (3A100a)"));
            iPod11.Add(new ComboBoxEntry("3A101a", "1.1 (3A101a)"));
            iPod11.Add(new ComboBoxEntry("3A110a", "1.1.1 (3A110a)"));
            iPod11.Add(new ComboBoxEntry("3B48b", "1.1.2 (3B48b)"));
            iPod11.Add(new ComboBoxEntry("4A93", "1.1.3 (4A93)"));
            iPod11.Add(new ComboBoxEntry("4A102", "1.1.4 (4A102)"));
            iPod11.Add(new ComboBoxEntry("4B1", "1.1.5 (4B1)"));
            iPod11.Add(new ComboBoxEntry("5A347", "2.0 (5A347)"));
            iPod11.Add(new ComboBoxEntry("5B108", "2.0.1 (5B108)"));
            iPod11.Add(new ComboBoxEntry("5C1", "2.0.2 (5C1)"));
            iPod11.Add(new ComboBoxEntry("5F137", "2.1 (5F137)"));
            iPod11.Add(new ComboBoxEntry("5G77", "2.2 (5G77)"));
            iPod11.Add(new ComboBoxEntry("5H11", "2.2.1 (5H11)"));
            iPod11.Add(new ComboBoxEntry("7A341", "3.0 (7A341)"));
            iPod11.Add(new ComboBoxEntry("7C145", "3.1.1 (7C145)"));
            iPod11.Add(new ComboBoxEntry("7D11", "3.1.2 (7D11)"));
            iPod11.Add(new ComboBoxEntry("7E18", "3.1.3 (7E18)"));

            iPod21 = new List<ComboBoxEntry>();
            iPod21.Add(new ComboBoxEntry("5F138", "2.1.1 (5F138)"));
            iPod21.Add(new ComboBoxEntry("5G77a", "2.2 (5G77a)"));
            iPod21.Add(new ComboBoxEntry("5H11a", "2.2.1 (5H11a)"));
            iPod21.Add(new ComboBoxEntry("7A341", "3.0 (7A341)"));
            iPod21.Add(new ComboBoxEntry("7C145", "3.1.1 (7C145)"));
            iPod21.Add(new ComboBoxEntry("7D11", "3.1.2 (7D11)"));
            iPod21.Add(new ComboBoxEntry("7E18", "3.1.3 (7E18)"));
            iPod21.Add(new ComboBoxEntry("8A293", "4.0 (8A293)"));
            iPod21.Add(new ComboBoxEntry("8A400", "4.0.2 (8A400)"));
            iPod21.Add(new ComboBoxEntry("8B117", "4.1 (8B117)"));
            iPod21.Add(new ComboBoxEntry("8C148", "4.2.1 (8C148)"));

            iPod31 = new List<ComboBoxEntry>();
            iPod31.Add(new ComboBoxEntry("7C145", "3.1.1 (7C145)"));
            iPod31.Add(new ComboBoxEntry("7C146", "3.1.1 (7C146)"));
            iPod31.Add(new ComboBoxEntry("7D11", "3.1.2 (7D11)"));
            iPod31.Add(new ComboBoxEntry("7E18", "3.1.3 (7E18)"));
            iPod31.Add(new ComboBoxEntry("8A293", "4.0 (8A293)"));
            iPod31.Add(new ComboBoxEntry("8A400", "4.0.2 (8A400)"));
            iPod31.Add(new ComboBoxEntry("8B117", "4.1 (8B117)"));
            iPod31.Add(new ComboBoxEntry("8C148", "4.2.1 (8C148)"));
            iPod31.Add(new ComboBoxEntry("8F190", "4.3 (8F190)"));
            iPod31.Add(new ComboBoxEntry("8G4", "4.3.1 (8G4)"));
            iPod31.Add(new ComboBoxEntry("8H7", "4.3.2 (8H7)"));
            iPod31.Add(new ComboBoxEntry("8J2", "4.3.3 (8J2)"));
            iPod31.Add(new ComboBoxEntry("8K2", "4.3.4 (8K2)"));
            iPod31.Add(new ComboBoxEntry("8L1", "4.3.5 (8L1)"));
            iPod31.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPod31.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPod31.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPod31.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));

            iPod41 = new List<ComboBoxEntry>();
            iPod41.Add(new ComboBoxEntry("8B117", "4.1 (8B117)"));
            iPod41.Add(new ComboBoxEntry("8B118", "4.1 (8B118)"));
            iPod41.Add(new ComboBoxEntry("8C148", "4.2.1 (8C148)"));
            iPod41.Add(new ComboBoxEntry("8F190", "4.3 (8F190)"));
            iPod41.Add(new ComboBoxEntry("8G4", "4.3.1 (8G4)"));
            iPod41.Add(new ComboBoxEntry("8H7", "4.3.2 (8H7)"));
            iPod41.Add(new ComboBoxEntry("8J2", "4.3.3 (8J2)"));
            iPod41.Add(new ComboBoxEntry("8K2", "4.3.4 (8K2)"));
            iPod41.Add(new ComboBoxEntry("8L1", "4.3.5 (8L1)"));
            iPod41.Add(new ComboBoxEntry("9A334", "5.0 (9A334)"));
            iPod41.Add(new ComboBoxEntry("9A405", "5.0.1 (9A405)"));
            iPod41.Add(new ComboBoxEntry("9B176", "5.1 (9B176)"));
            iPod41.Add(new ComboBoxEntry("9B206", "5.1.1 (9B206)"));
            iPod41.Add(new ComboBoxEntry("10A403", "6.0 (10A403)"));
            iPod41.Add(new ComboBoxEntry("10A523", "6.0.1 (10A523)"));
            iPod41.Add(new ComboBoxEntry("10B144", "6.1 (10B144)"));
            iPod41.Add(new ComboBoxEntry("10B146", "6.1.2 (10B146)"));
            iPod41.Add(new ComboBoxEntry("10B329", "6.1.3 (10B329)"));
            iPod41.Add(new ComboBoxEntry("10B400", "6.1.4 (10B400)"));
        }
    }
}