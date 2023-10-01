/*
 * Configuration.cs
 *
 *   Created: 2023-04-19-05:29:47
 *   Modified: 2023-04-19-05:29:47
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.PowerShell.Enums;

[GenerateEnumerationRecordStruct("Configuration", "Dgmjr.PowerShell")]
public enum Configuration
{
    [Display(Name = "Local", ShortName = "l", Description = "Building for local development")]
    Local,

    [Display(
        Name = "Debug",
        ShortName = "d",
        Description = "Building for debugging, i.e., with debug symbols and no optimizations"
    )]
    Debug,

    [Display(
        Name = "Staging",
        ShortName = "s",
        Description = "Building for staging, i.e., with optimizations and no debug symbols"
    )]
    Staging,

    [Display(
        Name = "Testing",
        ShortName = "t",
        Description = "Building for testing, i.e., with optimizations and no debug symbols"
    )]
    Testing,

    [Display(
        Name = "Production",
        ShortName = "p",
        Description = "Building for the production environment, i.e., with optimizations and no debug symbols"
    )]
    Production,

    [Display(
        Name = "Release",
        ShortName = "r",
        Description = "Building for release, i.e., with optimizations and no debug symbols (same as Production)"
    )]
    Release
}
