VAR choiceOne = true//variable that unity code can influence

->introElder//goes into the introElder knot

===introElder===

The elder asks where Nolwazi is going?
    + [{choiceOne:  Hello| ? }]
        {choiceOne:The elder slaps his thigh and laughs! ->main | The elder doesn't seem to understand you. ->introElder  }
    * You now understand the language
        ~choiceOne = true
        ->introElder
->DONE
=== main ===
Ah yes Nolwazi, you can now understand me!
->DONE