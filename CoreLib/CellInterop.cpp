#include "CellInterop.hpp"

#include <bit>

CellInterop CreateCell(int x, int y, double width, double height)
{        
    return CellInterop
    {
        x,
        y,
        width,
        height,
        x % 2 == 0 ? (y % 2 == 0 ? L"Black" : L"White") : (y% 2 == 0) ? L"White" : L"Black"
    };
}

CellInterop* CreateCells(int horizontalAmount, int verticalAmount, double canvasWidth, double canvasHeight)
{
    const int cellAmount = horizontalAmount * verticalAmount;
    const auto cells = new CellInterop[cellAmount];
    const double cellWidth = canvasWidth / horizontalAmount;
    const double cellHeight = canvasHeight / verticalAmount;

    for(int i = 0; i < cellAmount; i++)
    {
        const int x = i % horizontalAmount;
        const int y = i / horizontalAmount;

        cells[i] = CreateCell(x, y, cellWidth, cellHeight);
    }
    
    return cells;
}
