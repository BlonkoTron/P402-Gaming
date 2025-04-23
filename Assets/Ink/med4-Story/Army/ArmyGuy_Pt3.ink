EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio2)
EXTERNAL Voice3(Audio2)
EXTERNAL Drink(Drink)
EXTERNAL Achievement(Achievement)

~Voice1("Starting")
JAmeN..Ohøj.. Kender jeg..Ehh...Dig der??? 
->My_Choices

== My_Choices ==
 * [Lige e-en sidste gang. H-hvad lavede du i hæren?] -> Explain
 * [vi-il du have en dri-ink mer?] -> Drinks
  * [Du går igen] -> Ends


== Explain ==
~Voice2("Starting")
Erghhj-Ja det var gode tider. Dengang jeg var trækkerdreng.. TIL SØS. Jeg havde det mest robuste greb på molen. Vi drak af lommelærken som om det var havvand. Min kaptajn befalede mig at drikke alkohol og ryge tobak på skibet var obligatorisk. Jeg var lidt bekymret i starten men det endte med at være den bedste sommerferie jeg nogen sinde havde i 8. klasse. 
->My_Choices
->END

== Drinks ==
~Voice3("Starting")
Så skidt da. Du kan få lidt af min flaske her. Det er tid til du prøver en ordentlig drik. Absint slukker trøsten efter... det fjerde shot  
~Drink(0.1)
~Achievement("Starting")
->My_Choices


== Ends ==
->END