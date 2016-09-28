Program Lesson1_Program3;
const 
	a = 5+1;
	b =10;
	c : real = 12;
type entero = integer;
	MonthType = (January, February, March, April,
              May, June, July, August, September,
              October, November, December);
	simple_integer_array = array [4..33, 34..99] of integer;
	simple_integer_array2 = array [4..33, 34..99] of entero;
		array1 = array [1..20] of integer;
		array2 = array [1..20] of entero;
		simple_integer_array3 = array [char] of 1..20;

	TPerson = record
	x2,y2,z2:integer;
	end;
	
	TPerson2 = record
	x,y,z:integer;
	end;
Var       
    Num1, Num2, Sum, Count: entero;
	num3: integer;
	arr : array1;
	arr2 : array2;
	tp : TPerson;
	tp2 : TPerson2;
function CircleArea(var radius, r1, r2: Integer): Integer;
var area: Integer;
begin
    
end;

function WhatIsChar( c: integer; x,z:integer):string;
 var
   s : string;
 begin
   s := '';
   case c of
		1..4 : s := 'lowercase letter (a-z)';
		$1111111..$11111111: s := 'lowercase letter (a-z)';
		a.. b : s := 'lowercase letter (a-z)';
		400+2, 400+3, 1000div 5: s := 'fuck';
		
   end;
   WhatIsChar := s;
 end;	
//sheu
(*hey**hey*)
begin {no semicolon}
	Num1 := 12;
	if Num1 > 45.67
	then
		Write('Hola');
	arr := arr2;
	//tp := tp2;
	Write('Input number 1:'); 
	Readln(Num1);
	Writeln('Input number 2:');
	Readln(Num2);
	Num2 := num3;
	Sum := Num1 div Num2; {addition} 
	Writeln(CircleArea(Sum, Sum, Sum));
	for Num1 := 2 to 100 do
	begin
	  sum := sum + count;
	  break;
	  continue;
	  break;
	  if sum = 38 then break;
	end;

	Readln;
end.
