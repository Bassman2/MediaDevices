namespace MediaDevices.Internal;

internal enum ErrorCodes : int
{
    NotSupported            /**/ = unchecked((int)0x80070032),      // ERROR_NOT_SUPPORTED
    InvalidParameter        /**/ = unchecked((int)0x80070057),      // ERROR_INVALID_PARAMETER + E_INVALIDARG
    ResourceNotAvailable    /**/ = unchecked((int)0x8007138e),      // ERROR_RESOURCE_NOT_AVAILABLE

    //unchecked((int)0x80070005)
    //unchecked((int)0x80070057)
    //unchecked((int)0x8007000E)
    //unchecked((int)0x80070032)
    //unchecked((int)0x8007007A)
    //unchecked((int)0x8007001F)
    //unchecked((int)0x80070002)
}
