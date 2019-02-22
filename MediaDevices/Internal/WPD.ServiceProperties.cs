using System;

namespace MediaDevices.Internal
{
    internal static partial class WPD
    {

        public static Guid STATUSSVC_SERVICE_PROPERTIES = new Guid("{49cd1f76-5626-4b17-a4e8-18b4aa1a2213}");

        public static PropertyKey SignalStrength = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 2
        };

        public static PropertyKey TextMessages = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 3
        };

        public static PropertyKey NewPictures = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 4
        };

        public static PropertyKey MissedCalls = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 5
        };

        public static PropertyKey VoiceMail = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 6
        };

        public static PropertyKey NetworkName = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 7
        };

        public static PropertyKey NetworkType = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 8
        };

        public static PropertyKey Roaming = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 9
        };

        public static PropertyKey BatteryLife = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 10
        };

        public static PropertyKey ChargingState = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 11
        };

        public static PropertyKey StorageCapacity = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 12
        };

        public static PropertyKey StorageFreeSpace = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 13
        };


        public static PropertyKey InternetConnected = new PropertyKey()
        {
            fmtid = STATUSSVC_SERVICE_PROPERTIES,
            pid = 15
        };
    }
}
