# Fetch Rewards - Points API Challenge

Author: Dylan McVay

Email: dfmcvay@gmail.com

## Description

This Web API will accept various HTTP requests allowing you to create new user accounts, add points to the user's account balances, and deduct points from the user in a FIFO ordering. If a user tries to redeem a reward worth more than their available point balance it will error out ensuring a user can never have a negative point balance.

## Implementation
This project was developed using .NET Core, EF Core, and AutoMapper and relies heavily on concepts such as Dependency Injection, Separation of Concerns, and various other programming patterns.

The API service will run on port 65072 if ran from Visual Studio.

Currently, there is no persistent database however it would be fairly trivial to change out the In Memory EF Core database for a persistent one if needed in the future.

## Usage and Testing

- You will need the latest Visual Studio 2019 and the latest .NET Core SDK.
- The latest SDK and tools can be downloaded from https://dot.net/core.

Clone the repository:

git clone https://github.com/McVay/PointsAPI.git
