using UnityEngine;

public class ComponentBased_Movement : MonoBehaviour
{
    [SerializeField] private float m_MoveSpeed = 5f;
    [SerializeField] private float m_BoundaryMinX = 0f;
    [SerializeField] private float m_BoundaryMaxX = 10f; 
    [SerializeField] private float m_BoundaryMinZ = 0f;
    [SerializeField] private float m_BoundaryMaxZ = 10f;
    [SerializeField] private Vector3 m_TargetPosition;

    void Start()
    {
        SetRandomTargetPosition();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, m_TargetPosition, m_MoveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, m_TargetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(m_BoundaryMinX, m_BoundaryMaxX);
        float randomZ = Random.Range(m_BoundaryMinZ, m_BoundaryMaxZ);
        m_TargetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}
