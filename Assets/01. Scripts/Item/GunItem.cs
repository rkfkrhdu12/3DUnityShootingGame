using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
{
    // interface
    protected string _itemID = "DefaultGun";
    public int _wayCount = 1;
    protected float _ShotSpeed = .001f;
    public float GetShotSpeed() { return _ShotSpeed; }

    protected GameObject _bulletPrefab;

    public void SetBullet(GameObject bulletPrefab)
    {
        _bulletPrefab = bulletPrefab;
    }
    
    virtual public void Fire(Quaternion startRotation)
    {
        if (null != _bulletPrefab)
        {
            GameObject bulletObject = GameObject.Instantiate(_bulletPrefab, transform.position, startRotation);
        }
    }

    // script
    /*
     *private void Start()
    {
        // struct GunItemAttr
        GunItemAttr attr = ScriptManager.instance.FindGunItemAttr(_itemID);
        _ShotSpeed = attr.shotSpeed;
        _wayCount = attr.wayCount;
    }
    */
}
