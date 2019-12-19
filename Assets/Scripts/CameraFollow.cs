using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;

    private Vector3 _offset;
	void Start () {
        _offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = Player.transform.position + _offset;
	}
}
