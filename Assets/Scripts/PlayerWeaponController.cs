using UnityEngine;
using System.Collections;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    Item currentlyEquippedItem;
    IWeapon equippedWeapon;
    CharacterStats characterStats;

    void Start()
    {
        spawnProjectile = transform.FindChild("ProjectileSpawn");
        characterStats = GetComponent<Player>().characterStats;
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if (EquippedWeapon != null)
        {
            InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(EquippedWeapon.transform.gameObject);
        }


        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),
            playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null)
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        equippedWeapon.Stats = itemToEquip.Stats;
        currentlyEquippedItem = itemToEquip;
        characterStats.AddStatBonus(itemToEquip.Stats);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            PerformWeaponAttack();
        if (Input.GetKeyDown(KeyCode.Z))
            PerformWeaponSpecialAttack();
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack(CalculateDamage());
    }
    public void PerformWeaponSpecialAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }

    private int CalculateDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue()*2) +
            Random.Range(2,8);
        damageToDeal += CalculateCrit(damageToDeal);
        Debug.Log("Dommage donnés: " + damageToDeal);
        return damageToDeal;
    }

    private int CalculateCrit(int damage)
    {
        if (Random.value <= .10f)
        {
            int critDamage = (int)(damage * Random.Range(.5f, .75f));
;            return critDamage; 
        }
        return 0;
    }
}