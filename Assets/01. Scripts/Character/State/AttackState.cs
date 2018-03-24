using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    bool _isShot = false;

    Quaternion _characterRotation;

    float _attackTime = 3.0f;
    float _attackDuration = 0.0f;

    override public void Start()
    {
        _characterRotation = _character.CharacterModel.transform.localRotation;

        _isShot = false;

        _shotTime = _character.GetShotSpeed();

        _character.GetAnimationModule().Play("attack", null, null, () =>
        {
            Debug.Log("A");
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
        if (_attackTime <= _attackDuration)
        {
            _character.ChangeState(Character.eState.IDLE);
        }
        else
        {
            UpdateShot();
            _character.UpdateMove();
        }
        _attackDuration += Time.deltaTime;
    }

    // Shot

    float _shotTime = 0.0f;

    void UpdateShot()
    {
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