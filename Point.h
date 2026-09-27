class Point
{

public:
    Point() : _x(0), _y(0)
    {
        std::cout << "Point created (0, 0)." << std::endl;
    };
    Point(int x, int y) : _x(x), _y(y)
    {
        std::cout << "Point created (" << x << ", " << y << ")." << std::endl;
    };
    Point(const Point &other) : _x(other._x), _y(other._y)
    {
        std::cout << "Point copied (" << other._x << ", " << other._y << ")." << std::endl;
    };
    int getX()
    {
        return _x;
    }
    int getY()
    {
        return _y;
    }
    void setX(int x)
    {
        if (x < 0)
        {
            std::cout << "Error: x cannot be negative." << std::endl;
            return;
        }
        _x = x;
    };
    void setY(int y)
    {
        if (y < 0)
        {
            std::cout << "Error: y cannot be negative." << std::endl;
            return;
        }
        _y = y;
    };
    void print()
    {
        std::cout << "Point: (" << _x << ", " << _y << ")" << std::endl;
    };
    void move(int dx, int dy);

    ~Point()
    {
        std::cout << "Point destroyed (" << _x << ", " << _y << ")." << std::endl;
    };

private:
    int _x;
    int _y;
};
void Point::move(int dx, int dy)
{
    _x += dx;
    _y += dy;
};
