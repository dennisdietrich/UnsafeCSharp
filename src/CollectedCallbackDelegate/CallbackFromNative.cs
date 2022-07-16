using System.Runtime.InteropServices;

namespace CollectedCallbackDelegate
{
    internal static class CallbackFromNative
    {
        [DllImport("CallbackFromNative.dll")]
        internal extern static void SetCallback(Action action);

        [DllImport("CallbackFromNative.dll")]
        internal extern static void CallMeMaybe();
    }
}