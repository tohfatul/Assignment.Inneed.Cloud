# Assignment.Inneed.Cloud
- Assignment requirement could be done in a simple project but I made it detailed to showcase how I think in terms of SOLID and CLEAN architecture and best practices for big project 
- I have used custom tables to store user information since assignment instruction was- not to use ASP.Net Core Identity
- Besides Dependency Injection and Repository, I have also used CQRS and Mediator pattern only to showcase how we can seperate database read and write operations


Instructions:
(1) Please select Assignment.Inneed.Persistence project to migrate. Because DbContext is there

(2) After migration, bellow data will be seeded -

  Roles: -Administrator
         -Standard
  Users:
   
   Full Name: Admin User
   Email: admin@admin.com
   Role: Administrator
   Password: 123456
 
  Full Name: Standard User
  Email: standard@standard.com
  Role: Standard
  Password: 123456

  (Only Administrator User can view user list. URI: localhost/api/user)
  
(3) Please use 'Administrator' or 'Standard' as role while creating new user. Otherwile validation will prevent to save. URI: localhost/api/user [http Post]
  Sample Json as payload to create user: 
    {
      "fullName": "New User",
      "email": "new@user.com",
      "password": "123456",
      "roleName": "Administrator"
    }
  
(4) Login URI localhost/api/user/login
  Sample json as payload to login:
  {
    "email": "admin@admin.com",
    "password": "123456"
  }
