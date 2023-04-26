# CommentsApp

A simple WebAPI application with n-layer architecture.

I tried to make meaningful commits and messages, that make sense.

What was done:
- n-layer application:
    - WebAPI - startup configuration, authenticationHandler, ErrorHandlingMiddleware, Controllers (Users, Comments)
    - EFCore - DB configuration + ef core migrations
    - Core - entity models
    - Application - business logic (services, interfaces, dtos)
    
- Quick documentation:
    - GET api/Users - get all users
    - GET api/Users/:userId - get user by Id
    - POST api/Users - create new user
    - DELETE api/Users/:userId - delete user by Id
    - GET api/Users/:userId/comments - get all comments for user with userId
    - POST api/Users/:userId/comments - add a new comment for user with userId
    - DELETE api/Users/:userId/comments - delete all comments for user with userId
    - DELETE api/Users/:userId/comments/:commentId - delete a comment by Id and UserId
    - GET api/Comments - get all comments with user info also

What should be improved in application:
- use of automapper: I skipped this and create a naive mapping (passing entity to the constructor of dto)
- db should be hosted somewhere, there should not be any hardcoded strings in the code.
- better swagger documentation - I don't think it is neccessary, since the application is not complicated and I followed REST principles.
