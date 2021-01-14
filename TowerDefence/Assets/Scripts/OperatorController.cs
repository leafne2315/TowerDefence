using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorController : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 AttackDir;
    public enum OperatorState{InActivated,Idle,Attacking,Die}
    public OperatorState currentState;
    private bool isActivated;
    public float RotateYAngle;
    public LayerMask WhatIsEnemy;
    public GameObject cube;

    public Animator OperatorAni;
    [Header("AttackSetting")]
    public bool canAttack = true;
    public float AttackCD = 0.4f;
    public float BasicLength = 1.0f;
    public Vector2 AttackSize;
    private float AttackLength;
    private float AttackWidth;
    public Vector3 AttackMiddlePos;
    public Collider[] EnemiesInRange;
    public Collider targetEnemy;
    public int BlockNumber;
    private float LeastDistance = 1000;
    void Start()
    {
        AttackDir = Vector3.right;
        if(gameObject.CompareTag("Attacker"))
        {
            AttackCD = 0.767f;
        }else if(gameObject.CompareTag("Gunner"))
        {
            AttackCD = 1.375f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case OperatorState.InActivated:

                transform.forward = Vector3.right;
                if(isActivated)
                {
                    currentState = OperatorState.Attacking;
                    //ShowAttackRange();
                }

            break;

            case OperatorState.Idle:

                

            break;

            case OperatorState.Attacking:

                Vector3 AttackRange = new Vector3(AttackLength,BasicLength,AttackWidth);

                EnemiesInRange = Physics.OverlapBox(AttackMiddlePos,AttackRange/2,Quaternion.Euler(0,RotateYAngle,0),WhatIsEnemy);
                BlockNumber = EnemiesInRange.Length;
                if(EnemiesInRange.Length!=0)
                {
                    OperatorAni.SetBool("isAttacking",true);
                    LeastDistance = 1000;
                    for(int i = 0;i<EnemiesInRange.Length;i++)
                    {
                        float RemainDist = EnemiesInRange[i].GetComponent<EnemyController>().RemainDistance;

                        if(RemainDist<LeastDistance)
                        {
                            LeastDistance = RemainDist;
                            targetEnemy = EnemiesInRange[i];
                        }
                    }
                }
                else
                {
                    OperatorAni.SetBool("isAttacking",false);
                    targetEnemy = null;
                }
                

                if(canAttack&&targetEnemy!=null)
                {
                    canAttack = false;
                    Attack();
                    StartCoroutine(AttackCD_Count());
                }

            break;

            case OperatorState.Die:
            break;
        }
    }
    public void Activate()
    {
        isActivated = true;
        GetComponent<Collider>().enabled = true;
        getAttackRange();
    }
    IEnumerator AttackCD_Count()
    {
        
        for(float i =0 ; i<=AttackCD ; i+=Time.deltaTime)
		{
			yield return 0;
		}
		canAttack = true;
    
    }
    void Attack()
    {
        targetEnemy.GetComponent<EnemyController>().Hp--;
    }
    void getAttackRange()
    {
        if(gameObject.CompareTag("Attacker"))
        {

            AttackSize = new Vector2(2.0f,1.0f);
            
        }
        if(gameObject.CompareTag("Gunner"))
        {
            AttackSize = new Vector2(4.0f,3.0f);
        }

        AttackLength = AttackSize.x*BasicLength;
        AttackWidth = AttackSize.y*BasicLength;
        AttackMiddlePos = transform.position + AttackDir*(AttackLength/2-BasicLength*0.5f);
    }
    void ShowAttackRange()
    {
        GameObject showCube = Instantiate(cube,AttackMiddlePos,Quaternion.Euler(0,RotateYAngle,0));

        Vector3 AttackRange = new Vector3(AttackLength,BasicLength,AttackWidth);
        showCube.transform.localScale = AttackRange;

        showCube.transform.parent = transform;
    }
}
