using UnityEngine;
using System.Collections;

public class Npc : Interactable {

    public string[] dialogue;
    public string name;

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);
        Debug.Log("Interacting with NPC.");
    }

}
