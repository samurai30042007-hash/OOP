#pragma once
#include <iostream>
#include "Point.h"
#include "ColoredPoint.h"
#include "Circle.h"

class Show
{

public:
    void showBlock1()
    {
        Point p1 = Point(3, 4);
        Point p2 = Point();
        {
            Point p3 = Point(p1);
        }
        Point *p4 = new Point(5, 6);
        p4->print();
        delete p4;
    }
    void showBlock2()
    {
        ColoredPoint cp1 = ColoredPoint(1, 2, "red");
        ColoredPoint cp2 = ColoredPoint();
        {
            ColoredPoint cp3 = ColoredPoint(cp1);
        }
        ColoredPoint *cp4 = new ColoredPoint(7, 8, "blue");
        cp4->move(1, 1);
        cp4->print();
        delete cp4;
    }
    void ShowBlock3()
    {

        Circle c2 = Circle();
        c2.print();
    }
    void ShowBlock4()
    {
        Point p1 = Point(3, 4);
        Point p2 = p1;
        p2.setX(10);
        p2.setY(20);
        p1.print();
        p2.print();
        Point *p3 = new Point(5, 6);
        Point *p4 = p3;
        p4->setX(30);
        p4->setY(40);
        p3->print();
        p4->print();
        delete p3;
    }
    void ShowBlock5()
    {
        Point *p1 = new ColoredPoint(3, 4, "red");
        p1->print();
        ((ColoredPoint *)p1)->print();
        delete p1;
        Point p2 = ColoredPoint(5, 6, "blue");
        p2.print();
    }
};