using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // �n�J
    public IEnumerator Login(string username, string password, System.Action<int> msg)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("loginUser", username);
        form.AddField("loginPW", password);

        // �`�N: ���}�n��http�A�����https�_�h�|�X��
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                msg(0);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("�n�J���\/"))
                {
                    string[] txt = www.downloadHandler.text.Split("/");
                    if(txt.Length>1)
                        UserInfo.RealName = txt[1];
                    msg(1);
                    UserInfo.Username = username;
                }
                else if(www.downloadHandler.text == "�j�ǵn�J���\")
                {
                    msg(2);
                    UserInfo.Username = username;
                }
                else if (www.downloadHandler.text == "�K�X���~")
                {
                    msg(3);
                }
                else if (www.downloadHandler.text == "���ϥΪ̦W�٤��s�b")
                {
                    msg(4);
                }
            }
        }
    }

    // ���U
    public IEnumerator Register(string username, string password, string password_check, string name, string email, int identity, int appearance, string school, string department, System.Action<int> msg)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("regUser", username);
        form.AddField("regPW", password);
        form.AddField("regPW_check", password_check);
        form.AddField("regName", name);
        form.AddField("regEmail", email);
        form.AddField("regIdentity", identity);
        form.AddField("regAppearance", appearance);
        form.AddField("regSchool", school);
        form.AddField("regDepartment", department);

        // �`�N: ���}�n��http�A�����https�_�h�|�X��
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ProjectV1/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                msg(0);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text == "���U���\")
                {
                    msg(1);
                }
                else if (www.downloadHandler.text == "���ϥΪ̦W�٤w�Q�ϥ�")
                {
                    msg(2);
                }
                else if (www.downloadHandler.text == "�ж�g�Ҧ����")
                {
                    msg(3);
                }
                else if (www.downloadHandler.text == "�T�{�K�X���~")
                {
                    msg(4);
                }
            }
        }
    }
}
