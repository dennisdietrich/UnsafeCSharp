#include "callbackdemo.h"
#include <Windows.h>

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
	HANDLE hThread = CreateThread(NULL, 0, &InvokeCallback, NULL, 0, NULL);

	if (hThread != 0)
		CloseHandle(hThread);
}

DWORD WINAPI InvokeCallback(_In_ LPVOID lpParameter)
{
	callbackPtr();
	return 0;
}