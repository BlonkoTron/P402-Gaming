EXTERNAL Voice1(Audio)
EXTERNAL Drink(Drink)

~Voice1("Starting")
Jaer, ska du ha 2 kolde fra kassen? 

->My_Choices
== My_Choices ==
 * [Nej tak] -> NoDrink
 * [Ja tak] -> YesDrink


== NoDrink ==
->END

== YesDrink ==
~Drink(0.1)
->END