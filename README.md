# GTSErpSystem

A simplified ERP starter inspired by the order-management and stock logic shown in the provided C# file.

## What is included
- Entity Framework Core setup with SQL Server connection
- Basic models for items, stock, orders, cost centers, and stores
- Order service class with simple business methods
- Helper class for connection settings

## Structure
- `GTSErpSystem/Helper/LoginDetails.cs`
- `GTSErpSystem/Data/GTSdbContext.cs`
- `GTSErpSystem/Models/Entities.cs`
- `GTSErpSystem/BLL/Class_Orders.cs`

## Run
```bash
dotnet restore
# then build
dotnet build GTSErpSystem/GTSErpSystem.csproj
```

## Notes
This is a clean starter from scratch, not a 1:1 copy of the original proprietary ERP system. It is designed as a solid base for expanding into a real order and inventory management ERP.
