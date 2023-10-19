using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueAsset : ScriptableObject
{
    [System.Serializable]
    public class dialogueScene
    {
        public string NPCname;
        public Sprite NPCsprite;
        public string NPCdialogue;
    }

    public dialogueScene[] sceneDialogue;
}
