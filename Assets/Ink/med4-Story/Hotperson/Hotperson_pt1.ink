EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio2)
EXTERNAL Voice3(Audio3)

Hvad?
~Voice1("Starting")
->My_Choices    

== My_Choices ==
 * [Du bliver intimideret og går igen..] -> Ends
 * [Jeg har en extra drink jeg gerne vil dele med dig] -> Story1
 * [Prøv på at se godt ud ] -> Story2


== Story1 ==
~Voice2("Ending")
Ad... med dig? 
->My_Choices

== Story2 ==
~Voice3("Ending")
Hvad er der galt med dig??
->My_Choices2

== My_Choices2 ==
 * [...ups] -> Ends

 == Ends ==
->END