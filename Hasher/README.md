# Hasher.KenKoV1

A lightweight and easy-to-use .NET library for securely hashing passwords using PBKDF2 (HMACSHA512), including support for salt, pepper, and configurable iteration counts.

## Features

- Password hashing using PBKDF2 with HMACSHA512  
- Cryptographically secure random salt generation  
- Pepper support (stored outside the database)  
- Configurable iteration count  
- Simple and reliable password verification  
- Easy integration into any .NET application  

## Installation

You can install the package from NuGet:

https://www.nuget.org/packages/Hasher.KenKoV1/1.0.0

.NET CLI:  
```
dotnet add package Hasher.KenKoV1 --version 1.0.0
```
NuGet Package Manager Console:  
Install-Package Hasher.KenKoV1 -Version 1.0.0

## Usage Example
```
using Hasher.Services;

var hashService = new HashService();

string password = "MySecurePassword123!";
string salt = hashService.GenerateSalt(16);
string pepper = "<your-secret-pepper>"; // store securely (environment variable, secret store, etc.)
int iterations = 100000;

// Create hash
string hash = hashService.GeneratePasswordHash(password, salt, pepper, iterations);

// Verify password
bool isValid = hashService.VerifyPassword(password, salt, pepper, iterations, hash);
```
## Security Notes

- Salt must be unique per user and stored in the database.  
- Pepper must be stored **outside** the database (environment variable, key vault, secret store).  
- Choose iteration count based on security and performance needs.  
- Never reuse salts between users.  
- Always use HTTPS when transmitting passwords.  

## API Overview
```
GenerateSalt(int length)  
```
Generates a cryptographically secure random Base64-encoded salt.
```
GeneratePasswordHash(string password, string salt, string pepper, int iterations)  
```
Creates a PBKDF2 hash with the provided parameters and returns it as Base64.
```
VerifyPassword(string password, string salt, string pepper, int iterations, string hashToCompare)  
````
Recomputes the hash with the same parameters and compares it with the stored value.
