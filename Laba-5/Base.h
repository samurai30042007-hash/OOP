#pragma once

#include <iostream>
using namespace std;

class Base {

	public:
		Base() {
			cout << "Base constructor" << endl;
		}
		virtual ~Base() {
			cout << "Base destructor" << endl;
		}
		Base(const Base& other) {
			cout << "Base copy constructor" << endl;
		}
		virtual void PrintVirtual() {
			cout << "Base value" << endl;
		}
		void  PrintNonVirtual() {
			cout << "Base value" << endl;
		}
		virtual string GetType() {
			return "Base";
		}
		virtual bool IsA(string type) {
			return type == "Base";
		}
		Base CreateByValue() {
			Base bas;
			return bas;
		}
		Base* CreateByPointer() {
			Base* bas = new Base();
			return bas;
		}
		Base& CreateByReference() {
			Base* bas = new Base();
			return *bas;
		}
		Base& CreateByReferenceStatic() {
			static Base bas;
			return bas;
		}
};