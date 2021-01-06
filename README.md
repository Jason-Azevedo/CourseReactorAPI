# CourseReactorAPI
The API assignment

## Setup
1. Make sure you have the [dotnet core 3.1 sdk](https://dotnet.microsoft.com/download/dotnet-core/3.1) installed.
2. In the root of the project run `dotnet restore`, this updates/installs the required dependancies and packages.
3. To run the project use `dotnet run` in the project root and the project will compile and run!

## API Documentation
Once the project has been compiled and is running you can invoke the api with the following routes:

1. ### Get a specific cookie entry:
    ### Route
    ``` HTTP 
    GET http://localhost:5000/api/cookies/get?id=2
    ```
    This returns a Json result containing the cookie's data or 404. The id is an integer.

2. ### Get an amount of cookie entries:
    ### Route
    ``` HTTP
    GET http://localhost:5000/api/cookies/getamount?amount=8
    ```
    Returns a Json result containing an array of cookie data entries or an empty array if there are none.

3. ### Create a cookie entry:
    ### Route
    ``` HTTP
    POST http://localhost:5000/api/cookies/create
    ```

    ### Request body
    The body must contain a json object as follows, don't forget about the application/json header ;)
    ``` JSON
    {
        "name": "The name of the cookie",
        "description": "The description of the cookie",
        "recipe": "The recipe of the cookie"
    }
    ```
    Returns a status code upon completion.

4. ### Update a cookie entry:
    ### Route
    ``` HTTP
        PATCH http://localhost:5000/api/cookies/update
    ```
    ### Request body
    The body must contain a json object as follows, don't forget about the application/json header ;)
    
    ``` JSON
        {
            "id": 1, // any int value representing the id
            "name": "The name of the cookie", 
            "description": "The description of the cookie",
            "recipe": "The recipe of the cookie"
        }
    ```

5. ### Delete a cookie entry:
    ### Route
    ``` HTTP
        DELETE http://localhost:5000/api/cookies/delete?id=1
    ```
    Deletes the specified cookie entry and returns a status code result,
    the id is an integer.