using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class radar_analysis_txt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button next_btn, previous_btn;
    [SerializeField] private Text txt;
    private int mode = 0;
    private string[] analysis_txt = { 
        "�z�̾A�X����t:\n1.��T�u�{ ����: 85 \n2.����u�{ ���� :73\n3.�q���u�{�t ����:70",
        "���p�F�Ϥ����R�覡�|�N�z��򥻱K�ǰk�檺�C���ɶ��B�ϥ�tips���ơB�������ơB�����d���Ѧ��ưO���U�ӡA�è̷ӥ��骱�a���ƦW��p�����",
        "�Ӭ�tlevel �@n��\n�U������ : \nlevel_score   = [100/(1+2+..+n)]*level\n\n�C���U���رo�� : \n[(100 - �ʤ��W��)/100 ] * (level_score / 4) \n�N�C���U���رo���[�`�Y���̲פ���"};
    void Start()
    {
        mode = 0;
        txt.text = analysis_txt[mode];
        next_btn.onClick.AddListener(() => change_txt("next"));
        previous_btn.onClick.AddListener(() => change_txt("previous"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void change_txt(string instruction)
    {
        if (instruction == "next")
        {
            if (mode < 3)
                mode++;
        }
        else
        {
            if (mode > 0)
                mode--;
        }

        txt.text = analysis_txt[mode];
    }
}
