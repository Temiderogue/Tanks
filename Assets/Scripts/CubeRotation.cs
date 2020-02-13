using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(30,14,33)*Time.deltaTime);
    }

}
