namespace MediaDevices;

public enum ManufacturerId : ushort
{
    /// <summary>
    /// Hewlett-Packard (HP)
    /// </summary>
    /// <remarks>Legacy HP cameras and MTP-enabled scanners</remarks>
    HewlettPackard = 0x03f0,

    /// <summary>
    /// Microsoft Corp.
    /// </summary>
    /// <remarks>Zune players (historical MTP variant)</remarks>
    Microsoft = 0x045e,

    /// <summary>
    /// Canon Inc.
    /// </summary>
    /// <remarks>EOS DSLR/Mirrorless and PowerShot cameras</remarks>
    Canon = 0x04a9,

    /// <summary>
    /// Nikon Corp.
    /// </summary>
    /// <remarks>Z-System mirrorless, DSLRs, and Coolpix cameras</remarks>
    Nikon = 0x04b0,

    /// <summary>
    /// Fujifilm Co., Ltd.
    /// </summary>
    /// <remarks>X-System and GFX medium format cameras</remarks>
    Fujifilm = 0x04cb,

    /// <summary>
    /// Panasonic Corporation
    /// </summary>
    /// <remarks>Lumix digital cameras</remarks>
    Panasonic = 0x04da,

    /// <summary>
    /// Samsung Electronics Co., Ltd.
    /// </summary>
    /// <remarks>Galaxy smartphones and tablets</remarks>
    Samsung = 0x04e8,

    /// <summary>
    /// Nactel (Nesta) / Leica
    /// </summary>
    /// <remarks>Leica digital cameras</remarks>
    Leica = 0x0511,

    /// <summary>
    /// Sony Corporation (Consumer Electronics)
    /// </summary>
    /// <remarks>Sony Alpha mirrorless cameras</remarks>
    SonyCorporation = 0x054c,

    /// <summary>
    /// Apple, Inc.
    /// </summary>
    /// <remarks>iPhones emulate PTP when connected to Windows/Mac for photo importing</remarks>
    Apple = 0x05ac,

    /// <summary>
    /// Qualcomm, Inc.
    /// </summary>
    /// <remarks>Various Android devices in USB debugging/MTP fallback modes</remarks>
    Qualcomm = 0x05c6,

    /// <summary>
    /// Olympus Optical Co., Ltd.
    /// </summary>
    /// <remarks>OM System and legacy Olympus cameras</remarks>
    Olympus = 0x07b4,

    /// <summary>
    /// Pentax Corporation
    /// </summary>
    /// <remarks>Pentax DSLRs and Ricoh cameras</remarks>
    Pentax = 0x0a17,

    /// <summary>
    /// HTC Corporation
    /// </summary>
    /// <remarks>Legacy HTC Android devices</remarks>
    HTC = 0x0bb4,

    /// <summary>
    /// Sony Mobile Communications (Smartphones & Tablets)
    /// </summary>
    /// <remarks>Xperia smartphones</remarks>
    SonyMobileCommunications = 0x0fce,

    /// <summary>
    /// LG Electronics Inc.
    /// </summary>
    /// <remarks>Legacy LG smartphones</remarks>
    LG = 0x1004,

    /// <summary>
    /// Huawei Technologies Co., Ltd.
    /// </summary>
    /// <remarks>Huawei and Honor devices</remarks>
    Huawei = 0x12d1,

    /// <summary>
    /// Google Inc.
    /// </summary>
    /// <remarks>Pixel smartphones and legacy Nexus devices</remarks>
    Google = 0x18d1,

    /// <summary>
    /// TCL Corporation
    /// </summary>
    /// <remarks>Alcatel and TCL mobile devices</remarks>
    TCL = 0x1bbb,

    /// <summary>
    /// Motorola PCS
    /// </summary>
    /// <remarks>Motorola smartphones</remarks>
    Motorola = 0x22b8,

    /// <summary>
    /// OPPO Mobile Telecommunications
    /// </summary>
    /// <remarks>Oppo and Realme smartphones</remarks>
    OPPO = 0x22d9,

    /// <summary>
    /// GoPro
    /// </summary>t
    /// <remarks>Hero action cameras</remarks>
    GoPro = 0x2672,

    /// <summary>
    /// Xiaomi Communications Co., Ltd.
    /// </summary>
    /// <remarks>Xiaomi, Redmi, Poco, and Black Shark devices</remarks>
    Xiaomi = 0x2717,

    /// <summary>
    /// OnePlus Technology Co., Ltd.
    /// </summary>
    /// <remarks>OnePlus devices</remarks>
    OnePlus = 0x2a70,

    /// <summary>
    /// Fairphone B.V.
    /// </summary>
    /// <remarks>Sustainable Fairphone models</remarks>
    Fairphone = 0x2b0e, 
}
