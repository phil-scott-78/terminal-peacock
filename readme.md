﻿# Terminal Peacock

A small tool to generate a collection of small lines to use as your background image to differentiate your Windows Terminal tabs.

## Using the Output

All images have a vertical and a horizontal mode. Just pick if you want them at the top or or the bottom of the screen.

```json
{
    "guid": "{61c54bbd-c2c6-5271-96e7-009a87ff44bf}",
    "name": "Windows PowerShell",
    "commandline": "powershell.exe",
    "hidden": false,
    "backgroundImage": "powershell-big-images\\blue-16px-horizontal.png",
    "backgroundImageStretchMode": "none",
    "backgroundImageAlignment": "bottomLeft",
    "padding": "8, 8, 8, 24",
},
```

Make sure to set stretch mode to none otherwise it'll stretch the line out to the size of your console window. Then adjust the padding to the appropriate size to allow your line to live. 

!["terminal picture](resources/terminal.png)

## Running the Generator

There are two options, one to create a single collection given a name, color and a width. The other generates a collection of images based on the default. 

```cmd
TerminalPeacock one red #ff0000 -w 24
```

or 

```cmd
TerminalPeacock defaults
```
## Grab the Files

If you just want the files grab them from the [Releases](https://github.com/phil-scott-78/terminal-peacock/releases)
