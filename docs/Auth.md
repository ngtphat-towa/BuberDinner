# Buber Dinner API

## Auth

### Register
``` POST{{host}}/auth/register ```

#### Register Request
```json
{
    "firstnName": "Phat",
    "lastName" : "Nguyen",
    "email": "ngtphat.towa@gmail.com",
    "password": "Password123"
}
```
#### Register Response
 ```js
 200 OK
 ```
```json
{
    "id": "guid-guid",
    "firstnName": "Phat",
    "lastName" : "Nguyen",
    "email": "ngtphat.towa@gmail.com",
    "token": "eyjsb..."
}