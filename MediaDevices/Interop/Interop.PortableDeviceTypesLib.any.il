
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Interop.PortableDeviceTypesLib
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibVersionAttribute::.ctor(int32,
                                                                                                int32) = ( 01 00 01 00 00 00 00 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Security.SecurityRulesAttribute::.ctor(valuetype [mscorlib]System.Security.SecurityRuleSet) = ( 01 00 02 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 32 62 30 30 62 61 32 66 2D 65 37 35 30   // ..$2b00ba2f-e750
                                                                                                  2D 34 62 65 62 2D 39 32 33 35 2D 39 37 31 34 32   // -4beb-9235-97142
                                                                                                  65 64 65 31 64 33 65 00 00 )                      // ede1d3e..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ImportedFromTypeLibAttribute::.ctor(string) = ( 01 00 16 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ...PortableDevic
                                                                                                                 65 54 79 70 65 73 4C 69 62 00 00 )                // eTypesLib..
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module PortableDeviceTypesLib.dll
// MVID: {6E662305-CA4E-47F6-B3A5-F6D8587C4715}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00460000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi import PortableDeviceTypesLib.WpdSerializerClass
       extends [mscorlib]System.Object
       implements PortableDeviceTypesLib.IWpdSerializer,
                  PortableDeviceTypesLib.WpdSerializer
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 42 39 31 41 37 34 42 2D 41 44 37 43   // ..$0B91A74B-AD7C
                                                                                                  2D 34 41 39 44 2D 42 35 36 33 2D 32 39 45 45 46   // -4A9D-B563-29EEF
                                                                                                  39 31 36 37 31 37 32 00 00 )                      // 9167172..
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(int16) = ( 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 02 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor() runtime managed internalcall
  {
  } // end of method WpdSerializerClass::.ctor

  .method public hidebysig newslot virtual 
          instance void  GetIPortableDeviceValuesFromBuffer([in] uint8& pBuffer,
                                                            [in] uint32 dwInputBufferLength,
                                                            [out] class PortableDeviceTypesLib.PortableDeviceValues&  marshal( interface ) ppParams) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IWpdSerializer::GetIPortableDeviceValuesFromBuffer
  } // end of method WpdSerializerClass::GetIPortableDeviceValuesFromBuffer

  .method public hidebysig newslot virtual 
          instance void  WriteIPortableDeviceValuesToBuffer([in] uint32 dwOutputBufferLength,
                                                            [in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pResults,
                                                            [out] uint8& pBuffer,
                                                            [out] uint32& pdwBytesWritten) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IWpdSerializer::WriteIPortableDeviceValuesToBuffer
  } // end of method WpdSerializerClass::WriteIPortableDeviceValuesToBuffer

  .method public hidebysig newslot virtual 
          instance void  GetBufferFromIPortableDeviceValues([in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pSource,
                                                            [out] native int ppBuffer,
                                                            [out] uint32& pdwBufferSize) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IWpdSerializer::GetBufferFromIPortableDeviceValues
  } // end of method WpdSerializerClass::GetBufferFromIPortableDeviceValues

  .method public hidebysig newslot virtual 
          instance void  GetSerializedSize([in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pSource,
                                           [out] uint32& pdwSize) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IWpdSerializer::GetSerializedSize
  } // end of method WpdSerializerClass::GetSerializedSize

} // end of class PortableDeviceTypesLib.WpdSerializerClass

.class interface public abstract auto ansi import PortableDeviceTypesLib.WpdSerializer
       implements PortableDeviceTypesLib.IWpdSerializer
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 42 33 32 46 34 30 30 32 2D 42 42 32 37   // ..$B32F4002-BB27
                                                                                                  2D 34 35 46 46 2D 41 46 34 46 2D 30 36 36 33 31   // -45FF-AF4F-06631
                                                                                                  43 31 45 38 44 41 44 00 00 )                      // C1E8DAD..
  .custom instance void [mscorlib]System.Runtime.InteropServices.CoClassAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 29 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ..)PortableDevic
                                                                                                                          65 54 79 70 65 73 4C 69 62 2E 57 70 64 53 65 72   // eTypesLib.WpdSer
                                                                                                                          69 61 6C 69 7A 65 72 43 6C 61 73 73 00 00 )       // ializerClass..
} // end of class PortableDeviceTypesLib.WpdSerializer

.class interface public abstract auto ansi import PortableDeviceTypesLib.IWpdSerializer
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 42 33 32 46 34 30 30 32 2D 42 42 32 37   // ..$B32F4002-BB27
                                                                                                  2D 34 35 46 46 2D 41 46 34 46 2D 30 36 36 33 31   // -45FF-AF4F-06631
                                                                                                  43 31 45 38 44 41 44 00 00 )                      // C1E8DAD..
  .method public hidebysig newslot abstract virtual 
          instance void  GetIPortableDeviceValuesFromBuffer([in] uint8& pBuffer,
                                                            [in] uint32 dwInputBufferLength,
                                                            [out] class PortableDeviceTypesLib.PortableDeviceValues&  marshal( interface ) ppParams) runtime managed internalcall
  {
  } // end of method IWpdSerializer::GetIPortableDeviceValuesFromBuffer

  .method public hidebysig newslot abstract virtual 
          instance void  WriteIPortableDeviceValuesToBuffer([in] uint32 dwOutputBufferLength,
                                                            [in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pResults,
                                                            [out] uint8& pBuffer,
                                                            [out] uint32& pdwBytesWritten) runtime managed internalcall
  {
  } // end of method IWpdSerializer::WriteIPortableDeviceValuesToBuffer

  .method public hidebysig newslot abstract virtual 
          instance void  GetBufferFromIPortableDeviceValues([in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pSource,
                                                            [out] native int ppBuffer,
                                                            [out] uint32& pdwBufferSize) runtime managed internalcall
  {
  } // end of method IWpdSerializer::GetBufferFromIPortableDeviceValues

  .method public hidebysig newslot abstract virtual 
          instance void  GetSerializedSize([in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pSource,
                                           [out] uint32& pdwSize) runtime managed internalcall
  {
  } // end of method IWpdSerializer::GetSerializedSize

} // end of class PortableDeviceTypesLib.IWpdSerializer

.class interface public abstract auto ansi import PortableDeviceTypesLib.IPortableDeviceValues
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 36 38 34 38 46 36 46 32 2D 33 31 35 35   // ..$6848F6F2-3155
                                                                                                  2D 34 46 38 36 2D 42 36 46 35 2D 32 36 33 45 45   // -4F86-B6F5-263EE
                                                                                                  45 41 42 33 31 34 33 00 00 )                      // EAB3143..
  .method public hidebysig newslot abstract virtual 
          instance void  GetCount([in] uint32& pcelt) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetCount

  .method public hidebysig newslot abstract virtual 
          instance void  GetAt([in] uint32 index,
                               [in][out] valuetype PortableDeviceTypesLib._tagpropertykey& pKey,
                               [in][out] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetAt

  .method public hidebysig newslot abstract virtual 
          instance void  SetValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                  [in] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                  [out] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetStringValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                        [in] string  marshal( lpwstr) Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetStringValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetStringValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                        [out] string&  marshal( lpwstr) pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetStringValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetUnsignedIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                 [in] uint32 Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetUnsignedIntegerValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetUnsignedIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                 [out] uint32& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetUnsignedIntegerValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetSignedIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                               [in] int32 Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetSignedIntegerValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetSignedIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                               [out] int32& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetSignedIntegerValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetUnsignedLargeIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                      [in] uint64 Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetUnsignedLargeIntegerValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetUnsignedLargeIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                      [out] uint64& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetUnsignedLargeIntegerValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetSignedLargeIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                    [in] int64 Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetSignedLargeIntegerValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetSignedLargeIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                    [out] int64& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetSignedLargeIntegerValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetFloatValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                       [in] float32 Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetFloatValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetFloatValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                       [out] float32& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetFloatValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetErrorValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                       [in] int32  marshal( error) Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetErrorValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetErrorValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                       [out] int32&  marshal( error) pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetErrorValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetKeyValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                     [in] valuetype PortableDeviceTypesLib._tagpropertykey& Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetKeyValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetKeyValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                     [out] valuetype PortableDeviceTypesLib._tagpropertykey& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetKeyValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetBoolValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                      [in] int32 Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetBoolValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetBoolValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                      [out] int32& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetBoolValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetIUnknownValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                          [in] object  marshal( iunknown ) pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetIUnknownValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetIUnknownValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                          [out] object&  marshal( iunknown ) ppValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetIUnknownValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetGuidValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                      [in] valuetype [mscorlib]System.Guid& Value) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetGuidValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetGuidValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                      [out] valuetype [mscorlib]System.Guid& pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetGuidValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetBufferValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                        [in] uint8& pValue,
                                        [in] uint32 cbValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetBufferValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetBufferValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                        [out] native int ppValue,
                                        [out] uint32& pcbValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetBufferValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetIPortableDeviceValuesValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                       [in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetIPortableDeviceValuesValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetIPortableDeviceValuesValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                       [out] class PortableDeviceTypesLib.PortableDeviceValues&  marshal( interface ) ppValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetIPortableDeviceValuesValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetIPortableDevicePropVariantCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                                      [in] class PortableDeviceTypesLib.PortableDevicePropVariantCollection  marshal( interface ) pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetIPortableDevicePropVariantCollectionValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetIPortableDevicePropVariantCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                                      [out] class PortableDeviceTypesLib.PortableDevicePropVariantCollection&  marshal( interface ) ppValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetIPortableDevicePropVariantCollectionValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetIPortableDeviceKeyCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                              [in] class PortableDeviceTypesLib.PortableDeviceKeyCollection  marshal( interface ) pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetIPortableDeviceKeyCollectionValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetIPortableDeviceKeyCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                              [out] class PortableDeviceTypesLib.PortableDeviceKeyCollection&  marshal( interface ) ppValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetIPortableDeviceKeyCollectionValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetIPortableDeviceValuesCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                                 [in] class PortableDeviceTypesLib.PortableDeviceValuesCollection  marshal( interface ) pValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::SetIPortableDeviceValuesCollectionValue

  .method public hidebysig newslot abstract virtual 
          instance void  GetIPortableDeviceValuesCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                                 [out] class PortableDeviceTypesLib.PortableDeviceValuesCollection&  marshal( interface ) ppValue) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::GetIPortableDeviceValuesCollectionValue

  .method public hidebysig newslot abstract virtual 
          instance void  RemoveValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::RemoveValue

  .method public hidebysig newslot abstract virtual 
          instance void  CopyValuesFromPropertyStore([in] class PortableDeviceTypesLib.IPropertyStore  marshal( interface ) pStore) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::CopyValuesFromPropertyStore

  .method public hidebysig newslot abstract virtual 
          instance void  CopyValuesToPropertyStore([in] class PortableDeviceTypesLib.IPropertyStore  marshal( interface ) pStore) runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::CopyValuesToPropertyStore

  .method public hidebysig newslot abstract virtual 
          instance void  Clear() runtime managed internalcall
  {
  } // end of method IPortableDeviceValues::Clear

} // end of class PortableDeviceTypesLib.IPortableDeviceValues

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._tagpropertykey
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public valuetype [mscorlib]System.Guid fmtid
  .field public uint32 pid
} // end of class PortableDeviceTypesLib._tagpropertykey

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tag_inner_PROPVARIANT
       extends [mscorlib]System.ValueType
{
  .pack 8
  .size 0
  .field public uint16 vt
  .field public uint8 wReserved1
  .field public uint8 wReserved2
  .field public uint32 wReserved3
  .field public valuetype PortableDeviceTypesLib.__MIDL___MIDL_itf_PortableDeviceTypes_0003_0015_0001 __MIDL____MIDL_itf_PortableDeviceTypes_0003_00150001
} // end of class PortableDeviceTypesLib.tag_inner_PROPVARIANT

