using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody _enmyRgbdy;
    public float speed;

    private void Start()
    {
        _enmyRgbdy = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enmyRgbdy.AddForce( lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
