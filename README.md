C# app to manage a middle school basketball league. This project was not mandatory to pass the course.
30 teams representing 30 schools. It's assumed that data (school names, teams, students and matches) is already registered, but I've also posted the code which does that part(hardcoded).

Entities:
-Elev ( student )
-Jucator ( player )
-Jucator Activ ( active player, a player that has an attribute which is a foreign key of the match he plays in + number of points)
-Meci ( game )

Functional features:
1. Display all the players for a chosen team.
2. Display all the players that played in a chosen game.
3. Display all the games from a certain time period.
4. Calculate and display the score for a chosen game.

I've also created a GUI using Windows Forms.
Data was saved using PostgreSQL.
Concepts used : Inheritance, Linq, Delegates, SQL, Foreign keys, Service Repository pattern.

