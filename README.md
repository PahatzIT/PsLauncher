# PsLauncher

A lightweight Windows launcher for running PowerShell scripts silently with argument forwarding and exit code passthrough.

PsLauncher is designed for automation, software deployment, scheduled tasks, and other scenarios where a PowerShell script should run without displaying a console window.

## Features

* Runs PowerShell scripts without a visible console window
* Uses Windows PowerShell (`powershell.exe`)
* Runs PowerShell with `-NoProfile`
* Runs PowerShell with `-ExecutionPolicy Bypass`
* Forwards arguments to the PowerShell script
* Waits for the PowerShell process to finish
* Returns the PowerShell exit code to the calling process
* Lightweight and easy to deploy
* No installation required

## Usage

Run a PowerShell script:

```cmd
PsLauncher.exe "C:\Scripts\Install.ps1"
```

Pass additional arguments to the script:

```cmd
PsLauncher.exe "C:\Scripts\Install.ps1" -Silent -Company "Example"
```

PsLauncher launches the script using Windows PowerShell in the background without displaying a PowerShell console window.

The equivalent PowerShell command is:

```cmd
powershell.exe -NoProfile -ExecutionPolicy Bypass -WindowStyle Hidden -File "C:\Scripts\Install.ps1" -Silent -Company "Example"
```

## Exit Codes

PsLauncher waits for the launched PowerShell process to finish and returns the same exit code to the calling process.

For example, if the PowerShell script exits with:

```powershell
exit 3010
```

PsLauncher will also exit with code:

```text
3010
```

This makes PsLauncher suitable for environments where the calling application needs to determine whether the PowerShell script completed successfully.

Typical use cases include:

* Scheduled Tasks
* RMM systems
* Endpoint management platforms
* Software deployment
* Installation and update scripts
* Automated administrative tasks

## Build

### Requirements

* Windows
* .NET 8 SDK or later

### Build

```cmd
dotnet build -c Release
```

### Publish

To create a self-contained Windows x64 executable:

```cmd
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

The published executable can be found in the project's `bin\Release` publish directory.

## Security Notice

PsLauncher intentionally launches PowerShell without displaying a console window and uses `ExecutionPolicy Bypass` for the launched PowerShell process.

Because hidden PowerShell execution is also a technique used by malicious software, some antivirus or EDR products may flag PsLauncher based on heuristic or behavioral detection.

Review the source code before deploying PsLauncher and only create security-product exclusions or allowlisting rules after verifying the executable and assessing the security implications for your environment.

`ExecutionPolicy Bypass` applies only to the PowerShell process launched by PsLauncher. It does not permanently change the Windows PowerShell execution policy of the system.

## Compatibility

PsLauncher currently uses Windows PowerShell:

```text
powershell.exe
```

PowerShell 7 (`pwsh.exe`) is currently not used.

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

## Author

Developed by PahatzIT.
