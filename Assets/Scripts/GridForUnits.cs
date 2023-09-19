using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridForUnits : MonoBehaviour
{
    [SerializeField] private Grid grid;
    public GameObject agentPrefab;  // Префаб с NavMeshAgent
    private int rowCount;  // Количество строк в сетке
    private int colCount;  // Количество столбцов в сетке

    private void Update()
    {
        
            Vector3 cellSize = grid.cellSize;
            Vector3 startPos = transform.position;  // Начальная позиция для сетки

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    Vector3 cellPosition = new Vector3(startPos.x + i * cellSize.x, startPos.y, startPos.z + j * cellSize.z);
                    Vector3Int gridPosition = grid.WorldToCell(cellPosition);
                    Vector3 instantiatePos = grid.GetCellCenterWorld(gridPosition);

                    // Создаем экземпляр агента и устанавливаем его позицию
                    GameObject agent = Instantiate(agentPrefab, instantiatePos, Quaternion.identity);
                    agent.GetComponent<NavMeshAgent>().Warp(instantiatePos);  // Используем метод Warp для установки позиции агента
                }
            }
    

}
