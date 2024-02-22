# Create Project Structure
```bash
# Add gitignore
dotnet new gitignore

# Create sln
dotnet new sln -o BuberDinner

# Presentation
dotnet new webapi -o BuberDinner.Api
dotnet new classlib -o BuberDinner.Contracts

# Infrastructure
dotnet new classlib -o BuberDinner.Infrastructure

# Domain
dotnet new classlib -o BuberDinner.Domain

# Add Project into solution
dotnet sln add (ls -r **/*.csproj)   

#  Api <- Contracts, Application
dotnet add .\BuberDinner.Api\ reference .\BuberDinner.Contracts\ .\BuberDinner.Application\ 

# Infrastructure <-Application
dotnet add .\BuberDinner.Infrastructure\ reference .\BuberDinner.Application\ 

# Application <- Domain
dotnet add .\BuberDinner.Application\ reference .\BuberDinner.Domain\
```
# Run project:
```bash
dotnet run --project .\BuberDinner.Api\
```

# VSCode Tools:

Rest Client