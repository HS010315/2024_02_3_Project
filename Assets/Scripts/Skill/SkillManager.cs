using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SkillManager : MonoBehaviour
{
    public Player TargetPlayer;
    public Enemy TargetEnemy;

    public List<Enemy> targets = new List<Enemy>();


    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) Skill(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Skill(2);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Skill(3);
    }
    void Skill(float skill)
    {
        var fireball = new Skill<ISkillTarget, DamageEffect>("Fireball", new DamageEffect(20));
        var healSpell = new Skill<Player, HealEffect>("Heal", new HealEffect(20));
        var multiTargetSkill = new Skill<ISkillTarget, DamageEffect>("AoE Attack", new DamageEffect(10));

        switch (skill)
        {
            case 1:
                fireball.Use(TargetEnemy);
                break;
            case 2:
                healSpell.Use(TargetPlayer);
                break;
            case 3:
                foreach(var target in targets)
                {
                    multiTargetSkill.Use(target);
                }
                break;

        }
    }
}
