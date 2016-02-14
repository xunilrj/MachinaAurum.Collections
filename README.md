
(very Work-In-Progress)

# MachinaAurum.Collections
Abstract contracts to collections based on the works of:

TRAITS: COMPOSABLE UNITS OF BEHAVIOUR  
http://scg.unibe.ch/archive/papers/Scha03aTraits.pdf

APPLYING TRAITS TO THE SMALLTALK COLLECTION HIERARCHY  
http://www.researchgate.net/publication/2564879_Applying_Traits_to_the_Smalltalk_Collection_Hierarchy

MODERN C++ DESIGN  
http://erdani.com/index.php/books/modern-c-design/

COLLECTION HIERARCHIES  
http://www.c2.com/cgi/wiki?CollectionHierarchies

# Motivation

Domain-Driven Design: Tackling Complexity in the Heart of Software  
Eric Evans  
Chapter 6, Factories  

> The Java class library offers interesting examples. All collections implement interfaces that decouple the client from the concrete implementation. Yet they are all created by direct calls to constructors. A FACTORY could have encapsulated the collection hierarchy. The FACTORY's methods could have allowed a client to ask for the features it needed, with the FACTORY selecting the appropriate class to instantiate. Code that created collections would be more expressive, and new collection classes could be installed without breaking every Java program.
