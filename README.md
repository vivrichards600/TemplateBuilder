VB.Net Template Builder
===============

Auto Generate an Accessible HTML5 VB.Net Web Form, it's VB Code, Unit Tests, Integration Tests (using Selenium Web Driver) and SQL Scripts for creating the table to hold the Web Forms data as well as stored procedures to do the insertions, select a customer and delete a customer etc based on a few simple user parameters.

Example Usage
------

To use this application the user would need to input the following in the web form:

ProjectName FormName Field:FieldType(OptionalSize)*

*User can input unlimited number of Field:FieldType's


```vb
CustomerRepository CreateNewCustomer FirstName:Varchar(200) LastName:Varchar(100) Age:Int
```
