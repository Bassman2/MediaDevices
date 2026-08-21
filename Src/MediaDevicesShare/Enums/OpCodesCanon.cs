namespace MediaDevices;

public enum OpCodesCanon : ushort
{

    #region Canon Powershot

    /// <summary>
    /// Retrieves the size of a specified object on the Canon PowerShot device.
    /// </summary>
    Canon_PowershotGetObjectSize = 0x9001,

    /// <summary>
    /// Keeps the Canon PowerShot device active to prevent automatic power-down during communication sessions.
    /// </summary>
    Canon_PowershotKeepDeviceOn = 0x9003,

    /// <summary>
    /// Locks the user interface on the Canon PowerShot device to prevent accidental button presses during remote operations.
    /// </summary>
    Canon_PowershotLockDeviceUI = 0x9004,

    /// <summary>
    /// Unlocks the user interface on the Canon PowerShot device to allow normal button presses and manual control.
    /// </summary>
    Canon_PowershotUnlockDeviceUI = 0x9005,

    /// <summary>
    /// Initiates remote camera release control mode on the Canon PowerShot device for triggering captures.
    /// </summary>
    Canon_PowershotInitiateReleaseControl = 0x9008,

    /// <summary>
    /// Enables the viewfinder display on the Canon PowerShot device to show real-time preview.
    /// </summary>
    Canon_PowershotViewfinderOn = 0x900B,

    /// <summary>
    /// Disables the viewfinder display on the Canon PowerShot device to conserve power.
    /// </summary>
    Canon_PowershotViewfinderOff = 0x900C,

    /// <summary>
    /// Checks for pending events on the Canon PowerShot device such as button presses or focus completion.
    /// </summary>
    Canon_PowershotCheckEvent = 0x9013,

    /// <summary>
    /// Retrieves the current viewfinder image from the Canon PowerShot device for live preview display.
    /// </summary>
    Canon_PowershotGetViewfinderImage = 0x901D,

    /// <summary>
    /// Sets wireless LAN pairing information on the Canon PowerShot device for network connectivity.
    /// </summary>
    Canon_PowershotSetPairingInfoWLAN = 0x902F,

    /// <summary>
    /// Sets Bluetooth pairing information on the Canon PowerShot device for wireless communication.
    /// </summary>
    Canon_PowershotSetPairingInfoBluetooth = 0x9030,

    #endregion

    #region Canon EOS

    /// <summary>
    /// Retrieves the list of storage device identifiers (handles) available on the Canon EOS camera.
    /// </summary>
    Canon_EOSGetStorageIDs = 0x9101,

    /// <summary>
    /// Downloads a file object from the Canon EOS camera to the PC.
    /// </summary>
    Canon_EOSGetObject = 0x9104,

    /// <summary>
    /// Queries extended device information and capabilities specific to Canon EOS cameras.
    /// </summary>
    Canon_EOSGetDeviceInfoEx = 0x9108,

    /// <summary>
    /// Triggers a remote shutter release on the Canon EOS camera.
    /// </summary>
    /// <remarks>Triggers the camera via USB/IP.</remarks>
    Canon_EOSRemoteRelease = 0x910F,


    /// <summary>
    /// Enables or disables remote control mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>Switches the camera to PC control mode.</remarks>
    Canon_EOSSetRemoteMode = 0x9114,

    /// <summary>
    /// Polls for pending events on the Canon EOS camera such as button presses, focus completion, or operational status changes.
    /// </summary>
    /// <remarks>Queries camera events, e.g., setting changes.</remarks>
    Canon_EOSGetEvent = 0x9116,

    /// <summary>
    /// Initiates continuous bulb exposure (long shutter) mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>For long exposures</remarks>
    Canon_EOSBulbStart = 0x9125,

    /// <summary>
    /// Terminates continuous bulb exposure (long shutter) mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>For long exposures</remarks>
    Canon_EOSBulbEnd = 0x9126,

    /// <summary>
    /// Starts the viewfinder preview stream on the Canon EOS camera for live view display.
    /// </summary>
    /// <remarks>For Live View</remarks>
    Canon_EOSInitiateViewfinder = 0x9151,

    /// <summary>
    /// Stops the viewfinder preview stream on the Canon EOS camera.
    /// </summary>
    /// <remarks>For Live View</remarks>
    Canon_EOSTerminateViewfinder = 0x9152,

    /// <summary>
    /// Retrieves the current viewfinder image frame from the Canon EOS camera for live preview display.
    /// </summary>
    /// <remarks>Transfers the live view still images to the PC.</remarks>
    Canon_EOSGetViewFinderImage = 0x9153,

    /// <summary>
    /// Triggers autofocus on the Canon EOS camera.
    /// </summary>
    Canon_EOSDoAf = 0x9154,

    /// <summary>
    /// Controls lens focus motor movement on the Canon EOS camera for manual focus adjustments.
    /// </summary>
    /// <remarks>Manual focusing/lens stepping via software.</remarks>
    Canon_EOSDriveLens = 0x9155,

    #endregion

}
