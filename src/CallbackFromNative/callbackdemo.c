#include "callbackdemo.h"

void SetCallback(void (*ptr)(void))
{
	callbackPtr = ptr;
}

void CallMeMaybe(void)
{
	callbackPtr();
}