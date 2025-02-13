using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class cursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReload;
    private Vector2 hostpot = new Vector2(22,30);
    protected Gun gun;
    void Start()
    {
        Cursor.SetCursor(cursorNormal, hostpot, CursorMode.Auto);
        gun = GameObject.FindAnyObjectByType<Gun>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0)){
        Cursor.SetCursor(cursorShoot, hostpot, CursorMode.Auto);
        }
        else if(Input.GetMouseButtonUp(0)){
        Cursor.SetCursor(cursorNormal, hostpot, CursorMode.Auto);
        }
        if(Input.GetMouseButtonDown(1) && gun.reloadBullet == 3){
        Cursor.SetCursor(cursorReload, hostpot, CursorMode.Auto);
        }
        if(Input.GetMouseButtonUp(1)){
        Cursor.SetCursor(cursorNormal, hostpot, CursorMode.Auto);
        }
    }
}
