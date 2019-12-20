using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	[SerializeField]
	private GameObject _monster;
	[SerializeField]
	private Transform[] points;
	[SerializeField]
	private float _nextLaunch, _minDelay = 1, _maxDelay = 3;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > _nextLaunch)
		{
			int _randomPoint = Random.Range(0, 3);
			var position = points[_randomPoint].position;

			Instantiate(_monster, position, Quaternion.identity);
			_nextLaunch = Time.time + Random.Range(_minDelay, _maxDelay);
		}
	}
}
