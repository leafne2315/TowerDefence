using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyPref;
    public bool canGenerate;
    public float GenerateCD;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canGenerate)
        {
            canGenerate = false;
            GenerateEnemy();
            StartCoroutine(GenerateTime_Count());
        }
    }
    IEnumerator GenerateTime_Count()
    {
        for(float i =0 ; i<=GenerateCD ; i+=Time.deltaTime)
		{
			yield return 0;
		}
		canGenerate = true;
    }
    void GenerateEnemy()
    {
        Vector3 GeneratePos = transform.position;
        GeneratePos.y = 1.22f;
        Instantiate(EnemyPref,GeneratePos,Quaternion.identity);
    }
}
