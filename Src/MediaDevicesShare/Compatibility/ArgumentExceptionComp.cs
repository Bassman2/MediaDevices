using System;

namespace MediaDevices.Compatibility
{
    internal class ArgumentExceptionComp : ArgumentException
    {
#if !NET7_0_OR_GREATER  
        public static void ThrowIfNullOrEmpty(object argument, string paramName = null)
        {
            if (argument is null || (argument is string str && string.IsNullOrEmpty(str)))
            {
                Throw(paramName);
            }
        }

        private static void Throw(string paramName) =>
            throw new ArgumentException(paramName);
#endif
    }
}
