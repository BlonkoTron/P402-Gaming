EXTERNAL Voice1(Audio)
EXTERNAL Voice2(Audio2)
EXTERNAL Voice3(Audio3)
EXTERNAL Drink(Drink)
EXTERNAL Achievement(Achievement)

~Voice1("Starting")
JAMEN..Er det dig igen min lille rekrut?
->My_Choices

== My_Choices ==
 * [Hvad var det nu du lavede i hæren igen?] -> Explain
 * [Skal vi dele en drink eller to?] -> Drinks
 * [Du går igen] -> Ends


== Explain ==
~Voice2("Starting")
Nu skal du bare høre! Jeg var den ondeste kok i køkkenet. De kaldte mig bønne-kongen. Du kan lige tro at jeg lavede den styggeste chili-con-carne på denne klode. Men hvad de aldrig fandt ud af var, at jeg kom masser af rom og tomat i retten. Du kan lige tro at de andre soldater synes at jeg var en sand helt, da de vendte hjem efter en lang dag ude på marken. 
->My_Choices
->END

== Drinks ==
~Voice3("Starting")
JA DA! Nu skal jeg vise dig en god whisky. Det er den her, jeg drikker her. Jeg kan godt nok ikke huske hvor mange jeg har fået, men de lægger sig dejligt i maven. Ellers tager vi en gibbernakker eller to. 
~Achievement(2)
~Drink(0.1)
->My_Choices


== Ends ==
->END