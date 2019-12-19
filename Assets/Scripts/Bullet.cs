using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float _bulletSpeed = 35;
	
	void Update () {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * _bulletSpeed);
    }
}
