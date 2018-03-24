using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    override public void FindTarget()
    {
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    override protected void InitItem()
    {
        _gun = GunObject.AddComponent<SparialGunItem>();
        _gun.SetBullet(BulletPrefab);
    }
}