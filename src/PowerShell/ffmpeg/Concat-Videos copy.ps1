function Invoke-Brew
{
    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [string]$Command
    )
    $brew = "brew"
    $brewCommand = "$brew $Command"
    $brewCommand | Invoke-Expression
brew comm}