#include "main.hpp"

#include <iostream>

#include "CellInterop.hpp"

constexpr auto horizontalAmount = 20;
constexpr auto verticalAmount = 20;
CellInterop* cells;

bool InitializeEngine(double canvasWidth, double canvasHeight)
{
    cells = CreateCells(horizontalAmount, verticalAmount, canvasWidth, canvasHeight);
    
    for(int i = 0; i < horizontalAmount * verticalAmount; i++)
    {
        const auto cell = cells[i];
        AddCellToCanvasCallback(cell);
    }
    
    return true;
}

void UpdateEngine()
{
    for(int i = 0; i < horizontalAmount * verticalAmount; i++)
    {
        CellInterop& cell = cells[i];
        if(cell.FillColor == L"Black")
        {
            cell.FillColor = L"White";
        }
        else
        {
            cell.FillColor = L"Black";
        }
        UpdateCellOnCanvasCallback(cell.X, cell.Y, cell.FillColor);
    }
}

void CleanupEngine()
{
    DeleteCells(cells);
}