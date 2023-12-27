# Habit Tracker

This is a C# application using JetBrain Rider.

This is a console based CRUD Application to register how many glasses the user drank.


## Requirements

- [x] This is an application where you’ll register one habit.
- [x] This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
- [x] The application should store and retrieve data from a real database
- [x] When the application starts, it should create a sqlite database, if one isn’t present.
- [x] It should also create a table in the database, where the habit will be logged.
- [x] The app should show the user a menu of options.
- [x] The users should be able to insert, delete, update and view their logged habit.
- [x] You should handle all possible errors so that the application never crashes.
- [x] The application should only be terminated when the user inserts 0.
- [x] You can only interact with the database using raw SQL. You can’t use mappers such as Entity Framework.

## Features

- SQLite database connection
  - It uses a SQLite db connection to store and read information.
  - If no database exists, it will be created on program start.

- A console based UI users can navigage by key presses.

- CRUD DB functions
  - Users can create, read, update, and delete entries for whichever date.

## Challenges

- This is my first time dabbling with SQL with an actual application, while I am familar with the commands, learning how to apply that to an application was a bit of a challenge.
- At first it was a bit disorganized, till I made an engine.cs

## Lesson Learned

- Learned how important and useful it is to create a branch for each feature. I didn't do it often enough in my previous projects, but I realized it helps me to stay focused. Also a good way to keep track of things.
- Plan out projects properly. It helps so much!

## Areas to Improve
- Get faster with JetBrain Rider.
- Also try to get a stronger understanding of OOP.

## Resources used
- CSharpAcademy
