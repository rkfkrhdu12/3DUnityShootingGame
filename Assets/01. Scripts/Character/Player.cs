using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    override protected void UpdateProcess()
    {
        CheckMouseLock();

        UpdateInput();
        UpdateRotate();
        UpdateState();
    }

    // State

    protected override void InitState()
    {
        base.InitState();

        State idleState = new PlayerIdleState();
        idleState.Init(this);
        _stateDic[eState.IDLE] = idleState;

        State attackState = new PlayerAttackState();
        attackState.Init(this);
        _stateDic[eState.IDLE] = attackState;
    }

    // Item

    protected override void InitItem()
    {
        _gun = GunObject.AddComponent<GunItem>();
        _gun.SetBullet(BulletPrefab);
    }

    // Input

    bool _mouseLock = true;

    void CheckMouseLock()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _mouseLock = !_mouseLock;
        }

        if (_mouseLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void UpdateInput()
    {
        _inputAniDir = eInputDir.NONE;

        _inputVerticalDir = eInputDir.NONE;
        if (Input.GetKey(KeyCode.W))
        {
            _inputVerticalDir = eInputDir.FRONT;
            _inputAniDir = eInputDir.FRONT;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _inputVerticalDir = eInputDir.BACK;
            _inputAniDir = eInputDir.BACK;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            _inputVerticalDir = eInputDir.FRONTWALK;
            _inputAniDir = eInputDir.FRONTWALK;
        }

        _inputHorizontalDir = eInputDir.NONE;
        if (Input.GetKey(KeyCode.A))
        {
            _inputHorizontalDir = eInputDir.LEFT;
            _inputAniDir = eInputDir.LEFT;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _inputHorizontalDir = eInputDir.RIGHT;
            _inputAniDir = eInputDir.RIGHT;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A))
        {
            _inputHorizontalDir = eInputDir.LEFTWALK;
            _inputAniDir = eInputDir.LEFTWALK;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D))
        {
            _inputHorizontalDir = eInputDir.RIGHTWALK;
            _inputAniDir = eInputDir.RIGHTWALK;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ChangeState(eState.ATTACK);
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            ChangeState(eState.IDLE);
        }
    }

    override protected void UpdateRotate()
    {
        if (false == _mouseLock)
            return;

        float rateSpeed = 360.0f;
        float addRotationY = Input.GetAxis("Mouse X") * rateSpeed;
        _rotationY += (addRotationY * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0.0f, _rotationY, 0.0f);
    }
    
}
