VAR choiceOne = false//variable that unity code can influence

->introElder//goes into the introElder knot

===introElder===

The elder asks where Nolwazi is going?#speaker:Elder #portrait:confused
    + [{choiceOne:  Hello| ? }]
        {choiceOne:The elder slaps his thigh and laughs! ->main | The elder doesn't seem to understand you. ->introElder  }
    * You now understand the language#speaker:Nolwazi #potrait:answer
        ~choiceOne = true
        ->introElder
->DONE
=== main ===
Ah yes Nolwazi, you can now understand me!#speaker:Elder #portrait:happy
->DONE