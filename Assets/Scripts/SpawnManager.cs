using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	[SerializeField]
	private GameObject[] _monsters;
	[SerializeField]
	private Transform[] points;
	[SerializeField]
	private float _nextLaunch, _minDelay = 1, _maxDelay = 3;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var _enemies = FindObjectsOfType<Monster>();

		if (Time.time > _nextLaunch && _enemies.Length < 10)
		{
			int _randomMonster = Random.Range(0, 2);
			int _randomPoint = Random.Range(0, 3);

			var position = points[_randomPoint].position;
			var _monster = _monsters[_randomMonster];
			Instantiate( _monster, position, Quaternion.identity);
			_nextLaunch = Time.time + Random.Range(_minDelay, _maxDelay);
		}

	}
}
