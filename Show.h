#pragma once
#include <iostream>
#include "Point.h"
#include "ColoredPoint.h"

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
};