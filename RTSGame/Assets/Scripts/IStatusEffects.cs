using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatusEffects
{
    void ApplyEffect(Units u);
    void ApplyEffect(Buildings b);

    void Effect(Units u);
    void Effect(Buildings b);
}
