using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MediaDevices;

public enum NikonLiveViewAFAreaZ
{
    /// <summary>
    /// Ultra-small target zone meant for macro work or static, precise target selection.
    /// </summary>
    Pinpoint = 0,

    /// <summary>
    /// Standard focal acquisition zone box.Movable manually across the frame matrix.
    /// </summary>
    SinglePoint = 1,

    /// <summary>
    /// Small regional cluster tracking box.
    /// </summary>
    WideAreaSmall = 2,

    /// <summary>
    /// Large regional cluster tracking box.
    /// </summary>
    WideAreaLarge = 3,

    /// <summary>
    /// The camera evaluates the entire frame independently to locate subjects, priority given to humans/animals/vehicles.
    /// </summary>
    AutoArea = 4,

    /// <summary>
    /// Locks focus onto a target and dynamically follows it across all dimensions of the sensor field.
    /// </summary>
    ThreeDTracking = 5, 
}
