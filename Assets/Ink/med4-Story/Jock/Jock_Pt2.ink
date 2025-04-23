EXTERNAL Voice1(Audios)
EXTERNAL Voice2(Audios2)

Hvad vil du nu? Svagpisser.
~Voice1("Starting")
->My_Choices

== My_Choices ==
  * [Du bliver intimideret og går igen] -> Ends
  * [Du bliver intimideret og går igen] -> Ends
  * [Du er sgu ikke særlig rar] -> Story
  
== Story ==
~Voice2("Starting")
  Jeg er sgu da ligeglad med hvad du mener. Smut med dig pomfrit! 
  ->My_Choices
  
== Ends ==
->END