EXTERNAL Voice1(Audios)
EXTERNAL Voice2(Audios2)
EXTERNAL Achievement(Achievement)

Mener du virkelig at det er dig igen????? 
~Voice1("Starting")
->My_Choices

== My_Choices ==
  * [Du bliver vred og råber tilbage] -> Story
  * [Du bliver vred og råber tilbage] -> Story
  * [Du bliver vred og råber tilbage] -> Story
  
== Story ==
~Voice2("Starting")
DET DER GIDER JEG KRAFT EMMENDE IK!
~Achievement(4)
->My_Choices2

== My_Choices2 ==
  * [→] -> Ends

== Ends ==
->END