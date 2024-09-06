using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsApproach_Manager : MonoBehaviour
{
    [SerializeField] private GameObject m_PlayerPreafab;
    [SerializeField] private int m_PlayerCount;

    private void Start()
    {
        for (int i = 0; i < m_PlayerCount; i++) { 
            Instantiate(m_PlayerPreafab, this.transform);
        }
    }
}
