using System;

namespace MediaDevices
{
    internal class ArgumentNullExceptionComp : ArgumentNullException
    {
#if !NET
        public static void ThrowIfNull(object argument, string paramName = null)
        {
            if (argument is null)
            {
                Throw(paramName);
            }
        }

        private static void Throw(string paramName) =>
            throw new ArgumentNullException(paramName);
#endif
    }
}
