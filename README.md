# EHIAppSolution
EHIAppSolution
EHI Crud Application 
Purpose of the web application to perform crud operation o Contact details.
website Pages  
Home Page (this page is not full function)  
Contact infoContact - contact information will appear 
  User can view all records 
  User can Update and Delete the records from this page
  User can Active or inactive the contact by clicking the check box
  *Paging and sorting is pending
 Contact New page 
  for adding and updating the records 
  
This Application is designed in 3 modules 
    1.EHIClient (Angular UI)
    2.EHIWebAPi (net framework 4.7)
    3.EHI.Services (C# Class library project ) 
    4.Backend Entity framework (code-first approach)

All these projects build under a single solution EHISolution.
Angular project folder added in the same location (folder name EHIClient).
WebAPI project is the default project of asp. web API.
EHI Services is a C# class library project, All the code is designed at very hight level of considering the microservice design architecture style (containerization the servcies).

Steps to Run this Solution
  1.Pull the repo from Git, URL as below.  
  2.Installed dependant pcakges Build the solution in VS 2019
  3.For Angular goto folder EHIClient, open this folder in VS Code build the angular project and do ng serve
  
 To run it locally Important configuration need to be do
    1. to Enable CORS for Angular application register local URL (uncomment the line in WebApiConfig.cs file)
    2. In Angular project goto services add the local API Url (uncomment the line in contact.servcie.ts)
    3. You can add a connection string in the web config file to run the application on the targeted server 

Future enhancement 
1.Services can be migrated into GRPC or WCF services 
2. Test projects need to be added at the project level (Nunit)
3.Context creation can be moved into a base class
3.AutoMapper at the service level as well
4.Logs and for tacking issues (log4net, elastic search )
5. All the one-time configuration can be converted into the common base class 
6.Separate the Web API solution from the default one created 
7. In the angular end can use standard UI begin 
8. Implanting the object-oriented class base type script  module 
9. more can be added considering Build and Deployment etc etct

 
 
