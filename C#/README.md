# Toll Calculator
Simple continuation of the AFRY toll calculator app described at https://github.com/afry-recruitment/toll-calculator . The solution contains four projects:

- `TollCalculator.App` which holds the main application.
- `TollCalculator.Domain` which contains domain-specific models and constants.
- `TollCalculator.Services` which contains application services. 
- `TollCalculator.Tests` which contains all unit tests. 

# Instructions

In the solution folder: 
- Run the program with `dotnet run --project .\TollCalculator\` too see the instructions.
    - Example: `dotnet run --project .\TollCalculator.App\ --vehicle car --dates "2024-10-21 06:50:30,2024-10-21 07:50:30,2024-10-21 17:50:30"`  

- Run the tests with `dotnet test` .

# Third party licenses

_(PublicHoliday is MIT, see https://github.com/martinjw/Holiday)_

#### PublicHoliday

Copyright (C) 2013 Martin Willey

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


#### XUnit

Unless otherwise noted, the source code here is covered by the following license:

	Copyright (c) .NET Foundation and Contributors
	All Rights Reserved

	Licensed under the Apache License, Version 2.0 (the "License");
	you may not use this file except in compliance with the License.
	You may obtain a copy of the License at

		http://www.apache.org/licenses/LICENSE-2.0

	Unless required by applicable law or agreed to in writing, software
	distributed under the License is distributed on an "AS IS" BASIS,
	WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	See the License for the specific language governing permissions and
	limitations under the License.

The source in src/xunit.v3.runner.common/Utility/ConsoleHelper.cs was adapted from code
that is covered the following license (copied from
https://github.com/Microsoft/msbuild/blob/ab090d1255caa87e742cbdbc6d7fe904ecebd975/LICENSE):

	MSBuild

	The MIT License (MIT)

	Copyright (c) .NET Foundation and contributors

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in all
	copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
	SOFTWARE.
	