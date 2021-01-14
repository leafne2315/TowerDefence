using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 AttackDir;
    public enum AttackerState{InActivated,Idle,Attacking,Die}
    public AttackerState currentState;
    private bool isActivated;
    void Start()
    {
        AttackDir = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case AttackerState.InActivated:
                transform.forward = AttackDir;
            break;

            case AttackerState.Idle:
            break;

            case AttackerState.Attacking:
            break;

            case AttackerState.Die:
            break;
        }
    }
    public void Activate()
    {
        isActivated = true;
    }
}
