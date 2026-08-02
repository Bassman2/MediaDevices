namespace MediaDevices;

partial class MainWorker
{
    public IEnumerable<uint> VendorOpcodes(IPortableDevice device)
    {
        return InvokeEnumerable(() =>
        {
            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_GET_SUPPORTED_VENDOR_OPCODES);
            cmd.Send(device);
            var list = cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_VENDOR_OPERATION_CODES);
            return list.Select(p => p.ToUInt());
        });
    }

    public IEnumerable<int> VendorExcecute(IPortableDevice device, int opCode, IEnumerable<int> inputParams, out int respCode)
    {
        int resp = 0;
        var list = InvokeEnumerable(() =>
        {
            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_EXECUTE_COMMAND_WITHOUT_DATA_PHASE);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_CODE, opCode);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_PARAMS, inputParams);
            cmd.Send(device);
            resp = cmd.GetInt(WPD.PROPERTY_MTP_EXT_RESPONSE_CODE);
            return cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_RESPONSE_PARAMS).Select(p => p.ToInt());
        });
        respCode = resp;
        return list;
    }

    public IEnumerable<int> VendorExcecuteRead(IPortableDevice device, int opCode, IEnumerable<int> inputParams)
    {
        return InvokeEnumerable(() =>
        {
            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_READ);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_CODE, opCode);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_PARAMS, inputParams);
            cmd.Send(device);
            var list = cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_VENDOR_OPERATION_CODES).ToList();
            return list.Select(p => p.ToInt());
        });
    }

    public IEnumerable<int> VendorExcecuteWrite(IPortableDevice device, int opCode, IEnumerable<int> inputParams)
    {
        return InvokeEnumerable(() =>
        {
            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_WRITE);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_CODE, opCode);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_PARAMS, inputParams);
            cmd.Send(device);
            var list = cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_VENDOR_OPERATION_CODES).ToList();
            return list.Select(p => p.ToInt());
        });
    }

    //public IEnumerable<byte> VendorRead(IPortableDevice mediaDevice, string context, int bytesToRead, byte[] input, out int bytesRead)
    //{
    //    return InvokeEnumerable(() =>
    //    {
    //        Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_READ_DATA);
    //        cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_CONTEXT, opCode);
    //        cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_NUM_BYTES_TO_READ, inputParams);
    //        cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_DATA, inputParams);
    //        cmd.Send(mediaDevice);
    //        var list = cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_VENDOR_OPERATION_CODES).ToList();
    //        return list.Select(p => p.ToInt()).ToList();
    //    });
    //}

    //public int VendorWrite(IPortableDevice mediaDevice, string context, int bytesToWrite, byte[] buffer)
    //{
    //    return InvokeEnumerable(() =>
    //    {
    //        Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_WRITE_DATA);
    //        cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_CONTEXT, context);
    //        cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_NUM_BYTES_TO_WRITE, bytesToWrite);
    //        cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_DATA, buffer);
    //        cmd.Send(mediaDevice);
    //        return cmd.GetInt(WPD.PROPERTY_MTP_EXT_TRANSFER_NUM_BYTES_WRITTEN);
    //    });
    //}

    public IEnumerable<int> VendorEndTransfer(IPortableDevice device, string context, out int respCode)
    {
        int resp = 0;
        var list = InvokeEnumerable(() =>
        {
            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_END_DATA_TRANSFER);
            cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_CONTEXT, context);
            cmd.Send(device);
            resp = cmd.GetInt(WPD.PROPERTY_MTP_EXT_RESPONSE_CODE);
            return cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_RESPONSE_PARAMS).Select(p => p.ToInt());
        });
        respCode = resp;
        return list;
    }

    public string VendorExtentionDescription(IPortableDevice device)
    {
        return Invoke(() =>
        {

            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_GET_VENDOR_EXTENSION_DESCRIPTION);
            cmd.Send(device);
            string description = cmd.GetString(WPD.PROPERTY_MTP_EXT_VENDOR_EXTENSION_DESCRIPTION);
            return description;
        });
    }
}
