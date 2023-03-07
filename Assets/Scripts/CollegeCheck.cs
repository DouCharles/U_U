using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Nethereum.JsonRpc.UnityClient;
using Contract_code_new4.Contracts.certificate.ContractDefinition;

public class CollegeCheck : MonoBehaviour
{
    [SerializeField] private Button LeaveButton;
    public InputField Hash;
    public Button CheckButton;
    public Text Result;
    string privatekey = "8a54894ebd43e948be8ff7991ac9b88cf977a0bcfe0ca1d0f625d208f4d730be";
    string url = "https://rinkeby.infura.io/v3/ac4428b25beb43bbb7fff640f877c654";
    string fromAddress = "0x85df66a2361b7d10610935ccca5069c70f686fc2";
    string contractAddress = "0x9Cf4dD713f234aeDb10d9cd975111A0d01478030";
    // Start is called before the first frame update
    void Start()
    {
        CheckButton.onClick.AddListener(() =>
        {
            // check block chain
            Debug.Log(Hash.text);
            StartCoroutine(check_certificate(Hash.text));
            
        });
        LeaveButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator check_certificate(string hash)
    {
        var queryRequest = new QueryUnityRequest<CheckRealFakeFunction, CheckRealFakeOutputDTO>(url, privatekey);
        yield return queryRequest.Query(new CheckRealFakeFunction() { FromAddress = fromAddress, Hash =  hash}, contractAddress);
        print(queryRequest.Result.ReturnValue1);
        if(queryRequest.Result.ReturnValue1 == 1)
        {
            Result.text = "查驗結果 : 證書存在";
        }
        else
        {
            Result.text = "查驗結果 : 查無此證書";
        }
    }
}
