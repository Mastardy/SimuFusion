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

CellInterop CreateCell(int x, int y, double width, double height);
CellInterop* CreateCells(int horizontalAmount, int verticalAmount, double canvasWidth, double canvasHeight);
void DeleteCells(const CellInterop* cells);

typedef void (*AddCellToCanvasFunc)(CellInterop cellInterop);
inline AddCellToCanvasFunc AddCellToCanvasCallback;
ENGINE_DLL_EXPORT void RegisterAddCellToCanvasCallback(AddCellToCanvasFunc callback);

typedef void (*UpdateCellOnCanvasFunc)(int x, int y, const wchar_t* color);
inline UpdateCellOnCanvasFunc UpdateCellOnCanvasCallback;
ENGINE_DLL_EXPORT void RegisterUpdateCellOnCanvasCallback(UpdateCellOnCanvasFunc callback);