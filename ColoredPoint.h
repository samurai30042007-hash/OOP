#pragma once
#include <iostream>
#include "Point.h"
class ColoredPoint : public Point
{
public:
    std::string getColor()
    {
        return _color;
    }
    void setColor(const std::string &color)
    {
        _color = color;
    }
    ColoredPoint() : Point(), _color("black")
    {
        std::cout << "ColoredPoint created (0, 0, black)." << std::endl;
    }
    ColoredPoint(int x, int y, const std::string &color) : Point(x, y), _color(color)
    {
        std::cout << "ColoredPoint created (" << x << ", " << y << ", " << color << ")." << std::endl;
    }
    ~ColoredPoint()
    {
        std::cout << "ColoredPoint destroyed (" << _x << ", " << _y << ", " << _color << ")." << std::endl;
    }
    ColoredPoint(const ColoredPoint &other) : Point(other), _color(other._color)
    {
        std::cout << "ColoredPoint copied (" << other._x << ", " << other._y << ", " << other._color << ")." << std::endl;
    }
    void print()
    {
        Point::print();
        std::cout << "Color: " << _color << std::endl;
    }

private:
    std::string _color;
};
