#include "callbackdemo.h"

void SetCallback(void (*ptr)(void))
{
	callbackPtr = ptr;
}

void CallMeMaybe(void)
{
	callbackPtr();
}

void CallMeOnNewThread(void)
{
	const HANDLE hThread = CreateThread(NULL, 0, &InvokeCallback, NULL, 0, NULL);

	if (hThread != 0)
		CloseHandle(hThread);
}

DWORD InvokeCallback(_In_ LPVOID lpParameter)
{
	callbackPtr();
	return 0;
}