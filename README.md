# Fetch Rewards - Points API Challenge

Author: Dylan McVay

Email: dfmcvay@gmail.com

## Description

This Web API will accept various HTTP requests allowing you to create new user accounts, add points to the user's account balances, and deduct points from the user in a FIFO order. If a user tries to redeem a reward worth more than their available point balance it will error out ensuring their balance does not go into the negatives.

## Implementation
This project was developed using .NET Core, EF Core, and AutoMapper. It was developed to be as clean and maintainable as possible and utilizes many programming concepts such as Dependency Injection, SoC, Repository Pattern, Unit Of Worker Pattern, and more. While this is not fully production-ready, I wanted to get as close as possible. 

Currently, there is no persistent database however it would be fairly trivial to change out the In-Memory EF Core database for a persistent one if needed in the future.

## Usage and Testing

- You will need the latest Visual Studio 2019 and .NET Core 3.1 SDK.
- The SDK and tools can be downloaded from https://dot.net/core.
- You will need a way to send payloads to the API, for this I would recommend https://www.postman.com/

1. Clone the repository: git clone https://github.com/McVay/PointsAPI.git
1. Open the solution file: PointsAPI.sln
1. Run the application (Program.cs contains the Main program entry point) and take note of the port the application is running on.

> There is also a prepackage .exe you can download from the Releases section if you don't want to install VS.

For the following test examples, I will be using a pre-generated user account with an Id of 1, however, you can create new user accounts if needed.

### Creating Users
New users can be created by sending an HTTP POST request to {host}/api/users with the following payload

```json
{
    "Name": "New User"
}
```

![Alt text](.github/NewUser.png?raw=true "Create User")

### Viewing Users
Users can be viewed by sending an HTTP GET request to {host}/api/users

![Alt text](.github/GetUsers.png?raw=true "Get User")

#### Adding points
Points can be added to a user account by an HTTP POST request to {host}/api/points/{userId} with the following payload

```json
{
    "PayerName": "DANNON",
    "Amount": 300,
    "TransactionDate" : "2020-10-31T10:00:00"
}
```

![Alt text](.github/NewPoints.png?raw=true "Adding Points")


#### Deducting points
Points can be deducted from a user account by sending an HTTP POST request to {host}/api/points/{userId}/deduct/{amount}

![Alt text](.github/DeductPoints.png?raw=true "Deducting Points")


#### Viewing point balance
Point balances can be viewed by sending an HTTP GET request to {host}/api/points/{userId}

![Alt text](.github/GetPoints.png?raw=true "Getting Points")

