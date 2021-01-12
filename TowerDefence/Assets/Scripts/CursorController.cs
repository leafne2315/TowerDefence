using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private DisplayManager DManager;
    public Material hightLightMat;
    public GameObject choosingPlayer;
    public GameObject ChooseSlash;
    private Transform _Selection;
    private Material DefaultMat;
    public float DisplayY;
    public float FixedValue;
    public float FixValue_Ground;
    public float FixValue_High;
    private Vector3 rayDir;
    private GameObject HoldCharacter;
    public GameObject GunnerPf;
    public GameObject AttackerPf;
    public bool isHoldingCharacter;
    public bool ChoosingRanged;
    public bool ChoosingMelee;
    void Start()
    {
        DManager = GameObject.Find("DisplayManager").GetComponent<DisplayManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_Selection!=null)
        {
            Renderer _SelectRenderer = _Selection.GetComponent<Renderer>();
            _SelectRenderer.material = DefaultMat;
            _Selection = null;
        }
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Transform selection = hit.transform;
                if(selection.CompareTag("Ground")&&ChoosingMelee)
                {
                    HoldCharacter.transform.parent = selection;
                    HoldCharacter = null;
                }
                else
                if(selection.CompareTag("High")&&ChoosingRanged)
                {
                    HoldCharacter.transform.parent = selection.parent;
                    HoldCharacter = null;
                }
                else
                {
                    Destroy(HoldCharacter);
                }
            }
            StopHolding();
            CloseDManger();
            
        }

        if(Input.GetMouseButton(0)&&isHoldingCharacter)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                
                Transform selection = hit.transform;
                Renderer SelectRenderer = selection.GetComponent<Renderer>();
                rayDir = (hit.point-Camera.main.transform.position).normalized;
                if(SelectRenderer!=null)
                {
                    DefaultMat = SelectRenderer.material;
                    SelectRenderer.material = hightLightMat;
                }

                _Selection = selection;

                if(selection.CompareTag("Ground")&&ChoosingMelee)
                {
                    rayDir = (selection.transform.position-Camera.main.transform.position).normalized;
                    Vector3 MousePosOnDisplay = FixValue_Ground*(-rayDir)+selection.transform.position;
                    MousePosOnDisplay.y = DisplayY;
                    transform.position = MousePosOnDisplay;
                    
                }
                else
                if(selection.CompareTag("High")&&ChoosingRanged)
                {
                    rayDir = (selection.parent.transform.position-Camera.main.transform.position).normalized;
                    Vector3 MousePosOnDisplay = FixValue_High*(-rayDir)+selection.parent.transform.position;
                    MousePosOnDisplay.y = DisplayY;
                    transform.position = MousePosOnDisplay;
                }
                else
                {
                    rayDir = (hit.point-Camera.main.transform.position).normalized;
                    Vector3 MousePosOnDisplay = FixedValue*(-rayDir)+hit.point;
                    MousePosOnDisplay.y = DisplayY;
                    transform.position = MousePosOnDisplay;
                }
                
                Debug.DrawLine(Camera.main.transform.position,hit.point,Color.red);
            }
            else
            {
                Vector3 MousePosOnDisplay = new Vector3(hit.point.x,DisplayY,hit.point.z);
                transform.position = MousePosOnDisplay;
            }
        }
    }
    public void ChooseGunner()
    {
        print("press");
        DManager.showHighEmpty = true;
        HoldCharacter = Instantiate(GunnerPf,transform.position,Quaternion.identity);
        HoldCharacter.transform.parent = transform;
        isHoldingCharacter = true;
        ChoosingRanged = true;
    }
    public void ChooseAttacker()
    {
        print("press");
        DManager.showGroundEmpty = true;
        HoldCharacter = Instantiate(AttackerPf,transform.position,Quaternion.identity);
        HoldCharacter.transform.parent = transform;
        isHoldingCharacter = true;
        ChoosingMelee = true;
    }
    void CloseDManger()
    {
        DManager.showGroundEmpty = false;
        DManager.showHighEmpty = false;
    }
    void StopHolding()
    {
        isHoldingCharacter = false;
        ChoosingMelee = false;
        ChoosingRanged = false;
    }
    
}
