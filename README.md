# Introduction 
Sample API for designing a monolith that can be broken into micro services as needed.

CONTENTS OF THIS FILE
---------------------
   
 * Introduction
 * Project Structure
 * Requirements
 * Installation
 * Configuration

 INTRODUCTION
------------

If you are embarking on a software project that requires microservices, a good approach is to start
with a monolith keeping in mind that you will want to peel services off in the future as independently
deployable apis. If you start with a very modular design by making each "service" a DLL to start encapsulating
the business logic in that DLL, you can pull that DLL out at a later time and wrap it with a Controller layer
and wire it up however you chose. (Http, pub/sub, etc...)

PROJECT STRUCTURE
------------

This project is monolithic with the intent that we can break services
out into separate services when needed.

* MicroMonolithSample - API Controllers/routes
* IntegrationTests - Tests against the api using SQL as the backing DB.
* KYCService - Responsible for all things related to KYC (Know Your Customer)
* MemberService - Responsible for all things related to Members
* Models - Data models i.e. Members,
* OrchestrationService - Responsible for workflows across services. i.e. Adding a member

REQUIREMENTS
------------

* .Net core (6)

INSTALLATION
------------

To install locally, do the following:
1. Clone the repo
2. Perform a Nuget restore of all packages

CONFIGURATION
------------

This is a .Net core application which uses appsettings.json files
for Configuration. appsettings.json serves as the base config file. It 
supports additional config files for environment specific variables.
Locally or on the server, ASPNETCORE_ENVIRONMENT needs to be set 
which will instruct .Net core to read in the appropriate settings file.

