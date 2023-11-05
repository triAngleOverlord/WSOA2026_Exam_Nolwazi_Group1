VAR choiceOne = true

->introElder

===introElder===

The elder asks where Nolwazi is going?
    + [{choiceOne: ? | Hello }]
        {choiceOne: The elder doesn't seem to understand you. ->introElder | The elder slaps his thigh and laughs! ->main }
    * You now understand the language
        ~choiceOne = false
        ->introElder
->DONE 
=== main ===
Ah yes Nolwazi, you can now understand me!
->DONE