.class public explicit ansi sealed PortableDeviceTypesLib.__MIDL___MIDL_itf_PortableDeviceTypes_0003_0015_0001
       extends [mscorlib]System.ValueType
{
  .pack 8
  .size 8
} // end of class PortableDeviceTypesLib.__MIDL___MIDL_itf_PortableDeviceTypes_0003_0015_0001

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._LARGE_INTEGER
       extends [mscorlib]System.ValueType
{
  .pack 8
  .size 0
  .field public int64 QuadPart
} // end of class PortableDeviceTypesLib._LARGE_INTEGER

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._ULARGE_INTEGER
       extends [mscorlib]System.ValueType
{
  .pack 8
  .size 0
  .field public uint64 QuadPart
} // end of class PortableDeviceTypesLib._ULARGE_INTEGER

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._FILETIME
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public uint32 dwLowDateTime
  .field public uint32 dwHighDateTime
} // end of class PortableDeviceTypesLib._FILETIME

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCLIPDATA
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cbSize
  .field public int32 ulClipFmt
  .field public native int pClipData
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCLIPDATA

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagBSTRBLOB
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cbSize
  .field public native int pData
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagBSTRBLOB

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagBLOB
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cbSize
  .field public native int pBlobData
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagBLOB

.class interface public abstract auto ansi import PortableDeviceTypesLib.IStream
       implements PortableDeviceTypesLib.ISequentialStream
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 30 30 30 30 30 30 43 2D 30 30 30 30   // ..$0000000C-0000
                                                                                                  2D 30 30 30 30 2D 43 30 30 30 2D 30 30 30 30 30   // -0000-C000-00000
                                                                                                  30 30 30 30 30 34 36 00 00 )                      // 0000046..
  .method public hidebysig newslot abstract virtual 
          instance void  RemoteRead([out] uint8& pv,
                                    [in] uint32 cb,
                                    [out] uint32& pcbRead) runtime managed internalcall
  {
  } // end of method IStream::RemoteRead

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteWrite([in] uint8& pv,
                                     [in] uint32 cb,
                                     [out] uint32& pcbWritten) runtime managed internalcall
  {
  } // end of method IStream::RemoteWrite

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteSeek([in] valuetype PortableDeviceTypesLib._LARGE_INTEGER dlibMove,
                                    [in] uint32 dwOrigin,
                                    [out] valuetype PortableDeviceTypesLib._ULARGE_INTEGER& plibNewPosition) runtime managed internalcall
  {
  } // end of method IStream::RemoteSeek

  .method public hidebysig newslot abstract virtual 
          instance void  SetSize([in] valuetype PortableDeviceTypesLib._ULARGE_INTEGER libNewSize) runtime managed internalcall
  {
  } // end of method IStream::SetSize

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteCopyTo([in] class PortableDeviceTypesLib.IStream  marshal( interface ) pstm,
                                      [in] valuetype PortableDeviceTypesLib._ULARGE_INTEGER cb,
                                      [out] valuetype PortableDeviceTypesLib._ULARGE_INTEGER& pcbRead,
                                      [out] valuetype PortableDeviceTypesLib._ULARGE_INTEGER& pcbWritten) runtime managed internalcall
  {
  } // end of method IStream::RemoteCopyTo

  .method public hidebysig newslot abstract virtual 
          instance void  Commit([in] uint32 grfCommitFlags) runtime managed internalcall
  {
  } // end of method IStream::Commit

  .method public hidebysig newslot abstract virtual 
          instance void  Revert() runtime managed internalcall
  {
  } // end of method IStream::Revert

  .method public hidebysig newslot abstract virtual 
          instance void  LockRegion([in] valuetype PortableDeviceTypesLib._ULARGE_INTEGER libOffset,
                                    [in] valuetype PortableDeviceTypesLib._ULARGE_INTEGER cb,
                                    [in] uint32 dwLockType) runtime managed internalcall
  {
  } // end of method IStream::LockRegion

  .method public hidebysig newslot abstract virtual 
          instance void  UnlockRegion([in] valuetype PortableDeviceTypesLib._ULARGE_INTEGER libOffset,
                                      [in] valuetype PortableDeviceTypesLib._ULARGE_INTEGER cb,
                                      [in] uint32 dwLockType) runtime managed internalcall
  {
  } // end of method IStream::UnlockRegion

  .method public hidebysig newslot abstract virtual 
          instance void  Stat([out] valuetype PortableDeviceTypesLib.tagSTATSTG& pstatstg,
                              [in] uint32 grfStatFlag) runtime managed internalcall
  {
  } // end of method IStream::Stat

  .method public hidebysig newslot abstract virtual 
          instance void  Clone([out] class PortableDeviceTypesLib.IStream&  marshal( interface ) ppstm) runtime managed internalcall
  {
  } // end of method IStream::Clone

} // end of class PortableDeviceTypesLib.IStream

.class interface public abstract auto ansi import PortableDeviceTypesLib.ISequentialStream
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 43 37 33 33 41 33 30 2D 32 41 31 43   // ..$0C733A30-2A1C
                                                                                                  2D 31 31 43 45 2D 41 44 45 35 2D 30 30 41 41 30   // -11CE-ADE5-00AA0
                                                                                                  30 34 34 37 37 33 44 00 00 )                      // 044773D..
  .method public hidebysig newslot abstract virtual 
          instance void  RemoteRead([out] uint8& pv,
                                    [in] uint32 cb,
                                    [out] uint32& pcbRead) runtime managed internalcall
  {
  } // end of method ISequentialStream::RemoteRead

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteWrite([in] uint8& pv,
                                     [in] uint32 cb,
                                     [out] uint32& pcbWritten) runtime managed internalcall
  {
  } // end of method ISequentialStream::RemoteWrite

} // end of class PortableDeviceTypesLib.ISequentialStream

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagSTATSTG
       extends [mscorlib]System.ValueType
{
  .pack 8
  .size 0
  .field public  marshal( lpwstr) string pwcsName
  .field public uint32 'type'
  .field public valuetype PortableDeviceTypesLib._ULARGE_INTEGER cbSize
  .field public valuetype PortableDeviceTypesLib._FILETIME mtime
  .field public valuetype PortableDeviceTypesLib._FILETIME ctime
  .field public valuetype PortableDeviceTypesLib._FILETIME atime
  .field public uint32 grfMode
  .field public uint32 grfLocksSupported
  .field public valuetype [mscorlib]System.Guid 'clsid'
  .field public uint32 grfStateBits
  .field public uint32 reserved
} // end of class PortableDeviceTypesLib.tagSTATSTG

