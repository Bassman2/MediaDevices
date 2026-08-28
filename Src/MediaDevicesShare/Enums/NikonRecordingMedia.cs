using System.Collections;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

namespace MediaDevices;

public enum NikonRecordingMedia : ushort
{
    /// <summary>
    /// Photos stream directly to the internal CFexpress/XQD/SD slot..
    /// The computer receives a notification but no automatic file bytes.
    /// </summary>
    CardOnly = 0,

    /// <summary>
    /// The camera bypasses the physical memory card entirely. 
    /// Images write temporarily to internal camera RAM and dump directly into your application via standard MTP object events.
    /// </summary>
    HostOnly = 1,

    /// <summary>
    /// Highly recommended. The camera writes a safe copy to the local memory card while simultaneously sending a copy across the USB wire.
    /// </summary>
    BackupMode = 2
}
