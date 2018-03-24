using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletItem : MonoBehaviour
{

    // Use this for initialization
    
    float _lifeTime = 0.5f;
    void Start()
    {
        GameObject.Destroy(gameObject, _lifeTime);
    }

    float _moveSpeed = 10.0f;
    void Update()
    {
        Vector3 moveOffset = _moveSpeed * Vector3.forward;
        transform.position += (transform.rotation * moveOffset) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Destroy(gameObject);
    }
}
