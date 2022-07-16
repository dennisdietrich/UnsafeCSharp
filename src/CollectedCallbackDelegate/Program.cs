using CollectedCallbackDelegate;
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

// Multicast with instance methods
Action greeters = new GreetingWriter("C#").Greet;
greeters += new GreetingWriter(".NET").Greet;

SetCallback(greeters);
CallMeMaybe();

// Callback may throw an exception
SetCallback(() => throw new Exception("That didn't work as expected..."));
CallMeMaybe();