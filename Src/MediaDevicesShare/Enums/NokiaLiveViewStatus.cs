namespace MediaDevices;

public enum NokiaLiveViewStatus
{

    /// <summary>
    /// Live View OFFSensor readout stops. Mirror drops down (DSLRs).
    /// The camera enters standard optical/idle standby mode.
    /// </summary>
    LiveViewOff = 0,

    /// <summary>
    /// Sensor activates. Mirror locks up (DSLRs). 
    /// Camera begins streaming live data across the internal bus.
    /// </summary>
    LiveViewOn = 1
}
