namespace MediaDevices;

partial class MediaDevice
{
    /// <summary>
    /// Queries for vendor extended operation code.
    /// </summary>
    /// <returns>List of vendor extended operation code.</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<OpCodes> VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => WpdDevice.VendorOpcodes<OpCodes>(this.device!));
        
    }

    /// <summary>
    /// Execute a vendor command.
    /// </summary>
    /// <param name="opCode">Operational code of the vendor command.</param>
    /// <param name="inputParams">Input parameters.</param>
    /// <param name="respCode">Response code</param>
    /// <returns>Output parameters</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<int> VendorExcecute(OpCodes opCode, IEnumerable<int> inputParams, out int respCode)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        int resp = 0;
        var list = worker.InvokeEnumerable(() => WpdDevice.VendorExcecute(this.device!, opCode, inputParams, out resp));
        respCode = resp;
        return list;
    }

    /// <summary>
    /// Sends a MTP command block followed by a data phase with data from Device to Host.
    /// </summary>
    /// <param name="opCode">Operational code of the vendor command.</param>
    /// <param name="inputParams">Input parameters.</param>
    /// <returns>Returned as a context identifier for subsequent data transfer</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<int> VendorExcecuteRead(OpCodes opCode, IEnumerable<int> inputParams)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => WpdDevice.VendorExcecuteRead(this.device!, opCode, inputParams));
    }

    /// <summary>
    /// Sends a MTP command block followed by a data phase with data from Host to Device 
    /// </summary>
    /// <param name="opCode">Operational code of the vendor command.</param>
    /// <param name="inputParams">Input parameters.</param>
    /// <returns>Returned as a context identifier for subsequent data transfer</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<int> VendorExcecuteWrite(OpCodes opCode, IEnumerable<int> inputParams)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => WpdDevice.VendorExcecuteWrite(this.device!, opCode, inputParams));
    }


    //public IEnumerable<byte> VendorRead(string context, int bytesToRead, byte[] input, out int bytesRead)
    //{
    //    NotConnectedException.ThrowIfNotConnected(this);
    //
    //    return worker.VendorRead(this.mediaDevice, opCode, inputParams);
    //}

    //public int VendorWrite(string context, int bytesToWrite, byte[] buffer )
    //{
    //    NotConnectedException.ThrowIfNotConnected(this);
    //
    //    return worker.VendorWrite(this.mediaDevice, opCode, inputParams);
    //}

    /// <summary>
    /// completes a data transfer and read response from mediaDevice. The transfer is initiated by VendorExcecuteWrite
    /// </summary>
    /// <param name="context">The context idetifier returned in previous calls.</param>
    /// <param name="respCode">the response code to the vendor operation code.</param>
    /// <returns>identifying response params if any</returns>
    public IEnumerable<int> VendorEndTransfer(string context, out int respCode)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        int resp = 0;
        var list = worker.InvokeEnumerable(() => WpdDevice.VendorEndTransfer(this.device!, context, out resp));
        respCode = resp;
        return list;
    }

    /// <summary>
    /// Retrieves the vendor extension description string.
    /// </summary>
    /// <returns>Vendor extension description string</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string VendorExtentionDescription()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.Invoke(() => WpdDevice.VendorExtentionDescription(this.device!));
    }
}
