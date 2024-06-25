# Welcome to the Todo List 

## Solution Overview 

```mermaid
sequenceDiagram
Alice ->> Bob: Hello Bob, how are you?
Bob-->>John: How about you John?
Bob--x Alice: I am good thanks!
Bob-x John: I am good thanks!
Note right of John: Bob thinks a long<br/>long time, so long<br/>that the text does<br/>not fit on a row.

Bob-->Alice: Checking with John...
Alice->John: Yes... John, how are you?
```
## Front End 

## Back End

## API Integration Tests

## User Interface Tests

# Getting started

## Goals

### Local Developer Experience

### Quality Assursance Experience

### Suitability for CI/CD

## Prerequisites

The following tools are recommended for the best local developement and quality assurance experience.

### Dependencies

### Tools

| Tool | Description |
|--|--|
| [Docker Desktop](https://www.docker.com/products/docker-desktop/) | Integrated application for building, running, and managing containers. |
| [Mockoon](https://mockoon.com/) | Mockoon is the easiest and quickest way to design and run mock REST APIs. |
| [Node Version Manager](https://github.com/nvm-sh/nvm) | Install, manage, and switch between multiple versions of Node.js on your system. |

## Cloning the repository

## Building the containers

To build or rebuild the containers, you can use:

 `docker compose build`

To force a rebuild of the container without using cache:

`docker compose build --no-cache`

## Running the application

To run the containers use:

`docker compose up --build --remove-orphans --detach`

| Parameter | Description |
|--|--|
| build | (Recommended) Builds the containers to ensure they are up to date. |
| remove-orphans | (Optional) Clean up services that are no longer defined in the compose YAML. |
| detach | (Optional) Allows you to continue using the terminal for other tasks. |
