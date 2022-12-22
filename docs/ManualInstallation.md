---
permalink: /ManualInstallation.html
title: Manual Installation
description: the flat-pack Kiea instructions, written in Kerbalese, unusally present
tags: installation,directions,page,kerbal,ksp,zer0Kerbal,zedK
---
<!-- ManualInstallation.md v1.1.8.1
Kerbal XMAS (XMAS)
created: 01 Oct 2019
updated: 29 Jul 2022 -->

<!-- based upon work by Lisias -->

# Kerbal XMAS (XMAS)

[Home](./index.md)

> A few weeks ago, a pink-skinned alien "landed" on Kerbin.
>
> After gathering up all the debris, our scientists decided to reverse engineer these strange but obviously useful parts.
>
> The alien's corpse was identified as Santa K. We're assuming his last name was Kerman.

## Installation Instructions

### Using CurseForge/OverWolf app or CKAN

You should be all good! (check for latest version on CurseForge)

### If Downloaded from CurseForge/OverWolf manual download

To install, place the `LunaticAeronautics` folder inside your Kerbal Space Program's GameData folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**
  * Delete `<KSP_ROOT>/GameData/LunaticAeronautics/KerbalXMAS`
* Extract the package's `LunaticAeronautics` folder into your KSP's GameData folder as follows:
  * `<PACKAGE>/LunaticAeronautics` --> `<KSP_ROOT>/GameData`
    * Overwrite any preexisting folder/file(s).
  * you should end up with `<KSP_ROOT>/GameData/LunaticAeronautics/KerbalXMAS`

### If Downloaded from SpaceDock / GitHub / other

To install, place the `GameData` folder inside your Kerbal Space Program folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**
  * Delete `<KSP_ROOT>/GameData/LunaticAeronautics/KerbalXMAS`
* Extract the package's `GameData` folder into your KSP's root folder as follows:
  * `<PACKAGE>/GameData` --> `<KSP_ROOT>`
    * Overwrite any preexisting file.
  * you should end up with `<KSP_ROOT>/LunaticAeronautics/GameData/KerbalXMAS`

## The following file layout must be present after installation

```markdown
<KSP_ROOT>
  + [GameData]
    + [LunaticAeronautics]
      + [LunaticAeronauticsLtd]
        ...
      + [KerbalXMAS]
        + [Assets]
          ...
        + [Compatibility]
          ...
        + [Config]
          ...
        + [Localization]
          ...
        + [Parts]
          ...
        + [Plugins]
          ...
        * #.#.#.#.htm
        * Attributions.htm
        * changelog.md
        * GPL-2.0.txt
        * ManualInstallation.htm
        * readme.htm
        * KerbalXMAS.version
    ...
    * ModuleManager.ConfigCache
  * KSP.log
  ...
```

### Dependencies

* [Lunatic Aeronautics Ltd (LA/L)][LAL]

[LAL]: https://forum.kerbalspaceprogram.com/index.php?/topic/191424-*/ "Lunatic Aeronautics Ltd (LAL)"
