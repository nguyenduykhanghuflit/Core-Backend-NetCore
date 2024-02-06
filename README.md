# Overview

 update later


# Clean architect

 update later

# Project structure
```
├───Base.Application
│   ├───Helpers
│   ├───Middlewares
│   ├───Properties
│   └───UseCases
│       ├───Auth
│       ├───GetOptions
│       ├───SyncAllPerm
│       └───User
│           ├───Crud
│           │   └───Presenter
│           └───GetCurrentUser
├───Base.Business
│   ├───ActionLogics
│   └───Rules
├───Base.Core
│   ├───Database
│   ├───ExceptionHandle
│   ├───Migrations
│   └───Schemas
├───Base.Services
│   ├───Base
├───Base.UnitTest
│   ├───ControllerTests
│   │   └───MockData
│   ├───ServiceTests
│   │   └───MockData
│   └───WorkflowTests
├───Base.Utils
└───Base.Benchmark
    ├───Base.BenchmarkDotNet.Artifacts
    │   └───results
    └───Services
```