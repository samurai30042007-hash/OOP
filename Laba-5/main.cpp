#include <iostream>
#include "Base.h"
#include "Desc.h"
using namespace std;

int main(){
	Base* base = new Desc();
	Desc* desc = new Desc();
	base->PrintNonVirtual();
	base->PrintVirtual();
	desc->PrintNonVirtual();
	desc->PrintVirtual();	
}