README - Automation Testing by Rupa Mandal
==========================================

This document outlines the automated testing tasks completed by Rupa Mandal, covering three key areas: SQS automation, JSON processing, and calculator unit testing, along with code review feedback.

Frameworks Used:
- Newtonsoft.Json
- NUnit
- NUnit3TestAdapter

Tools Used:
- Language: C#

How to Test:
- Go to Menu - Test
- Click Test Explorer 
- Run-all 

---------------------------------------------------------
1. SQS Automation Testing
---------------------------------------------------------
Encountered setup challenges that prevented completing SQS Testing.
Additional time would required to resolve/troubleshoot issues and finalize the implementation. Below are few issues
- Docker & LocalStack Installation Issues - It was not running/setup properly
- AWS Credentials - Alternatevely did not had the credential for this one
- LocalStack Connectivity or Port Conflicts

---------------------------------------------------------
2. JSON Automation Testing
---------------------------------------------------------
Description:
- A file named `Cost Analysis.json` contains an array of cost objects.
- A custom class `JSONTest.cs` was coaded to deserialize individual JSON objects.
- Implemented unit tests to verify content and logic incluing positive, Negative and edge case scenarios.

Steps Implemented:
- Used `Newtonsoft.Json` for deserialization.
- Deserialized the JSON into a list of defined objects.
- Used LINQ to:
  • Assert the number of items in the list.
  • Retrieve the item with the highest cost and assert its CountryId.
  • Calculate and assert the total cost for the year 2016.

---------------------------------------------------------
3. Calculator Automation Testing
---------------------------------------------------------
Description:
- A `Calculator` class was available/implemented with basic arithmetic methods:
  • Add
  • Subtract
  • Multiply
  • Divide
  • Square
  • Squareroot

- Unit tests were written using [e.g., NUnit for C#] to validate:
  • Correct results for positive, negative, and zero values.
  • Proper handling of edge cases (e.g., division by zero).

---------------------------------------------------------
4. Code Review - TestAutomation.cs
---------------------------------------------------------
Few points mentioned below are initial observations. Additional issues may surface upon executing and validating the code using the xUnit framework. Currently, my test environment is configured with NUnit, 
so I was unable to fully validate the xUnit-specific behavior. However, I can perform a complete validation if needed—please allow some additional time to set up the appropriate framework

1. Line 112 has empty curly braces – The BatchMessages test doesn’t check or confirm anything. Every unit test should include checks (called assertions) to make sure the code works as expected.
2. LoraxSQS is used as both a class-level variable and a local variable in some tests – This can be confusing and might cause mistakes, especially in bigger projects. It's better to use one consistently to avoid errors.

---------------------------------------------------------
5. Hosting Information
---------------------------------------------------------
The completed solution is hosted at:
https://github.com/rupa251989/InterviewTestQA

---------------------------------------------------------
Prepared by:
Rupa Mandal
