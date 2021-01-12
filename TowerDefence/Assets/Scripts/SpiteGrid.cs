using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpiteGrid : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 truePos;
    public GameObject[] target;
    public float gridSize;
    public float gridSizeY;
    public Vector3 DistToGround;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        for(int i= 0;i<target.Length;i++)
        {
            truePos.x = Mathf.Round(target[i].transform.position.x/gridSize)*gridSize;
            truePos.y = Mathf.Round(target[i].transform.position.y/gridSizeY)*gridSizeY;
            truePos.z = Mathf.Round(target[i].transform.position.z/gridSize)*gridSize;

            target[i].transform.position = truePos+DistToGround;
        }

    }
}
