using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarChart : MonoBehaviour
{
    [SerializeField] private Image[] m_bars;
    [SerializeField] private float m_fulSize = 300f;
    [SerializeField] public float[] m_statusValues;
    [SerializeField] private int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < num; i++)
        {
            SetValues(i, m_statusValues[i]);
        }
    }
    void OnValidate()
    {
        if (m_statusValues.Length != m_bars.Length)
        {
            return;
        }
        

        /*for(int i = 0; i < num; i++)
        {
            SetValues(i, m_statusValues[i]);
        }*/
    }
    public void SetValues(int index, float values)
    {
        m_statusValues[index] = values;

        Vector2 size = m_bars[index].rectTransform.sizeDelta;
        size.y = m_fulSize * values;
        m_bars[index].rectTransform.sizeDelta = size;
        m_bars[index].gameObject.transform.localPosition = new Vector3(m_bars[index].gameObject.transform.localPosition.x, (-3 - ((300 - size.y)/2)), 0);
    }
}
