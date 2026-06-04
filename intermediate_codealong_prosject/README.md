# Codealong project C# Intermediate. 

## Classes, Interfaces and Generics.

Today's goal is to look at the creative side of programming. How classes can be a canvas to create. 

Having some "boundaries" or guidelines can still be a good idea, however. We see a class can usually fit into one of three categories. Model, Service or Repository. 

This first part covers how we can utilize these three class-designs to accomplish a railway-style system-design. 

Each implementation has xml doc comments tied to it. Hovering your mouse over the any instance should display it. 


### Models
When you need to represent a statefull object in your code, that sounds like a model. "A statefull object" sounds fancy, so think something akin to real-life objects. Something that holds a "state".
- A car
- A book
- A house
- An animal

Sometimes it might even be usefull to represent you own system's state as an object. In this code, look at how we represent "Good Path" and "Bad Path" as actual objects in the IResult.cs file.
We have two records (classes, but with immutable(unchangeable) fields) that both implement the interface IResult.
Each record represents one of two states our programflow can be in:
- success
- error

This is also a kind of a model. A model of our predicted states. 

### Services

A service is a kind of class that is supposed to represent your business-logic. This class is how you take some state, and change it into another state. This represents how your program functions. 
A service is often represented as a method collection, or a static class, with static fields with methods attached. 
In this project we have two kinds of services.
We have one service in the console app, that handles the businesslogic that is needed for our console app to function. 

We also have a separate service in the core class library that handles how to create a repairform object. 

The one in the Console project lives in the Console project, since it is directly tied to user input and output via the console. 

The other lives in the core library since it directly handles how a form should be created. 


### Repositories

A repository is a way to represent a collection of models. It can be valuable to create an abstraction around one of the standard collection types to ensure a programmer doesn't accidentally override an important part of the collection using your API. 
In this case we create an abstraction around a list. 
We expose an abstraction to add an item to the list, but we do not expose the list directly. Instead we expose it as a readonly list, meaning they can read all elements, but not add something directly to it, or manipulate it in any way. 

### Generics

Generics is a handy way for us to write code that can work on more than one datatype. In this project we use Generics in our IResult implementation. We see that our Success object can carry any datatype we want. This is handy if we want to use the IResult pattern in other parts of our code, and it's not directly coupled to the Form class. 

You can ctrl+left-click on standard implementations of List and see that they also implement a generic type via a type parameter. 
It allows the class to know what datatype it works with when defined. 

### Notes

Notice how we use the interface IResult as a return type. By using the interface as a returntype, both Success and Error is valid for all methods. As long as we handle both usecases in the methods receiving an IResult, that's fine.