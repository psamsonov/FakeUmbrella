# FakeUmbrella

This is a simple weather reporting application.

Prerequisites: .NET core framework 3.1.400-preview-015178 or higher

## To run

Navigate to the FakeUmbrella/FakeUmbrellaAPI directory and execute the following command: `dotnet run -p FakeUmbrellaAPI`

Navigate to the  FakeUmbrella/FakeUmbrellaUI directory and execute the following command: `ng serve --proxy-config proxy.conf.json -o`

Your browser should open with the Fake Umbrella application running.

## Limitations

The following were omitted due to time constraints:
* Input validation
* Real unit tests
* Dependency injection
* A more robust database than SQLite
* Pretty UI styling
* More user friendly error messaging mechanism
* Concealment of the API token