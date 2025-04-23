EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio2)
EXTERNAL Voice3(Audio3)
EXTERNAL Achievement(Achievement)

~Voice1("Starting")
Nå! Hvad kan jeg gøre for dig lille pjut?

->My_Choices
== My_Choices ==
 * [Kan jeg høre om din tid i hæren?] -> Explain
 * [Hvad drikker du?] -> Drink
  * [Gå væk igen] -> Ends


== Explain ==
~Voice2("Starting")
Helt sikkert. De kaldte mig ”rense dyret”! Jeg var den hurtigste med en moppe. Gulvet stod ikke en chance og lignede et spejl. Jeg vandt endda den årlige pris som “MR clean”. Og jeg var også grunden til de puttede brækmiddel i håndspritten.
->My_Choices
->END

== Drink ==
~Voice3("Starting")
Whisky med isterninger. Det her er kun min tredje så det er en langsom start i dag. 
~Achievement(2)
->My_Choices


== Ends ==
->END