.class interface public abstract auto ansi import PortableDeviceTypesLib.IStorage
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 30 30 30 30 30 30 42 2D 30 30 30 30   // ..$0000000B-0000
                                                                                                  2D 30 30 30 30 2D 43 30 30 30 2D 30 30 30 30 30   // -0000-C000-00000
                                                                                                  30 30 30 30 30 34 36 00 00 )                      // 0000046..
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  CreateStream([in] string  marshal( lpwstr) pwcsName,
                                      [in] uint32 grfMode,
                                      [in] uint32 reserved1,
                                      [in] uint32 reserved2,
                                      [out] class PortableDeviceTypesLib.IStream&  marshal( interface ) ppstm) runtime managed internalcall
  {
  } // end of method IStorage::CreateStream

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteOpenStream([in] string  marshal( lpwstr) pwcsName,
                                          [in] uint32 cbReserved1,
                                          [in] uint8& reserved1,
                                          [in] uint32 grfMode,
                                          [in] uint32 reserved2,
                                          [out] class PortableDeviceTypesLib.IStream&  marshal( interface ) ppstm) runtime managed internalcall
  {
  } // end of method IStorage::RemoteOpenStream

  .method public hidebysig newslot abstract virtual 
          instance void  CreateStorage([in] string  marshal( lpwstr) pwcsName,
                                       [in] uint32 grfMode,
                                       [in] uint32 reserved1,
                                       [in] uint32 reserved2,
                                       [out] class PortableDeviceTypesLib.IStorage&  marshal( interface ) ppstg) runtime managed internalcall
  {
  } // end of method IStorage::CreateStorage

  .method public hidebysig newslot abstract virtual 
          instance void  OpenStorage([in] string  marshal( lpwstr) pwcsName,
                                     [in] class PortableDeviceTypesLib.IStorage  marshal( interface ) pstgPriority,
                                     [in] uint32 grfMode,
                                     [in] valuetype PortableDeviceTypesLib.tagRemSNB& snbExclude,
                                     [in] uint32 reserved,
                                     [out] class PortableDeviceTypesLib.IStorage&  marshal( interface ) ppstg) runtime managed internalcall
  {
    .param [4]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 1E 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ...PortableDevic
                                                                                                            65 54 79 70 65 73 4C 69 62 2E 77 69 72 65 53 4E   // eTypesLib.wireSN
                                                                                                            42 00 00 )                                        // B..
  } // end of method IStorage::OpenStorage

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteCopyTo([in] uint32 ciidExclude,
                                      [in] valuetype [mscorlib]System.Guid& rgiidExclude,
                                      [in] valuetype PortableDeviceTypesLib.tagRemSNB& snbExclude,
                                      [in] class PortableDeviceTypesLib.IStorage  marshal( interface ) pstgDest) runtime managed internalcall
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 1E 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ...PortableDevic
                                                                                                            65 54 79 70 65 73 4C 69 62 2E 77 69 72 65 53 4E   // eTypesLib.wireSN
                                                                                                            42 00 00 )                                        // B..
  } // end of method IStorage::RemoteCopyTo

  .method public hidebysig newslot abstract virtual 
          instance void  MoveElementTo([in] string  marshal( lpwstr) pwcsName,
                                       [in] class PortableDeviceTypesLib.IStorage  marshal( interface ) pstgDest,
                                       [in] string  marshal( lpwstr) pwcsNewName,
                                       [in] uint32 grfFlags) runtime managed internalcall
  {
  } // end of method IStorage::MoveElementTo

  .method public hidebysig newslot abstract virtual 
          instance void  Commit([in] uint32 grfCommitFlags) runtime managed internalcall
  {
  } // end of method IStorage::Commit

  .method public hidebysig newslot abstract virtual 
          instance void  Revert() runtime managed internalcall
  {
  } // end of method IStorage::Revert

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteEnumElements([in] uint32 reserved1,
                                            [in] uint32 cbReserved2,
                                            [in] uint8& reserved2,
                                            [in] uint32 reserved3,
                                            [out] class PortableDeviceTypesLib.IEnumSTATSTG&  marshal( interface ) ppenum) runtime managed internalcall
  {
  } // end of method IStorage::RemoteEnumElements

  .method public hidebysig newslot abstract virtual 
          instance void  DestroyElement([in] string  marshal( lpwstr) pwcsName) runtime managed internalcall
  {
  } // end of method IStorage::DestroyElement

  .method public hidebysig newslot abstract virtual 
          instance void  RenameElement([in] string  marshal( lpwstr) pwcsOldName,
                                       [in] string  marshal( lpwstr) pwcsNewName) runtime managed internalcall
  {
  } // end of method IStorage::RenameElement

  .method public hidebysig newslot abstract virtual 
          instance void  SetElementTimes([in] string  marshal( lpwstr) pwcsName,
                                         [in] valuetype PortableDeviceTypesLib._FILETIME& pctime,
                                         [in] valuetype PortableDeviceTypesLib._FILETIME& patime,
                                         [in] valuetype PortableDeviceTypesLib._FILETIME& pmtime) runtime managed internalcall
  {
  } // end of method IStorage::SetElementTimes

  .method public hidebysig newslot abstract virtual 
          instance void  SetClass([in] valuetype [mscorlib]System.Guid& 'clsid') runtime managed internalcall
  {
  } // end of method IStorage::SetClass

  .method public hidebysig newslot abstract virtual 
          instance void  SetStateBits([in] uint32 grfStateBits,
                                      [in] uint32 grfMask) runtime managed internalcall
  {
  } // end of method IStorage::SetStateBits

  .method public hidebysig newslot abstract virtual 
          instance void  Stat([out] valuetype PortableDeviceTypesLib.tagSTATSTG& pstatstg,
                              [in] uint32 grfStatFlag) runtime managed internalcall
  {
  } // end of method IStorage::Stat

} // end of class PortableDeviceTypesLib.IStorage

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagRemSNB
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 ulCntStr
  .field public uint32 ulCntChar
  .field public native int rgString
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagRemSNB

.class interface public abstract auto ansi import PortableDeviceTypesLib.IEnumSTATSTG
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 30 30 30 30 30 30 44 2D 30 30 30 30   // ..$0000000D-0000
                                                                                                  2D 30 30 30 30 2D 43 30 30 30 2D 30 30 30 30 30   // -0000-C000-00000
                                                                                                  30 30 30 30 30 34 36 00 00 )                      // 0000046..
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  RemoteNext([in] uint32 celt,
                                    [out] valuetype PortableDeviceTypesLib.tagSTATSTG& rgelt,
                                    [out] uint32& pceltFetched) runtime managed internalcall
  {
  } // end of method IEnumSTATSTG::RemoteNext

  .method public hidebysig newslot abstract virtual 
          instance void  Skip([in] uint32 celt) runtime managed internalcall
  {
  } // end of method IEnumSTATSTG::Skip

  .method public hidebysig newslot abstract virtual 
          instance void  Reset() runtime managed internalcall
  {
  } // end of method IEnumSTATSTG::Reset

  .method public hidebysig newslot abstract virtual 
          instance void  Clone([out] class PortableDeviceTypesLib.IEnumSTATSTG&  marshal( interface ) ppenum) runtime managed internalcall
  {
  } // end of method IEnumSTATSTG::Clone

} // end of class PortableDeviceTypesLib.IEnumSTATSTG

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagVersionedStream
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public valuetype [mscorlib]System.Guid guidVersion
  .field public  marshal( interface ) class PortableDeviceTypesLib.IStream pStream
} // end of class PortableDeviceTypesLib.tagVersionedStream

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireSAFEARRAY
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint16 cDims
  .field public uint16 fFeatures
  .field public uint32 cbElements
  .field public uint32 cLocks
  .field public valuetype PortableDeviceTypesLib._wireSAFEARRAY_UNION uArrayStructs
  .field public native int rgsabound
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._wireSAFEARRAY

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireSAFEARRAY_UNION
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public uint32 sfType
  .field public valuetype PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0001 u
} // end of class PortableDeviceTypesLib._wireSAFEARRAY_UNION

.class public explicit ansi sealed PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0001
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 24
} // end of class PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0001

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireSAFEARR_BSTR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 Size
  .field public native int aBstr
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._wireSAFEARR_BSTR

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._FLAGGED_WORD_BLOB
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 fFlags
  .field public uint32 clSize
  .field public native int asData
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._FLAGGED_WORD_BLOB

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireSAFEARR_UNKNOWN
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 Size
  .field public native int apUnknown
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._wireSAFEARR_UNKNOWN

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireSAFEARR_DISPATCH
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 Size
  .field public native int apDispatch
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._wireSAFEARR_DISPATCH

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireSAFEARR_VARIANT
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 Size
  .field public native int aVariant
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._wireSAFEARR_VARIANT

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireVARIANT
       extends [mscorlib]System.ValueType
{
  .pack 8
  .size 0
  .field public uint32 clSize
  .field public uint32 rpcReserved
  .field public uint16 vt
  .field public uint16 wReserved1
  .field public uint16 wReserved2
  .field public uint16 wReserved3
  .field public valuetype PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0004 DUMMYUNIONNAME
} // end of class PortableDeviceTypesLib._wireVARIANT

.class public explicit ansi sealed PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0004
       extends [mscorlib]System.ValueType
{
  .pack 8
  .size 16
} // end of class PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0004

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireBRECORD
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 fFlags
  .field public uint32 clSize
  .field public  marshal( interface ) class PortableDeviceTypesLib.IRecordInfo pRecInfo
  .field public native int pRecord
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._wireBRECORD

.class interface public abstract auto ansi import PortableDeviceTypesLib.IRecordInfo
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 30 30 30 30 30 32 46 2D 30 30 30 30   // ..$0000002F-0000
                                                                                                  2D 30 30 30 30 2D 43 30 30 30 2D 30 30 30 30 30   // -0000-C000-00000
                                                                                                  30 30 30 30 30 34 36 00 00 )                      // 0000046..
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  RecordInit([out] native int pvNew) runtime managed internalcall
  {
  } // end of method IRecordInfo::RecordInit

  .method public hidebysig newslot abstract virtual 
          instance void  RecordClear([in] native int pvExisting) runtime managed internalcall
  {
  } // end of method IRecordInfo::RecordClear

  .method public hidebysig newslot abstract virtual 
          instance void  RecordCopy([in] native int pvExisting,
                                    [out] native int pvNew) runtime managed internalcall
  {
  } // end of method IRecordInfo::RecordCopy

  .method public hidebysig newslot abstract virtual 
          instance void  GetGuid([out] valuetype [mscorlib]System.Guid& pguid) runtime managed internalcall
  {
  } // end of method IRecordInfo::GetGuid

  .method public hidebysig newslot abstract virtual 
          instance void  GetName([out] string&  marshal( bstr) pbstrName) runtime managed internalcall
  {
  } // end of method IRecordInfo::GetName

  .method public hidebysig newslot abstract virtual 
          instance void  GetSize([out] uint32& pcbSize) runtime managed internalcall
  {
  } // end of method IRecordInfo::GetSize

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeInfo([out] class [mscorlib]System.Type&  marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                     "")) ppTypeInfo) runtime managed internalcall
  {
  } // end of method IRecordInfo::GetTypeInfo

  .method public hidebysig newslot abstract virtual 
          instance void  GetField([in] native int pvData,
                                  [in] string  marshal( lpwstr) szFieldName,
                                  [out] object&  marshal( struct) pvarField) runtime managed internalcall
  {
  } // end of method IRecordInfo::GetField

  .method public hidebysig newslot abstract virtual 
          instance void  GetFieldNoCopy([in] native int pvData,
                                        [in] string  marshal( lpwstr) szFieldName,
                                        [out] object&  marshal( struct) pvarField,
                                        [out] native int& ppvDataCArray) runtime managed internalcall
  {
  } // end of method IRecordInfo::GetFieldNoCopy

  .method public hidebysig newslot abstract virtual 
          instance void  PutField([in] uint32 wFlags,
                                  [in][out] native int pvData,
                                  [in] string  marshal( lpwstr) szFieldName,
                                  [in] object&  marshal( struct) pvarField) runtime managed internalcall
  {
  } // end of method IRecordInfo::PutField

  .method public hidebysig newslot abstract virtual 
          instance void  PutFieldNoCopy([in] uint32 wFlags,
                                        [in][out] native int pvData,
                                        [in] string  marshal( lpwstr) szFieldName,
                                        [in] object&  marshal( struct) pvarField) runtime managed internalcall
  {
  } // end of method IRecordInfo::PutFieldNoCopy

  .method public hidebysig newslot abstract virtual 
          instance void  GetFieldNames([in][out] uint32& pcNames,
                                       [out] string&  marshal( bstr) rgBstrNames) runtime managed internalcall
  {
  } // end of method IRecordInfo::GetFieldNames

  .method public hidebysig newslot abstract virtual 
          instance int32  IsMatchingType([in] class PortableDeviceTypesLib.IRecordInfo  marshal( interface ) pRecordInfo) runtime managed preservesig internalcall
  {
  } // end of method IRecordInfo::IsMatchingType

  .method public hidebysig newslot abstract virtual 
          instance native int  RecordCreate() runtime managed preservesig internalcall
  {
  } // end of method IRecordInfo::RecordCreate

  .method public hidebysig newslot abstract virtual 
          instance void  RecordCreateCopy([in] native int pvSource,
                                          [out] native int& ppvDest) runtime managed internalcall
  {
  } // end of method IRecordInfo::RecordCreateCopy

  .method public hidebysig newslot abstract virtual 
          instance void  RecordDestroy([in] native int pvRecord) runtime managed internalcall
  {
  } // end of method IRecordInfo::RecordDestroy

} // end of class PortableDeviceTypesLib.IRecordInfo

