using UnityEngine;
using System.Collections;

public class ConsumableController : MonoBehaviour {
    CharacterStats stats;

	void Start () {
        stats = GetComponent<Player>().characterStats;
	}

    public void ConsumeItem(Item item)
    {
        GameObject itemToSpawn = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        if (item.ItemModifier)
        {
            itemToSpawn.GetComponent<IConsumable>().Consume(stats);
        }
        else
        {
            itemToSpawn.GetComponent<IConsumable>().Consume();
        }
        
    }

}
