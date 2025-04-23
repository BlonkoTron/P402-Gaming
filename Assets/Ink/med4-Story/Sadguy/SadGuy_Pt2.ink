EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio2)
EXTERNAL Voice3(Audio2)
EXTERNAL Drink(Drink)

~Voice1("Starting")
...Elsker du ikke også bare livet???
->My_Choices

== My_Choices ==
 * [Skal vi dele en drink?] -> Explain
 * [Er du okay?] -> okays
  * [Du går igen] -> Ends


== Explain ==
~Voice2("Starting")
~Drink(0.1)
Ved du hvad.. Det er lige præcis hvad jeg har brug for lige nu..
->My_Choices

== okays ==
~Voice3("Starting")
Ikke umiddelbart det har været en... interessant uge. Men bare rolig! efter denne her får jeg det.. meget bedre. 
->My_Choices


== Ends ==
->END
