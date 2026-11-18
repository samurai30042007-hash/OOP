#pragma once

#include <iostream>
#include "Base.h"
using namespace std;

class Desc : public Base {
public:
	Desc() {
		cout << "Desc constructor" << endl;
	}
	virtual ~Desc() {
		cout << "Desc destructor" << endl;
	}
	void PrintVirtual() override {
		cout << "Desc value" << endl;
	}
	void PrintNonVirtual() {
		cout << "Desc value" << endl;
	}
};