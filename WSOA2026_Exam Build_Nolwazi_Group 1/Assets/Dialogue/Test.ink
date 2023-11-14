VAR choiceOne = false//variable that unity code can influence

->introElder//goes into the introElder knot

===introElder===

The elder asks where Nolwazi is going?#speaker:2Elder #portrait:confusedElder
    + [{choiceOne:  Hello| ? }]
        {choiceOne:The elder slaps his thigh and laughs! ->main | The elder doesn't seem to understand you. ->introElder  }
    * You now understand the language#speaker:1Nolwazi #portrait:nolwaziAnswer #give: redbook
        ~choiceOne = true
        ->introElder
->DONE
=== main ===
Ah yes Nolwazi, you can now understand me!#speaker:2Elder #portrait:happyElder
->DONE