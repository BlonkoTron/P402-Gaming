EXTERNAL Voice1(Audio)
EXTERNAL Achievement(Achievement)
~Voice1("Starting")
.....

->My_Choices
== My_Choices ==
 * [e-e-e-r du ok-ay? ] -> Explain
  * [Du går igen] -> Ends


== Explain ==
~Achievement(5)
.....
->My_Choices

== Ends ==
->END