.class interface public abstract auto ansi import PortableDeviceTypesLib.ITypeInfo
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 30 30 32 30 34 30 31 2D 30 30 30 30   // ..$00020401-0000
                                                                                                  2D 30 30 30 30 2D 43 30 30 30 2D 30 30 30 30 30   // -0000-C000-00000
                                                                                                  30 30 30 30 30 34 36 00 00 )                      // 0000046..
  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetTypeAttr([out] native int ppTypeAttr,
                                           [out] uint32& pDummy) runtime managed internalcall
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 1C 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ...PortableDevic
                                                                                                            65 54 79 70 65 73 4C 69 62 2E 44 57 4F 52 44 00   // eTypesLib.DWORD.
                                                                                                            00 ) 
  } // end of method ITypeInfo::RemoteGetTypeAttr

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeComp([out] class PortableDeviceTypesLib.ITypeComp&  marshal( interface ) ppTComp) runtime managed internalcall
  {
  } // end of method ITypeInfo::GetTypeComp

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetFuncDesc([in] uint32 index,
                                           [out] native int ppFuncDesc,
                                           [out] uint32& pDummy) runtime managed internalcall
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 1C 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ...PortableDevic
                                                                                                            65 54 79 70 65 73 4C 69 62 2E 44 57 4F 52 44 00   // eTypesLib.DWORD.
                                                                                                            00 ) 
  } // end of method ITypeInfo::RemoteGetFuncDesc

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetVarDesc([in] uint32 index,
                                          [out] native int ppVarDesc,
                                          [out] uint32& pDummy) runtime managed internalcall
  {
    .param [3]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 1C 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ...PortableDevic
                                                                                                            65 54 79 70 65 73 4C 69 62 2E 44 57 4F 52 44 00   // eTypesLib.DWORD.
                                                                                                            00 ) 
  } // end of method ITypeInfo::RemoteGetVarDesc

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetNames([in] int32 memid,
                                        [out] string&  marshal( bstr) rgBstrNames,
                                        [in] uint32 cMaxNames,
                                        [out] uint32& pcNames) runtime managed internalcall
  {
  } // end of method ITypeInfo::RemoteGetNames

  .method public hidebysig newslot abstract virtual 
          instance void  GetRefTypeOfImplType([in] uint32 index,
                                              [out] uint32& pRefType) runtime managed internalcall
  {
  } // end of method ITypeInfo::GetRefTypeOfImplType

  .method public hidebysig newslot abstract virtual 
          instance void  GetImplTypeFlags([in] uint32 index,
                                          [out] int32& pImplTypeFlags) runtime managed internalcall
  {
  } // end of method ITypeInfo::GetImplTypeFlags

  .method public hidebysig newslot abstract virtual 
          instance void  LocalGetIDsOfNames() runtime managed internalcall
  {
  } // end of method ITypeInfo::LocalGetIDsOfNames

  .method public hidebysig newslot abstract virtual 
          instance void  LocalInvoke() runtime managed internalcall
  {
  } // end of method ITypeInfo::LocalInvoke

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetDocumentation([in] int32 memid,
                                                [in] uint32 refPtrFlags,
                                                [out] string&  marshal( bstr) pbstrName,
                                                [out] string&  marshal( bstr) pBstrDocString,
                                                [out] uint32& pdwHelpContext,
                                                [out] string&  marshal( bstr) pBstrHelpFile) runtime managed internalcall
  {
  } // end of method ITypeInfo::RemoteGetDocumentation

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetDllEntry([in] int32 memid,
                                           [in] valuetype PortableDeviceTypesLib.tagINVOKEKIND invkind,
                                           [in] uint32 refPtrFlags,
                                           [out] string&  marshal( bstr) pBstrDllName,
                                           [out] string&  marshal( bstr) pbstrName,
                                           [out] uint16& pwOrdinal) runtime managed internalcall
  {
  } // end of method ITypeInfo::RemoteGetDllEntry

  .method public hidebysig newslot abstract virtual 
          instance void  GetRefTypeInfo([in] uint32 hreftype,
                                        [out] class [mscorlib]System.Type&  marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "")) ppTInfo) runtime managed internalcall
  {
  } // end of method ITypeInfo::GetRefTypeInfo

  .method public hidebysig newslot abstract virtual 
          instance void  LocalAddressOfMember() runtime managed internalcall
  {
  } // end of method ITypeInfo::LocalAddressOfMember

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteCreateInstance([in] valuetype [mscorlib]System.Guid& riid,
                                              [out] object&  marshal( iunknown ) ppvObj) runtime managed internalcall
  {
  } // end of method ITypeInfo::RemoteCreateInstance

  .method public hidebysig newslot abstract virtual 
          instance void  GetMops([in] int32 memid,
                                 [out] string&  marshal( bstr) pBstrMops) runtime managed internalcall
  {
  } // end of method ITypeInfo::GetMops

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetContainingTypeLib([out] class PortableDeviceTypesLib.ITypeLib&  marshal( interface ) ppTLib,
                                                    [out] uint32& pIndex) runtime managed internalcall
  {
  } // end of method ITypeInfo::RemoteGetContainingTypeLib

  .method public hidebysig newslot abstract virtual 
          instance void  LocalReleaseTypeAttr() runtime managed internalcall
  {
  } // end of method ITypeInfo::LocalReleaseTypeAttr

  .method public hidebysig newslot abstract virtual 
          instance void  LocalReleaseFuncDesc() runtime managed internalcall
  {
  } // end of method ITypeInfo::LocalReleaseFuncDesc

  .method public hidebysig newslot abstract virtual 
          instance void  LocalReleaseVarDesc() runtime managed internalcall
  {
  } // end of method ITypeInfo::LocalReleaseVarDesc

} // end of class PortableDeviceTypesLib.ITypeInfo

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagTYPEATTR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public valuetype [mscorlib]System.Guid guid
  .field public uint32 lcid
  .field public uint32 dwReserved
  .field public int32 memidConstructor
  .field public int32 memidDestructor
  .field public  marshal( lpwstr) string lpstrSchema
  .field public uint32 cbSizeInstance
  .field public valuetype PortableDeviceTypesLib.tagTYPEKIND typekind
  .field public uint16 cFuncs
  .field public uint16 cVars
  .field public uint16 cImplTypes
  .field public uint16 cbSizeVft
  .field public uint16 cbAlignment
  .field public uint16 wTypeFlags
  .field public uint16 wMajorVerNum
  .field public uint16 wMinorVerNum
  .field public valuetype PortableDeviceTypesLib.tagTYPEDESC tdescAlias
  .field public valuetype PortableDeviceTypesLib.tagIDLDESC idldescType
} // end of class PortableDeviceTypesLib.tagTYPEATTR

.class public auto ansi sealed PortableDeviceTypesLib.tagTYPEKIND
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_ENUM = int32(0x00000000)
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_RECORD = int32(0x00000001)
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_MODULE = int32(0x00000002)
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_INTERFACE = int32(0x00000003)
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_DISPATCH = int32(0x00000004)
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_COCLASS = int32(0x00000005)
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_ALIAS = int32(0x00000006)
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_UNION = int32(0x00000007)
  .field public static literal valuetype PortableDeviceTypesLib.tagTYPEKIND TKIND_MAX = int32(0x00000008)
} // end of class PortableDeviceTypesLib.tagTYPEKIND

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagTYPEDESC
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public valuetype PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0005 DUMMYUNIONNAME
  .field public uint16 vt
} // end of class PortableDeviceTypesLib.tagTYPEDESC

.class public explicit ansi sealed PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0005
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 4
} // end of class PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0005

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagARRAYDESC
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public valuetype PortableDeviceTypesLib.tagTYPEDESC tdescElem
  .field public uint16 cDims
  .field public native int rgbounds
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagARRAYDESC

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagSAFEARRAYBOUND
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public uint32 cElements
  .field public int32 lLbound
} // end of class PortableDeviceTypesLib.tagSAFEARRAYBOUND

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagIDLDESC
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public uint32 dwReserved
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 20 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // .. PortableDevic
                                                                                                          65 54 79 70 65 73 4C 69 62 2E 55 4C 4F 4E 47 5F   // eTypesLib.ULONG_
                                                                                                          50 54 52 00 00 )                                  // PTR..
  .field public uint16 wIDLFlags
} // end of class PortableDeviceTypesLib.tagIDLDESC

