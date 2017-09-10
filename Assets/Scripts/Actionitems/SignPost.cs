using UnityEngine;
using System.Collections;

public class SignPost : ActionItem {

    public string[] dialogue;
    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, "Panneau");
        Debug.Log("Interacting with sign post.");
    }

}
