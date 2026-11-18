#include <iostream>
#include "Base.h"
#include "Desc.h"
using namespace std;

int main(){
	Desc* desc = new Desc();
	Base* base = new Desc();
	base->PrintNonVirtual();
	base->PrintVirtual();
	desc->PrintNonVirtual();
	desc->PrintVirtual();	
	
	Base* trueBase = new Base();
	Desc* mayDesc = dynamic_cast<Desc*>(trueBase);
	if (mayDesc == nullptr)
	{
		cout << "dynamic_cast failed" << endl;
	}
	else
	{
		cout << "dynamic_cast succeeded" << endl;
	}
	mayDesc = dynamic_cast<Desc*>(base);	
	if (mayDesc == nullptr)
	{
		cout << "dynamic_cast failed" << endl;
	}
	else
	{
		cout << "dynamic_cast succeeded" << endl;
		mayDesc->OnlyDesc();
	}


	delete desc;
	delete trueBase;
	delete base;
}

