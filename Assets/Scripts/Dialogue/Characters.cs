using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Character Dialogues", order = 0)]

public class Characters : ScriptableObject
{
  public List<DialogueSection> dialogueToLoadIntoQueue = new(); 
}
[System.Serializable]
public struct  DialogueSection
{
    public string name;
    public string dialogue;
    public Sprite characterimg;
    public bool isplayercharacter; 

    public DialogueSection ( string name, string dialogue,Sprite characterimg, bool isplayercharacter)
    {
        this .name = name;
        this .dialogue = dialogue;
        this .characterimg = characterimg;
        this .isplayercharacter = isplayercharacter;

    }
}
