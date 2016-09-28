@echo off
cd C:\xampp\tomcat\webapps\ROOT\WEB-INF\

cd C:\xampp\tomcat\webapps\ROOT\WEB-INF\classes
echo change to servlet directory.
javac -cp C:\xampp\tomcat\lib\servlet-api.jar C:\Users\IBARRA\Documents\Pascal\Servlet\servlet.java
xcopy /s C:\Users\IBARRA\Documents\Pascal\Servlet C:\xampp\tomcat\webapps\ROOT\WEB-INF\classes
echo Copy compiled servlet to Tomcat.
start chrome http://localhost:8080/servlet
echo No errors Found.
pause

 