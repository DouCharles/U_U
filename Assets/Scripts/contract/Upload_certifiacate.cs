using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nethereum.JsonRpc.UnityClient;

using UnityEngine.UI;
using TMPro;


public class Upload_certifiacate : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] Text show_txt;
    [SerializeField] TMP_Text show_txt;
    void Start()
    {
        //StartCoroutine(UpdateScore());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public IEnumerator UpdateScore()
    {
        string privatekey = "8a54894ebd43e948be8ff7991ac9b88cf977a0bcfe0ca1d0f625d208f4d730be";
        string url = "https://rinkeby.infura.io/v3/ac4428b25beb43bbb7fff640f877c654";
        string fromAddress = "0x85df66a2361b7d10610935ccca5069c70f686fc2";
        string contractAddress = "0x6be8df9e05ca512693b91ecdbcfd387da8a995aa";

        var transactionTransferRequest = new TransactionSignedUnityRequest(url, privatekey);
        //var transactionTransferRequest = new Eth
        /var transactionMessage = new StoreMemberFunction
        {
            FromAddress = fromAddress,
            AccountName = "charles123",
            Score = 30,
            RealName = "DOUDOU",
            Date = "2022/05/07",
            InputSchool = "NCKU",
            InputDepartment = "CSIE"
        };

        //var queryRequest = new QueryUnityRequest<GetAccountDetailFunction, GetAccountDetailOutputDTO>(url, privatekey);
        /*yield return queryRequest.Query(new GetAccountDetailFunction() { FromAddress = fromAddress,AccountName = "charles" }, contractAddress);*/
        //upload certifiacate
        /*yield return transactionTransferRequest.SignAndSendTransaction(transactionMessage, contractAddress);
        print(transactionTransferRequest.Result);
/*        print(queryRequest.Result);
        print(queryRequest.Result.ReturnValue1);
        print(queryRequest.Result.ReturnValue2);
        print(queryRequest.Result.ReturnValue3);
        print(queryRequest.Result.ReturnValue4);
        show_txt.text = queryRequest.Result.ReturnValue1 +"/" +queryRequest.Result.ReturnValue2 + "/" + queryRequest.Result.ReturnValue3 + "/" + queryRequest.Result.ReturnValue4 + "/" + queryRequest.Result.ReturnValue5;*/

   //}
}
