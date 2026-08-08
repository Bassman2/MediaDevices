namespace MediaDevices.Internal;

internal enum ErrorCodes : int
{
    False = 1,
    OK = 0,
    NotImplemented          /**/ = unchecked((int)0x80004001),      // E_NOT_IMPLEMENTED
    NotSupported            /**/ = unchecked((int)0x80070032),      // ERROR_NOT_SUPPORTED
    InvalidParameter        /**/ = unchecked((int)0x80070057),      // ERROR_INVALID_PARAMETER + E_INVALIDARG
    NotFound                /**/ = unchecked((int)0x80070490),      // ERROR_NOT_FOUND
    ResourceNotAvailable    /**/ = unchecked((int)0x8007138e),      // ERROR_RESOURCE_NOT_AVAILABLE
    
    
}
