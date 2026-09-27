#include <iostream>
#include "Point.h"

int main()
{
    Point p1 = Point(3, 4);
    Point p2 = Point();
    {
        Point p3 = Point(p1);
    }
    Point *p4 = new Point(5, 6);
    p4->print();
    delete p4;
    return 0;
}