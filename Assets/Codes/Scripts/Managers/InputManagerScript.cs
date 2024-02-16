using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManagerScript : MonoBehaviour
{
    public delegate void UpdateTargetPosition(Vector3 pos);
    public event UpdateTargetPosition UpdateTargetPositionEvent;


    public static InputManagerScript instance;


    RaycastHit hit;
    Ray ray;
    LayerMask mask;

    private void Awake()
    {
        instance = this;
        mask = LayerMask.GetMask("InputLayer");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManagerScript.GameOn)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                UpdateTargetPositionEvent?.Invoke(hit.point);
            }
        }
    }


}
