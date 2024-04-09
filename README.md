# DOTNET_Task-1
COPY AND PASTE THE BELOW LINK TO GET MORE PROJECTS AND MORE THINGS😊
{github.com/keshri29}
    if(moduleName == "Person")
              {
                query += $" where ([{schema}].[{moduleName}].[Full_Name] <> 'System Generated' ) and [{schema}].[{moduleName}].[Record_State] in ('{recordState.Replace(",", "', '")}')";
              }
            else
            {
                query += $" where [{schema}].[{moduleName}].[Record_State] in ('{recordState.Replace(",", "', '")}')";
            }

Create 3 table in DotNet using swaggerAPI
1.School
  -id
  -Name
  -No. of Class

2.Class
 -Id
 -name
 -No. of Students
 -School(Fk of school)

3.Student
 -Id
 -Name
 -Class(fk of class)
 -Age
 -Roll No.

:-Perform CRUD Operation 
:-Make 2 seprate API of {1.GetAllStu by class Id}, {2.GetAllClass by school Id}
:-Make Validation on class that the NO. of Students in a class is 50 Maximum  
