using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadarChart : MonoBehaviour
{
    [SerializeField] private Image[] m_panels;
    [SerializeField] private float m_fulSize = 100f;
    [SerializeField] public float[] m_statusValues;
    /* 0 :文
     * 1 :理
     * 2 :電資
     * 3 :醫學
     * 4 :管理
     * 5 :工
     * 6 :社科
     */

    // Start is called before the first frame update
    void Update()
    {
        for (int i = 0; i < 7; i++)
        {
            SetValues(i, m_statusValues[i]);
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
    //void OnValidate()
    /*
    {
        if (m_statusValues.Length != m_panels.Length)
        {
            return;
        }

        for(int i = 0; i < 7; i++)
        {
            SetValues(i, m_statusValues[i]);
        }
    }*/
    public void SetValues(int index, float values)
    {
        m_statusValues[index] = values;

        Vector2 size = m_panels[index].rectTransform.sizeDelta;
        size.x = m_fulSize * values;
        m_panels[index].rectTransform.sizeDelta = size;

        int pre = (index + m_panels.Length - 1) % m_panels.Length;
        size = m_panels[pre].rectTransform.sizeDelta;
        size.y = m_fulSize * values;
        m_panels[pre].rectTransform.sizeDelta = size;
    }
}
