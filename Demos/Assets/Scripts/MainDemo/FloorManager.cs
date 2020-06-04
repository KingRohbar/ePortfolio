using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    private bool isGoal = false;
    private bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isGoal){
            m_Rigidbody.isKinematic = false;
        }
        else if (isGoal)
        {
            isWin = true;
        }
    }
    public void SetGoalTrue()
    {
        isGoal = true;
    }

    public bool getIsWin()
    {
        return isWin;
    }
}
