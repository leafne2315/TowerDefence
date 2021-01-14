using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float Hp = 7.0f;
    private NavMeshAgent agent;
    public Transform TargetPos;
    public bool TouchOperator;
    public enum EnemyState {Move,Attack,Die}
    public EnemyState currentState;
    public float RemainDistance;

    public GameObject OperatorInfront;

    public GameObject HpBarPf;
    private GameObject currentHP_UI;
    public Image HpUI;
    public GameObject RealWorldCanvas;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        TargetPos = GameObject.Find("End").transform;
        RealWorldCanvas = GameObject.Find("RealWorldCanvas");

        currentHP_UI = Instantiate(HpBarPf,transform.position,Quaternion.Euler(90.0f,0.0f,0.0f),RealWorldCanvas.transform);
        HpUI = currentHP_UI.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

        HpUI.fillAmount = Hp/7.0f;
        currentHP_UI.transform.position = transform.position + new Vector3(0,0,1);

        switch(currentState)
        {
            case EnemyState.Move:

                
                agent.SetDestination(TargetPos.position);
                RemainDistance = Vector3.Distance(TargetPos.position,transform.position);
                

                
                

                if(TouchOperator)
                {
                    currentState = EnemyState.Attack;
                }

            break;

            case EnemyState.Attack:
                agent.speed = 0;
                print(agent.speed);
            break;

            case EnemyState.Die:
            break;
        }

        if(Hp<=0)
        {
            
            Destroy(gameObject);
            Destroy(currentHP_UI);
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.CompareTag("Attacker"))
        {
            if(other.collider.GetComponent<OperatorController>().BlockNumber<2)
            {
                agent.speed = 0;
                TouchOperator = true;
                print("get in touch");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Attacker"))
        {
            if(other.GetComponent<OperatorController>().BlockNumber<2)
            {
                agent.speed = 0;
                TouchOperator = true;
            }
        }   
    }
}
