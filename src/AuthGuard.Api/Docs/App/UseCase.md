## Use-Cases

All endpoints are protected with Bearer token. For this reason, you should definitely authenticate before using any endpoint.

### Authentication Request

Method : POST

URL : {Identity_Server_Base_Url}/connect/token

FromForm : 

grant_type : client_credentials

scope : employeeApi.read

client_id : employeeApi

client_secret : ProCodeGuide

**Note**
If you want to produce a token with all the powers, you can leave the scope section blank.

**Response**

```json
{
	"access_token": "eyJhbGciOiJSUzI1NiIsImtpZCI6IjFGMEQzMTc3QzM3QzU3OEFFOUM1OEQzOTA0OTQwMzFEIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2NjAxMzU4NTEsImV4cCI6MTY2MDEzOTQ1MSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NDQzNDYiLCJhdWQiOiJlbXBsb3llZUFwaSIsImNsaWVudF9pZCI6ImVtcGxveWVlQXBpIiwianRpIjoiN0M0MzNBRTA2NEQwOUY4ODhEMUYxNTc0QkM5NjY0MDEiLCJpYXQiOjE2NjAxMzU4NTEsInNjb3BlIjpbImVtcGxveWVlQXBpLnJlYWQiXX0.BrIKUTYM32gOag47f8BJBD4HdXNJrzZNMpVctc-P7Ajgudo9RPFtNCzHoaqzQVWmyhSIu8rnitwQpgiWw61YkI_SrwpTtWOnrhtuK9hnFQpxO5pXu0AMQ6pbpeD1aFdOjs4F99joGNVCXACb_SBtLGb9jvlMSKLMpryTjr4prWjg14pnT4EChX-30dD4JOWt1tEOQp3ghiG0UMmbyXRySPTeRIjlEjwRztc-vP07xqaER_scuhw5vwQ785V_OTTYAjCqX3v1Ous8ZrCjvqh4tP6O-fXjMCiAPUEmFK-WNuo4RzI6VwHnwSZg3927UtwL_u3TZH0BO2EEKe6zvM990w",
	"expires_in": 3600,
	"token_type": "Bearer",
	"scope": "employeeApi.read"
}
```

**Decode To Token**

```json

{
  "alg": "RS256",
  "kid": "1F0D3177C37C578AE9C58D390494031D",
  "typ": "at+jwt"
}.{
  "nbf": 1660135851,
  "exp": 1660139451,
  "iss": "https://localhost:44346",
  "aud": "employeeApi",
  "client_id": "employeeApi",
  "jti": "7C433AE064D09F888D1F1574BC966401",
  "iat": 1660135851,
  "scope": [
    "employeeApi.read"
  ]
}

```

****

## Add Employee

**Request**

```json
{
  "firstName": "Furkan",
  "lastName": "Güngör",
  "age": 25
}
```

**Response**

```json
{
  "success": true,
  "key": "OK",
  "data": {
    "firstName": "Furkan",
    "lastName": "Güngör",
    "age": 25,
    "id": "ee71aa23-c3a4-44f8-bdac-0883025e929c",
    "creationDate": "2022-08-10T13:04:26.2189305Z",
    "modificationDate": "2022-08-10T13:04:26.8445649Z"
  }
}
```

****

## Update Employee

**Request**

Note : From Route PK of Employee

```json
{
  "firstName": "Mahmut",
  "lastName": "Tuncer",
  "age": 60
}
```

**Response**

```json
{
  "success": true,
  "key": "OK",
  "data": {
    "firstName": "Mahmut",
    "lastName": "Tuncer",
    "age": 60,
    "id": "ee71aa23-c3a4-44f8-bdac-0883025e929c",
    "creationDate": "2022-08-10T13:04:26.21893Z",
    "modificationDate": "2022-08-10T13:04:26.844564Z"
  }
}
```

****

## Advanced Filter

URL : {BASE_URL}/v1.0/employees?FirstName=Furkan

METHOD : GET

**Response**

```json
{
  "success": true,
  "key": "OK",
  "data": [
    {
      "firstName": "Furkan",
      "lastName": "Güngör",
      "age": 25,
      "id": "062911af-9bbd-4264-abc2-722506ce5f2d",
      "creationDate": "2022-08-10T12:51:46.14462Z",
      "modificationDate": "2022-08-10T12:51:46.23637Z"
    }
  ],
  "meta": {
    "totalCount": 2
  }
}
```

Note : You can also query according to Last Name, Range of Age and Range of Creation Date parameters.