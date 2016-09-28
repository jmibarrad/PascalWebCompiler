<!DOCTYPE html>
<html>
<head>
<style>
table, th, td {
    border: 1px solid black;
    border-collapse: collapse;
}
th, td {
    padding: 5px;
}
</style>
</head>
<body>
<%
	var stringo : string = getformdata('pringo');
	println(stringo);
	type days = (sun,sat, mon, tue,wed, thu, fri);
	type arr3= array [12 .. 45 , 100 .. 101] of integer;
	type arr2 = array [13 .. 90] of arr3;
	var num, num1 : integer;
	var str, str1 : string;
	var ch : char;
	var pi : real = 12.45;
	arr3[12][100] := 67;
	var str2 :string = 'Soy cadena';
	var division : integer = (12 div 4);
	var realdivision : real = (12.34 / 67);
	if 12 > 34 then
	begin
	end;			
	var en : days;
	en := sun;
	var en1 : days = sat;
	type Person = record
		age : integer;
		//vector3: array [ 1 .. 25] of integer;
		name : record 
			first : string;
			last : string;
		end;
	end;
	
	type arrPerson = array [0 .. 3] of Person;
	//procedure bubbleSort(var arr: arrperson); 
	 // begin
		 
	  //end;
	  
	var person1 : Person;
    person1.age := 99;
    person1.name.first := 'Eve';
    person1.name.last := 'Jackson';

    var person2 : Person;
    person2.age := 23;
    person2.name.first := 'John';
    person2.name.last := 'Doe';

    var person3 : Person;
    person3.age := 344;
    person3.name.first := 'Adam';
    person3.name.last := 'Johnson';

    var person4 : Person;
    person4.age := 1;
    person4.name.first := 'Jill';
    person4.name.last := 'Smith';

    arrPerson[0] := person1;
    arrPerson[1] := person2;
    arrPerson[2] := person3;
    arrPerson[3] := person4;
	
	var cont : integer;
	var per : person;
	var n : integer = 4;
		 var i : integer;
		 var j : integer = 0;
		 repeat 
		   for i := 1 to n - j do
		   begin
			 if arrPerson[i-1].age < arrPerson[i].age then
			  begin
			   var temp : Person = arrPerson[i-1];
			   arrPerson[i-1] := arrPerson[i];
			   arrPerson[i] := temp;
			  end;
		   end;
		   j := j + 1;
		 until j < n ;
	//bubbleSort(arrPerson);
	
%>
<table >
<tbody>
<tr>
  <th>Age</th>
  <th>First Name</th>
  <th>Last Name</th>    
</tr>
<%
  for personInfo in arrPerson do
  begin
    println('<tr>');
    println('<td>'+personInfo.age+'</td>');
    println('<td>'+personInfo.name.first+'</td>');
    println('<td>'+personInfo.name.last+'</td>');
    println('</tr>');
  end;
%>
</tbody></table>
<%	
	for cont := 0 to 34 do
	begin
		var myint :integer = per.age;
	end;
%>
	<h1> Holavosrrr </h1>
<%
	function max(var i,j,k: integer; z: string) : integer;
	begin
		exit 3;
	end;
	
	var vi : integer = max(2,3,4, 'hey');
	println(vi);
	println(max(2,3,4, 'hey'));
	
	var place: integer = 12; 
	case place of
		1,4,5: var g : integer;
		11 .. 17: var g2 : integer;
		9 .. 10: var g3 : integer;
		else var g4 : integer;
	end;
%>
</body>
</html>