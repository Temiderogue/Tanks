using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	[SerializeField]
	private Player _player;
	[SerializeField]
	private float _monsterSpeed = 10.0f;


	void Start()
	{
		_player = GameObject.FindObjectOfType<Player>();
	}
	void Update () {
		var _playerPosition = _player.transform.position; 
		transform.LookAt(_playerPosition);
		transform.Translate(Vector3.forward * Time.deltaTime * _monsterSpeed);
	}
}
