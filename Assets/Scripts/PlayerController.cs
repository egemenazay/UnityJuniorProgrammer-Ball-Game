using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forceVal;
    private Rigidbody _rigidbody;
    public float powerUpPower = 15f;
    private float powerUpDuration = 5f;
    public GameObject focalPoint;
    public static bool hasPowerUp;
    private void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        _rigidbody.AddForce(Vector3.forward * verticalInput * forceVal);
        _rigidbody.AddForce(Vector3.right * horizontalInput * forceVal);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enmyRgbdy = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);
            enmyRgbdy.AddForce(awayFromPlayer * powerUpPower, ForceMode.Impulse);
            StartCoroutine(PowerUpDuration());
        }
    }

    IEnumerator PowerUpDuration()
    {
        yield return new WaitForSeconds(powerUpDuration);
        hasPowerUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            SpawnManager.isPowerUpUp = false;
            Destroy(other.gameObject);
        }
    }
}
