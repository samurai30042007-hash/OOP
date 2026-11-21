#include <iostream>
#include "Base.h"
#include "Desc.h"
#include <memory>
// ДОБАВЛЕНО (ЛР 5): std::move для передачи владения unique_ptr.
#include <utility>
using namespace std;

void func1(Base obj);
void func2(Base* obj);
void func3(Base& obj);
Base CreateByValue();
Base* CreateByPointer();
Base& CreateByReference();
Base& CreateByReferenceStatic();
Base* CreateLocalByPointer();
Base& CreateLocalByReference();
void CheckShared(shared_ptr<Base> ptr);
shared_ptr<Base> CreateShared();
// ДОБАВЛЕНО (ЛР 5): возвращаем созданный через new объект ПО ЗНАЧЕНИЮ, без утечки.
Base CreateDynamicByValue();
// ДОБАВЛЕНО (ЛР 5): функция возвращает единственного владельца unique_ptr.
unique_ptr<Base> CreateUnique();
// ДОБАВЛЕНО (ЛР 5): функция принимает unique_ptr по значению и становится его владельцем.
void ConsumeUnique(unique_ptr<Base> ptr);

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

	Base baseByValue = CreateByValue();
	baseByValue.PrintVirtual();
	Base* baseByPointer = CreateByPointer();
	baseByPointer->PrintVirtual();
	delete baseByPointer;
	Base& baseByReference = CreateByReference();
	baseByReference.PrintVirtual();	
	delete &baseByReference;
	Base& baseByReferenceStatic = CreateByReferenceStatic();
	baseByReferenceStatic.PrintVirtual();
	cout << "\n" << endl;

	Base& first = CreateByReferenceStatic();
	Base& second = CreateByReferenceStatic();
	cout << "first address: " << &first << endl;
	cout << "second address: " << &second << endl;

	cout << "\n" << endl;

	{
		auto ptr1 = make_unique<Base>();
		auto ptr2 = move(ptr1);
		if (ptr1 == nullptr)
		{
			cout << "ptr1 is nullptr" << "\n";
			ptr2->PrintVirtual();
		}
		else {
			cout << "Error" << "\n";
		}
	}

	cout << "\n" << endl;

	auto ptr1 = make_shared<Base>();
	auto ptr2 = ptr1;
	cout << ptr2.use_count() << "\n";
	ptr1.reset();
	cout << ptr2.use_count() << "\n";
	ptr2.reset();

	cout << "\n" << endl;

	auto ptr = make_shared<Base>();

	cout << ptr.use_count() << endl;
	CheckShared(ptr);
	cout << ptr.use_count() << endl;

	cout << "\n" << endl;

	{
		auto sharedPtr = CreateShared();
		CheckShared(sharedPtr);
	}


	cout << "\n" << endl;

	{
		Base b;
		Base b1(&b);
		Base b2(b);

		Desc d;
		Desc d1(&d);
		Desc d2(d);
	}

	cout << "\n" << endl;

	Base* obj = new Desc();

	obj->CallVirtual();
	obj->CallNonVirtual();

	delete obj;

	// ДОБАВЛЕНО (ЛР 5): возвращённое значение независимо от исходного объекта в динамической памяти.
	{
		Base copied = CreateDynamicByValue();
		copied.PrintVirtual();
	} // Автоматическое уничтожение copied; исходный объект удалён внутри CreateDynamicByValue().

	// ДОБАВЛЕНО (ЛР 5): возврат unique_ptr из функции и передача владения в другую функцию.
	{
		auto uniquePtr = CreateUnique(); // Созданный объект теперь принадлежит uniquePtr.
		ConsumeUnique(move(uniquePtr)); // Владение передаётся функции, копирования объекта Base нет.
		cout << (uniquePtr == nullptr ? "uniquePtr is nullptr" : "Error: uniquePtr still owns an object") << endl;
	} // Объект Base уже уничтожен при завершении ConsumeUnique().

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
void CheckShared(shared_ptr<Base> ptr) {
	cout << ptr.use_count() << "\n";
}
shared_ptr<Base> CreateShared() {
	auto ptr = make_shared<Base>();
	return ptr;
}


/*
Base* CreateLocalByPointer() {
	Base obj; 
	return &obj; 
}
Base& CreateLocalByReference() {
	Base obj;
	return obj;
}
*/

// ДОБАВЛЕНО (ЛР 5): безопасный возврат по значению из объекта, созданного через new.
Base CreateDynamicByValue() {
	Base* heapObj = new Base(); // Динамический исходный объект, требует освобождения.
	Base result = *heapObj; // Создаём отдельный объект через конструктор копирования.
	delete heapObj; // Освобождаем исходный объект ДО возврата; нет утечки.
	return result; // NRVO может устранить дополнительное копирование при возврате.
}

// ДОБАВЛЕНО (ЛР 5): make_unique создаёт объект и возвращает владеющий unique_ptr.
unique_ptr<Base> CreateUnique() {
	auto ptr = make_unique<Base>();
	return ptr; // Возврат перемещает владение; объект Base не копируется.
}

// ДОБАВЛЕНО (ЛР 5): параметр по значению принимает владение, полученное через std::move.
void ConsumeUnique(unique_ptr<Base> ptr) {
	ptr->PrintVirtual();
} // При выходе из функции ptr уничтожается вместе с принадлежащим ему Base.
