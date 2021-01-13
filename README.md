# Task Tracking Web Application
## Purpose of Application
-    With this application, it is aimed to follow up and sustain the tasks.
## Working  Logic of the Application
- One user in Admin role is defined in the system
-    The admin user is added to the system with seed data while the application is up
- Personnel register to the system with the role of Member
- The admin user allows the staff to follow up the work by assigning tasks
## Skills of the Application
### Admin
- Creating and editing the Priority List
- Creating / Editing / Deleting a Task
- Assigning the created tasks to the personnel 
- Keeping track of completed tasks
- Viewing General statistics on the home page
- Keeping track of "Most Completing Personnel" and "Most Visible Assigned Personnel" with graphics
- Informing the personnel about the actions taken and the tasks completed
- Exporting the actions taken by the personnel in Excel and Pdf format.
- Profile Editing
### Member
- Listing the tasks assigned self
- Taking action regarding the assigned task
- Follow-up of completed tasks
- Informing about the assigned tasks.
- Profile Editing
## Setting Up The Application
- The application is set to run in LocalDB on Sql Server by default.
- In order to change this setting, you can change the configuration via ToDoList.DataAccess / EntityFrameworkCore / Contexts / TodoContexts path, and you can set it up on any server.
- While on the DataAccess project, you can activate the database by running the 
```update-database```
 command with the help of PM Console.
-    You can change the information of the Admin user in the IdentityInitializer class in the ToDoList.WebUI project.
- After making the relevant configurations, you can run the project.
## Technology and Tools
- Net Core 3.1 
- Sql Server
- EntityFramework Core
- Code First Approach
- N-Tier Architecture
- Nlog