.class interface public abstract auto ansi import PortableDeviceTypesLib.ITypeComp
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 30 30 32 30 34 30 33 2D 30 30 30 30   // ..$00020403-0000
                                                                                                  2D 30 30 30 30 2D 43 30 30 30 2D 30 30 30 30 30   // -0000-C000-00000
                                                                                                  30 30 30 30 30 34 36 00 00 )                      // 0000046..
  .method public hidebysig newslot abstract virtual 
          instance void  RemoteBind([in] string  marshal( lpwstr) szName,
                                    [in] uint32 lHashVal,
                                    [in] uint16 wFlags,
                                    [out] class [mscorlib]System.Type&  marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                    "")) ppTInfo,
                                    [out] valuetype PortableDeviceTypesLib.tagDESCKIND& pDescKind,
                                    [out] native int ppFuncDesc,
                                    [out] native int ppVarDesc,
                                    [out] class PortableDeviceTypesLib.ITypeComp&  marshal( interface ) ppTypeComp,
                                    [out] uint32& pDummy) runtime managed internalcall
  {
    .param [9]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 1C 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ...PortableDevic
                                                                                                            65 54 79 70 65 73 4C 69 62 2E 44 57 4F 52 44 00   // eTypesLib.DWORD.
                                                                                                            00 ) 
  } // end of method ITypeComp::RemoteBind

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteBindType([in] string  marshal( lpwstr) szName,
                                        [in] uint32 lHashVal,
                                        [out] class [mscorlib]System.Type&  marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "")) ppTInfo) runtime managed internalcall
  {
  } // end of method ITypeComp::RemoteBindType

} // end of class PortableDeviceTypesLib.ITypeComp

.class public auto ansi sealed PortableDeviceTypesLib.tagDESCKIND
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype PortableDeviceTypesLib.tagDESCKIND DESCKIND_NONE = int32(0x00000000)
  .field public static literal valuetype PortableDeviceTypesLib.tagDESCKIND DESCKIND_FUNCDESC = int32(0x00000001)
  .field public static literal valuetype PortableDeviceTypesLib.tagDESCKIND DESCKIND_VARDESC = int32(0x00000002)
  .field public static literal valuetype PortableDeviceTypesLib.tagDESCKIND DESCKIND_TYPECOMP = int32(0x00000003)
  .field public static literal valuetype PortableDeviceTypesLib.tagDESCKIND DESCKIND_IMPLICITAPPOBJ = int32(0x00000004)
  .field public static literal valuetype PortableDeviceTypesLib.tagDESCKIND DESCKIND_MAX = int32(0x00000005)
} // end of class PortableDeviceTypesLib.tagDESCKIND

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagFUNCDESC
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public int32 memid
  .field public native int lprgscode
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public native int lprgelemdescParam
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public valuetype PortableDeviceTypesLib.tagFUNCKIND funckind
  .field public valuetype PortableDeviceTypesLib.tagINVOKEKIND invkind
  .field public valuetype PortableDeviceTypesLib.tagCALLCONV 'callconv'
  .field public int16 cParams
  .field public int16 cParamsOpt
  .field public int16 oVft
  .field public int16 cScodes
  .field public valuetype PortableDeviceTypesLib.tagELEMDESC elemdescFunc
  .field public uint16 wFuncFlags
} // end of class PortableDeviceTypesLib.tagFUNCDESC

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagELEMDESC
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public valuetype PortableDeviceTypesLib.tagTYPEDESC tdesc
  .field public valuetype PortableDeviceTypesLib.tagPARAMDESC paramdesc
} // end of class PortableDeviceTypesLib.tagELEMDESC

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagPARAMDESC
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public native int pparamdescex
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint16 wParamFlags
} // end of class PortableDeviceTypesLib.tagPARAMDESC

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagPARAMDESCEX
       extends [mscorlib]System.ValueType
{
  .pack 8
  .size 0
  .field public uint32 cBytes
  .field public  marshal( struct) object varDefaultValue
} // end of class PortableDeviceTypesLib.tagPARAMDESCEX

.class public auto ansi sealed PortableDeviceTypesLib.tagFUNCKIND
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype PortableDeviceTypesLib.tagFUNCKIND FUNC_VIRTUAL = int32(0x00000000)
  .field public static literal valuetype PortableDeviceTypesLib.tagFUNCKIND FUNC_PUREVIRTUAL = int32(0x00000001)
  .field public static literal valuetype PortableDeviceTypesLib.tagFUNCKIND FUNC_NONVIRTUAL = int32(0x00000002)
  .field public static literal valuetype PortableDeviceTypesLib.tagFUNCKIND FUNC_STATIC = int32(0x00000003)
  .field public static literal valuetype PortableDeviceTypesLib.tagFUNCKIND FUNC_DISPATCH = int32(0x00000004)
} // end of class PortableDeviceTypesLib.tagFUNCKIND

.class public auto ansi sealed PortableDeviceTypesLib.tagINVOKEKIND
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype PortableDeviceTypesLib.tagINVOKEKIND INVOKE_FUNC = int32(0x00000001)
  .field public static literal valuetype PortableDeviceTypesLib.tagINVOKEKIND INVOKE_PROPERTYGET = int32(0x00000002)
  .field public static literal valuetype PortableDeviceTypesLib.tagINVOKEKIND INVOKE_PROPERTYPUT = int32(0x00000004)
  .field public static literal valuetype PortableDeviceTypesLib.tagINVOKEKIND INVOKE_PROPERTYPUTREF = int32(0x00000008)
} // end of class PortableDeviceTypesLib.tagINVOKEKIND

.class public auto ansi sealed PortableDeviceTypesLib.tagCALLCONV
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_FASTCALL = int32(0x00000000)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_CDECL = int32(0x00000001)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_MSCPASCAL = int32(0x00000002)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_PASCAL = int32(0x00000002)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_MACPASCAL = int32(0x00000003)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_STDCALL = int32(0x00000004)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_FPFASTCALL = int32(0x00000005)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_SYSCALL = int32(0x00000006)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_MPWCDECL = int32(0x00000007)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_MPWPASCAL = int32(0x00000008)
  .field public static literal valuetype PortableDeviceTypesLib.tagCALLCONV CC_MAX = int32(0x00000009)
} // end of class PortableDeviceTypesLib.tagCALLCONV

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagVARDESC
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public int32 memid
  .field public  marshal( lpwstr) string lpstrSchema
  .field public valuetype PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0006 DUMMYUNIONNAME
  .field public valuetype PortableDeviceTypesLib.tagELEMDESC elemdescVar
  .field public uint16 wVarFlags
  .field public valuetype PortableDeviceTypesLib.tagVARKIND varkind
} // end of class PortableDeviceTypesLib.tagVARDESC

.class public explicit ansi sealed PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0006
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 4
} // end of class PortableDeviceTypesLib.__MIDL_IOleAutomationTypes_0006

.class public auto ansi sealed PortableDeviceTypesLib.tagVARKIND
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype PortableDeviceTypesLib.tagVARKIND VAR_PERINSTANCE = int32(0x00000000)
  .field public static literal valuetype PortableDeviceTypesLib.tagVARKIND VAR_STATIC = int32(0x00000001)
  .field public static literal valuetype PortableDeviceTypesLib.tagVARKIND VAR_CONST = int32(0x00000002)
  .field public static literal valuetype PortableDeviceTypesLib.tagVARKIND VAR_DISPATCH = int32(0x00000003)
} // end of class PortableDeviceTypesLib.tagVARKIND

.class interface public abstract auto ansi import PortableDeviceTypesLib.ITypeLib
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 30 30 32 30 34 30 32 2D 30 30 30 30   // ..$00020402-0000
                                                                                                  2D 30 30 30 30 2D 43 30 30 30 2D 30 30 30 30 30   // -0000-C000-00000
                                                                                                  30 30 30 30 30 34 36 00 00 )                      // 0000046..
  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetTypeInfoCount([out] uint32& pcTInfo) runtime managed internalcall
  {
  } // end of method ITypeLib::RemoteGetTypeInfoCount

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeInfo([in] uint32 index,
                                     [out] class [mscorlib]System.Type&  marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                     "")) ppTInfo) runtime managed internalcall
  {
  } // end of method ITypeLib::GetTypeInfo

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeInfoType([in] uint32 index,
                                         [out] valuetype PortableDeviceTypesLib.tagTYPEKIND& pTKind) runtime managed internalcall
  {
  } // end of method ITypeLib::GetTypeInfoType

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeInfoOfGuid([in] valuetype [mscorlib]System.Guid& guid,
                                           [out] class [mscorlib]System.Type&  marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                           "")) ppTInfo) runtime managed internalcall
  {
  } // end of method ITypeLib::GetTypeInfoOfGuid

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetLibAttr([out] native int ppTLibAttr,
                                          [out] uint32& pDummy) runtime managed internalcall
  {
    .param [2]
    .custom instance void [mscorlib]System.Runtime.InteropServices.ComAliasNameAttribute::.ctor(string) = ( 01 00 1C 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ...PortableDevic
                                                                                                            65 54 79 70 65 73 4C 69 62 2E 44 57 4F 52 44 00   // eTypesLib.DWORD.
                                                                                                            00 ) 
  } // end of method ITypeLib::RemoteGetLibAttr

  .method public hidebysig newslot abstract virtual 
          instance void  GetTypeComp([out] class PortableDeviceTypesLib.ITypeComp&  marshal( interface ) ppTComp) runtime managed internalcall
  {
  } // end of method ITypeLib::GetTypeComp

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteGetDocumentation([in] int32 index,
                                                [in] uint32 refPtrFlags,
                                                [out] string&  marshal( bstr) pbstrName,
                                                [out] string&  marshal( bstr) pBstrDocString,
                                                [out] uint32& pdwHelpContext,
                                                [out] string&  marshal( bstr) pBstrHelpFile) runtime managed internalcall
  {
  } // end of method ITypeLib::RemoteGetDocumentation

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteIsName([in] string  marshal( lpwstr) szNameBuf,
                                      [in] uint32 lHashVal,
                                      [out] int32& pfName,
                                      [out] string&  marshal( bstr) pBstrLibName) runtime managed internalcall
  {
  } // end of method ITypeLib::RemoteIsName

  .method public hidebysig newslot abstract virtual 
          instance void  RemoteFindName([in] string  marshal( lpwstr) szNameBuf,
                                        [in] uint32 lHashVal,
                                        [out] class [mscorlib]System.Type&  marshal( custom ("System.Runtime.InteropServices.CustomMarshalers.TypeToTypeInfoMarshaler, CustomMarshalers, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
                                        "")) ppTInfo,
                                        [out] int32& rgMemId,
                                        [in][out] uint16& pcFound,
                                        [out] string&  marshal( bstr) pBstrLibName) runtime managed internalcall
  {
  } // end of method ITypeLib::RemoteFindName

  .method public hidebysig newslot abstract virtual 
          instance void  LocalReleaseTLibAttr() runtime managed internalcall
  {
  } // end of method ITypeLib::LocalReleaseTLibAttr

} // end of class PortableDeviceTypesLib.ITypeLib

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagTLIBATTR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .field public valuetype [mscorlib]System.Guid guid
  .field public uint32 lcid
  .field public valuetype PortableDeviceTypesLib.tagSYSKIND syskind
  .field public uint16 wMajorVerNum
  .field public uint16 wMinorVerNum
  .field public uint16 wLibFlags
} // end of class PortableDeviceTypesLib.tagTLIBATTR

