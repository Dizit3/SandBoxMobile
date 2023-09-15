using System;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private CellProperties cellProperties;

    [SerializeField] private GameObject cellContent;



    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null && player.HasKey(cellProperties.requiredKeyID))
        {
            OpenCell();
        }
    }

    private void OpenCell()
    {
        throw new NotImplementedException();
    }
}
