using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    private float _bulletSpeed = 35;
	
	void Update () {

        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * _bulletSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Monster")
        {
            Destroy(gameObject);
        }
    }
}   