.class public auto ansi sealed PortableDeviceTypesLib.tagSYSKIND
       extends [mscorlib]System.Enum
{
  .field public specialname rtspecialname int32 value__
  .field public static literal valuetype PortableDeviceTypesLib.tagSYSKIND SYS_WIN16 = int32(0x00000000)
  .field public static literal valuetype PortableDeviceTypesLib.tagSYSKIND SYS_WIN32 = int32(0x00000001)
  .field public static literal valuetype PortableDeviceTypesLib.tagSYSKIND SYS_MAC = int32(0x00000002)
  .field public static literal valuetype PortableDeviceTypesLib.tagSYSKIND SYS_WIN64 = int32(0x00000003)
} // end of class PortableDeviceTypesLib.tagSYSKIND

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireSAFEARR_BRECORD
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 Size
  .field public native int aRecord
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._wireSAFEARR_BRECORD

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._wireSAFEARR_HAVEIID
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 Size
  .field public native int apUnknown
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public valuetype [mscorlib]System.Guid iid
} // end of class PortableDeviceTypesLib._wireSAFEARR_HAVEIID

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._BYTE_SIZEDARR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 clSize
  .field public native int pData
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._BYTE_SIZEDARR

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._SHORT_SIZEDARR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 clSize
  .field public native int pData
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._SHORT_SIZEDARR

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._LONG_SIZEDARR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 clSize
  .field public native int pData
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._LONG_SIZEDARR

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib._HYPER_SIZEDARR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 clSize
  .field public native int pData
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib._HYPER_SIZEDARR

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAC
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAC

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAUB
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAUB

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAI
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAI

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAUI
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAUI

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAL
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAL

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAUL
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAUL

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAH
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAH

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAUH
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAUH

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAFLT
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAFLT

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCADBL
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCADBL

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCABOOL
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCABOOL

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCASCODE
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCASCODE

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCACY
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCACY

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCADATE
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCADATE

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAFILETIME
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAFILETIME

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCACLSID
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCACLSID

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCACLIPDATA
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCACLIPDATA

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCABSTR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCABSTR

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCABSTRBLOB
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCABSTRBLOB

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCALPSTR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCALPSTR

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCALPWSTR
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCALPWSTR

.class public sequential ansi sealed beforefieldinit PortableDeviceTypesLib.tagCAPROPVARIANT
       extends [mscorlib]System.ValueType
{
  .pack 4
  .size 0
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .field public uint32 cElems
  .field public native int pElems
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
} // end of class PortableDeviceTypesLib.tagCAPROPVARIANT

.class interface public abstract auto ansi import PortableDeviceTypesLib.IPortableDevicePropVariantCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 38 39 42 32 45 34 32 32 2D 34 46 31 42   // ..$89B2E422-4F1B
                                                                                                  2D 34 33 31 36 2D 42 43 45 46 2D 41 34 34 41 46   // -4316-BCEF-A44AF
                                                                                                  45 41 38 33 45 42 33 00 00 )                      // EA83EB3..
  .method public hidebysig newslot abstract virtual 
          instance void  GetCount([in] uint32& pcElems) runtime managed internalcall
  {
  } // end of method IPortableDevicePropVariantCollection::GetCount

  .method public hidebysig newslot abstract virtual 
          instance void  GetAt([in] uint32 dwIndex,
                               [in] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
  } // end of method IPortableDevicePropVariantCollection::GetAt

  .method public hidebysig newslot abstract virtual 
          instance void  Add([in] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
  } // end of method IPortableDevicePropVariantCollection::Add

  .method public hidebysig newslot abstract virtual 
          instance void  GetType([out] uint16& pvt) runtime managed internalcall
  {
  } // end of method IPortableDevicePropVariantCollection::GetType

  .method public hidebysig newslot abstract virtual 
          instance void  ChangeType([in] uint16 vt) runtime managed internalcall
  {
  } // end of method IPortableDevicePropVariantCollection::ChangeType

  .method public hidebysig newslot abstract virtual 
          instance void  Clear() runtime managed internalcall
  {
  } // end of method IPortableDevicePropVariantCollection::Clear

  .method public hidebysig newslot abstract virtual 
          instance void  RemoveAt([in] uint32 dwIndex) runtime managed internalcall
  {
  } // end of method IPortableDevicePropVariantCollection::RemoveAt

} // end of class PortableDeviceTypesLib.IPortableDevicePropVariantCollection

.class interface public abstract auto ansi import PortableDeviceTypesLib.IPortableDeviceKeyCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 41 44 41 32 33 35 37 2D 45 30 41 44   // ..$DADA2357-E0AD
                                                                                                  2D 34 39 32 45 2D 39 38 44 42 2D 44 44 36 31 43   // -492E-98DB-DD61C
                                                                                                  35 33 42 41 33 35 33 00 00 )                      // 53BA353..
  .method public hidebysig newslot abstract virtual 
          instance void  GetCount([in] uint32& pcElems) runtime managed internalcall
  {
  } // end of method IPortableDeviceKeyCollection::GetCount

  .method public hidebysig newslot abstract virtual 
          instance void  GetAt([in] uint32 dwIndex,
                               [in] valuetype PortableDeviceTypesLib._tagpropertykey& pKey) runtime managed internalcall
  {
  } // end of method IPortableDeviceKeyCollection::GetAt

  .method public hidebysig newslot abstract virtual 
          instance void  Add([in] valuetype PortableDeviceTypesLib._tagpropertykey& key) runtime managed internalcall
  {
  } // end of method IPortableDeviceKeyCollection::Add

  .method public hidebysig newslot abstract virtual 
          instance void  Clear() runtime managed internalcall
  {
  } // end of method IPortableDeviceKeyCollection::Clear

  .method public hidebysig newslot abstract virtual 
          instance void  RemoveAt([in] uint32 dwIndex) runtime managed internalcall
  {
  } // end of method IPortableDeviceKeyCollection::RemoveAt

} // end of class PortableDeviceTypesLib.IPortableDeviceKeyCollection

.class interface public abstract auto ansi import PortableDeviceTypesLib.IPortableDeviceValuesCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 36 45 33 46 32 44 37 39 2D 34 45 30 37   // ..$6E3F2D79-4E07
                                                                                                  2D 34 38 43 34 2D 38 32 30 38 2D 44 38 43 32 45   // -48C4-8208-D8C2E
                                                                                                  35 41 46 34 41 39 39 00 00 )                      // 5AF4A99..
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  GetCount([in] uint32& pcElems) runtime managed internalcall
  {
  } // end of method IPortableDeviceValuesCollection::GetCount

  .method public hidebysig newslot abstract virtual 
          instance void  GetAt([in] uint32 dwIndex,
                               [out] class PortableDeviceTypesLib.PortableDeviceValues&  marshal( interface ) ppValues) runtime managed internalcall
  {
  } // end of method IPortableDeviceValuesCollection::GetAt

  .method public hidebysig newslot abstract virtual 
          instance void  Add([in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pValues) runtime managed internalcall
  {
  } // end of method IPortableDeviceValuesCollection::Add

  .method public hidebysig newslot abstract virtual 
          instance void  Clear() runtime managed internalcall
  {
  } // end of method IPortableDeviceValuesCollection::Clear

  .method public hidebysig newslot abstract virtual 
          instance void  RemoveAt([in] uint32 dwIndex) runtime managed internalcall
  {
  } // end of method IPortableDeviceValuesCollection::RemoveAt

} // end of class PortableDeviceTypesLib.IPortableDeviceValuesCollection

.class interface public abstract auto ansi import PortableDeviceTypesLib.IPropertyStore
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 38 38 36 44 38 45 45 42 2D 38 43 46 32   // ..$886D8EEB-8CF2
                                                                                                  2D 34 34 34 36 2D 38 44 30 32 2D 43 44 42 41 31   // -4446-8D02-CDBA1
                                                                                                  44 42 44 43 46 39 39 00 00 )                      // DBDCF99..
  .custom instance void [mscorlib]System.Runtime.InteropServices.InterfaceTypeAttribute::.ctor(int16) = ( 01 00 01 00 00 00 ) 
  .method public hidebysig newslot abstract virtual 
          instance void  GetCount([out] uint32& cProps) runtime managed internalcall
  {
  } // end of method IPropertyStore::GetCount

  .method public hidebysig newslot abstract virtual 
          instance void  GetAt([in] uint32 iProp,
                               [out] valuetype PortableDeviceTypesLib._tagpropertykey& pKey) runtime managed internalcall
  {
  } // end of method IPropertyStore::GetAt

  .method public hidebysig newslot abstract virtual 
          instance void  GetValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                  [out] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pv) runtime managed internalcall
  {
  } // end of method IPropertyStore::GetValue

  .method public hidebysig newslot abstract virtual 
          instance void  SetValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                  [in] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& propvar) runtime managed internalcall
  {
  } // end of method IPropertyStore::SetValue

  .method public hidebysig newslot abstract virtual 
          instance void  Commit() runtime managed internalcall
  {
  } // end of method IPropertyStore::Commit

} // end of class PortableDeviceTypesLib.IPropertyStore

