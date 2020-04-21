using System;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
//using System.Text;
using System.ComponentModel;
//using System.Runtime.CompilerServices;

//#if NETCOREAPP
//#nullable enable
//#endif

namespace MediaDevices.Internal
{
#if NETCOREAPP

    //[EditorBrowsable(EditorBrowsableState.Never)]
    //public struct STATSTG
    //{
    //    public FILETIME atime;
    //    public long cbSize;
    //    public Guid clsid;
    //    public FILETIME ctime;
    //    public int grfLocksSupported;
    //    public int grfMode;
    //    public int grfStateBits;
    //    public FILETIME mtime;
    //    [NullableAttribute(1)]
    //    public string pwcsName;
    //    public int reserved;
    //    public int type;
    //}

#else

    //public struct STATSTG
    //{
    //    public string pwcsName;
    //    public int type;
    //    public long cbSize;
    //    public FILETIME mtime;
    //    public FILETIME ctime;
    //    public FILETIME atime;
    //    public int grfMode;
    //    public int grfLocksSupported;
    //    public Guid clsid;
    //    public int grfStateBits;
    //    public int reserved;
    //}

#endif
}
