# Country Route API

## Overview

Country Route API is a simple ASP.NET Core Web API that determines a
driving route from the United States to a supported North American
country. Given a three-letter country code, the API returns the sequence
of countries that must be traveled through to reach the destination.

The application represents countries and their shared borders as a graph
and uses breadth-first search (BFS) to find a route with the fewest
border crossings.

## Technologies

-   C#
-   ASP.NET Core
-   .NET 9
-   xUnit

## API

### Get a Route

``` text
GET /{destination}
```

`destination` is a three-letter country code. Country codes are
case-insensitive.

Example request:

``` text
GET /PAN
```

Example response:

``` json
[
  "USA",
  "MEX",
  "GTM",
  "HND",
  "NIC",
  "CRI",
  "PAN"
]
```

Another example:

``` text
GET /BLZ
```

``` json
[
  "USA",
  "MEX",
  "BLZ"
]
```

## Error Handling

The API validates the destination before attempting to find a route.

A country code that does not contain exactly three letters returns a
`400 Bad Request`.

Example:

``` text
GET /US
```

A correctly formatted country code that is not part of the supported
country data returns a `404 Not Found`.

Example:

``` text
GET /ABC
```

Lowercase and mixed-case country codes are accepted and normalized
before processing.

## Routing Algorithm

Countries are represented as an unweighted graph where each country is a
node and each shared border is an edge.

The application uses breadth-first search (BFS), beginning at `USA`, to
find the destination. Because each border crossing has equal cost, BFS
finds a route requiring the fewest border crossings.

As countries are discovered, the algorithm records the country from
which each one was reached. After finding the destination, these parent
relationships are followed backward to reconstruct the complete route
from `USA` to the destination.

The time complexity of BFS is `O(V + E)`, where `V` is the number of
countries and `E` is the number of shared borders.

## Running Locally

### Prerequisites

Install the .NET SDK.

### Run the API

From the repository root:

``` bash
dotnet run --project CountryRouteApi
```

The development server can then be accessed at the address displayed in
the terminal.

For example:

``` text
http://localhost:5003/PAN
```

The included `CountryRouteApi.http` file also contains several example
requests for testing the API locally.

## Running Tests

The project includes xUnit tests covering the primary routing behavior
and destination validation.

From the repository root, run:

``` bash
dotnet test
```

The tests cover:

-   A multi-country route to Panama
-   A route to Belize
-   A direct route to Canada
-   A route where the destination is the United States
-   Supported destination validation
-   Unsupported destination validation

## Assumptions

-   Every route begins in the United States (`USA`).
-   Only the countries included in the provided border data are
    supported.
-   Country codes are three letters and are treated as case-insensitive.
-   Each border crossing has equal cost, so the preferred route is the
    route with the fewest border crossings.
-   The provided country data is small and fixed, so it is stored in
    memory rather than in an external database.
-   All supported countries are reachable from the United States.

## Deployment

The API is deployed at:

`<deployment URL>`
