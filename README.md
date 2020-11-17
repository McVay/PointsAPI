# Fetch Rewards - Points API Challenge

Author: Dylan McVay

Email: dfmcvay@gmail.com

## Description

This Web API will accept various HTTP requests allowing you to create new user accounts, add points to the user's account balances, and deduct points from the user in a FIFO ordering. If a user tries to redeem a reward worth more than their available point balance it will error out ensuring their balance does not go into the negatives.

## Implementation
This project was developed using .NET Core, EF Core, and AutoMapper. It was developed with the idea of being as clean and maintainable as possible and as such a lot of programming paradigms such as Dependency Injection, SoC, Repository Pattern, Unit Of Worker Pattern, and more. While this is not fully production ready, I wanted to get as close as possible. 

Currently, there is no persistent database however it would be fairly trivial to change out the In Memory EF Core database for a persistent one if needed in the future.

## Usage and Testing

- You will need the latest Visual Studio 2019 and the latest .NET Core SDK.
- The latest SDK and tools can be downloaded from https://dot.net/core.
- You will need a way to send payloads to the API, for this I would recommend https://www.postman.com/

1. Clone the repository: git clone https://github.com/McVay/PointsAPI.git
1. Open the solution file: PointsAPI.sln
1. Run the application (Program.cs contains the Main program entry point) and take note of the port the application is running on.


For the following test examples I will be using a pre-generated user account with and Id of 1.

#### Adding points
Points can be added to a user account by sending the following payload in an HTTP POST request to {host}/api/points/{userId}

```json
{
    "PayerName": "DANNON",
    "Amount": 300,
    "TransactionDate" : "2020-10-31T10:00:00"
}
```

![Alt text](.github/NewPoints.png?raw=true "Adding Points")


#### Deducting points
Points can be deducted from a user account by sending the following payload in an HTTP POST request to {host}/api/points/{userId}/deduct/{amount}

![Alt text](.github/DeductPoints.png?raw=true "Deducting Points")


#### Viewing point balance
Point balances can be viewed by sending a HTTP GET request to {host}/api/points/{userId}

![Alt text](.github/GetPoints.png?raw=true "Getting Points")

