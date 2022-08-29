# EasyDebug-dotnet-application
Make it easier to read local variables while debugging optimized .NET applications, we will disable code optimization by:
- Create a `.ini` file have the same name with the file that we want to debug: `something.dll` -> `something.ini`
- Set environment variable in registry key to disable optimization

## Usage

Note: Because we will modify registry key value in HKEY_LOCAL_MACHINE which is a protected space, this application/executable file need to be **Run as Administrator**

```
EasyDebug.exe <filePath>
```

`filePath` : is the absolute path to the file that you want to debug.

Successful output:
![image](https://user-images.githubusercontent.com/37280106/187181388-ae256b2c-8828-44bc-b421-57a61bdc3784.png)
