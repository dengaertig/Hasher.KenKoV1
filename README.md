# Hasher.KenKoV1

Hasher.KenKoV1 is a minimal .NET library for password hashing with PBKDF2 (HMACSHA512). It includes support for salt, pepper, and customizable iterations, making it suitable for secure authentication implementations.

## Features

- PBKDF2 (HMACSHA512) password hashing
- Secure random salt generation
- Optional pepper support (stored outside the database)
- Configurable iteration count
- Simple password verification
- Easy integration into any .NET application

## Installation

.NET CLI:

    dotnet add package Hasher.KenKoV1 --version 1.0.0

NuGet Package Manager:

    Install-Package Hasher.KenKoV1 -Version 1.0.0

## Example Usage

```csharp
using Hasher.Services;

var hashService = new HashService();

string password  = "MySecurePassword123!";
string salt      = hashService.GenerateSalt(16);
string pepper    = "<your-secret-pepper>";
int iterations   = 100_000;

string hash = hashService.GeneratePasswordHash(password, salt, pepper, iterations);

// Later for verification:
bool isValid = hashService.VerifyPassword(password, salt, pepper, iterations, hash);
```

## Security Recommendations

- Salt should be unique per user and stored in the database.
- Pepper should be stored outside the database (environment variable or secret vault).
- The iteration count should match your security and performance requirements.
- Never reuse the same salt across different users.
- Always use HTTPS when transmitting passwords.


## API Overview

| Method | Description |
|--------|-------------|
| `GenerateSalt(int length)` | Generates a secure random salt (Base64). |
| `GeneratePasswordHash(string password, string salt, string pepper, int iterations)` | Generates a PBKDF2 hash and returns it as Base64. |
| `VerifyPassword(string password, string salt, string pepper, int iterations, string hashToCompare)` | Recomputes the hash using the same parameters and compares it. |
