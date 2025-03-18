This project is a simple MAUI Blazor App which uses Firebase authentication.

Packages/Libraries used:
  FirebaseAuthentication.net 4.1.0
  The logged user is being stored in the Microsoft.Maui.Storage.Preferences library

Required configuration for Firebase to work with E-mail and password auth:
  1- Open Firebase in your Google account 
  2- Create a new project
  3- Go to Authentication tab - Login Methods -> Add new provider(E-mail,Password)
  4- Go to configuration -> Authorized domains and copy/create a new domain.
  5- Paste the domain and api key(Project -> Settings .> API Key) in the Firebase constructor.


Test cases:
  Run the application and follow the below steps:

1- Login Fail due to not created user
  
  1-Inform all the required fields
  2-Do NOT select "Register"
  3-Press Submit

  Expected behavior: Login Failed (User is not yet created)

2- Password missmatch

  1-Inform all the fields
  2-Change the Confirm password to a different one
  3-Press Submit

  Expected behavior: Login Failed (Passoword missmatch)

3- User created successfully

  1-Inform all the fields
  2-Swich to Register as ON
  3-Press Submit

  Expected behavior: Logged Successfully - Screen should show the data accordingly

4- Reinitialize the App

  1-Reinitialize the App

  Expected behavior: Same screen from test 3 should be shown with the data accordingly

5- Logout and login

  1-With the App opened, press Logout button

  Expected behavior: Login form should appear cleared

  2-Inform the correct data and with the "Register" checkbox as OFF, press Submit

  Expected behavior: Same screen from test 3 should be shown with the data accordingly

  
