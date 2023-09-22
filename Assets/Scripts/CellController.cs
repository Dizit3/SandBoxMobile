using System;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private CellProperties cellProperties;

    [SerializeField] private GameObject cellContent;

    public event Action OnCellOpen;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null && player.HasKey(cellProperties.requiredKeyID))
        {
            OpenCell();
        }
    }



    private void OpenCell()
    {
        transform.DetachChildren();

        OnCellOpen?.Invoke();

        Destroy(gameObject);
    }
}
