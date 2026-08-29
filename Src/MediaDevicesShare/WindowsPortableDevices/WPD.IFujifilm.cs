namespace MediaDevices.WindowsPortableDevices;

partial class WPD
{
    public static Guid FujifilmDeviceProperties = new Guid("EEEA5461-951E-418E-87A1-847A46810B63");

    //0xD108 Shooting Mode
    public static PropertyKey FujifilmDevicePropertyFilmSimulationMode = new(FujifilmDeviceProperties, 0xD019 - 0x8000);

    /*
    
    Core Exposure & Tether Control
    
    0xD019 – Film Simulation Mode (Controls the color profile: e.g., Provia, Velvia, Classic Chrome, Acros, Reala Ace).0xD028 – Focus Lever / Focus Mode Overrides (Allows the host software to bypass the physical focus switch state).0xD100 – Tether Connection Mode (Switches the camera internally between a standard USB card reader mode and software remote-control mode).0xD240 – Drive Mode Option (Single frame, continuous shooting, bracketing, etc.).0xD241 – Shutter Speed Control Selector (Determines if the shutter speed is set by the physical top dial or dictated via USB software).
    
     Film Recipe & Image Adjustments (Range 0xD18E to 0xD1A5)Modern bodies (like the X-T5, X-T50, X100VI, or GFX100 II) transfer complete JPEG recipe configurations over MTP:0xD18E – Film Simulation Parameter Extension0xD18F – Grain Effect (Off, Weak, Strong / Size: Small, Large).0xD190 – Color Chrome Effect / Color Chrome FX Blue0xD191 – White Balance Mode (Extended Custom)0xD192 – Color Temperature (Kelvin) (Direct numerical integer value transfer).0xD193 – Dynamic Range (DR100, DR200, DR400, Auto).0xD194 – Highlight Tone (Highlight curve adjustments).0xD195 – Shadow Tone (Shadow curve adjustments).0xD196 – Color / Saturation Strength0xD197 – Sharpness0xD198 – Noise Reduction (High ISO NR)0xD199 – Clarity
     
    Physical Dial Hardware TrackingBecause Fujifilm cameras rely heavily on tactile retro dials (ISO, Shutter Speed, Aperture rings), the camera communicates the physical positions of these dials to the software so the application knows whether a setting is locked:0xD201 – Shutter Speed Dial Status (Reports if the top physical dial is set to "A", "T", "B", or a locked mechanical speed).0xD202 – ISO Dial Status (Reports if the ISO wheel is set to "A", "C", or a locked hardware value).0xD203 – Aperture Ring Status (Reports if the lens aperture ring is locked to "A" or overridden manually).
     */

}
