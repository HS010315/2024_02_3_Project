using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour, ISkillTarget
{
    public int Health { get; set; } = 50;

    public void ApplyEffect(ISkillEffect effect)
    {
        effect.Apply(this);
    }
}