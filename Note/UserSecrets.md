# dotnet-user-secrets
===================

`dotnet-user-secrets` is a command line tool for managing the secrets in a user secret store.

### How To Use

Run `dotnet user-secrets --help` for more information about usage.

[Readmore](https://github.com/dotnet/AspNetCo*re.Docs/blob/main/aspnetcore/security/app-secrets.md)

# Create Secrets
```bash
# Init project
dotnet user-secrets init -p .\BuberDinner.Api\

# Create user-secret
dotnet user-secrets set -p .\BuberDinner.Api\ "JwtSettings:Secret" "supper-dupper-secret-key-from-user"
```