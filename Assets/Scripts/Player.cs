using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float _moveVertical, _rotate;

    [SerializeField]
    private float _speed = 20.0f, _bulletSpeed = 20.0f;
    [SerializeField]
    private float _rotationSpeed = 120.0f;

    [SerializeField]
    private float _nextshot = 0.2f ,_shotDelay;

    [SerializeField]
    private GameObject _bullet, _gun, _spawnBullet;

   

    // Update is called once per frame
    void Update () {
        _moveVertical = Input.GetAxis("Vertical") * _speed;
        _rotate = Input.GetAxis("Horizontal") * _rotationSpeed;
        _moveVertical *= Time.deltaTime;
        _rotate *= Time.deltaTime;
        transform.Translate(0, 0, _moveVertical);
        transform.Rotate(0, _rotate, 0);

        if (Time.time > _nextshot && Input.GetButton("Fire1"))
        {
            _nextshot = Time.time + _shotDelay;

            Vector3 _startPos = _gun.transform.position;

            Quaternion _startRot = _gun.transform.rotation;

            _spawnBullet = Instantiate(_bullet, _startPos, _startRot);

            Rigidbody _rb = _spawnBullet.GetComponent<Rigidbody>();

            _rb.AddForce(_spawnBullet.transform.forward * _bulletSpeed, ForceMode.Impulse);
        }
    }
}
