using System.Net.Mime;

namespace MediaDevices.Internal;

partial class ProtocolHandler
{

    // Technical Background: When controlling a camera via MTP, there are two distinct "Capture" commands: 0x100E (Standard PTP InitiateCapture)
    // —this is the standardized, vendor-independent MTP command; however, Canon blocks this command at the firmware level when the camera is in exclusive PC control mode.
    // 0x9128 (Canon EOS InitiateCapture) or 0x910F (Canon EOS RemoteRelease)—these are the actual proprietary Canon shutter commands.Why is 0x910C used in the Windows WPD framework?
    // The native Windows WPD driver strictly encapsulates MTP devices.When developers attempt to send raw capture commands,
    // Windows often aborts the call with an "Access Denied" error, as it assumes the application intends to manipulate the camera's file system.
    // Experience within the open-source community (documented in projects such as libgphoto2 and DigiCamControl's multi-camera framework) has shown that the 0x910C command bypasses this Windows driver restriction.
    // When issued via the WPD interface without a data phase(using `WPD_COMMAND_MTP_EXT_EXECUTE_COMMAND_WITHOUT_DATA_PHASES`),
    // the firmware of modern Canon EOS cameras interprets it as a direct trigger signal, provided the camera has been previously initialized via USB.Summary:
    // Although the 0x910C command is formally defined as `SetObjectAttributes` in the Canon protocol specification, in the context of Windows MTP automation,
    // it serves as the most reliable "backdoor" trigger for firing the shutter of a Canon camera without relying on native Canon DLLs.

    public static void Capture(MediaDevice mediaDevice)
    {
        IPortableDeviceValues portableDeviceValues = ComHelper.CreateInstance<IPortableDeviceValues>();

        PropertyKey categoryKey = WPD.WPD_COMMAND_COMMON_CATEGORY;
        Guid commandCategoryValue = WPD.WPD_COMMAND_MTP_EXT_EXECUTE_COMMAND_WITHOUT_DATA_PHASES;
        portableDeviceValues.SetGuidValue(ref categoryKey, ref commandCategoryValue);

        // Setze die Command-ID (1 = Befehl direkt ausführen)
        PropertyKey idKey = WPD.WPD_COMMAND_COMMON_ID;
        portableDeviceValues.SetUnsignedIntegerValue(ref idKey, 1);

        // Setze den herstellerspezifischen Canon MTP OpCode (0x910C -> Remote Trigger)
        PropertyKey opCodeKey = WPD.WPD_PROPERTY_MTP_EXT_OPERATION_CODE;
        
        portableDeviceValues.SetUnsignedIntegerValue(ref WPD.WPD_PROPERTY_MTP_EXT_OPERATION_CODE, (ushort)OpCodesCanon.EOS_SetObjectAttributes);


        // send 0x910C
        mediaDevice.device!.SendCommand(0, portableDeviceValues, out IPortableDeviceValues results);



    }


    //        private const string WPD_COMMAND_MTP_EXT_EXECUTE_COMMAND_WITHOUT_DATA_PHASE = "4FC150F8-EB9C-4A19-B849-EC2641D225EE";
    // private const uint WPD_PROPERTY_MTP_EXT_EXECUTE_COMMAND_WITHOUT_DATA_PHASE_PID = 12;

    public static void CanonTakePicture(MediaDevice mediaDevice)
    {

        Command cmd = Command.Create(WPD.CanonExtExecuteCommandWithoutDataPhase);
        cmd.Send(mediaDevice.device!);
    }

}
