# BaseCleanArchitectureProject


This is my starting point for Clean Architecture with ASP.NET Core. [Clean Architecture](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html) is just the latest in a series of names for the same loosely-coupled, dependency-inverted architecture. You will also find it named [hexagonal](http://alistair.cockburn.us/Hexagonal+architecture), [ports-and-adapters](http://www.dossier-andreas.net/software_architecture/ports_and_adapters.html), or [onion architecture](http://jeffreypalermo.com/blog/the-onion-architecture-part-1/).
It is based on [Ardalis Clean Architecture](https://github.com/ardalis/CleanArchitecture)

I appologise if there is any break on the concpetion of pure Clean Arquitecture but this is how I think should be easy to hook things up.

It uses the [mediatr](https://github.com/jbogard/MediatR) to raise the Domain Event instead of the original (Ardalis uses his own dispatcher.)
