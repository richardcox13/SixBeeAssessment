# SixBeeAssessment

## Technical Assessment for 6B Digital

See snapshot of [instructions](./Instructions.md).

# To Rum

- Use Visual Studio 2026 (and edition should work) with the ASP.NET Core workload.
- Load the solution.
- Create database SixBeeTechHealthTech in local SQL Server, with current use having dba role.
- From VS's package manager console run `update-database`.
- Run the project.
- Use the versions of dependencies that come with the project, rather than debugging impact of using the latest (which is worth it on a new project).

# Notes & Choices on Approach

## Technology & Platform

- .NET 10, ASP.NET MVC Core without full blown frontend framework.
- MS SQL Server (Dev Ed) 2025.

## Scope and Time Limited

### Focus on KISS

- No AI, beyond code completion. This is to assess me, no some LLM. (And I don't have the tokens!)

- One project, limited abstractions. The requirements do not justify the complexity.

- There is very little business logic 

- For a larger MVC project I would set up for "feature folders" to keep controller, views, & models together. However within this scope that brings little benefit. The benefits come as the scope increases, especially with a target of a "modular monolith".

- Use "Individual Accounts" for authentication & authorisation in ASP.NET Core Identity as it satisfies the requirement to use the local DB.

- Sizes of name and email columns are somewhat arbitrary of course.

- If the scope included internationalisation time zone handling would be needed. This is an area, when setting future times for appointments, that "just use UTC" doesn't work and there is no simple approach.

### Styling

- As I don't know Tailwind CSS and the initial learning curve is non-trivial I'll stick with the defaults from the project template.

- I know the customisation is simplistic. I would expect to work with a designer on a look and feel.

- Browsers' inbuilt date/time editor isn't great, but it is functional. On a real project would
  be looking for a client side control for this.

- The UI for identity doesn't offer quick customisation, and assumes Bootstrap.

## Next Steps

- Extract a repository to wrap CRUD etc. operations on appointment to allow unit testing of the (limited logic here).
