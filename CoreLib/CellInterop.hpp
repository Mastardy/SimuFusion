#pragma once
#include "core.hpp"

struct CellInterop
{
    int X;
    int Y;
    double Width;
    double Height;
    const wchar_t* FillColor;
};

ENGINE_DLL_EXPORT CellInterop CreateCell(int x, int y, double width, double height);
ENGINE_DLL_EXPORT CellInterop* CreateCells(int horizontalAmount, int verticalAmount, double canvasWidth, double canvasHeight);
