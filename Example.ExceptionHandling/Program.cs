using Example.ExceptionHandling.Executors;
using Example.ExceptionHandling.Extensions;
using Example.ExceptionHandling.Requests;
using Example.ExceptionHandling.Workflows;

UserWorkflow userWorkflow = new();
CreateUserExecutor createUserExecutor = new();

try
{
    bool shouldContinue;

    do
    {
        CreateUserRequest request = new()
        {
            Username = "colinxes",
            FirstName = "Colin",
            LastName = "Eikis-Sagcob",
            RequestingUsername = "Administrator",
            DateOfBirth = new DateTime(2000, 5, 15)
        };
    
        createUserExecutor.Try(() =>
        {
            Console.WriteLine("Trying to add an user.");
            userWorkflow.CreateUser(request);
            Console.WriteLine($"The user {request.Username} was created successfully.");
        });
    
        createUserExecutor.Try(() => userWorkflow.CreateUser(null));
        createUserExecutor.Try(() => userWorkflow.CreateUser(new CreateUserRequest()));
        shouldContinue = ConsoleExtensions.Confirm("Do you wanna add an user again?");


    } while (shouldContinue);
}
catch (Exception exception)
{
    // Last chance to handle something like logging and shutting down the app correctly if this is critical.
    Console.WriteLine($"Something went wrong! Shutting down the application. Exception: {exception}");
    Environment.Exit(1);
}