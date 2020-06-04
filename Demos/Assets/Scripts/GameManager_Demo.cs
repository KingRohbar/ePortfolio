using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Demo : MonoBehaviour
{
    public GameObject m_FloorPrefab;
    public GameObject m_PlayerPrefab;
    //public GameObject m_GoalLightPrefab;
    //public Text m_Text;
    public int m_FloorSize = 15;
    [HideInInspector]public float m_TrapPercentage = .3f;

    private GameObject[,] m_Floor;
    private GameObject m_Instance;
    private Vector3 m_PlayerSpawn;
    private GameObject m_Player;
    private GameObject m_Goal;

    private Quaternion m_SpawnRotation = Quaternion.Euler(0f, 0f, 0f);

    //Awake is called when the Script is loaded
    private void Awake()
    {
        m_Floor = new GameObject[m_FloorSize, m_FloorSize];
    }


    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
        //SpawnPlayer();
        //SetGoal();
    }

    // Update is called once per frame
    void Update()
    {
        //Loose();
        //Win();
    }


    private void CreateLevel()
    {
        Vector3 m_StartPosition = new Vector3(-(m_FloorSize / 2), 0f, (m_FloorSize / 2));
        float m_PositionX = m_StartPosition.x;
        float m_PositionZ = m_StartPosition.z;
        Vector3 m_SpawnPosition = new Vector3(m_PositionX, m_PositionZ);
        for (int i = 0; i < m_FloorSize; i++)
        {
            for (int j = 0; j < m_FloorSize; j++)
            {
                m_SpawnPosition.Set(m_PositionX, 0f, m_PositionZ);
                m_Instance = Instantiate(m_FloorPrefab, m_SpawnPosition, m_SpawnRotation);
                //SetTrap(m_Instance);
                MeshRenderer renderer = m_Instance.GetComponentInChildren<MeshRenderer>();
                renderer.material.color = SetColor();
                m_Floor[i, j] = m_Instance;
                m_PositionZ -= 2;
            }
            m_PositionZ = m_StartPosition.z;
            m_PositionX += 2;
        }
    }
    /*
    private void SetTrap(GameObject instance)
    {
        
    }
    */
    /*
    private void SetGoal()
    {
        bool validGoalSpawn = false;
        int randomX = 0;
        int randomZ = 0;
        while (!validGoalSpawn)
        {
            randomX = Random.Range(0, m_FloorSize - 1);
            randomZ = Random.Range(0, m_FloorSize - 1);
            if (m_Floor[randomX, randomZ].GetComponent<BoxCollider>().isTrigger == false && m_Floor[randomX, randomZ].transform.position != m_PlayerSpawn)
            {
                validGoalSpawn = true;
            }
        }
        m_Floor[randomX, randomZ].GetComponent<FloorManager>().SetGoalTrue();
        BoxCollider collider = m_Floor[randomX, randomZ].GetComponent<BoxCollider>();
        collider.isTrigger = true;
        m_Goal = m_Floor[randomX, randomZ];
        GameObject goalLight = Instantiate(m_GoalLightPrefab);
        goalLight.transform.position = new Vector3(m_Floor[randomX, randomZ].transform.position.x, goalLight.transform.position.y, m_Floor[randomX, randomZ].transform.position.z);
    }

    private void SpawnPlayer()
    {
        bool validPlayerSpawn = false;
        int randomX = 0;
        int randomZ = 0;
        while (!validPlayerSpawn)
        {
            randomX = Random.Range(0, m_FloorSize - 1);
            randomZ = Random.Range(0, m_FloorSize - 1);
            if (m_Floor[randomX, randomZ].GetComponent<BoxCollider>().isTrigger == false)
            {
                validPlayerSpawn = true;
            }
        }
        m_PlayerSpawn = new Vector3(m_Floor[randomX, randomZ].transform.position.x, 1.5f, m_Floor[randomX, randomZ].transform.position.z);
        m_Player = Instantiate(m_PlayerPrefab, m_PlayerSpawn, m_SpawnRotation);
    }*/

    private Color SetColor()
    {
        float m_grey = Random.Range(0.4f, 0.5f);
        Color m_instanceColor = new Color(m_grey, m_grey, m_grey, 1);
        return m_instanceColor;
    }

    /*
    private void Loose()
    {
        if (m_Player.transform.position.y < -5)
        {
            //TODO:set an text
            m_Player.GetComponent<Rigidbody>().isKinematic = true;
            DisableControl();
        }
    }

    private void Win()
    {
        if (m_Goal.GetComponent<FloorManager>().getIsWin())
        {
            //TODO:set an text
            m_Player.GetComponent<Rigidbody>().isKinematic = true;
            DisableControl();
        }
    }
    
    private void DisableControl()
    {
        m_Player.GetComponent<SphereMovement>().enabled = false;
    }
    */
}
