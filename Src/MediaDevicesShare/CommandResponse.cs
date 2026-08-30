namespace MediaDevices;

public class CommandResponse
{
    private static readonly ThreadSafeWorker worker = ThreadSafeWorker.Instance;

    private IPortableDeviceValues result;

    internal CommandResponse(IPortableDeviceValues result)
    {
        this.result = result;
    }

    public Guid? GetGuid(PropertyKey key)
    {
        return worker.Invoke<Guid?>(() =>
        {
            if (this.result.GetGuidValue(ref key, out Guid value) != 0)
            {
                return null;
            }
            return value;
        });
    }

    public int? GetInt(PropertyKey key)
    {
        return worker.Invoke<int?>(() =>
        {
            if (this.result.GetSignedIntegerValue(ref key, out int value) != 0)
            {
                return null;
            }
            return value;
        });
    }

    public string? GetString(PropertyKey key)
    {
        return worker.Invoke(() =>
        {
            if (this.result.GetStringValue(ref key, out string value) != 0)
            {
                return null;
            }
            return value;
        });
    }
}
