# Matt.Net

Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Matt Lewis, matt dot lewis at nccgroup dot com

http://www.github.com/nccgroup/matt.net

Released under the AGPL. See LICENSE for more information.

## Overview

Matt.Net is a simple GUI wrapper around Microsoft's CAT.NET Code Auditing Tool.

It can be used to locate .NET binaries within a given folder and will run CAT.NET on all relevant binaries.

Any security flaws identified are logged in a local database for future reference, which allows for tracking over time of flaws in different .NET binaries.

# Usage

Simply launch the GUI. Point it to a version of Microsoft's CAT.NET (either 32 or 64-bit version), give it a source/input directory and an output directory to store results. The timeout parameter determines how long CAT.NET will run on each binary before giving up and moving on to the next. Adjust this as required (i.e. increase if Matt.NET gives up too early on a binary).

# Limitations

This is a simple, first version of the tool. Note that it is only single-threaded and is quite heavy on computation as CAT.NET performs a lot of processing around taint analysis.

# Libraries used

* [CAT.NET v1 32-bit](http://www.microsoft.com/en-gb/download/details.aspx?id=19968) - 32-bit version of CAT.NET
* [CAT.NET v1 64-bit](http://www.microsoft.com/en-gb/download/details.aspx?id=5570) - 64-bit version of CAT.NET
* [System.Data.SQLite](http://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki) - used to create and use a local sqlite database for tracking .NET binary security flaws.
