# MarsRobotAPI
Robot that navigate on Mars terrain.
See the description detailed in [Wiki](https://github.com/pablobrunetti/MarsRobotAPI/wiki/Test-Description).

## Framework
* .NET 6

## Library
* FluentValidation
* FluentValidation.AspNetCore
* Microsoft.EntityFrameworkCore.InMemory
* Newtonsoft.Json
* Swashbuckle.AspNetCore
* xunit
* Microsoft.NET.Test.Sdk

## Run

    cd MarsRobot
    dotnet run

## Input
    [POST]
    {
        "grid": "FFRFLFLF",
        "commands": "5x5"
    }

Grid accept only characteres L, R or F

Commands accept only input in format IntegerxInteger, and Integer > 0