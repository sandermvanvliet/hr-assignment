# HR Unit Testing Assignment

Your assignment is to build an application that can count words. Seems simple, it is!

## Acceptance criteria
These are the acceptance criteria defined for the application, read them carefully!

## Getting started
1. First clone the repository: `git clone https://github.com/sandermvanvliet/hr-assignment.git`
1. Enter the repository directory: `cd hr-assignment`
1. Restore the necessary nuget packages: `dotnet restore`
1. Build the solution: `dotnet build`
1. Run the verification test: `dotnet test`

## 1: Count all occurrences of words in a scentence
The application should return a list of words and the number of times that word is found in the scentence. 

Given a scentence:

> This is the sample input for the application

The output is:

| Word | Count |
|------|-------|
| is   | 1     |
| This| 1 |
| sample | 1 |
| the | 2 |

etc..

## 2: Give a list of most used words
Building on the previous example, the application should return a list of words sorted decending on occurrence. In addition the list should only return the top-5 list of words.

## 3: Count occurrances of input word
The application should prompt for a word and then return how many times that word occurs in the given scentence. Think about how to handle unhappy scenarios as well.