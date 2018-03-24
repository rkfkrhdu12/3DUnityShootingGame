using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationModule : MonoBehaviour
{
    System.Action _startCallback = null;
    System.Action _midCallback = null;
    System.Action _endCallback = null;

    public void Play(string triggerName, 
        System.Action StartCallback, System.Action midCallback, System.Action endCallback)
    {
        gameObject.GetComponent<Animator>().SetTrigger(triggerName);
        _endCallback = endCallback;
        _midCallback = midCallback;
        _startCallback = StartCallback;
    }

    public void OnStartAnimation()
    {
        if (null != _startCallback)
        {
            _startCallback();
        }
    }

    public void OnMidAnimation()
    {
        if (null != _midCallback)
        {
            _midCallback();
        }
    }

    public void OnEndAnimation()
    {
        if(null != _endCallback)
        {
            _endCallback();
        }
    }
}