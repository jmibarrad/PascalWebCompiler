<%
type vector = array [ 1 ..25, 2 ..3] of integer;
type vector3 = array [ 1 ..25] of vector;
type vector4 = array [ 2 .. 3] of integer;
var int90 : integer = vector3[9][7][8];
var velocity: vector;
vector[2] := vector4;
var velocity3: vector3;
velocity := velocity3[1];
var vel : integer;
for vel in velocity3 do
  vel := 23;
type
  TPerson = record
    (* CONSTANT PART *)
    test: integer;
    (* of course records may be nested *)
    name: record
      first: string;
	  middle: string;
	  last: string;
      name2: record
        first: string;
		middle: string;
		last: string;
        name3: record
          first: string;
		  middle: string;
		  last: string;
          vector3: array [ 1 .. 25] of integer;
        end;
      end;
    end;
    gender: (male, female);
  end;
var prueba : TPerson;
prueba.test := velocity3[0][0][0];
prueba.name.name2.name3.vector3[3] := 3;
prueba.gender := female;
prueba.name.first := 'hola';
procedure findMin(x, y, z: integer; var m: integer); 
begin
   if(x < y ) then
      m := x;
   else
      m := y;
   if (z <m) then
      m := z;
end;
type entero = integer;
var x : entero = velocity[0][0];
function max(num1, num2: integer): integer;
begin
  var result: integer;
   if (num1 > num2) then
   begin
      result := num1 + x;
      if (num1 > num2) then
      begin
        result := num1 + x;
        max := result;
      end;
      else
      begin
        result := num2;
        max := result;
      end;
   end;
   else
   begin
      result := num2;
      max := result;
   end;
end;

var y : integer = 5;
var z : integer;
z := x + y;
  if(x < y) then
  begin
    var variableIf : integer = 9;
    z := 6 + variableIf;
  end;
  else
    z := max(x, y);

var a : integer;
for a := 10  to 20 do
begin
  var afor : integer;
  z := z + a + afor;
  while a < 6 do
  begin
    var awhile : integer;
    z := a + awhile;
    a := afor + 1;
  end;
end;
findMin(x, y, z,a);

type MonthType = (January, February, March, April,
              May, June, July, August, September,
              October, November, December);

var Month : MonthType;
Month := May;
var p : BOOLEAN = 3 > (5);

var Contador : Integer;
Contador := 1; 
   repeat
      Contador := Contador + 1;  
   until Contador > 10;          

var testing: boolean;
testing := false or true;

var grade: integer;
   grade := 1;

   case grade of
      2 : grade:= 5 ;
      3,4: grade:= 7;
      5 : grade:= 9;
      90 .. 99 : grade:= 12;
   end; 
 %>