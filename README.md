# Toy-Robot
This application is built on .Net core 6. It is recommended to have .Net core 6 installed if you want to debug

Tests cases are written using Nunit framework

There are two flavors to the application, the way you take the input. Program.cs has the Preprocessor directive.
Please switch to Debug configuration in the drop down in Menu then you can debug the application by providing file path after Input requirement 

**What is included in the Repo?**
 - Robot - Main console project
 - Robot.Tests - Has all the test cases
 - commands.txt - test data for the application (Can be found under ../Robot folder)
 - Solution file - .Net solution file

**Pre-requisites**
 - .Net runtime
 - Visual studio/code (for building and debugging)
   
**Setup**

Clone this repo:

https://github.com/joker2210/Toy-Robot.git

After you clone, open the Robot.sln in any IDE (preferebly visual studio) and build in Release. The application will be here:
../Robot/bin/Release

**How to run app**

Create a .txt file with a series of commands on new lines, for instance commands.txt

In a cmd window, navigate to the directory with executable file (../Robot/bin/Release) and type in the following.

>Robot commands.txt - If the commands text file is in the same directory as .exe

>Robot "C:\Users\[user]\Documents\commands.txt" - If commands file is in any other location, please provide complete path to it


**How to run tests cases**

Open solution in visual studio, build it in debug mode and navigate to Test tab on top and click "Run All Tests"
