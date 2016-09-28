import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;


public class servlet extends HttpServlet {
 
enum _days { 
_fri,_thu,_wed,_tue,_mon,_sat,_sun
}
class _name{
String _last;String _first;public _name(){ 
}
public _name(_name originalCopy){
this._last = originalCopy._last;
this._first = originalCopy._first;
 }
}
class _person{
_name _name = new _name();
int _age;public _person(){ 
}
public _person(_person originalCopy){
this._name = originalCopy._name;
this._age = originalCopy._age;
 }
}

    
    public int _max (int _i,int _j,int _k,String _z){
return 3;
}


    public void init() throws ServletException
    {
      
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        String method = "post";
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<!DOCTYPEhtml><html><head><style>table,th,td{border:1pxsolidblack;border-collapse:collapse;}th,td{padding:5px;}</style></head><body>");
String _stringo = request.getParameter("pringo");
out.println(_stringo);

int[][] _arr3 = new int[34][2];

int[][][] _arr2 = new int[78][34][2];

int _num,_num1;
String _str,_str1;
char _ch;
double _pi = 12.45;
_arr3[12 - 12][100 - 100] = 67;
String _str2 =  "Soy cadena";
int _division = 12 / 4;
double _realdivision = 12.34 / 67;
if ( 12 > 34 ) { 
} else {
}
_days _en;
_en = _days._sun;
_days _en1 = _days._sat;

_person[] _arrperson = new _person[4];

_person _person1 = new _person();
_person1._age = 99;
_person1._name._first =  "Eve";
_person1._name._last =  "Jackson";
_person _person2 = new _person();
_person2._age = 23;
_person2._name._first =  "John";
_person2._name._last =  "Doe";
_person _person3 = new _person();
_person3._age = 344;
_person3._name._first =  "Adam";
_person3._name._last =  "Johnson";
_person _person4 = new _person();
_person4._age = 1;
_person4._name._first =  "Jill";
_person4._name._last =  "Smith";
_arrperson[0 - 0] = _person1;
_arrperson[1 - 0] = _person2;
_arrperson[2 - 0] = _person3;
_arrperson[3 - 0] = _person4;
int _cont;
_person _per = new _person();
int _n = 4;
int _i;
int _j = 0;
do{
for (_i = 1; _i < _n - _j; _i++){
if ( _arrperson[_i - 1 - 0]._age < _arrperson[_i - 0]._age ) { 
_person _temp = _arrperson[_i - 1 - 0];_arrperson[_i - 1 - 0] = _arrperson[_i - 0];_arrperson[_i - 0] = _temp;} else {
}
}

_j = _j + 1;
}while(_j < _n);

out.println("<table><tbody><tr><th>Age</th><th>FirstName</th><th>LastName</th></tr>");
for(_person _personinfo : _arrperson){
out.println( "<tr>");
out.println( "<td>" + _personinfo._age +  "</td>");
out.println( "<td>" + _personinfo._name._first +  "</td>");
out.println( "<td>" + _personinfo._name._last +  "</td>");
out.println( "</tr>");
}
out.println("</tbody></table>");
for (_cont = 0; _cont < 34; _cont++){
int _myint = _per._age;
}

out.println("<h1>Holavosrrr</h1>");

int _vi = _max(2,3,4, "hey");
out.println(_vi);
out.println(_max(2,3,4, "hey"));
int _place = 12;
switch (_place ){
case 1:
case 5:
case 4:
int _g;
break;case 11:
case 12:
case 13:
case 14:
case 15:
case 16:
case 17:
int _g2;
break;case 9:
case 10:
int _g3;
break;default: int _g4;
break;}

out.println("</body></html>");

    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        String method = "get";
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<!DOCTYPEhtml><html><head><style>table,th,td{border:1pxsolidblack;border-collapse:collapse;}th,td{padding:5px;}</style></head><body>");
String _stringo = request.getParameter("pringo");
out.println(_stringo);

int[][] _arr3 = new int[34][2];

int[][][] _arr2 = new int[78][34][2];

int _num,_num1;
String _str,_str1;
char _ch;
double _pi = 12.45;
_arr3[12 - 12][100 - 100] = 67;
String _str2 =  "Soy cadena";
int _division = 12 / 4;
double _realdivision = 12.34 / 67;
if ( 12 > 34 ) { 
} else {
}
_days _en;
_en = _days._sun;
_days _en1 = _days._sat;

_person[] _arrperson = new _person[4];

_person _person1 = new _person();
_person1._age = 99;
_person1._name._first =  "Eve";
_person1._name._last =  "Jackson";
_person _person2 = new _person();
_person2._age = 23;
_person2._name._first =  "John";
_person2._name._last =  "Doe";
_person _person3 = new _person();
_person3._age = 344;
_person3._name._first =  "Adam";
_person3._name._last =  "Johnson";
_person _person4 = new _person();
_person4._age = 1;
_person4._name._first =  "Jill";
_person4._name._last =  "Smith";
_arrperson[0 - 0] = _person1;
_arrperson[1 - 0] = _person2;
_arrperson[2 - 0] = _person3;
_arrperson[3 - 0] = _person4;
int _cont;
_person _per = new _person();
int _n = 4;
int _i;
int _j = 0;
do{
for (_i = 1; _i < _n - _j; _i++){
if ( _arrperson[_i - 1 - 0]._age < _arrperson[_i - 0]._age ) { 
_person _temp = _arrperson[_i - 1 - 0];_arrperson[_i - 1 - 0] = _arrperson[_i - 0];_arrperson[_i - 0] = _temp;} else {
}
}

_j = _j + 1;
}while(_j < _n);

out.println("<table><tbody><tr><th>Age</th><th>FirstName</th><th>LastName</th></tr>");
for(_person _personinfo : _arrperson){
out.println( "<tr>");
out.println( "<td>" + _personinfo._age +  "</td>");
out.println( "<td>" + _personinfo._name._first +  "</td>");
out.println( "<td>" + _personinfo._name._last +  "</td>");
out.println( "</tr>");
}
out.println("</tbody></table>");
for (_cont = 0; _cont < 34; _cont++){
int _myint = _per._age;
}

out.println("<h1>Holavosrrr</h1>");

int _vi = _max(2,3,4, "hey");
out.println(_vi);
out.println(_max(2,3,4, "hey"));
int _place = 12;
switch (_place ){
case 1:
case 5:
case 4:
int _g;
break;case 11:
case 12:
case 13:
case 14:
case 15:
case 16:
case 17:
int _g2;
break;case 9:
case 10:
int _g3;
break;default: int _g4;
break;}

out.println("</body></html>");

    }

    public void destroy()
    {
        // do nothing.
    }
}
