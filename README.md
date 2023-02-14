# Databases In WPF - Vance Brender-A-Brandis #

## Description ##
- This assignment revolves around connecting a database made in Microsoft Access to a WPF application in VS2022 and displaying information from said database in the program. 
- To get data from the databases, we use SQL queries to interact with the database and loop through all data rows to populate certain text boxes with pertinent information.
- In this assignment, one database with two tables - Assets and Employees - is accessed and read from. For the tables, I decided to write in Tom Holland and Andrew Garfield as the employees (and gave them random employee ids) and assigned them random assets based on which Spiderman movie they came from. The only reason I mention this is to clear my own potential future confusion when I look back at this assignment to refresh my memory on database useage.

## Rough Procedure for Adding Data Sources ## 
1. Create a .NET WPF Application.
2. Select the "View" button from the top row in VS22 and hover over "Other Windows ->". In the new set of options that appears, select "Data Sources".
3. Within the newly-opened "Data Sources" window, click the first button along its top row (should have a green plus arrow in the top left of the icon) to add a new data source.
4. Choose "Database", then hit "Next >". Then, "Dataset", and "Next >" again.
5. You should now be in the "Choose Your Data Connection" window. Select "New Connection..." towards the right of the first dropdown box and select Microsoft Access Database File (if using that, of course).
6. Make sure the "Data provider:" dropdown is set to ".NET Framework Data Provider for OLE DB". Hit the "Continue" button.
7. Browse for your database file name and select it. Ignore the "Log on to the database" option.
8. Hit the "Test Connection" button. It should return a success message. If not, scream, because I don't know what you should do at that point. Try again, maybe?
9. Hit "Okay". You should now be back at the "Choose Your Data Connection" window. Click the "Show the connection string that you will save in the application" checkbox and copy the string that appears. For me, it's: "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Vance\Downloads\Database1.accdb".
10. Important note here: When you use this in your code, make sure you actually put it in as a string for your connection method, otherwise it will throw an error. It's called a connection *string* for a reason. Make it a string. Just add quotes.
11. Click the "Next >" button again. It should show you the database objects present in your database file. Hit the checkbox to the left of each object you want to use in your program.
12. Hit "Finish". That's it - you now have a newly-added Data Source in your WPF program! That connection string you got in Step 9 will be needed for connecting to the added Data Source, so make sure you have that. If not, don't worry, you can just right click on the added Data Source in your "Data Sources" window and hit the Wizard option (should be the third one). You'll see the Database Objects window again. Just hit "< Previous" and it'll take you to a window where you can hit that special checkbox to get the connection string you'll need to use. Just hit "Cancel" when you get it that way you don't mess anything up.
13. Done.
