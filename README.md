# Base Converter
This simple **Windows Forms App** converts between Binary(2), Octal(8), Decimal(10) and Hexadecimal(16) numeral systems. The purpose of creating this application was to get started with **C#** and **.Net Framework**.

Some included features:
- Validate entries (i.e. only 0-9 and A-F are accepted for Hex).
- Simultaneously convert to other bases as user type in.
- Copy the corresponding number to clipboard once a label is clicked.
- Automatically *select all* once a particular text box is clicked.

Nothing really fancy, yet!

## Getting Started
Here are some useful documentations:
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/index)
- [Windows Forms](https://docs.microsoft.com/en-us/dotnet/framework/winforms/)

### Testing
Since the project is considered from an untrustworthy source, it might get blocked for security reasons.
If you receive the following error message upon building the project:

![Error Message](../resources/BuildingError.PNG?raw=true)

Navigate to the main directory, where the **Form1.resx** file is located. Right click on the file and go to properties. Make sure the **Unlock** box is checked. (Shown is red box below)

![File Properties](../resources/FileProperties.PNG?raw=true)

## License
This project is licensed under the [MIT License](https://github.com/aalsehly86/BaseConverter/blob/master/LICENSE).

## Acknowledgments
- [Stackoverflow](https://stackoverflow.com), what a great community!
- IconArchive for [Equal](http://www.iconarchive.com/show/polygon-icons-by-graphicloads/equal-icon.html) and [Copy](http://www.iconarchive.com/show/qetto-2-icons-by-ampeross/copy-icon.html) icons.
