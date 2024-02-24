using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy {
    void Damage(float dmg);
    void Dead();

    void SetHp(float health);
}
