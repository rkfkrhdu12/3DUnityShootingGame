using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{
    bool _isShot = false;

    Quaternion _characterRotation;

    override public void Start()
    {
        _characterRotation = _character.CharacterModel.transform.localRotation;

        _isShot = false;
        _shotTime = _character.GetShotSpeed();
        _character.GetAnimationModule().Play("attack", null, null, () =>
        {
            _isShot = true;
        });
    }

    public override void Stop()
    {
        _character.CharacterModel.transform.localRotation = _characterRotation;
    }

    override public void Update()
    {
        base.Update();
        _character.CharacterModel.transform.localPosition = Vector3.zero;

        UpdateShot();
        _character.UpdateMove();
    }


    float _shotTime = 0.0f;

    void UpdateShot()
    {
        _character.CharacterModel.transform.localPosition = Vector3.zero;

        if (!_isShot)
            return;

        if(_character.GetShotSpeed() <= _shotTime)
        {
            _shotTime = 0.0f;
            Shot();
        }
        _shotTime += Time.deltaTime;
    }

    void Shot()
    {
        _character.Shot();
    }
}