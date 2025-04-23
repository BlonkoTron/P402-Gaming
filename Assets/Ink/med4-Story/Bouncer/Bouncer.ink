EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio2)
Godaften. Nu ik nogen ballade.. vel?

->My_Choices
== My_Choices ==
~Voice1("Starting")
 * [Nej selvfølgelig ikke] -> Good1
 * [Jeg laver ikke andet] -> Good2


== Good1 ==
Yes yes... Opfør jer nu bare pænt, OK?
~Voice2("Ending")
* [Afslut] -> Ends
->END

== Good2 ==
Yes yes... Opfør jer nu bare pænt, OK?
~Voice2("Ending")
* [Afslut] -> Ends

== Ends ==
->END
