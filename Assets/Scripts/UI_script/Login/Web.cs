using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{
    // 登入
    public IEnumerator Login(string username, string password, System.Action<int> msg)
    {
        WWWForm form = new WWWForm();
        // POST
        form.AddField("loginUser", username);
        form.AddField("loginPW", password);

        // 注意: 網址要用http，不能用https否則會出錯
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
                if (www.downloadHandler.text.Contains("登入成功/"))
                {
                    string[] txt = www.downloadHandler.text.Split("/");
                    if(txt.Length>1)
                        UserInfo.RealName = txt[1];
                    msg(1);
                    UserInfo.Username = username;
                }
                else if(www.downloadHandler.text == "大學登入成功")
                {
                    msg(2);
                    UserInfo.Username = username;
                }
                else if (www.downloadHandler.text == "密碼錯誤")
                {
                    msg(3);
                }
                else if (www.downloadHandler.text == "此使用者名稱不存在")
                {
                    msg(4);
                }
            }
        }
    }

    // 註冊
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

        // 注意: 網址要用http，不能用https否則會出錯
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
                if (www.downloadHandler.text == "註冊成功")
                {
                    msg(1);
                }
                else if (www.downloadHandler.text == "此使用者名稱已被使用")
                {
                    msg(2);
                }
                else if (www.downloadHandler.text == "請填寫所有資料")
                {
                    msg(3);
                }
                else if (www.downloadHandler.text == "確認密碼錯誤")
                {
                    msg(4);
                }
            }
        }
    }
}
