EXTERNAL Voice1(Audios)
EXTERNAL Voice2(Audios2)
EXTERNAL Voice3(Audios3)
EXTERNAL Voice4(Audios4)
EXTERNAL Voice5(Audios5)
EXTERNAL Achievement(Achievement)

Hej... Hvad vil du???
~Voice1("Starting")
->My_Choices
== My_Choices ==
 * [Skal i have en drink?] -> Explain
 * [Må jeg være med?] -> Drink
 * [Gå igen] -> Ends


== Explain ==
~Voice2("Starting")
NEJ TAK, VI HAR DET FINT! Vi vil ikke have det der djævlebryg, vi har vigtigere ting at tage os til.
* [→] -> Explain2
->Explain2

== Explain2 ==
~Voice3("Starting")
Ehm..hva? Jeg er sgu da kun kommet her for at drikke???
* [→] -> Explain3

== Explain3 ==
~Voice4("Starting")
HVAAAAA! Du kan da ikke mene at du er kommet her for at drikke når vi sidder og spiller! Det er langt vigtigere!
~Achievement(1)

->My_Choices

== Drink ==
~Voice5("Starting")
Øhhh. Det er et 2 personer spil. Sååååå nej du kan ikke være med...
->My_Choices


== Ends ==
->END