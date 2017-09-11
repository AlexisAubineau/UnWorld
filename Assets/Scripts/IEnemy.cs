using UnityEngine;
using System.Collections;

public interface IEnemy {

    int Experience { get; set; }
    //void Die();
    void TakeDamage(int amount);
    void PerformAttack();

}
