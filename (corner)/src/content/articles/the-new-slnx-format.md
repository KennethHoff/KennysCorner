---
title: "Solution files are now (slightly) more bearable"
description: "Solution files have always been an annoying pain-point for .Net developers.
We will go through how the .Net team is trying to fix that"
author: "Kenneth Hoff"
created: "2025-04-05"
---

[Microsoft blog article](https://devblogs.microsoft.com/dotnet/introducing-slnx-support-dotnet-cli/)

## The old format

```sln
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "my-app", "my-app\my-app.csproj", "{845B7716-6F03-4D02-8E86-79F95485B5D7}"
EndProject
Global
        GlobalSection(SolutionConfigurationPlatforms) = preSolution
                Debug|Any CPU = Debug|Any CPU
                Debug|x64 = Debug|x64
                Debug|x86 = Debug|x86
                Release|Any CPU = Release|Any CPU
                Release|x64 = Release|x64
                Release|x86 = Release|x86
        EndGlobalSection
        GlobalSection(ProjectConfigurationPlatforms) = postSolution
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Debug|Any CPU.Build.0 = Debug|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Debug|x64.ActiveCfg = Debug|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Debug|x64.Build.0 = Debug|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Debug|x86.ActiveCfg = Debug|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Debug|x86.Build.0 = Debug|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Release|Any CPU.ActiveCfg = Release|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Release|Any CPU.Build.0 = Release|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Release|x64.ActiveCfg = Release|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Release|x64.Build.0 = Release|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Release|x86.ActiveCfg = Release|Any CPU
                {845B7716-6F03-4D02-8E86-79F95485B5D7}.Release|x86.Build.0 = Release|Any CPU
        EndGlobalSection
        GlobalSection(SolutionProperties) = preSolution
                HideSolutionNode = FALSE
        EndGlobalSection
EndGlobal
```

## The new format

```slnx
<Solution>
  <Configurations>
    <Platform Name="Any CPU" />
    <Platform Name="x64" />
    <Platform Name="x86" />
  </Configurations>
  <Project Path="my-app/my-app.csproj" />
</Solution>
```
