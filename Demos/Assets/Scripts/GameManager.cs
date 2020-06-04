using System;
using System.Drawing;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.SocialPlatforms;
using Color = UnityEngine.Color;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public GameObject m_FloorPrefab;
    public int m_FloorSize = 15;
    private GameObject[,] m_Floor;
    private GameObject m_Instance;

    //Awake is called when the Script is loaded
    private void Awake()
    {
        m_Floor = new GameObject[m_FloorSize, m_FloorSize];
    }


    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void CreateLevel()
    {
        Vector3 m_StartPosition = new Vector3(-(m_FloorSize / 2), 0f, (m_FloorSize / 2));
        float m_PositionX = m_StartPosition.x;
        float m_PositionZ = m_StartPosition.z;
        Vector3 m_SpawnPosition = new Vector3(m_PositionX, m_PositionZ);
        Quaternion m_SpawnRotation = Quaternion.Euler(0f, 0f, 0f);
        for(int i = 0; i < m_FloorSize; i++)
        {
            for(int j = 0; j < m_FloorSize; j++)
            {
                m_SpawnPosition.Set(m_PositionX, 0f, m_PositionZ);
                m_Instance = Instantiate(m_FloorPrefab, m_SpawnPosition, m_SpawnRotation);
                MeshRenderer renderer = m_Instance.GetComponentInChildren<MeshRenderer>();
                renderer.material.color = Color();
                m_Floor[i, j] = m_Instance;
                m_PositionZ -= 2;
            }
            m_PositionZ = m_StartPosition.z;
            m_PositionX += 2;
        }
    }

    private Color Color()
    {
        float m_grey =  Random.Range(0.4f, 0.5f);
        Color m_instanceColor = new Color(m_grey, m_grey, m_grey, 1);
        return m_instanceColor;
    }
}
