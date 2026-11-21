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

	cout << "desc->GetType(): " << desc->GetType() << endl;
	cout << "base->GetType(): " << base->GetType() << endl;
	cout << "desc->IsA(\"Base\"): " << desc->IsA("Base") << endl;
	cout << "desc->IsA(\"Desc\"): " << desc->IsA("Desc") << endl;


	delete desc;
	delete trueBase;
	delete base;
}

