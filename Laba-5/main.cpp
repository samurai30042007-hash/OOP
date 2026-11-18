#include <iostream>
#include "Base.h"
#include "Desc.h"
using namespace std;

int main(){
	Desc* desc = new Desc();
	Base* base = desc;
	base->PrintNonVirtual();
	base->PrintVirtual();
	desc->PrintNonVirtual();
	desc->PrintVirtual();	
	delete desc;
}