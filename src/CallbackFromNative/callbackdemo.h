#pragma once
#include <stdio.h>

void (*callbackPtr)(void) = NULL;

__declspec(dllexport) void __stdcall SetCallback(void (*ptr)(void));
__declspec(dllexport) void __stdcall CallMeMaybe(void);