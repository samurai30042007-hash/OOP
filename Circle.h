#pragma once
#include <iostream>
#include "Point.h"

class Circle
{
public:
    Circle() : _radius(0), _center()
    {
        std::cout << "Circle created with radius 0 at center (0, 0)." << std::endl;
    }
    Circle(int radius, const Point &center) : _radius(radius), _center(center)
    {
        std::cout << "Circle created with radius " << _radius << " at center (" << _center.getX() << ", " << _center.getY() << ")." << std::endl;
    }
    ~Circle()
    {
        std::cout << "Circle destroyed." << std::endl;
    }
    int getRadius() const
    {
        return _radius;
    }
    Point getCenter() const
    {
        return _center;
    }
    void setRadius(int radius)
    {
        if (radius < 0)
        {
            std::cout << "Error: radius cannot be negative." << std::endl;
            return;
        }
        _radius = radius;
    }
    void setCenter(const Point &center)
    {
        _center = center;
    }
    void print()
    {
        _center.print();
        std::cout << "Radius: " << _radius << std::endl;
    }

private:
    int _radius;
    Point _center;
};

class CirclePtr
{
public:
    CirclePtr() : _radius(0), _center(new Point())
    {
        std::cout << "CirclePtr created with radius 0 at center (0, 0)." << std::endl;
    }
    CirclePtr(int radius, const Point &center) : _radius(radius), _center(new Point(center))
    {
        std::cout << "CirclePtr created with radius " << _radius << " at center (" << _center->getX() << ", " << _center->getY() << ")." << std::endl;
    }
    ~CirclePtr()
    {
        delete _center;
        std::cout << "CirclePtr destroyed." << std::endl;
    }
    int getRadius() const
    {
        return _radius;
    }
    const Point &getCenter() const
    {
        return *_center;
    }
    void setRadius(int radius)
    {
        if (radius < 0)
        {
            std::cout << "Error: radius cannot be negative." << std::endl;
            return;
        }
        _radius = radius;
    }
    void setCenter(const Point &center)
    {
        *_center = center;
    }
    void print()
    {
        _center->print();
        std::cout << "Radius: " << _radius << std::endl;
    }
    void moveCenter(int dx, int dy)
    {
        _center->move(dx, dy);
    }

private:
    int _radius;
    Point *_center;
};