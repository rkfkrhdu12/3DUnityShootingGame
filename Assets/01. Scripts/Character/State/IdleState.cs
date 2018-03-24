using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    float _waitTime = 1.0f;
    float _waitDuration = 0.0f;

    override public void Start()
    {
        _character.CharacterModel.GetComponent<Animator>().SetTrigger("idle");
        //_character.FindTarget();

        _waitDuration = 0.0f;
        _waitTime = Random.Range(1.0f, 2.0f);

    }

    override public void Update()
    {
        if (_waitTime <= _waitDuration)
        {
            _character.ChangeState(Player.eState.FIND_TARGET);
        }
        _waitDuration += Time.deltaTime;
    }
}
/*
override public void Start()
    {
        _character.CharacterModel.GetComponent<Animator>().SetTrigger("idle");
    }

    override public void Update()
    {
        Vector3 inputVertical = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        Vector3 inputHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (0.0f != inputVertical.z || 0.0f != inputHorizontal.x)
        {
            _character.ChangeState(Player.eState.MOVE);
        }
    }
}
*/