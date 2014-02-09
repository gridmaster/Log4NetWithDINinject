Log4NetWithDINinject
====================

Basic Log4Net example using Ninject for DI. 

I wanted a base starting point with DI and Log4Net installed and wired up with an IoCContainer. This is it.

There are 4 projects in all:

Core: only has ILogger in it because this interface needs to be accessable to several projects that would 
cause circular redundancy otherwise.

DIContainer: only has the IOCContainer in it.

Services: which contains 2 fake servies as examples.

LogWriter4: which is currently a console application. Next itteration and I will separate out the logging. 
Set this as the startup project and run it. 
