using System;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace CSharp_Puzzlers.EvilStructs {
    public struct MyHandle : IDisposable {
        public IntPtr Handle { get; private set; }

        public MyHandle(IntPtr preexistingHandle) {
            Handle = preexistingHandle;
        }

        public void Dispose() {
            if (Handle != IntPtr.Zero)
                CloseHandle(Handle);
            Handle = IntPtr.Zero;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr handle);
    }

    public class MyHandleClient {
        public void Test1() {
            var handle = new MyHandle(new IntPtr(16));
            try {
                // do something
            }
            finally {
                handle.Dispose();
            }
            // Sanity check
            Debug.Assert(handle.Handle == IntPtr.Zero);
        }

        public void Test2() {
            var handle = new MyHandle(new IntPtr(16));
            try {
                // do something
            }
            finally {
                ((IDisposable)handle).Dispose();
            }
            // Sanity check
            Debug.Assert(handle.Handle == IntPtr.Zero);
        }

        public void Test3() {
            var handle = new MyHandle(new IntPtr(16));
            using (handle)
            {
                // Do something
            }
            // Sanity check
            Debug.Assert(handle.Handle == IntPtr.Zero);
        }

        #region Secret
        public void Test4() {
            var handle = new MyHandle(new IntPtr(16));
            {
                MyHandle invisible = handle;
                try
                {
                    // Do something
                }
                finally
                {
                    invisible.Dispose(); // No boxing, due to optimization
                }
            }
            // Sanity check
            Debug.Assert(handle.Handle == IntPtr.Zero);
        }
        #endregion
    }
}