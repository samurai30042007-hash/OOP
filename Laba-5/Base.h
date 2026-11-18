#pragma once

#include <iostream>
using namespace std;

class Base {

	public:
		Base() {
			cout << "Base constructor" << endl;
		}
		~Base() {
			cout << "Base destructor" << endl;
		}
		virtual void PrintVirtual() {
			cout << "Base value" << endl;
		}
		void  PrintNonVirtual() {
			cout << "Base value" << endl;
		}
};