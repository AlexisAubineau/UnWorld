using UnityEngine;
using System.Collections;

public class PickupItem : Interactable {
    public Item ItemDrop { get; set; }
    public override void Interact()
    {
        Debug.Log("looting initialisé");
        InventoryController.Instance.GiveItem(ItemDrop);
        Destroy(gameObject);
    }

}
