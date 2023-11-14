INCLUDE globals.ink
{narrativePoint==2: ->one | ->two}

===one===

EXT. EASTERN VILLAGE - ELOMBE'S HOME - DAY

NOLWAZI arrives at Elombe's doorstep. Elombe, initially hesitant, eases when he notices the mask Nolwazi carries.

Who are you, and what brings you here?  #speaker2:Elombe #portrait:seriousElombe

Greetings, Elombe. I come seeking information about Moziki. #speaker1:Nolwazi #portrait:neutralNolwazi


->My_Choices
==My_Choices==
+[Do not show Elombe the mask]->Donot
+[Reveal the mask to Elombe]-> Reveal

->My_Choice
==My_Choice==
+[Next]->Next

==Donot==
Nolwazi does not show Elombe the mask and he remains skeptical of her
->My_Choice
->DONE

==Reveal==
Nolwazi reveals the mask to Elombe and his demeanor shifts slightly
->My_Choice
->DONE


==Next==
Ah, a familiar sight. Why do you carry a mask like mine? #speaker2:Elombe #portrait:niceElombe

It belonged to my Grandmother, I believe it was a gift. Do you recognize her in this photo? #speaker1:Nolwazi #portrait:neutralNolwazi

Your grandma, you say? I recall a similar mask. It was in her possession, but I can't place her face. My wife's mother might know more.  #speaker2:Elombe #portrait:seriousElombe

Your wife's mother?#speaker1:Nolwazi #portrait:neutralNolwazi

Yes, she's in that picture taken at the elder's daughter's wedding. Sadly, my son-in-law recently passed away. #speaker2:Elombe #portrait:seriousElombe

I'm sorry to hear that. The elder mentioned a drink at the wedding, Cham-cham. What is it?#speaker1:Nolwazi #portrait:neutralNolwazi

Cham-cham, a drink poured on the floor for our ancestors. A tradition. Here, take this bottle as a condolence gift for the elder.#speaker2:Elombe #portrait:seriousElombe

+[Accept the bottle]
-Elombe hands a bottle to Nolwazi.

And speaking of gifts, here's my mask. My wife's is by that wall. I've forgotten its importance since the officials arrived.#speaker2:Elombe #portrait:seriousElombe


Thank you. Could you also tell me who Moziki is?#speaker1:Nolwazi #portrait:happyNolwazi

Elombe: Moziki was part of organizing the wedding#speaker2:Elombe #portrait:niceElombe

---

The scene fades as Nolwazi absorbs the newfound information, her journey to unravel the mystery deepening.She makes her way back to the Elder.
~narrativePoint=3
->END

===two===
Elombe stands watching the officials
->DONE
