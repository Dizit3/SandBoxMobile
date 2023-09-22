using System;
using UnityEngine;
using DG.Tweening;

public class Flag : MonoBehaviour
{

    private void Start()
    {
        GameObject.FindGameObjectWithTag("NavZone").GetComponent<NavZone>().OnRayHit += MoveHandler;
    }

    private void MoveHandler(Vector3 vector)
    {
        //transform.position = vector;

        transform.DOMove(vector, 1f);
    }
}