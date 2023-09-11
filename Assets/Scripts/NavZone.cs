using System;
using UnityEngine;

public class NavZone : MonoBehaviour
{
    public event Action<Vector3> OnRayHit;


    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            OnRayHit?.Invoke(hit.point);
        }
    }
}