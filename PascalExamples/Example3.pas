<%
	
	type matrix = ARRAY [1 .. 5, 1 ..15] OF Integer;
	matrix[1][2] := 12;
	
	type persona = record 
		firstname : string;
		arr : array [1 .. 5,1 .. 15] of integer;
		month : (jan, feb, mar, apr, oct);
		hijo : record
			juguete : string;
		end;
	end;
	
	var per : persona;
	matrix := per.arr;
	
	function max(var num1, num2: integer; num : integer) : integer;
	begin
	end;
	
	procedure max2(var num1, num2: integer; num : integer);
	begin
		var place: integer = 12; 
		case place of
			1,4,5: var g : integer;
			8: var g2 : integer;
			9: var g3 : integer;
			else var g4 : integer;
	   end;
	end;
	
	var mynum : integer;
	var t, h : integer;
	max2(t,h,4);
	mynum := max(t,h,4);
	//str := per.firstname;

%>
	<html>Text HTML</html>
<%
	var gg : string;
	println (3+4);
	const pi : real = 3.1465;
	
	const rightAngle = 90+23;
	type perrito = Integer;
	var x,y,z : perrito; 
	var m : Integer = 12; 
	z := 23;
	type days = (lunes, martes, miercoles, jueves, viernes, sabado, domingo);
	type dias = (mon, tue, wed, thu, fri, sat, sun);
	
	var str : string;
	
	while true do 
	begin 
		
	end;
	
	if true and false then  
		repeat 
			var var1 : string = 'soy una variable';
		until true; 
	else  
		for x:= 1 to 10 do 
			var ggt: integer;
		
	if not ((12 > 54.98) and true) then 
	begin
		var t2 : integer;
	end;
		
	if true then 
		var str5 : string;

	per.firstname := 'Juan';
%>