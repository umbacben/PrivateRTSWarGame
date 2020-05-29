using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Attacks
{
    float BaseRange;
    float BaseDamage;
    float BaseSpeed;
    Damagetypes BaseType;
    IStatusEffects? BaseStatusEffect;
}
