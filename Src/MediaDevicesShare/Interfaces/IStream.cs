namespace MediaDevices.Interfaces;

// for source-generated COM interface wrapper, we need to define a struct that matches the layout of the original STATSTG struct,
// but with a raw pointer for the string field. This allows us to avoid issues with string marshalling and ensures that the memory layout is compatible with the COM interface.
// Another option is to write a custom marshaller for the string field, but using a raw pointer is simpler and more efficient in this case.

/*
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public unsafe struct NativeSTATSTG
{
    // public string pwcsName; // Original field, but we need to change it to a raw pointer for source-generated COM interface wrapper
    //public char* pwcsName; // Changed from string to a raw pointer
    public IntPtr pwcsName; // Changed from string to a raw pointer
    public int type;
    public long cbSize;
    public System.Runtime.InteropServices.ComTypes.FILETIME mtime;
    public System.Runtime.InteropServices.ComTypes.FILETIME atime;
    public System.Runtime.InteropServices.ComTypes.FILETIME mtime2; // Verify mapping names to match original layout
    public int grfMode;
    public int grfLocksSupported;
    public Guid clsid;
    public int grfStateBits;
    public int reserved;
}
*/

[GeneratedComInterface]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("0000000c-0000-0000-C000-000000000046")]
internal partial interface IStream
{
    [PreserveSig]
    int Read(
        [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, 
        int cb,
        out ulong read); //IntPtr pcbRead);

    [PreserveSig]
    int Write(
        [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv,
        int cb,
        out ulong written); // IntPtr pcbWritten);

    // IStream portion
    [PreserveSig]
    int Seek(
        long dlibMove, 
        int dwOrigin, 
        IntPtr plibNewPosition);

    [PreserveSig]
    int SetSize(
        long libNewSize);

    [PreserveSig]
    int CopyTo(
        IStream pstm, 
        long cb, 
        IntPtr pcbRead, 
        IntPtr pcbWritten);

    [PreserveSig]
    int Commit(
        int grfCommitFlags);

    void Revert();

    void LockRegion(
        long libOffset, 
        long cb, 
        int dwLockType);

    void UnlockRegion(
        long libOffset, 
        long cb, 
        int dwLockType);

    //void Stat(
    //    out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg,
    //    int grfStatFlag);
    
    //void Clone(
    //    out IStream ppstm);
}
