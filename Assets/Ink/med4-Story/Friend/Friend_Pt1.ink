EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio2)
Hey? Er du oppe? Du gik ret hårdt til den i går 
~Voice1("Starting")
->My_Choices
== My_Choices ==
 * [Hvad snakker du om?] -> Storys


== Storys ==
~Voice2("Ending")
Kan du virkeligt ikke huske noget?? Helt ærligt…. 
->My_Choices2

== My_Choices2 ==
 * [Ikke rigtigt....] -> Ends
 
 == Ends ==
->END