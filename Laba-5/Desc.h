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
	Desc(const Desc& other) : Base(other) {
		cout << "Desc copy constructor" << endl;
	}
	Desc(Desc& other) : Base(other) {
		cout << "Desc reference copy constructor" << endl;
	}
	Desc(Desc* other) : Base(other) {
		cout << "Desc pointer copy constructor" << endl;
	}	
	void PrintVirtual() override {
		cout << "Desc value" << endl;
	}
	void PrintNonVirtual() {
		cout << "Desc value" << endl;
	}
	void OnlyDesc() {
		cout << "Desc only method" << endl;
	}
	string  GetType() override {
		return "Desc";
	}
	bool IsA(string type) override {
		return type == "Desc" || Base::IsA(type);
	}	
};