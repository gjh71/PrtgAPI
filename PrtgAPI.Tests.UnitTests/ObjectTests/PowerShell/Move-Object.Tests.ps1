﻿. $PSScriptRoot\Support\Standalone.ps1

Describe "Move-Object" -Tag @("PowerShell", "UnitTest") {

    SetActionResponse

    It "can execute with a device" {
        $device = Run Device { Get-Device }

        $device | Move-Object 1234
    }

    It "can execute with a group" {
        $group = Run Group { Get-Group }

        $group | Move-Object 1234
    }

    It "executes with -WhatIf" {
        $device = Run Device { Get-Device }

        $device | Move-Object 1234 -WhatIf
    }

    It "passes through" {
        SetMultiTypeResponse

        $device = Get-Device -Count 1

        $newDevice = $device | Move-Object 5678 -PassThru

        $newDevice | Should Be $device
    }
}