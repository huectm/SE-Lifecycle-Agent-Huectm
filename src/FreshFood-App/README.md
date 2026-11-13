# FreshFood App

Technology: Flutter / Dart. Package structure follows the requested MVVM split.

- lib/Views: future presentation widgets.
- lib/ViewModels: future presentation-logic classes.
- lib/Models: future client-side data and service-access classes.
- test: reserved Flutter tests.

pubspec.yaml declares only Flutter SDK dependencies. No Dart source, main.dart,
widget, ViewModel, model or API call has been created. Android/iOS platform
projects have not been generated; they can be generated in a later authorized
bootstrap step. This folder is intentionally not a runnable Flutter app yet.
Client Models are distinct from backend Entities and API DTO runtime classes.
