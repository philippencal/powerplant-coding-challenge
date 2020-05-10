# PowerPlant API

## Welcome !

This repository is part of a code challenge provided by [ENGIE](https://www.engie.com/), internal development teams.
The goal of this coding challenge was to provide the applicant some insight into the business and to be discussed in future interview steps.

[![N|Solid](https://github.com/philipgpencal/powerplant-coding-challenge/blob/master/blob/challenge_swagger.png)]

## Implementation

The application was developed using Visual Studio 2019 and .NET Core 3.1 for the API and .NET Standart 2.0 for all libraries, the reason for this choice is because in real scenarios it may be reused in future implementations or even some legacy code.

#### API Versioning
I decided to use url based versioning, instead of query string or http header as this option is easier to identify and more adopted for companies. (Default api version 1.0)

#### API Documentation
The root path contains a swagger customized ui with the challenge POST method well documented.

#### API Entry Validations
The body parameters are all validated with .NET Core native resources and some customized validations which is using the same pattern, I decided to use DataAnnotations, which Microsoft made a great job with the last improvements, the validation is clean, useful and efficient.

#### YAGNI and KISS
I tried to keep it as simple as possible and don't overengineer it. 
Hot patterns such as mediator and CRQS does fit in an application like that.

### Patterns and Libs used

Some topics I should consider:
 - Automapper usage: The automapper is not only for organizing and improve the way we parse DTOs to Models, in my opinion, it also gives a better look at our methods, keeps the code clean.
 - Design Patterns: I was planning to use a well-know design patter, I applied the Factory pattern which fits nice for the PowerPlant generic creation.

### Best practices adopted
   - Architecture in N-Layers designed for Design Drive Domain base evolution. 
   - SOLID Concepts (Methods with a single responsibility, open to extension, Liskov principle followed as the hierarchy used to respect the principle, no complexity for interface segregate, Ioc with DI)

### APP Details
   - Logs are available in file.txt at ROOT/LOGS
   - The Payload returns are ordered by efficiency cost
   - The docker file extra challenge has been included on the API project
   - I created the algorithm from scratch without check references as a personal challenge

### Aspects not implemented
The following items were not implemented but I know the importance of their implementation in real scenarios.
 - Security (Authentication, Authorization)
 - Tests (Unit and Integration)

Also, the extra challenges (WebSocket and CO2 calculation) were not implemented for this first version.

### Thanks for check this project

I would like to invite you to check my [linkedin](https://www.linkedin.com/in/philip-pencal/) to know more about my experience and skills.
