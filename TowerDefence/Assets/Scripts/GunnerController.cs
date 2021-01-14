using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerController : MonoBehaviour
{
    public Vector3 AttackDir;
    void Start()
    {
        AttackDir = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = AttackDir;
    }
}
