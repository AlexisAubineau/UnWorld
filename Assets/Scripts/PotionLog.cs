using UnityEngine;
using System.Collections;
using System;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("Vous buvez entièrement la potion. Super !");
        Destroy(gameObject);
    }

    public void Consume(CharacterStats stats)
    {
        Debug.Log("Vous buvez entièrement la potion. Burk !");
    }
}
