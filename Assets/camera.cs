using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Vector3 m_posDifference;
    float m_posDifferenceX;
    public GameObject m_fighter;

    // Use this for initialization
    void Start()
    {

        m_posDifference = transform.localPosition;
        m_posDifferenceX = m_posDifference.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (m_fighter != null)
        {
            Vector3 startVec = m_fighter.transform.localPosition;
            transform.localPosition = new Vector3(m_posDifferenceX, startVec.y + m_posDifference.y, startVec.z + m_posDifference.z);
        }

    }
}
