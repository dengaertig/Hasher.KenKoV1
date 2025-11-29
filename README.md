# Hasher

A lightweight .NET library for securely hashing passwords using PBKDF2 (HMACSHA512) with support for salt, pepper, and configurable iterations.

## Features

- PBKDF2 hashing with HMACSHA512
- Secure random salt generation
- Pepper support (stored outside the database)
- Configurable iteration count
- Simple password verification
- Easy integration into any .NET application

## Installation

.NET CLI:
dotnet add package Hasher

NuGet Package Manager Console:
Install-Package Hasher

(Replace "Hasher" with your actual NuGet package ID if different.)

## Usage Example

using Hasher.Services;

var hashService = new HashService();

string password = "MySecurePassword123!";
string salt = hashService.GenerateSalt(16);
string pepper = "<your-secret-pepper>"; // store securely!
int iterations = 100000;

string hash = hashService.GeneratePasswordHash(password, salt, pepper, iterations);

bool isValid = hashService.VerifyPassword(password, salt, pepper, iterations, hash);

## Security Notes

- Salt should be unique per user and stored in the database.
- Pepper must be stored outside the database (environment variable, secret vault, etc.).
- Adjust iterations based on performance/security requirements.
- Never reuse salts between users.
- Always use HTTPS for password transmission.

## API Overview

GenerateSalt(int length)
Generates a cryptographically secure random salt (Base64).

GeneratePasswordHash(string password, string salt, string pepper, int iterations)
Creates a PBKDF2 hash and returns it as Base64.

VerifyPassword(string password, string salt, string pepper, int iterations, string hashToCompare)
Recreates the hash and compares it with a stored one.
