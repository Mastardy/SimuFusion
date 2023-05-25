#include "main.hpp"

#include <iostream>

#include "CellInterop.hpp"

extern "C"
{
    #include "lua.h"
    #include "lauxlib.h"
    #include "lualib.h"
}

constexpr auto horizontalAmount = 20;
constexpr auto verticalAmount = 20;
CellInterop* cells;

void TestLua()
{
    lua_State *LuaState = luaL_newstate();
    luaL_openlibs(LuaState);
    
    const std::string luaCommand = R"(
        a = 4 + 2 + math.sin(20);
        print("[LUA] a in Lua: " + a);
    )";
    const int r = luaL_dostring(LuaState, luaCommand.c_str());
    
    if(r == LUA_OK)
    {
        lua_getglobal(LuaState, "a");
        if(lua_isnumber(LuaState, -1))
        {
            const auto a_in_cpp = static_cast<float>(lua_tonumber(LuaState, -1));
            std::cout << "[C++] a in C++: " << a_in_cpp << std::endl;
        }
    }
    else
    {
        const std::string error = lua_tostring(LuaState, -1);
        std::cout << error << std::endl;
    }

    lua_close(LuaState);   
}

bool InitializeEngine(double canvasWidth, double canvasHeight)
{
    TestLua();  
    
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