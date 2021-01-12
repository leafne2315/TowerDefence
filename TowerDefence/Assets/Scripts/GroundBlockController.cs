using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBlockController : MonoBehaviour
{
    // Start is called before the first frame update
    private DisplayManager DManager;
    public bool showingCanPlace;
    public GameObject LightSpite;
    public bool isPlace;
    void Start()
    {
        DManager = GameObject.Find("DisplayManager").GetComponent<DisplayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DManager.showGroundEmpty)
        {
            if(!isPlace)
            {
                LightSpite.SetActive(true);
            }
        }
        else
        {
            LightSpite.SetActive(false);
        }
    }
}
