/*
 * Severity.cs
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

[GenerateEnumerationRecordStruct("Severity", "Dgmjr.PowerShell")]
public enum Severity
{
    [Display(
        Name = "Error",
        ShortName = "e",
        Description = "Fix diagnostics categorized as errors"
    )]
    Error,

    [Display(
        Name = "Info",
        ShortName = "i",
        Description = "Fix diagnostics categorized as informational"
    )]
    Info,

    [Display(
        Name = "Warn",
        ShortName = "w",
        Description = "Fix diagnostics categorized as warnings"
    )]
    Warn,
}
