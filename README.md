<h1>
Using DebugScript in Microsoft Visual Studio
</h1>

- [Roundup](#roundup)
- [Getting Started](#getting-started)
- [Requirements](#requirements)
- [Adjustments](#adjustments)
  - [1. Change several namings](#1-change-several-namings)
  - [2. Source Code Adjustments](#2-source-code-adjustments)
    - [2.1 TestDebugScript.csproj](#21-testdebugscriptcsproj)
    - [2.2 AssemblyInfo.cs](#22-assemblyinfocs)
- [LEEGOO BUILDER integration](#leegoo-builder-integration)
- [Sample script to call our assembly](#sample-script-to-call-our-assembly)

## Roundup
This is a demonstration of how to run LEEGOO BUILDER from Visual Studio to use it's debugger and to have the ability to set breakpoints to simplify script development.


## Getting Started
This Project can be found on GitHub.

url: https://github.com/eas-solutions/TestDebugScript

It is recommended to create a fork of this repository and store it in your own private repository on GitHub.


## Requirements
The following requirements must be met.
- A working installation of an up to date version of LEEGOO BUILDER G3
- MS Visual Studio 2022 or another development environment
- (optional) a personal GitHub account 


## Adjustments
There are several things to be adjusted to make this project working on a developers machine.


### 1. Change several namings
Change the following file names according to your requirements:

- TestDebugScript.csproj
- TestDataExport.cs

Do not forget to update the namespaces.


### 2. Source Code Adjustments

#### 2.1 TestDebugScript.csproj
Open PlugIn.csproj and change the following nodes according to your requirements:
- \<TargetFramework>
- \<UseWpf>
- \<OutputPath>
- \<AssemblyName>
- \<RootNamespace>

OutputPath should point to your binaries folder (where EAS.LeegooBuilder.Client.GUI.Shell.exe is located).
<br><br> 


#### 2.2 AssemblyInfo.cs
Open AssemblyInfo.cs and update all relevant attributes.
```c#
[assembly: AssemblyTitle("TestDebugScript")]
[assembly: AssemblyDescription("Exsample of using DebugScript for LEEGOO BUILDER G3")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("EAS")]
[assembly: AssemblyProduct("TestDebugScript")]
[assembly: AssemblyCopyright("Copyright ©  2022")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
...
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
```
<br>


Try to compile the project. No errors should occur.


## LEEGOO BUILDER integration
LEEGOO BUILDER needs to be configured to load this assembly.<br>
Go to the binaries folder (see above) and open `script.config`.<br>
Add the following nodes.
```xml
<?xml version="1.0" encoding="utf-8"?>
<ScriptConfiguration>
  <ExternalAssemblies>
    <ExternalAssembly Description="TestExport using DebugScript" AssemblyName="EAS.LeegooBuilder.Server.DebugScript.TestExport.dll" />
  </ExternalAssemblies>
  <AdditionalUsings>
    <AdditionalUsing Description="TestExport using DebugScript" Name="EAS.LeegooBuilder.Server.DebugScript.TestExport" />
  </AdditionalUsings>
</ScriptConfiguration>
```


## Sample script to call our assembly
Go to the script editor, create a new script and replace the source code with the following source code:
```c#
public override object Main(CustomScriptArgs args)
{
    var scriptDebugAssembly = new TestExportData(ScriptContext, "Alfred E. Neumann");
    scriptDebugAssembly.HelloWorld();
    WriteLine(scriptDebugAssembly.GetYourName());
	
    return null;
}
```
Set a breakpoint e.g. at TestExportData.HelloWorld() and start the script. 
Visual Studio should stop at the breakpoint.

Take a look at the displayed messagebox and the output window underneath the source code.
