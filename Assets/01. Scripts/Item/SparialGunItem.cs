using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparialGunItem : GunItem
{
    Quaternion _shotRotation;
    bool _isFire = false;
    
    public override void Fire(Quaternion startRotation)
    {
        if (null != _bulletPrefab)
        {
            if (false == _isFire)
                _shotRotation = startRotation;
            else
                _shotRotation = _shotRotation * Quaternion.Euler(0.0f, 2.0f, 45.0f);

            _isFire = true;
            GameObject bulletObject = GameObject.Instantiate(_bulletPrefab, transform.position, _shotRotation);
            bulletObject.transform.localScale = Vector3.one;
        }
    }
}