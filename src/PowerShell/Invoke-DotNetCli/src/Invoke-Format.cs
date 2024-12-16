using System;
/*
 * Invoke-Pack copy.cs
 *
 *   Created: 2023-04-19-06:04:27
 *   Modified: 2023-04-19-06:04:30
 *
 *   Author: David G. Moore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 - 2023 David G. Moore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Diagnostics;
using System.Management.Automation;

namespace Dgmjr.PowerShell;

/// <summary>
///  Formats code to match editorconfig settings.
/// </summary>
/// <usage>
/// Usage = "Invoke-Format [-ProjectPath] <String> [arguments]"
/// </usage>
[Cmdlet("Invoke", "Format", DefaultParameterSetName = "WithoutCommand")]
[Alias(new[] { "format" })]
public class InvokeFormat : InvokeDotnet
{
    [Parameter(
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        Mandatory = true,
        Position = 0,
        HelpMessage = "The path to the project file to build. Defaults to the first .*proj file in the current directory."
    )]
    [ValidatePattern(
        "^(?:(?:.*\\.*proj)|(?:.*\\.*props)|(?:.*\\.*targets)|(?:.*\\.*usings)|(?:.*\\.*tasks)|(?:.*\\.*items))$"
    )]
    [Alias(new[] { "proj", "project", "path", "projpath" })]
    public override string? ProjectPath { get; set; } = "./*.*proj";

    public override DotnetCommand Command
    {
        get => DotnetCommand.format.Instance;
        set;
    }

    [Parameter(
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        Mandatory = false,
        HelpMessage = "A space separated list of diagnostic ids to use as a filter when fixing code style or 3rd party issues.",
        ParameterSetName = "Format"
    )]
    public string[] Diagnostics { get; set; }

    [Parameter(
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        Mandatory = false,
        HelpMessage = "A space separated list of diagnostic ids to ignore when fixing code style or 3rd party issues.",
        ParameterSetName = "Format"
    )]
    public string[] ExcludeDiagnostics { get; set; }

    [Parameter(
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        Mandatory = false,
        HelpMessage = " Verify no formatting changes would be performed. Terminates with a non-zero exit code if any files would have been formatted.",
        ParameterSetName = "Format"
    )]
    public SwitchParameter VerifyNoChanges { get; set; } = false;

    [Parameter(
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        Mandatory = false,
        HelpMessage = "A list of relative file or folder paths to include in formatting. All files are formatted if empty.",
        ParameterSetName = "Format"
    )]
    public string[] Include { get; set; } = Array.Empty<string>();

    [Parameter(
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        Mandatory = false,
        HelpMessage = "A list of relative file or folder paths to exclude from formatting.",
        ParameterSetName = "Format"
    )]
    public string[] Exclude { get; set; } = Array.Empty<string>();

    [Parameter(
        ValueFromPipeline = true,
        ValueFromPipelineByPropertyName = true,
        Mandatory = false,
        HelpMessage = "Msbuild verbosity: q[uiet], m[inimal], n[ormal], d[etailed], and diag[nostic].  Defaults to \"minimal.\"",
        ParameterSetName = "Format"
    )]
    public override Verbosity Verbosity
    {
        get => base.Verbosity;
        set => base.Verbosity = value;
    }

    [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
    [Parameter(
        Mandatory = false,
        HelpMessage = "Log all project or solution load information to a binary log file.",
        ParameterSetName = "Format"
    )]
    [Alias(new[] { "bl", "binlog" })]
    public StringSwitch BinaryLogger { get; set; } = false;

    [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
    [Parameter(
        Mandatory = false,
        HelpMessage = "Accepts a file path which if provided will produce a json report in the given directory.",
        ParameterSetName = "Format"
    )]
    [Alias(new[] { "rpt" })]
    public string Report { get; set; } = string.Empty;

    [Parameter(ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
    [Parameter(
        Mandatory = false,
        HelpMessage = "Show version information",
        ParameterSetName = "Format"
    )]
    [Alias(new[] { "v" })]
    public SwitchParameter Version { get; set; } = false;
}