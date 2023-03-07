using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Verify : MonoBehaviour
{
    public InputField Stu_id;
    public InputField Name;
    public Button VerifyButton;
    public Button RegisterButton;
    public Dropdown School;
    public Dropdown Department;
    public Text msg;

    // ���Ҧ@�Ш���
    public IEnumerator Verifying(string s_id, string name, string school, string department)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("Stu_id", s_id);
        form.AddField("Name", name);
        form.AddField("School", school);
        form.AddField("Department", department);

        // �`�N: ���}�n��http�A�����https�_�h�|�X��
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/Verify.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "1")
                {
                    msg.text = "**���Ҧ��\**";
                    VerifyButton.interactable = false;
                    RegisterButton.interactable = true;
                }
                else
                {
                    msg.text = "**���ҥ���**";
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        VerifyButton.onClick.AddListener(() =>
        {
            string school_val = School.options[School.value].text;
            string department_val = Department.options[Department.value].text;
            StartCoroutine(Verifying(Stu_id.text, Name.text, school_val, department_val));
        });
    }
}
