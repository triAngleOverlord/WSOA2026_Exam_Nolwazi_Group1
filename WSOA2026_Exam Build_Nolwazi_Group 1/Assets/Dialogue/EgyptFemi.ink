
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
 +[next] -> next
 

 
 ->Bargain_Choice
 ==Bargain_Choice==
 +[Accept Femi's conditions]->Accept
 +[Reject Femi's conditions]->Reject
 
 ->Bargain2_Choice
 ==Bargain2_Choice==
 +[Reconsider Femi's conditions]->Reconsider
 
 ==Respect==
Nolwazi: As-salamu alaykum Auntie. I am Nolwazi. I am on a quest and I believe you might have something that will help me Edrice sent me and told me of a necklace in your possession.#speaker:1Nolwazi #potrait:happyNolwazi
 


Femi: Is this another one of Edrice’s tricks to get my necklace? I've had that necklace for years and I plan on selling it young lady. I will not be giving it away for free. What do you have in return? #speaker:2Femi #potrait:angryFemi
->Next_Choice
->DONE

==Next==
NOLWAZI: I’m willing to bargain with you, anything you want, just say the word. #speaker:1Nolwazi #potrait:neutralNolwazi

FEMI: Why is this necklace so important to you anyway? It’s a battered old thing of little value. #speaker:2Femi #potrait:angryFemi

NOLWAZI: That can’t be true. Anyway, It is a clue to solving a puzzle left by my grandmother, her name was Nandi you might have known her. #speaker:1Nolwazi #potrait:neutralNolwazi



           FEMI:Yes I knew her, she was always kind to me.Mmmmh… Okay girlie, If what you say is true and you really want the necklace, I’ll make you a deal. Go to the local market and trade in your gold bracelet  for 150 gold coin. Then go to Kareem and say aunty Femi sent you and get bay leaves, Saffron, Anise, Sumac and Incense. He should give you 27 gold coins back. Go back to the little children running around and split the coins equally between them and they shall give you a beaded necklace back, bring that beaded necklace to me.#speaker:2Femi #potrait:angryFemi

           ->Bargain_Choice
           ==Accept==
           Nolwazi: Fine.#speaker:1Nolwazi #potrait:neutralNolwazi
           
           Femi: Once I have all those things, only then will I give you the necklace back.
           ->Next_Choice2
           ->DONE
           
           ==Reject==
           Nolwazi: That is too much to ask for a necklace.#speaker:1Nolwazi #potrait:neutralNolwazi
           
           Femi: If you do not like it, then you can leave!
           
           ->Bargain2_Choice
           ==Reconsider==
           Nolwazi: Okay Fine, I will do it.#speaker:1Nolwazi #potrait:neutralNolwazi
           
           Femi: Good, once you have all those things, then I will give you the necklace.
           ->Next_Choice2
           ->DONE
           


-> DONE

==General==
Nolwazi:Hello, I am Nolwazi.#speaker:1Nolwazi #potrait:neutralNolwazi

Femi: I have no interest in whateveryou have to say. Goodbye!.#speaker:2Femi #potrait:angryFemi
->Other_choice

==respect==
Femi: Oh you have learnt some respect now.Is this another one of Edrice’s tricks to get my necklace? I've had that necklace for years and I plan on selling it young lady. I will not be giving it away for free. What do you have in return?.#speaker:2Femi #potrait:angryFemi
->Next_Choice
->DONE


->Next_Choice2
==next==
Nolwazi: Here are all the things you asked for. #speaker:1Nolwazi #potrait:neutralNolwazi

FEMI: (reluctantly) Here, take the darn thing. It's caused enough trouble..#speaker:2Femi #potrait:angryFemi

NOLWAZI: Edrice told me the story of this necklace. I know Ahmed broke your heart. #speaker:1Nolwazi #potrait:neutralNolwazi

FEMI: Do not talk about things you do not understand, girl. You have your necklace, now go!.#speaker:2Femi #potrait:angryFemi

NOLWAZI: Actually I do understand. I understand what it feels like to live with regrets. And I can tell you now that you are missing out on a valuable friendship,the anger you are holding onto is not worth it Femi, you are only hurting yourself. let it go. #speaker:1Nolwazi #potrait:neutralNolwazi

FEMI: I said get out!.#speaker:2Femi #potrait:angryFemi

NOLWAZI: No. I will not leave until you agree to come with me. Edrice needs her friend and so do you.#speaker:1Nolwazi #potrait:neutralNolwazi 

FEMI: (Considers) Fine. .#speaker:2Femi #potrait:angryFemi







 -> DONE
