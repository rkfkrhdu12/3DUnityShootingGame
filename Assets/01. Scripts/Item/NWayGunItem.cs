using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWayGunItem : GunItem
{
    public override void Fire(Quaternion startRotation)
    {
        if (null != _bulletPrefab)
        {
            Quaternion shotRotation = startRotation;
           
            float yRotOffset = 10.0f;

            float yRot = -(_wayCount - 1) * (yRotOffset / 2);
            //float yRot =  -(WayCount /2) * yRotOffset;

            for (int i = 0; i <= _wayCount - 1; i++)
            {
                shotRotation = Quaternion.Euler(.0f, yRot + (yRotOffset * i), .0f) * startRotation;
                GameObject bulletObject = GameObject.Instantiate(_bulletPrefab, transform.position, shotRotation);
                bulletObject.transform.localScale = Vector3.one;
            }
        }
    }
}