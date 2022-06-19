# Dinner Hosting App

[Dinner Hosting App API](#dinner-hosting-app-api)
[Auth](#auth)
[Register](#register)
[Register Request](#register-request)
[Register Response](#register-response)
[Login](#login)
[Login Request](#login-request)
[Login Response](#login-response)

## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName":"Ömer Faruk",
    "lastName":"Çelik",
    "email":"email@email.com",
    "password":"pass123"
}
```

#### Register Response

```js
200 OK
```

```json
{
    "id":"0ce92098-6459-4304-9134-cdd390bc0a76",
    "firstName":"Ömer Faruk",
    "lastName":"Çelik",
    "email":"email@email.com",
    "token":"token"
}
```

### Login

```js
POST {{host}}/auth/login
```

#### Login Request

```json
{
    "email":"email@email.com",
    "password":"pass123"
}
```

#### Login Response

```js
200 OK
```

```json
{
    "id":"0ce92098-6459-4304-9134-cdd390bc0a76",
    "firstName":"Ömer Faruk",
    "lastName":"Çelik",
    "email":"email@email.com",
    "token":"token"
}
```