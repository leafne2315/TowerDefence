using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionButtomEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject settingCharacter;
    private GameObject Cursor;
    private CursorController CursorCtrlScript;
    
    void Start()
    {
        Cursor = GameObject.Find("Cursor");
        CursorCtrlScript = Cursor.GetComponent<CursorController>();
    }
    public void DirUp()
    {
        OperatorController CharacterScript = settingCharacter.GetComponent<OperatorController>();
        CharacterScript.AttackDir = Vector3.forward;
        CharacterScript.Activate();
        CharacterScript.RotateYAngle = -90;

        print("set to Up");
        CharacterSettingOver();
        Destroy(gameObject);
    }
    public void DirDown()
    {
        OperatorController CharacterScript = settingCharacter.GetComponent<OperatorController>();
        CharacterScript.AttackDir = Vector3.back;
        CharacterScript.Activate();
        CharacterScript.RotateYAngle = 90;

        print("set to Down");
        CharacterSettingOver();
        Destroy(gameObject);
    }
    public void DirLeft()
    {
        OperatorController CharacterScript = settingCharacter.GetComponent<OperatorController>();
        CharacterScript.AttackDir = Vector3.left;
        CharacterScript.Activate();
        CharacterScript.RotateYAngle = 180;

        print("set to Left");
        CharacterSettingOver();
        Destroy(gameObject);
    }
    public void DirRight()
    {
        OperatorController CharacterScript = settingCharacter.GetComponent<OperatorController>();
        CharacterScript.AttackDir = Vector3.right;
        CharacterScript.RotateYAngle = 0;

        CharacterScript.Activate();
        print("set to Right");
        CharacterSettingOver();
        Destroy(gameObject);
    }
    void CharacterSettingOver()
    {
        CursorCtrlScript.currentState = CursorController.ManageState.NoWork;
    }
}
