﻿using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    List<BaseStat> Stats { get; set; }
    int CurrentDamage { get; set; }
    void PerformAttack(int damage);
    void PerformSpecialAttack();
}
