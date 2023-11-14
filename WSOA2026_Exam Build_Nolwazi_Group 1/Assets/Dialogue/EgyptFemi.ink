INCLUDE globals.ink
{narrativePoint==2: ->one| {narrativePoint==4:->next| ->two}}

===two===
I have nothing to say.#speaker:2Femi #potrait:angryFemi
->DONE
===one===
Greet Femi
 ->My_Choices
 ==My_Choices==
 +[Respect] -> Respect
 +[General] -> General 
 
 
 ->Other_choice
 ==Other_choice==
 +[respect.] -> respect
 
 ->Next_Choice
 ==Next_Choice==
 +[Next]-> Next
 
 ->Next_Choice2
 ==Next_Choice2==

 

 
 ->Bargain_Choice
 ==Bargain_Choice==
 +[Accept Femi's conditions]->Accept
 +[Reject Femi's conditions]->Reject
 
 ->Bargain2_Choice
 ==Bargain2_Choice==
 +[Reconsider Femi's conditions]->Reconsider
 
 ==Respect==
As-salamu alaykum Auntie. I am Nolwazi. I am on a quest and I believe you might have something that will help me#speaker:1Nolwazi #potrait:happyNolwazi 
Edrice sent me and told me of a necklace in your possession.#speaker:1Nolwazi #potrait:happyNolwazi
 
Is this another one of Edrice’s tricks to get my necklace? I've had that necklace for years and I plan on selling it young lady. #speaker:2Femi #potrait:angryFemi
I will not be giving it away for free. What do you have in return? #speaker:2Femi #potrait:angryFemi
->Next_Choice
->DONE

==Next==
I’m willing to bargain with you, anything you want, just say the word. #speaker:1Nolwazi #potrait:neutralNolwazi

Why is this necklace so important to you anyway? It’s a battered old thing of little value. #speaker:2Femi #potrait:angryFemi

That can’t be true. Anyway, It is a clue to solving a puzzle left by my grandmother, her name was Nandi you might have known her. #speaker:1Nolwazi #potrait:neutralNolwazi

Yes I knew her, she was always kind to me.Mmmmh… #speaker:2Femi #potrait:angryFemi
Okay girlie, If what you say is true and you really want the necklace, I’ll make you a deal.#speaker:2Femi #potrait:angryFemi
Go to the local market and trade in your gold bracelet  for 150 gold coins.#speaker:2Femi #potrait:angryFemi 
Then go to Kareem and say aunty Femi sent you and get bay leaves, Saffron, Anise, Sumac and Incense. #speaker:2Femi #potrait:angryFemi
He should give you 27 gold coins back.#speaker:2Femi #potrait:angryFemi

           ->Bargain_Choice
           ==Accept==
           Fine.#speaker:1Nolwazi #potrait:neutralNolwazi
           
           Once I have all those things, only then will I give you the necklace back.#speaker:2Femi #potrait:angryFemi 
           ~narrativePoint=3
           ->DONE
           
           ==Reject==
           That is too much to ask for a necklace.#speaker:1Nolwazi #potrait:neutralNolwazi
           
           If you do not like it, then you can leave!#speaker:2Femi #potrait:angryFemi
           
           ->Bargain2_Choice
           ==Reconsider==
           Okay Fine, I will do it.#speaker:1Nolwazi #potrait:neutralNolwazi
           
           Good, once you have all those things, then I will give you the necklace.#speaker:2Femi #potrait:angryFemi
           ~narrativePoint=3
           ->DONE
           


-> DONE

==General==
Hello, I am Nolwazi.#speaker:1Nolwazi #potrait:neutralNolwazi

I have no interest in whateveryou have to say. Goodbye!.#speaker:2Femi #potrait:angryFemi
->Other_choice

==respect==
Oh you have learnt some respect now.#speaker:2Femi #potrait:angryFemi
Is this another one of Edrice’s tricks to get my necklace? I've had that necklace for years and I plan on selling it young lady. #speaker:2Femi #potrait:angryFemi
I will not be giving it away for free. What do you have in return?.#speaker:2Femi #potrait:angryFemi
->Next_Choice
->DONE


->Next_Choice2
==next==
Here are all the things you asked for. #speaker:1Nolwazi #potrait:neutralNolwazi

(reluctantly) Here, take the darn thing. It's caused enough trouble..#speaker:2Femi #potrait:angryFemi

Edrice told me the story of this necklace. I know Ahmed broke your heart. #speaker:1Nolwazi #potrait:neutralNolwazi

Do not talk about things you do not understand, girl. You have your necklace, now go!.#speaker:2Femi #potrait:angryFemi

Actually I do understand. I understand what it feels like to live with regrets.#speaker:1Nolwazi #potrait:neutralNolwazi 
And I can tell you now that you are missing out on a valuable friendship,the anger you are holding onto is not worth it Femi, you are only hurting yourself. #speaker:1Nolwazi #potrait:neutralNolwazi
Let it go. #speaker:1Nolwazi #potrait:neutralNolwazi

I said get out!.#speaker:2Femi #potrait:angryFemi

No. I will not leave until you agree to come with me. Edrice needs her friend and so do you.#speaker:1Nolwazi #potrait:neutralNolwazi 

(Considers) Fine.#speaker:2Femi #potrait:angryFemi #action:end
~narrativePoint=5
 -> DONE
