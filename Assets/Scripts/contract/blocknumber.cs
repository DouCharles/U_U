using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Nethereum.JsonRpc.UnityClient;
//using Nethereum.JsonRpc.Client;

public class blocknumber : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("blockchain");
        //StartCoroutine(GetBlockNumber());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private IEnumerator GetBlockNumber()
    {
        string url = "https://rinkeby.etherscan.io/address/0x1138Dd289a17C1726491411A1e95CAA8017D3Cfd";
        var blockNumberRequest = new EthBlockNumberUnityRequest(url);
        yield return blockNumberRequest.SendRequest();
        
        print(blockNumberRequest.Result);
    }*/
}
