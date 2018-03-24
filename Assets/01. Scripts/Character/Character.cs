using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject CharacterModel;

    void Start()
    {
        InitItem();
        InitState();
        ChangeState(eState.IDLE);
    }

    protected void Update()
    {
        UpdateProcess();
    }
    
    virtual protected void UpdateProcess()
    {
        UpdateRotate();
        UpdateState();
    }

    // State

    public enum eState
    {
        IDLE,
        MOVE,
        ATTACK,
        FIND_TARGET,
    }

    State _currentState;
    protected Dictionary<eState, State> _stateDic = new Dictionary<eState, State>();

    virtual protected void InitState()
    {
        State idlestate = new IdleState();
        State movestate = new MoveState();
        State attackstate = new AttackState();
        State findTargetstate = new FindTargetState();

        idlestate.Init(this);
        movestate.Init(this);
        attackstate.Init(this);
        findTargetstate.Init(this);

        _stateDic.Add(eState.IDLE, idlestate);
        _stateDic.Add(eState.MOVE, movestate);
        _stateDic.Add(eState.ATTACK, attackstate);
        _stateDic.Add(eState.FIND_TARGET, findTargetstate);
    }

    protected void UpdateState()
    {
        _currentState.Update();
    }

    public void ChangeState(eState nextState)
    {
        if (null != _currentState)
        {
            _currentState.Stop();
        }
        _currentState = _stateDic[nextState];
        _currentState.Start();
    }

     // Input

    public enum eInputDir
    {
        NONE,
        FRONT,
        BACK,
        LEFT,
        RIGHT,
        FRONTWALK,
        LEFTWALK,
        RIGHTWALK,
    }
    protected eInputDir _inputVerticalDir = eInputDir.NONE;
    public eInputDir GetInputVerticalDir() { return _inputVerticalDir; }

    protected eInputDir _inputHorizontalDir = eInputDir.NONE;
    public eInputDir GetInputHorizontalDir() { return _inputHorizontalDir; }

    protected eInputDir _inputAniDir = eInputDir.NONE;
    public eInputDir GetAniDirection() { return _inputAniDir; }

    // Rotate

    protected float _rotationY = 0.0f;

    virtual protected void UpdateRotate()
    {

    }
    
    // Move

    [SerializeField]
    Vector3 _addPosition = Vector3.zero;

    public void UpdateMove()
    {
        _addPosition = Vector3.zero;

        switch (_inputVerticalDir)
        {
            case eInputDir.FRONT:
                _addPosition.z = MoveOffset(6.0f);
                break;
            case eInputDir.BACK:
                _addPosition.z = MoveOffset(-4.0f);
                break;
            case eInputDir.FRONTWALK:
                _addPosition.z = MoveOffset(3.0f);
                break;
                /*
            case eInputDir.NONE:
                _addPosition.z = MoveOffset(0.0f);
                break;
                */
        }

        switch (_inputHorizontalDir)
        {
            case eInputDir.LEFT:
                _addPosition.x = MoveOffset(-4.0f);
                break;
            case eInputDir.RIGHT:
                _addPosition.x = MoveOffset(4.0f);
                break;
            case eInputDir.LEFTWALK:
                _addPosition.x = MoveOffset(-2.0f);
                break;
            case eInputDir.RIGHTWALK:
                _addPosition.x = MoveOffset(2.0f);
                break;
                /*
            case eInputDir.NONE:
                _addPosition.x = MoveOffset(0.0f);
                break;
                */
        }

        transform.position += (transform.rotation * _addPosition);
    }

    float MoveOffset(float moveSpeed)
    {
        return (moveSpeed * Time.deltaTime);
    }

    //Item

    public GameObject GunObject;
    public GameObject BulletPrefab;

    protected GunItem _gun;

    virtual protected void InitItem()
    {
        _gun = GunObject.AddComponent<NWayGunItem>();
        //_gun = GunObject.AddComponent<SparialGunItem>();
        _gun.SetBullet(BulletPrefab);
    }



    // Gun

    public Character _target = null;
    virtual public void FindTarget() { _target = null; }
    public Character GetTarget() { return _target; }

    public void Look(Character character) { transform.LookAt(character.transform); }
    
    public void Shot() { _gun.Fire((Quaternion)transform.rotation); }
    public float GetShotSpeed() { return _gun.GetShotSpeed(); }

    // Animation

    public AnimationModule GetAnimationModule()
    {
        return CharacterModel.GetComponent<AnimationModule>();
    }
}
