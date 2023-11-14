INCLUDE globals.ink
{narrativePoint==2: ->one | ->DONE}
===one===
Nolwazi: Hey what do you think you're doing! It's not good to steal #speaker:1Nolwazi #portrait:angryNolwazi

Lekon: I'm sorry, I'm just hungry. #speaker:2Lekon #potrait sadLekon

Nolwazi: Oh my, Where do you live? Where is your mother? #speaker:1Nolwazi #portrait:sadNolwazi 

Lekon: I live there under that stalI. I don’t know my mother; I don’t have one.#speaker:2Lekon #potrait sadLekon

Nolwazi: I’m so sorry. Is there no one else you know here? Are you all alone?#speaker:1Nolwazi #portrait:sadNolwazi 

Lekon: *Nods* #speaker:2Lekon #potrait sadLekon



-> Boy_Choices
== Boy_Choices ==
+[Give Lekon Money]-> Give
+[Take Lekon with you]-> Take

-> DONE 
== Give ==
Nolwazi: Okay, I'm going to give you some coins. You have to promise to use them wisely okay. #speaker:1Nolwazi #potrait: neutralNolwazi

Lekon: *Nods* Thank you Madame.#speaker:2Lekon #potrait sadLekon

-> Boy_Continue
== Boy_Continue ==
+[You are stil lost,ask Lekon for directions]-> Youarestilllost

-> DONE


== Youarestilllost ==
Nolwazi: Do you know where the marketplace

Lekon: Yes, follow me, I can show you.
~narrativePoint=3
-> DONE

...

== Take ==
Nolwazi: Okay, you're going to come with me. There must be someone in this market place that might be able to take you. Do you know where it is?#speaker:1Nolwazi #potrait: neutralNolwazi

Lekon: Yes I do. You can follow me.#speaker:2Lekon #potrait sadLekon

Nolwazi: Great #speaker:1Nolwazi #potrait: neutralNolwazi

~narrativePoint=3
-> DONE