.class public auto ansi import PortableDeviceTypesLib.PortableDeviceValuesClass
       extends [mscorlib]System.Object
       implements PortableDeviceTypesLib.IPortableDeviceValues,
                  PortableDeviceTypesLib.PortableDeviceValues
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComConversionLossAttribute::.ctor() = ( 01 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 43 31 35 44 35 30 33 2D 44 30 31 37   // ..$0C15D503-D017
                                                                                                  2D 34 37 43 45 2D 39 30 31 36 2D 37 42 33 46 39   // -47CE-9016-7B3F9
                                                                                                  37 38 37 32 31 43 43 00 00 )                      // 78721CC..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 02 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(int16) = ( 01 00 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor() runtime managed internalcall
  {
  } // end of method PortableDeviceValuesClass::.ctor

  .method public hidebysig newslot virtual 
          instance void  GetCount([in] uint32& pcelt) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetCount
  } // end of method PortableDeviceValuesClass::GetCount

  .method public hidebysig newslot virtual 
          instance void  GetAt([in] uint32 index,
                               [in][out] valuetype PortableDeviceTypesLib._tagpropertykey& pKey,
                               [in][out] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetAt
  } // end of method PortableDeviceValuesClass::GetAt

  .method public hidebysig newslot virtual 
          instance void  SetValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                  [in] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetValue
  } // end of method PortableDeviceValuesClass::SetValue

  .method public hidebysig newslot virtual 
          instance void  GetValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                  [out] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetValue
  } // end of method PortableDeviceValuesClass::GetValue

  .method public hidebysig newslot virtual 
          instance void  SetStringValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                        [in] string  marshal( lpwstr) Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetStringValue
  } // end of method PortableDeviceValuesClass::SetStringValue

  .method public hidebysig newslot virtual 
          instance void  GetStringValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                        [out] string&  marshal( lpwstr) pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetStringValue
  } // end of method PortableDeviceValuesClass::GetStringValue

  .method public hidebysig newslot virtual 
          instance void  SetUnsignedIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                 [in] uint32 Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetUnsignedIntegerValue
  } // end of method PortableDeviceValuesClass::SetUnsignedIntegerValue

  .method public hidebysig newslot virtual 
          instance void  GetUnsignedIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                 [out] uint32& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetUnsignedIntegerValue
  } // end of method PortableDeviceValuesClass::GetUnsignedIntegerValue

  .method public hidebysig newslot virtual 
          instance void  SetSignedIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                               [in] int32 Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetSignedIntegerValue
  } // end of method PortableDeviceValuesClass::SetSignedIntegerValue

  .method public hidebysig newslot virtual 
          instance void  GetSignedIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                               [out] int32& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetSignedIntegerValue
  } // end of method PortableDeviceValuesClass::GetSignedIntegerValue

  .method public hidebysig newslot virtual 
          instance void  SetUnsignedLargeIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                      [in] uint64 Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetUnsignedLargeIntegerValue
  } // end of method PortableDeviceValuesClass::SetUnsignedLargeIntegerValue

  .method public hidebysig newslot virtual 
          instance void  GetUnsignedLargeIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                      [out] uint64& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetUnsignedLargeIntegerValue
  } // end of method PortableDeviceValuesClass::GetUnsignedLargeIntegerValue

  .method public hidebysig newslot virtual 
          instance void  SetSignedLargeIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                    [in] int64 Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetSignedLargeIntegerValue
  } // end of method PortableDeviceValuesClass::SetSignedLargeIntegerValue

  .method public hidebysig newslot virtual 
          instance void  GetSignedLargeIntegerValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                    [out] int64& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetSignedLargeIntegerValue
  } // end of method PortableDeviceValuesClass::GetSignedLargeIntegerValue

  .method public hidebysig newslot virtual 
          instance void  SetFloatValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                       [in] float32 Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetFloatValue
  } // end of method PortableDeviceValuesClass::SetFloatValue

  .method public hidebysig newslot virtual 
          instance void  GetFloatValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                       [out] float32& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetFloatValue
  } // end of method PortableDeviceValuesClass::GetFloatValue

  .method public hidebysig newslot virtual 
          instance void  SetErrorValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                       [in] int32  marshal( error) Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetErrorValue
  } // end of method PortableDeviceValuesClass::SetErrorValue

  .method public hidebysig newslot virtual 
          instance void  GetErrorValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                       [out] int32&  marshal( error) pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetErrorValue
  } // end of method PortableDeviceValuesClass::GetErrorValue

  .method public hidebysig newslot virtual 
          instance void  SetKeyValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                     [in] valuetype PortableDeviceTypesLib._tagpropertykey& Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetKeyValue
  } // end of method PortableDeviceValuesClass::SetKeyValue

  .method public hidebysig newslot virtual 
          instance void  GetKeyValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                     [out] valuetype PortableDeviceTypesLib._tagpropertykey& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetKeyValue
  } // end of method PortableDeviceValuesClass::GetKeyValue

  .method public hidebysig newslot virtual 
          instance void  SetBoolValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                      [in] int32 Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetBoolValue
  } // end of method PortableDeviceValuesClass::SetBoolValue

  .method public hidebysig newslot virtual 
          instance void  GetBoolValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                      [out] int32& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetBoolValue
  } // end of method PortableDeviceValuesClass::GetBoolValue

  .method public hidebysig newslot virtual 
          instance void  SetIUnknownValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                          [in] object  marshal( iunknown ) pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetIUnknownValue
  } // end of method PortableDeviceValuesClass::SetIUnknownValue

  .method public hidebysig newslot virtual 
          instance void  GetIUnknownValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                          [out] object&  marshal( iunknown ) ppValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetIUnknownValue
  } // end of method PortableDeviceValuesClass::GetIUnknownValue

  .method public hidebysig newslot virtual 
          instance void  SetGuidValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                      [in] valuetype [mscorlib]System.Guid& Value) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetGuidValue
  } // end of method PortableDeviceValuesClass::SetGuidValue

  .method public hidebysig newslot virtual 
          instance void  GetGuidValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                      [out] valuetype [mscorlib]System.Guid& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetGuidValue
  } // end of method PortableDeviceValuesClass::GetGuidValue

  .method public hidebysig newslot virtual 
          instance void  SetBufferValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                        [in] uint8& pValue,
                                        [in] uint32 cbValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetBufferValue
  } // end of method PortableDeviceValuesClass::SetBufferValue

  .method public hidebysig newslot virtual 
          instance void  GetBufferValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                        [out] native int ppValue,
                                        [out] uint32& pcbValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetBufferValue
  } // end of method PortableDeviceValuesClass::GetBufferValue

  .method public hidebysig newslot virtual 
          instance void  SetIPortableDeviceValuesValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                       [in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetIPortableDeviceValuesValue
  } // end of method PortableDeviceValuesClass::SetIPortableDeviceValuesValue

  .method public hidebysig newslot virtual 
          instance void  GetIPortableDeviceValuesValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                       [out] class PortableDeviceTypesLib.PortableDeviceValues&  marshal( interface ) ppValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetIPortableDeviceValuesValue
  } // end of method PortableDeviceValuesClass::GetIPortableDeviceValuesValue

  .method public hidebysig newslot virtual 
          instance void  SetIPortableDevicePropVariantCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                                      [in] class PortableDeviceTypesLib.PortableDevicePropVariantCollection  marshal( interface ) pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetIPortableDevicePropVariantCollectionValue
  } // end of method PortableDeviceValuesClass::SetIPortableDevicePropVariantCollectionValue

  .method public hidebysig newslot virtual 
          instance void  GetIPortableDevicePropVariantCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                                      [out] class PortableDeviceTypesLib.PortableDevicePropVariantCollection&  marshal( interface ) ppValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetIPortableDevicePropVariantCollectionValue
  } // end of method PortableDeviceValuesClass::GetIPortableDevicePropVariantCollectionValue

  .method public hidebysig newslot virtual 
          instance void  SetIPortableDeviceKeyCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                              [in] class PortableDeviceTypesLib.PortableDeviceKeyCollection  marshal( interface ) pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetIPortableDeviceKeyCollectionValue
  } // end of method PortableDeviceValuesClass::SetIPortableDeviceKeyCollectionValue

  .method public hidebysig newslot virtual 
          instance void  GetIPortableDeviceKeyCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                              [out] class PortableDeviceTypesLib.PortableDeviceKeyCollection&  marshal( interface ) ppValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetIPortableDeviceKeyCollectionValue
  } // end of method PortableDeviceValuesClass::GetIPortableDeviceKeyCollectionValue

  .method public hidebysig newslot virtual 
          instance void  SetIPortableDeviceValuesCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                                 [in] class PortableDeviceTypesLib.PortableDeviceValuesCollection  marshal( interface ) pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::SetIPortableDeviceValuesCollectionValue
  } // end of method PortableDeviceValuesClass::SetIPortableDeviceValuesCollectionValue

  .method public hidebysig newslot virtual 
          instance void  GetIPortableDeviceValuesCollectionValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key,
                                                                 [out] class PortableDeviceTypesLib.PortableDeviceValuesCollection&  marshal( interface ) ppValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::GetIPortableDeviceValuesCollectionValue
  } // end of method PortableDeviceValuesClass::GetIPortableDeviceValuesCollectionValue

  .method public hidebysig newslot virtual 
          instance void  RemoveValue([in] valuetype PortableDeviceTypesLib._tagpropertykey& key) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::RemoveValue
  } // end of method PortableDeviceValuesClass::RemoveValue

  .method public hidebysig newslot virtual 
          instance void  CopyValuesFromPropertyStore([in] class PortableDeviceTypesLib.IPropertyStore  marshal( interface ) pStore) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::CopyValuesFromPropertyStore
  } // end of method PortableDeviceValuesClass::CopyValuesFromPropertyStore

  .method public hidebysig newslot virtual 
          instance void  CopyValuesToPropertyStore([in] class PortableDeviceTypesLib.IPropertyStore  marshal( interface ) pStore) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::CopyValuesToPropertyStore
  } // end of method PortableDeviceValuesClass::CopyValuesToPropertyStore

  .method public hidebysig newslot virtual 
          instance void  Clear() runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValues::Clear
  } // end of method PortableDeviceValuesClass::Clear

} // end of class PortableDeviceTypesLib.PortableDeviceValuesClass

.class interface public abstract auto ansi import PortableDeviceTypesLib.PortableDeviceValues
       implements PortableDeviceTypesLib.IPortableDeviceValues
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 36 38 34 38 46 36 46 32 2D 33 31 35 35   // ..$6848F6F2-3155
                                                                                                  2D 34 46 38 36 2D 42 36 46 35 2D 32 36 33 45 45   // -4F86-B6F5-263EE
                                                                                                  45 41 42 33 31 34 33 00 00 )                      // EAB3143..
  .custom instance void [mscorlib]System.Runtime.InteropServices.CoClassAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 30 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ..0PortableDevic
                                                                                                                          65 54 79 70 65 73 4C 69 62 2E 50 6F 72 74 61 62   // eTypesLib.Portab
                                                                                                                          6C 65 44 65 76 69 63 65 56 61 6C 75 65 73 43 6C   // leDeviceValuesCl
                                                                                                                          61 73 73 00 00 )                                  // ass..
} // end of class PortableDeviceTypesLib.PortableDeviceValues

