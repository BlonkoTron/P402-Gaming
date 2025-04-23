EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio2)
EXTERNAL Voice3(Audio2)
EXTERNAL Achievement(Achievement)
~Voice1("Starting")
Hey... Hva..Hvad vil du?

->My_Choices
== My_Choices ==
 * [Hvad Drikker du?] -> Explain
 * [Er du okay?] -> Drink
  * [Gå igen] -> Ends


== Explain ==
~Voice2("Starting")
Du ved.. D-det bare en simpel fadøl, det jeg drikker...
->My_Choices

== Drink ==
~Voice3("Starting")
Ja.. jeg tror bare jeg er lidt træt. Vil du ikke være sød og lade mig være i fred.
~Achievement(3)

->My_Choices


== Ends ==
->END
