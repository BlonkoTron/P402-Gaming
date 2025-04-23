EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio)
EXTERNAL Drink(Drink)

~Voice1("Starting")
Godav igen. En flaske til? 

->My_Choices
== My_Choices ==
 * [Ikke Endnu] -> NoDrink
 * [JA TAK] -> YesDrink


== NoDrink ==
->END

== YesDrink ==
~Drink(0.1)
~Voice2("Starting")
OH..Det var hurtigt! Skal du ha en til? 
->My_Choices2

== My_Choices2 ==
 * [JA DA!] -> YesDrinkagain
 * [JA DA!] -> YesDrinkagain

== YesDrinkagain ==
~Drink(0.1)
->END