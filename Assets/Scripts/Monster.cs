using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{

	[SerializeField] 
	private GameObject _player;
	[SerializeField]
	private float _monsterSpeed = 10.0f;

	private NavMeshAgent _navMeshAgent;
	private Vector3 _playerTransform;

	private Animator _animator;

	private Health _health;

	[SerializeField]
	private GameObject _healPoint;

	Player _playerScript;
	private void Start()
	{
		_health = GetComponent<Health>();
		_player = GameObject.FindWithTag("Player");
		_playerScript = _player.GetComponent<Player>();
		_animator = GetComponent<Animator>();
		_navMeshAgent = GetComponent<NavMeshAgent>();
	}

	private void Update()
	{
		if (_health._currentHealth <= 0)
		{
			Destroy(gameObject);
			int _randomNum = Random.Range(0, 20);
			if (_randomNum > 15)
			{
				Instantiate(_healPoint, transform.position, Quaternion.identity);
			}
			_playerScript.Score++;
		}
	}

	private void FixedUpdate()
	{
		_navMeshAgent.SetDestination(_player.transform.position);
	}

	private void OnTriggerEnter(Collider _collider)
	{
		if (_collider.tag == "Bullet")
		{
			AudioManager.PlaySound("MonsterHit");
			_health.ModifyHealth(-20);
		}
	}
}