using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public abstract class Units : MonoBehaviour
{
    /// <summary>
    /// Movement stats
    /// </summary>
    public float Movement_Speed = 0f;
    public float Vision_Range = 0f;
    public bool flying = false;

    /// <summary>
    /// Attack stats
    /// </summary>
    public Attacks[] Atacks;

    /// <summary>
    /// overall stats
    /// </summary>
    public int Health = 0;
    public int Mana = 0;
    public int Energy = 0;
    public float Armor = 0f;

    /// <summary>
    /// Status Stats
    /// </summary>
    public IStatusEffects[] CurrentStatusEffects;
    public Damagetypes[] Immunities;
    public Dictionary<Damagetypes, float> Resistances;
    public Dictionary<Damagetypes, float> Vulnerabilites;

    private void StatusEffectsEffect()
    {
        if (CurrentStatusEffects.Length == 0)
            return;
        for (int i = 0; i < CurrentStatusEffects.Length; i++)
        {
            CurrentStatusEffects[i].Effect(this);
        }
    }

    private void TakeDamage(float Damage, Damagetypes Dtype)
    {
        if (Immunities.Contains(Dtype))
            return;

        float x = 0;
        if (Resistances.TryGetValue(Dtype, out x))
            Damage *= x;
        else if (Vulnerabilites.TryGetValue(Dtype, out x))
            Damage *= x;

        //Still need to calculate Armor

        Health -= (int)Damage;
        if (Health<1)
            Die();
    }

    private void Die()
    {
        //play Death Animation
        Destroy(this);
    }
}
