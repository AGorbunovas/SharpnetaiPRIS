# SharpnetaiPRIS

----------  C# kodo standartai ----------

Namespaces:  (ĮmonėsPavadinimas.ProduktoPavadinimas.Ypatybė)
             AkademijaIT.PRIS.WEB 
             AkademijaIT.PRIS.Tests
             AkademijaIT.PRIS. ...

PascalCasing use for: class, methods, types and constants;

camelCasing use for: local variables and method arguments;

class: (PascalCasing)
       User
       City
       Course
       CalculateStatistics
       
Methods: (PascalCasing)
         public void GetUser()
         ShowCourse()
         
Method arguments: (camelCasing)
         public void GetUser(string userName)
         ShowCourse(string courseTitle)
         
Methods with return values: (PascalCasing,  The name should reflect the return value)
                            public string GetUserName(string userName)
         
Variables: (camelCase)
           string password
           int score
           
Private member variables: (camelCase use 'm_' prefix)
                          private string m_fileName
                          
Interfaces: (PascalCasing) use 'I' prefix
            ICourse
            
Custom exceptions: (PascalCasing) Suffix all custom exception names with Exception
                   public class UserNotExistentException :
                                System.ApplicationException
                                
Delegates: (PascalCasing) Suffix all event handlers with Handler; suffix everything else with Delegate
           public delegate void ImageChangedHandler();
           public delegate string StringMethodDelegate();
           
----------  C# kodo standartai ----------
----------------  Pabaiga ----------------
