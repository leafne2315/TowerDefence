using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PrintPos()
    {
        //UI.transform.position = new Vector3(1.0f,1.5f,2.0f);
        print(UI.transform.position);
    }
}
