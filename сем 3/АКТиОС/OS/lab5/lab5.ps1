Get-ComputerInfo  -Property *mem* | fl @{Label="FreePhysicalMemory";  Expression={$_.osFreePhysicalMemory/1mb}} | Out-File -FilePath .\FreeMem.txt
Get-CimInstance -Class Win32_NetworkAdapterConfiguration -Filter IPEnabled=$true |
    Select-Object -ExpandProperty IPAddress | Out-File -FilePath .\FreePath.txt