.class public auto ansi import PortableDeviceTypesLib.PortableDeviceKeyCollectionClass
       extends [mscorlib]System.Object
       implements PortableDeviceTypesLib.IPortableDeviceKeyCollection,
                  PortableDeviceTypesLib.PortableDeviceKeyCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(int16) = ( 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 45 32 44 30 32 32 44 2D 32 34 38 30   // ..$DE2D022D-2480
                                                                                                  2D 34 33 42 45 2D 39 37 46 30 2D 44 31 46 41 32   // -43BE-97F0-D1FA2
                                                                                                  43 46 39 38 46 34 46 00 00 )                      // CF98F4F..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 02 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor() runtime managed internalcall
  {
  } // end of method PortableDeviceKeyCollectionClass::.ctor

  .method public hidebysig newslot virtual 
          instance void  GetCount([in] uint32& pcElems) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceKeyCollection::GetCount
  } // end of method PortableDeviceKeyCollectionClass::GetCount

  .method public hidebysig newslot virtual 
          instance void  GetAt([in] uint32 dwIndex,
                               [in] valuetype PortableDeviceTypesLib._tagpropertykey& pKey) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceKeyCollection::GetAt
  } // end of method PortableDeviceKeyCollectionClass::GetAt

  .method public hidebysig newslot virtual 
          instance void  Add([in] valuetype PortableDeviceTypesLib._tagpropertykey& key) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceKeyCollection::Add
  } // end of method PortableDeviceKeyCollectionClass::Add

  .method public hidebysig newslot virtual 
          instance void  Clear() runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceKeyCollection::Clear
  } // end of method PortableDeviceKeyCollectionClass::Clear

  .method public hidebysig newslot virtual 
          instance void  RemoveAt([in] uint32 dwIndex) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceKeyCollection::RemoveAt
  } // end of method PortableDeviceKeyCollectionClass::RemoveAt

} // end of class PortableDeviceTypesLib.PortableDeviceKeyCollectionClass

.class interface public abstract auto ansi import PortableDeviceTypesLib.PortableDeviceKeyCollection
       implements PortableDeviceTypesLib.IPortableDeviceKeyCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.CoClassAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 37 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ..7PortableDevic
                                                                                                                          65 54 79 70 65 73 4C 69 62 2E 50 6F 72 74 61 62   // eTypesLib.Portab
                                                                                                                          6C 65 44 65 76 69 63 65 4B 65 79 43 6F 6C 6C 65   // leDeviceKeyColle
                                                                                                                          63 74 69 6F 6E 43 6C 61 73 73 00 00 )             // ctionClass..
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 44 41 44 41 32 33 35 37 2D 45 30 41 44   // ..$DADA2357-E0AD
                                                                                                  2D 34 39 32 45 2D 39 38 44 42 2D 44 44 36 31 43   // -492E-98DB-DD61C
                                                                                                  35 33 42 41 33 35 33 00 00 )                      // 53BA353..
} // end of class PortableDeviceTypesLib.PortableDeviceKeyCollection

.class public auto ansi import PortableDeviceTypesLib.PortableDevicePropVariantCollectionClass
       extends [mscorlib]System.Object
       implements PortableDeviceTypesLib.IPortableDevicePropVariantCollection,
                  PortableDeviceTypesLib.PortableDevicePropVariantCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 02 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(int16) = ( 01 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 30 38 41 39 39 45 32 46 2D 36 44 36 44   // ..$08A99E2F-6D6D
                                                                                                  2D 34 42 38 30 2D 41 46 35 41 2D 42 41 46 32 42   // -4B80-AF5A-BAF2B
                                                                                                  43 42 45 34 43 42 39 00 00 )                      // CBE4CB9..
  .method public specialname rtspecialname 
          instance void  .ctor() runtime managed internalcall
  {
  } // end of method PortableDevicePropVariantCollectionClass::.ctor

  .method public hidebysig newslot virtual 
          instance void  GetCount([in] uint32& pcElems) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDevicePropVariantCollection::GetCount
  } // end of method PortableDevicePropVariantCollectionClass::GetCount

  .method public hidebysig newslot virtual 
          instance void  GetAt([in] uint32 dwIndex,
                               [in] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDevicePropVariantCollection::GetAt
  } // end of method PortableDevicePropVariantCollectionClass::GetAt

  .method public hidebysig newslot virtual 
          instance void  Add([in] valuetype PortableDeviceTypesLib.tag_inner_PROPVARIANT& pValue) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDevicePropVariantCollection::Add
  } // end of method PortableDevicePropVariantCollectionClass::Add

  .method public hidebysig newslot virtual 
          instance void  GetType([out] uint16& pvt) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDevicePropVariantCollection::GetType
  } // end of method PortableDevicePropVariantCollectionClass::GetType

  .method public hidebysig newslot virtual 
          instance void  ChangeType([in] uint16 vt) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDevicePropVariantCollection::ChangeType
  } // end of method PortableDevicePropVariantCollectionClass::ChangeType

  .method public hidebysig newslot virtual 
          instance void  Clear() runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDevicePropVariantCollection::Clear
  } // end of method PortableDevicePropVariantCollectionClass::Clear

  .method public hidebysig newslot virtual 
          instance void  RemoveAt([in] uint32 dwIndex) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDevicePropVariantCollection::RemoveAt
  } // end of method PortableDevicePropVariantCollectionClass::RemoveAt

} // end of class PortableDeviceTypesLib.PortableDevicePropVariantCollectionClass

.class interface public abstract auto ansi import PortableDeviceTypesLib.PortableDevicePropVariantCollection
       implements PortableDeviceTypesLib.IPortableDevicePropVariantCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 38 39 42 32 45 34 32 32 2D 34 46 31 42   // ..$89B2E422-4F1B
                                                                                                  2D 34 33 31 36 2D 42 43 45 46 2D 41 34 34 41 46   // -4316-BCEF-A44AF
                                                                                                  45 41 38 33 45 42 33 00 00 )                      // EA83EB3..
  .custom instance void [mscorlib]System.Runtime.InteropServices.CoClassAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 3F 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ..?PortableDevic
                                                                                                                          65 54 79 70 65 73 4C 69 62 2E 50 6F 72 74 61 62   // eTypesLib.Portab
                                                                                                                          6C 65 44 65 76 69 63 65 50 72 6F 70 56 61 72 69   // leDevicePropVari
                                                                                                                          61 6E 74 43 6F 6C 6C 65 63 74 69 6F 6E 43 6C 61   // antCollectionCla
                                                                                                                          73 73 00 00 )                                     // ss..
} // end of class PortableDeviceTypesLib.PortableDevicePropVariantCollection

.class public auto ansi import PortableDeviceTypesLib.PortableDeviceValuesCollectionClass
       extends [mscorlib]System.Object
       implements PortableDeviceTypesLib.IPortableDeviceValuesCollection,
                  PortableDeviceTypesLib.PortableDeviceValuesCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 33 38 38 32 31 33 34 44 2D 31 34 43 46   // ..$3882134D-14CF
                                                                                                  2D 34 32 32 30 2D 39 43 42 34 2D 34 33 35 46 38   // -4220-9CB4-435F8
                                                                                                  36 44 38 33 46 36 30 00 00 )                      // 6D83F60..
  .custom instance void [mscorlib]System.Runtime.InteropServices.TypeLibTypeAttribute::.ctor(int16) = ( 01 00 02 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ClassInterfaceAttribute::.ctor(int16) = ( 01 00 00 00 00 00 ) 
  .method public specialname rtspecialname 
          instance void  .ctor() runtime managed internalcall
  {
  } // end of method PortableDeviceValuesCollectionClass::.ctor

  .method public hidebysig newslot virtual 
          instance void  GetCount([in] uint32& pcElems) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValuesCollection::GetCount
  } // end of method PortableDeviceValuesCollectionClass::GetCount

  .method public hidebysig newslot virtual 
          instance void  GetAt([in] uint32 dwIndex,
                               [out] class PortableDeviceTypesLib.PortableDeviceValues&  marshal( interface ) ppValues) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValuesCollection::GetAt
  } // end of method PortableDeviceValuesCollectionClass::GetAt

  .method public hidebysig newslot virtual 
          instance void  Add([in] class PortableDeviceTypesLib.PortableDeviceValues  marshal( interface ) pValues) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValuesCollection::Add
  } // end of method PortableDeviceValuesCollectionClass::Add

  .method public hidebysig newslot virtual 
          instance void  Clear() runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValuesCollection::Clear
  } // end of method PortableDeviceValuesCollectionClass::Clear

  .method public hidebysig newslot virtual 
          instance void  RemoveAt([in] uint32 dwIndex) runtime managed internalcall
  {
    .override PortableDeviceTypesLib.IPortableDeviceValuesCollection::RemoveAt
  } // end of method PortableDeviceValuesCollectionClass::RemoveAt

} // end of class PortableDeviceTypesLib.PortableDeviceValuesCollectionClass

.class interface public abstract auto ansi import PortableDeviceTypesLib.PortableDeviceValuesCollection
       implements PortableDeviceTypesLib.IPortableDeviceValuesCollection
{
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 36 45 33 46 32 44 37 39 2D 34 45 30 37   // ..$6E3F2D79-4E07
                                                                                                  2D 34 38 43 34 2D 38 32 30 38 2D 44 38 43 32 45   // -48C4-8208-D8C2E
                                                                                                  35 41 46 34 41 39 39 00 00 )                      // 5AF4A99..
  .custom instance void [mscorlib]System.Runtime.InteropServices.CoClassAttribute::.ctor(class [mscorlib]System.Type) = ( 01 00 3A 50 6F 72 74 61 62 6C 65 44 65 76 69 63   // ..:PortableDevic
                                                                                                                          65 54 79 70 65 73 4C 69 62 2E 50 6F 72 74 61 62   // eTypesLib.Portab
                                                                                                                          6C 65 44 65 76 69 63 65 56 61 6C 75 65 73 43 6F   // leDeviceValuesCo
                                                                                                                          6C 6C 65 63 74 69 6F 6E 43 6C 61 73 73 00 00 )    // llectionClass..
} // end of class PortableDeviceTypesLib.PortableDeviceValuesCollection


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file Interop.PortableDeviceTypesLib.any.res
