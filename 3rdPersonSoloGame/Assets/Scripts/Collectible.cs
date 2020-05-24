using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 30, 45) * Time.deltaTime);
    }
}
