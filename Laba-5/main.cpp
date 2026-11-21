#include <iostream>
#include "Base.h"
#include "Desc.h"
using namespace std;

void func1(Base obj);
void func2(Base* obj);
void func3(Base& obj);

int main(){
	Desc* desc = new Desc();
	Base* base = new Desc();
	base->PrintNonVirtual();
	base->PrintVirtual();
	desc->PrintNonVirtual();
	desc->PrintVirtual();	
	cout << "\n" << endl;
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
	cout << "\n" << endl;

	cout << "desc->GetType(): " << desc->GetType() << endl;
	cout << "base->GetType(): " << base->GetType() << endl;
	cout << "desc->IsA(\"Base\"): " << desc->IsA("Base") << endl;
	cout << "desc->IsA(\"Desc\"): " << desc->IsA("Desc") << endl;
	cout << "trueBase->IsA(\"Desc\"): " << trueBase->IsA("Desc") << endl;
	if (base->IsA("Desc")) {
		Desc* descPtr = static_cast<Desc*>(base);
		descPtr->OnlyDesc();
	}
	cout << "\n" << endl;

	func1(*base);
	func2(base);
	func3(*base);
	cout << "\n" << endl;

	delete desc;
	delete trueBase;
	delete base;
}


void func1(Base obj) {
	obj.PrintVirtual();
}
void func2(Base* obj) {
	obj->PrintVirtual();
}void func3(Base& obj) {
	obj.PrintVirtual();
}