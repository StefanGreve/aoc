# Notes for AOC 2022

Grab the starter code from day 1 and copy the content to clipboard:

```powershell
Get-Content "2022/day1/day1-task1.ts" | clip
```

Every solution file should probably have a `readFile` and `main` method plus at
least one more function to perform the necessary calculations in order to complete
the challenge.

## Configure this Project for VS Code

Place these files in your `.vscode` directory in order to debug the script.
Update the `program` value as required to launch the appropriate solution file.

```json
{
    // launch.json
    "version": "0.2.0",
    "configurations": [
        {
            "type": "node",
            "request": "launch",
            "name": "Launch Program",
            "skipFiles": [
                "<node_internals>/**"
            ],
            "program": "${workspaceFolder}\\2022\\out\\day1\\day1-task1.js",
            "outFiles": [
                "${workspaceFolder}/**/*.js"
            ]
        }
    ]
}
```

```json
{
    // tasks.json
	"version": "2.0.0",
	"tasks": [
		{
			"type": "typescript",
			"tsconfig": "2022/tsconfig.json",
			"option": "watch",
			"problemMatcher": [
				"$tsc-watch"
			],
			"group": {
				"kind": "build",
				"isDefault": true
			},
			"label": "tsc: watch - 2022/tsconfig.json"
		}
	]
}

```
