using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {

	public static ItemDatabase Instance { get; set; }
    private List<Item> Items { get; set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
        BuildDatabase();
    }

    private void BuildDatabase()
    {
        Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
        Debug.Log(Items[0].Stats[0].StatName + " level est de " + Items[0].Stats[0].GetCalculatedStatValue());
        Debug.Log(Items[0].ItemName);
    }

    public Item GetItem(string itemSlug)
    {
        foreach (Item item in Items)
        {
            if (item.ObjectSlug == itemSlug)
                return item;
        }
        Debug.LogWarningFormat("Impossible de trouver l'objet: " + itemSlug);
        return null;
    }

}
