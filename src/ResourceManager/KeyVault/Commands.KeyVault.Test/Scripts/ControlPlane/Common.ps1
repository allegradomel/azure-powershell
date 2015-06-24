﻿# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Gets the location for the Website. Default to West US if none found.
#>
function Get-Location
{
    $location = Get-AzureLocation | where {$_.Name -eq "Microsoft.KeyVault/vaults"}
	if ($location -eq $null) 
	{
		return "East US"
	} 
	else 
	{
        $location.Locations[0]
	}
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($provider)
{
    $location = Get-AzureLocation | where {$_.Name -eq $provider}
    if ($location -eq $null) {
        "East US"
    } else {
        $location.Locations[0]
    }
}
