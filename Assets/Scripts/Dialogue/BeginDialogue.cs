using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginDialogue : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueScript; // Reference to your DialogueScript component.
    [SerializeField] private Characters characterObject; // Reference to the Character scriptable object you want to use.

    private void Start()
    {
        // Call the StartDialogue method to initiate the dialogue when the scene loads.
        dialogueScript.StartDialogue(characterObject);
    }
}
