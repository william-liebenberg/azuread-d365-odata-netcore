# Azure AD Authentication for Dynamics 365 to execute OData queries using .NET Core

## How to obtain an Access Token for Dynamics 365 CRM

### Azure AD Authentication Pre-requisites

* `Azure Tenant ID`
* `Dynamics 365 CRM URL`
* `Application ID` (Azure AD App Registration) and `Application Secret`
* `API Permission` for Dynamics 365 with `user_impersonation` scope
* `Application User` created in Dynamics 365 using Application ID and `interattion mode` set to `Non-interactive`

### Azure AD Authentication Process

1. Use `Basic` authentication (Base64 of `ApplicationId:ApplicationSecret` concatenation) to obtain the OAuth2 Access Token from the Microsoft Identity Platform (`https://login.microsoftonline.com/{YOUR Azure Tenant ID}/oauth2/v2.0/token`)
2. `accept` Header value must be set to `application/x-www-form-urlencoded`
3. `grant_type` Header value must be set to `client_credentials`
4. `scope` Header value is usually set to `.default`
5. Send the POST request
6. Read the JSON response
7. Deserialize JSON into `OAuth2Token` variable

The OAuth2 Access Token will contain the token type (usually `Bearer`) and the token expiration time.

The `OAuth2TokenProvider` caches the token so that we don't re-auth too frequently.

Cached Tokens will expire automatically when they reach the end of ther lifetime (`DateTime.Now + token.ExpiresIn`).

OAuth2 Access Tokens can now be used for authenticating against Dynamics 365 CRM to perform OData queries.

## How to execute an OData query against Dynamics 365 CRM

### OData Query Pre-requisites

* Valid Access Token

### OData Query Process

1. Obtain OAuth2 Token as shown above
2. Set up HTTP Client
3. `Authorization` Header value to use OAuth2 token type (usually `Bearer`) and the access token value
4. Formulate the CRM Uri (e.g. `https://mycompany.crm.dynamics.com/api/data/v9.1`) and OData query Uri
5. Attach the OData query Uri as querystring parameters
6. Send the GET request
7. Read JSON Response
8. Deserialize JSON into Models

DONE.
