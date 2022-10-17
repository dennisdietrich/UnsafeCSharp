using CollectedCallbackDelegate;
using static CollectedCallbackDelegate.CallbackFromNative;

static void SetupAndTriggerNativeCallback()
{
    static void SayHello() => Console.WriteLine("Hello, .NET!");

    SetCallback(SayHello);
    CallMeMaybe();
}

SetupAndTriggerNativeCallback();
GC.Collect();
GC.WaitForPendingFinalizers();

try
{
    CallMeMaybe();
}
catch (Exception e)
{
    Console.WriteLine("Callback threw exception of type {0}: {1}", e.GetType().FullName, e.Message);
}

// Multicast with instance methods
Action greeters = new GreetingWriter("C#").Greet;
greeters += new GreetingWriter(".NET").Greet;

SetCallback(greeters);
CallMeMaybe();

// Callback may throw an exception
SetCallback(() => throw new Exception("That didn't work as expected..."));

try
{
    CallMeMaybe();
}
catch (Exception e)
{
    Console.WriteLine($"Callback threw exception of type {e.GetType().FullName}: {e.Message}");
}

SetCallback(() => throw new Exception("That didn't work as expected..."));
CallMeOnNewThread();
Thread.Sleep(1000); // Yes, hacky, don't do this in production!