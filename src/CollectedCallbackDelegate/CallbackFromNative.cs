using System.Runtime.InteropServices;

namespace CollectedCallbackDelegate
{
    internal static class CallbackFromNative
    {
        private const string DllName = "CallbackFromNative.dll";

        [DllImport(DllName)]
        internal static extern void SetCallback(Action action);

        [DllImport(DllName)]
        internal static extern void CallMeMaybe();
    }
}