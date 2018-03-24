using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    override public void Start()
    {
        _prevDirection = Character.eInputDir.NONE;
        UpdateAnimation();
    }

    override public void Update()
    {
        if (Character.eInputDir.NONE == _character.GetInputVerticalDir() &&
            Character.eInputDir.NONE == _character.GetInputHorizontalDir())
        {
            _character.ChangeState(Character.eState.IDLE);
            return;
        }

        UpdateAnimation();

        _character.UpdateMove();
    }

    Character.eInputDir _prevDirection;
    void UpdateAnimation()
    {
        if (_prevDirection == _character.GetAniDirection())
            return;

        _prevDirection = _character.GetAniDirection();
        switch (_character.GetAniDirection())
        {
            case Character.eInputDir.FRONT:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("movefront");
                break;
            case Character.eInputDir.BACK:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("moveback");
                break;
            case Character.eInputDir.LEFT:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("moveleft");
                break;
            case Character.eInputDir.RIGHT:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("moveright");
                break;
            case Character.eInputDir.FRONTWALK:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("movefrontwalk");
                break;
            case Character.eInputDir.LEFTWALK:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("moveleftwalk");
                break;
            case Character.eInputDir.RIGHTWALK:
                _character.CharacterModel.GetComponent<Animator>().SetTrigger("moverightwalk");
                break;
        }
    }
}
