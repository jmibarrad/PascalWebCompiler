Feature: Syntax
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Declare a native type variable
	Given the following source code '<%var x : Integer;%>'
	When We Parse
	Then the result should pass

Scenario: Declaring a native type variable with initial value
	Given the following source code '<%type myArray = array [a..b] of integer;%>'
	When We Parse
	Then the result should pass

Scenario: Declare a list of variables without initializing
	GivenI have the following source code '<%var x, y, z : Integer;%>'
	When We Parse
	Then the result should pass 

Scenario: Calling a function
	Given the following source code '<%Add(Sum, Sum, Sum);%>'
	When We Parse
	Then the result should pass

Scenario:Declare an enumerated type
	Given the following source code '<%type weekend = (Friday, Saturday, Sunday);%>'
	When We Parse
	Then the result should pass

Scenario:Declare an enumerated type with Error
	Given the following source code '<%type weekend = (Friday, Saturday, Sunday;%>'
	When We Parse
	Then the result should fail

Scenario:Declare a record
	Given the following source code 'type rec = record begin x:integer end;%>'
	When We Parse
	Then the result should pass

Scenario:Declare a bidemensional array 
	Given the following source code '<%type array = array [1..3] of array [1..5] of integer;%>'
	When We Parse
	Then the result should pass

Scenario:Declare a bidemensional array #2
	Given the following source code '<%type array = array [1..3,1..5] of integer;%>'
	When We Parse
	Then the result should pass

Scenario:Declare a case
	Given the following source code '<%case c of 1..4 : s := 'lowercase letter (a-z)'; 1+100..4+100 : s := 'lowercase letter (a-z)'; a.. b : s := 'lowercase letter (a-z)';	400: s := '400 case'; end; %>'
	When We Parse
	Then the result should pass

Scenario: A while sentence
	Given the following source code '<%while a < 6 do begin writeln (a); a := a + 1 end;%>'
	When We Parse
	Then the result should pass

Scenario: A function declaration
	Given the following source code '<%function CircleArea(var radius, r1, r2: Integer): Integer; var area: Integer; begin end;%>'
	When We Parse
	Then the result should pass

Scenario: A for sentence
	Given the following source code '<%for count := 1 to 100 do begin sum := sum + count; if sum = 38 then break; end;%>'
	When We Parse
	Then the result should pass

Scenario: A procedure declaration
	Given the following source code '<%procedure swap(var c1,c2:char); var c:char; begin c:=c1; c1:=c2; c2:=c; end;%>'
	When We Parse
	Then the result should pass