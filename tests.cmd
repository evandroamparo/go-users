@echo off

call "%PROGRAMFILES%\Microsoft Visual Studio 12.0\Common7\Tools\vsvars32.bat"

mstest /testcontainer:GoUsersTests\bin\Debug\GoUsersTests.dll /noisolation