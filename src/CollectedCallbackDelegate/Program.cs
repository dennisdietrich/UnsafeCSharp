using static CollectedCallbackDelegate.CallbackFromNative;

static void SetupAndTriggerNativeCallback()
{
    static void SayHello() => Console.WriteLine("Hello, .NET!");

    SetCallback(SayHello);
    CallMeMaybe();
}

SetupAndTriggerNativeCallback();
// Do lots of stuff here...
GC.Collect();
GC.WaitForPendingFinalizers();
CallMeMaybe();