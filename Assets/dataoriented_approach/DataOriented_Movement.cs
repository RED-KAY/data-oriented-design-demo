using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataOriented_Movement : MonoBehaviour
{
    [SerializeField] private Mesh m_PlayerMesh;
    [SerializeField] private Material m_PlayerMaterial;
    [SerializeField] private int m_PlayerCount;
    [SerializeField] private Vector3 m_PlayerScale;

    [SerializeField] private float m_MoveSpeed = 5f;
    [SerializeField] private float m_BoundaryMinX = 0f;
    [SerializeField] private float m_BoundaryMaxX = 10f;
    [SerializeField] private float m_BoundaryMinZ = 0f;
    [SerializeField] private float m_BoundaryMaxZ = 10f;

    private float m_YOffset;
    private Matrix4x4[] m_PlayerMatrix;
    private Vector3[] m_PlayerPositions;
    private Vector3[] m_TargetPositions;

    private void Start()
    {
        m_YOffset = m_PlayerScale.y / 2;
        m_PlayerMatrix = new Matrix4x4[m_PlayerCount];
        m_PlayerPositions = new Vector3[m_PlayerCount];
        m_TargetPositions = new Vector3[m_PlayerCount];

        for (int i = 0; i < m_PlayerCount; i++)
        {
            SetRandomTargetPosition(i);
            m_PlayerPositions[i] = Vector3.zero + (Vector3.up * m_YOffset);
            m_PlayerMatrix[i] = Matrix4x4.TRS(m_PlayerPositions[i], Quaternion.identity, m_PlayerScale);
        }
    }

    private void Update()
    {
        for (int i = 0; i < m_PlayerCount; i++) { 
            Move(i);
        }

        Draw();
    }

    private void Draw()
    {
        Graphics.DrawMeshInstanced(m_PlayerMesh, 0, m_PlayerMaterial, m_PlayerMatrix);
    }

    void Move(int i)
    {
        m_PlayerPositions[i] = Vector3.MoveTowards(m_PlayerPositions[i], m_TargetPositions[i], m_MoveSpeed * Time.deltaTime);
        m_PlayerMatrix[i] = Matrix4x4.TRS(m_PlayerPositions[i] + (Vector3.up * m_YOffset), Quaternion.identity, m_PlayerScale);

        if (Vector3.Distance(m_PlayerPositions[i], m_TargetPositions[i]) < 0.1f)
        {
            SetRandomTargetPosition(i);
        }
    }

    void SetRandomTargetPosition(int i)
    {
        float randomX = Random.Range(m_BoundaryMinX, m_BoundaryMaxX);
        float randomZ = Random.Range(m_BoundaryMinZ, m_BoundaryMaxZ);
        m_TargetPositions[i] = new Vector3(randomX, m_PlayerPositions[i].y, randomZ);
    }
}
