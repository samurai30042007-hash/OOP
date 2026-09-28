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
        Circle c1 = Circle(5, Point(2, 3));
        Circle c2 = Circle();
        {
            Circle c3 = Circle(c1.getRadius(), c1.getCenter());
        }
        CirclePtr cp1 = CirclePtr(10, Point(4, 5));
        cp1.print();
        cp1.setRadius(15);
        cp1.moveCenter(2, 3);
        cp1.print();
        std::cout << "Radius: " << cp1.getRadius() << std::endl;
    }
};