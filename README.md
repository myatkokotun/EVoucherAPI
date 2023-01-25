
# EVoucher Management System (API)

Firstly, need to call Login api to get token and that token is used to call other apis. Project includes Login, EVoucher (CRUD), Payment Method (CRUD), CMS User.


## API Reference

Base URL "http://localhost:5127/"

#### Login

```http
  GET /api/Login/Login
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Username` | `string` | **Required**. "saka" |
Password|string|**Required**. "123@456"

#### Get User List

```http
  GET /api/Login/GetUserList
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| page      | `int` | |
pagesize|int||

#### Get User Detail

```http
  GET /api/Login/GetUserObj
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| ID      | `int` | **Required**. 3|

#### Get Delete User

```http
  GET /api/Login/DeleteUser
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| ID      | `int` | **Required**. 3|

#### Get Insert/Update User

```http
  POST /api/Login/UpSertCMSUser
```

{
    "Name":"Megan Fox",
    "Username":"megan",
    "Password":"megan!123"
}

{
    "Name":"Tailor Swift",
    "Username":"tailor",
    "Password":"tailor!123"
}


#### Get EVoucher List

```http
  GET /api/EVoucher/GetEVoucherList
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| page      | `int` | |
|pagesize|`int`||
|FilterName|`string`||
|Keyword|`string`||

#### Get EVoucher Detail

```http
  GET /api/EVoucher/GetEVoucherObj
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| ID      | `int` | **Required**. 3|

#### Delete EVoucher

```http
  GET /api/EVoucher/DeleteEVoucher
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| ID      | `int` | **Required**. 3|

#### Get Insert/Update EVoucher

```http
  POST /api/EVoucher/UpSertEVoucher
```

{
    "Title":"Table",
    "Description":"This is Description for Table",
    "Amount":120000,
    "Quantity":7,
    "ExpiryDate":"2023-10-24",
    "PaymentMethod":"Kpay",
    "BuyType":"only me usage",
    "MyselfName":"Ko Banyar",
    "MyselfPhone":"09435233435",
    "MyselfMaxLimit":100
}

{
    "Title":"Air Con",
    "Description":"This is Description for Air Con",
    "Amount":720000,
    "Quantity":3,
    "ExpiryDate":"2023-10-24",
    "PaymentMethod":"VISA",
    "BuyType":"gift to others",
    "OtherName":"Ko Mg Myint",
    "OtherPhone":"09435443435",
    "OtherGiftLimit":100,
    "OtherBuyLimit":200
}


#### Get PaymentMethod List

```http
  GET /api/PaymentMethod/GetPayMethodList
```

#### Get PaymentMethod Detail

```http
  GET /api/PaymentMethod/GetPayMethodObj
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| ID      | `int` | **Required**. 3|

#### Delete PaymentMethod

```http
  GET /api/PaymentMethod/DeletePayMethod
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| ID      | `int` | **Required**. 3|

#### Get Insert/Update EVoucher

```http
  POST /api/PaymentMethod/UpSertPayMethod
```

{
    "MethodName":"Master Card",
    "Discount":10
}

{
    "MethodName":"Paypal",
    "Discount":12
}
