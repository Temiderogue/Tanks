using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    [SerializeField] private float _bulletSpeed;

    Rigidbody _bullet;
    private void Start()
    {
        _bullet = GetComponent<Rigidbody>();
        _bullet.AddForce(transform.forward * _bulletSpeed);
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }
}   
