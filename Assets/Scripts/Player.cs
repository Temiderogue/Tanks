using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private float _moveVertical, _rotate;


    private float _speed = 20.0f, _rotationSpeed = 160.0f;


    [SerializeField] private float _nextshot = 0.23f, _shotDelay = 0.34f;

    [SerializeField] private GameObject _bullet, _gun;

    private Rigidbody _tank;

    [SerializeField] private NavMeshSurface _surface;

    private Health _health;

    public int Score;

    [SerializeField] private Text _scoreText;
    [SerializeField] private Canvas _restartScreen;
    [SerializeField] private GameObject _brokenTank;

    private bool _isPaused = false;

    void Start()
    {
        Score = 0;
        _restartScreen.enabled = false;
        _health = GetComponent<Health>();
        StartCoroutine("Building");
        _tank = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!_isPaused)
        {
            _moveVertical = Input.GetAxis("Vertical") * _speed;
            _rotate = Input.GetAxis("Horizontal") * _rotationSpeed;

            _moveVertical *= Time.deltaTime;
            _rotate *= Time.deltaTime;

            _tank.transform.Translate(0, 0, _moveVertical);
            _tank.transform.Rotate(0, _rotate, 0);

            _scoreText.text = "Score:" + Score;

            if (Time.time > _nextshot && Input.GetKey(KeyCode.X))
            {
                _nextshot = Time.time + _shotDelay;

                Vector3 _startPos = _gun.transform.position;

                Quaternion _startRot = _gun.transform.rotation;
                AudioManager.PlaySound("Shoot");
                Instantiate(_bullet, _startPos, _startRot);

            }

            if (_health._currentHealth <= 0)
            {
                OnPlayerDeath();
            }
        }
    }

    IEnumerator Building()
    {
        yield return new WaitForSeconds(1f);
        _surface.BuildNavMesh();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            AudioManager.PlaySound("TankHit");
            _health.ModifyHealth(-10);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HealPoint" && _health._currentHealth < 100)
        {
            AudioManager.PlaySound("Heal");
            _health.ModifyHealth(20);
            Destroy(other.gameObject);
        }
    }

    public void OnPlayerDeath()
    {
        _isPaused = true;
        _restartScreen.enabled = true;
        Time.timeScale = 0.25f;
        AudioManager.PlaySound("PlayerDeath");
        Instantiate(_brokenTank, transform.position, transform.rotation);
        Destroy(gameObject);  
    }
}
