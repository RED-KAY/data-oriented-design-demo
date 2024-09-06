using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameObjects_MovementManager : MonoBehaviour
{
    [SerializeField] private int m_PlayerCount;
    [SerializeField] private GameObject m_PlayerPrefab;
    [SerializeField] private Transform[] m_Players;
    [SerializeField] private float m_MoveSpeed = 5f; 
    [SerializeField] private float m_BoundaryMinX = 0f; 
    [SerializeField] private float m_BoundaryMaxX = 10f;  
    [SerializeField] private float m_BoundaryMinZ = 0f; 
    [SerializeField] private float m_BoundaryMaxZ = 10f;  

    private Vector3[] m_TargetPositions;

    private void Start()
    {
        m_Players = new Transform[m_PlayerCount];
        for (int i = 0; i < m_PlayerCount; i++)
        {
            var p = Instantiate(m_PlayerPrefab, this.transform);
            m_Players[i] = p.transform;
        }
        m_TargetPositions = new Vector3[m_Players.Length];

        for (int i = 0; i < m_Players.Length; i++)
        {
            SetRandomTargetPosition(i);
        }
    }

    private void Update()
    {
        for (int i = 0; i < m_Players.Length; i++)
        {
            Move(i);
        }
    }

    void Move(int i)
    {
        m_Players[i].position = Vector3.MoveTowards(m_Players[i].position, m_TargetPositions[i], m_MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(m_Players[i].position, m_TargetPositions[i]) < 0.1f)
        {
            SetRandomTargetPosition(i);
        }
    }

    void SetRandomTargetPosition(int i)
    {
        float randomX = Random.Range(m_BoundaryMinX, m_BoundaryMaxX);
        float randomZ = Random.Range(m_BoundaryMinZ, m_BoundaryMaxZ);
        m_TargetPositions[i] = new Vector3(randomX, m_Players[i].position.y, randomZ);
    }
}
