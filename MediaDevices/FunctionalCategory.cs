using System;

namespace MediaDevices
{
    /// <summary>
    /// Functional categories
    /// </summary>
    public enum FunctionalCategory
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [EnumGuid]
        Unknown,

        /// <summary>
        /// Used for the device object, which is always the top-most object of the device. 
        /// </summary>
        [EnumGuid(0x08EA466B, 0xE3A4, 0x4336, 0xA1, 0xF3, 0xA4, 0x4D, 0x2B, 0x5C, 0x43, 0x8C)]
        Device,

        /// <summary>
        /// Indicates this object encapsulates storage functionality on the device 
        /// (e.g. memory cards, internal memory)
        /// </summary>
        [EnumGuid(0x23F05BBC, 0x15DE, 0x4C2A, 0xA5, 0x5B, 0xA9, 0xAF, 0x5C, 0xE4, 0x12, 0xEF)]
        Storage,

        /// <summary>
        /// Indicates this object encapsulates still image capture functionality on the device 
        /// (e.g. camera or camera attachment) 
        /// </summary>            
        [EnumGuid(0x613CA327, 0xAB93, 0x4900, 0xB4, 0xFA, 0x89, 0x5B, 0xB5, 0x87, 0x4B, 0x79)]
        StillImageCapture,

        /// <summary>
        /// Indicates this object encapsulates audio capture functionality on the device 
        /// (e.g. voice recorder or other audio recording component) 
        /// </summary>               
        [EnumGuid(0x3F2A1919, 0xC7C2, 0x4A00, 0x85, 0x5D, 0xF5, 0x7C, 0xF0, 0x6D, 0xEB, 0xBB)]
        AudioCapture,

        /// <summary>
        /// Indicates this object encapsulates video capture functionality on the device 
        /// (e.g. video recorder or video recording component) 
        /// </summary>                      
        [EnumGuid(0xE23E5F6B, 0x7243, 0x43AA, 0x8D, 0xF1, 0x0E, 0xB3, 0xD9, 0x68, 0xA9, 0x18)]
        VideoCapture,

        /// <summary>
        /// Indicates this object encapsulates SMS sending functionality on the device 
        /// (not the receiving or saved SMS messages since those are represented as content objects on the device)
        /// </summary>                     
        [EnumGuid(0x0044A0B1, 0xC1E9, 0x4AFD, 0xB3, 0x58, 0xA6, 0x2C, 0x61, 0x17, 0xC9, 0xCF)]
        SMS,

        /// <summary>
        /// Indicates this object provides information about the rendering characteristics of the device. 
        /// </summary>                            
        [EnumGuid(0x08600BA4, 0xA7BA, 0x4A01, 0xAB, 0x0E, 0x00, 0x65, 0xD0, 0xA3, 0x56, 0xD3)]
        RenderingInformation,

        /// <summary>
        /// Indicates this object encapsulates network configuration functionality on the device 
        /// (e.g. WiFi Profiles, Partnerships). 
        /// </summary>                 
        [EnumGuid(0x48F4DB72, 0x7C6A, 0x4AB0, 0x9E, 0x1A, 0x47, 0x0E, 0x3C, 0xDB, 0xF2, 0x6A)]
        NetworkConfiguration,

        /// <summary>
        /// This functional category is only valid as a parameter to API functions and driver commands. 
        /// It should not be reported as a supported functional category by the driver.
        /// </summary>                  
        [EnumGuid(0x2D8A6512, 0xA74C, 0x448E, 0xBA, 0x8A, 0xF4, 0xAC, 0x07, 0xC4, 0x93, 0x99)]
        All                   
    }
}
