using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace MediaDevices.Internal
{
    internal class StreamWrapper : Stream
    {
        private IStream stream;
        private IntPtr pLength;

        private void CheckDisposed()
        {
            if (this.stream == null)
            {
                throw new ObjectDisposedException("StreamWrapper");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.stream != null)
            {
                Marshal.ReleaseComObject(this.stream);
                this.stream = null;
            }
            if (this.pLength != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(this.pLength);
                this.pLength = IntPtr.Zero;
            }
        }

        public StreamWrapper(IStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            this.stream = stream;
            this.pLength = Marshal.AllocHGlobal(16);
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override void Flush()
        {
            this.stream.Commit(0);
        }

        public override long Length
        {
            get
            {
                CheckDisposed();
                System.Runtime.InteropServices.ComTypes.STATSTG stat;
#if NETCOREAPP
                this.stream.Stat(out stat, 0);
#else
                this.stream.Stat(out stat, 1); //STATFLAG_NONAME
#endif
                return stat.cbSize;
            }
        }

        public override long Position
        {
            get
            {
                return Seek(0, SeekOrigin.Current);
            }
            set
            {
                Seek(value, SeekOrigin.Begin);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            CheckDisposed();

            if (offset < 0 || count < 0 || offset + count > buffer.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            byte[] localBuffer = buffer;

            if (offset > 0)
            {
                localBuffer = new byte[count];
            }

            try
            {
                this.stream.Read(localBuffer, count, this.pLength);
                int bytesRead = Marshal.ReadInt32(this.pLength);

                if (offset > 0)
                {
                    Array.Copy(localBuffer, 0, buffer, offset, bytesRead);
                }

                return bytesRead;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return 0;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            CheckDisposed();

            int dwOrigin;

            switch (origin)
            {
            case SeekOrigin.Begin:
                dwOrigin = 0;   // STREAM_SEEK_SET
                break;

            case SeekOrigin.Current:
                dwOrigin = 1;   // STREAM_SEEK_CUR
                break;

            case SeekOrigin.End:
                dwOrigin = 2;   // STREAM_SEEK_END
                break;

            default:
                throw new ArgumentOutOfRangeException();
            }

            try
            {
                this.stream.Seek(offset, dwOrigin, this.pLength);
                return Marshal.ReadInt64(this.pLength);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return 0;
        }

        public override void SetLength(long value)
        {
            CheckDisposed();

            stream.SetSize(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            CheckDisposed();

            if (offset < 0 || count < 0 || offset + count > buffer.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            byte[] localBuffer = buffer;

            if (offset > 0)
            {
                localBuffer = new byte[count];
                Array.Copy(buffer, offset, localBuffer, 0, count);
            }

            // workaround for Windows 10 Update 1703 problem 
            // https://social.msdn.microsoft.com/Forums/en-US/7f7a045d-9d9d-4ff4-b8e3-de2d7477a177/windows-10-update-1703-problem-with-wpd-and-mtp?forum=csharpgeneral
            stream.Write(localBuffer, count, this.pLength);
        }
    }
}
