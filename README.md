# Flashcard Angular Application
A flashcard web application for learning foreign words, specific terminologies.

## What is it and how does it work?
It gives users the opportunity to create decks, consisting of cards. A card is basically a word, for which you give a definition and give yourself a hint, as well as an image to boot. The idea is to be able to create collections of words you want to learn, find neat ways of remembering them and afterwards testing them out. A deck is basically a collection of the previously mentioned cards.

You can arrange a deck to be public, and give it a poster, name, description as well as languages from and to, to make people chose more easily what decks they are of their interest.

## The technical bits
This web app provides a C# .NET Core API that stores the decks, cards and statistics and both feeds and consumes data given by the frontend Angular Application. It features both frontend authentication and authorization (mainly about not seeing things you are not supposed to) and the back end deals with the specifics of both (e.g. a user shouldn't be able to delete other people's decks unless he is an admin). The authentication and authorization is done using the JWT token authentication method implemented in the backend, as well as some custom validation in the service layers in order to restrict/allow certain actions.

## About the Angular Application
In this application the [Angular Material](https://material.angular.io/) is heavily in order to give it that 'mobile app' feel on top of the good looking and smooth UI.
Notifications are used every time the server returns a response with a message field. When the screen is in desktop mode, the notifications used are the [ngx-toastr](https://github.com/scttcper/ngx-toastr) toasts, and when it is in a handheld mode it's the [Angular Material Snackbars](https://material.angular.io/components/snack-bar/overview)
