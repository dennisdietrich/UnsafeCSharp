#pragma once
#include <stdio.h>
#include <windows.h>

void (*callbackPtr)(void) = NULL;

__declspec(dllexport) void __stdcall SetCallback(void (*ptr)(void));
__declspec(dllexport) void __stdcall CallMeMaybe(void);
__declspec(dllexport) void __stdcall CallMeOnNewThread(void);

DWORD WINAPI InvokeCallback(_In_ LPVOID lpParameter);