using UnityEngine;
using System.Collections;

public interface IEnemy {

    Spawner Spawner { get; set; }
    int Experience { get; set; }
    void Die();
    void TakeDamage(int amount);
    void PerformAttack();

}
