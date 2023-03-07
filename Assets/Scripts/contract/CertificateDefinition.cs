using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Contract_code_new4.Contracts.certificate.ContractDefinition
{


    public partial class CertificateDeployment : CertificateDeploymentBase
    {
        public CertificateDeployment() : base(BYTECODE) { }
        public CertificateDeployment(string byteCode) : base(byteCode) { }
    }

    public class CertificateDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50610b21806100206000396000f3fe608060405234801561001057600080fd5b50600436106100935760003560e01c8063b5f5064b11610066578063b5f5064b1461011e578063c82882a014610142578063c96eeef714610155578063cd8e654314610168578063eacdf4031461019357600080fd5b80632d93ea13146100985780637f55bdf4146100ad5780639eae97e5146100d3578063b00e1e50146100f3575b600080fd5b6100ab6100a636600461087b565b6101a6565b005b6100c06100bb36600461095c565b6102cc565b6040519081526020015b60405180910390f35b6100e66100e136600461099e565b6102f7565b6040516100ca9190610a28565b6100c061010136600461099e565b805160208183018101805160058252928201919093012091525481565b61013161012c36600461095c565b61039c565b6040516100ca959493929190610a42565b6100e661015036600461099e565b61068a565b6100e661016336600461099e565b6106ae565b6100c061017636600461099e565b805160208183018101805160008252928201919093012091525481565b6100e66101a136600461099e565b6106d2565b84600088886040516101b9929190610aa1565b90815260200160405180910390208190555082600488886040516101de929190610aa1565b908152602001604051809103902090805190602001906101ff9291906106f6565b508360018888604051610213929190610aa1565b908152602001604051809103902090805190602001906102349291906106f6565b508160028888604051610248929190610aa1565b908152602001604051809103902090805190602001906102699291906106f6565b50806003888860405161027d929190610aa1565b9081526020016040518091039020908051906020019061029e9291906106f6565b506001600588886040516102b3929190610aa1565b9081526040519081900360200190205550505050505050565b6000600583836040516102e0929190610aa1565b908152602001604051809103902054905092915050565b80516020818301810180516004825292820191909301209152805461031b90610ab1565b80601f016020809104026020016040519081016040528092919081815260200182805461034790610ab1565b80156103945780601f1061036957610100808354040283529160200191610394565b820191906000526020600020905b81548152906001019060200180831161037757829003601f168201915b505050505081565b606080606060006060600187876040516103b7929190610aa1565b9081526020016040518091039020600288886040516103d7929190610aa1565b9081526020016040518091039020600389896040516103f7929190610aa1565b908152602001604051809103902060008a8a604051610417929190610aa1565b90815260200160405180910390205460048b8b604051610438929190610aa1565b908152602001604051809103902084805461045290610ab1565b80601f016020809104026020016040519081016040528092919081815260200182805461047e90610ab1565b80156104cb5780601f106104a0576101008083540402835291602001916104cb565b820191906000526020600020905b8154815290600101906020018083116104ae57829003601f168201915b505050505094508380546104de90610ab1565b80601f016020809104026020016040519081016040528092919081815260200182805461050a90610ab1565b80156105575780601f1061052c57610100808354040283529160200191610557565b820191906000526020600020905b81548152906001019060200180831161053a57829003601f168201915b5050505050935082805461056a90610ab1565b80601f016020809104026020016040519081016040528092919081815260200182805461059690610ab1565b80156105e35780601f106105b8576101008083540402835291602001916105e3565b820191906000526020600020905b8154815290600101906020018083116105c657829003601f168201915b505050505092508080546105f690610ab1565b80601f016020809104026020016040519081016040528092919081815260200182805461062290610ab1565b801561066f5780601f106106445761010080835404028352916020019161066f565b820191906000526020600020905b81548152906001019060200180831161065257829003601f168201915b50505050509050945094509450945094509295509295909350565b80516020818301810180516002825292820191909301209152805461031b90610ab1565b80516020818301810180516003825292820191909301209152805461031b90610ab1565b80516020818301810180516001825292820191909301209152805461031b90610ab1565b82805461070290610ab1565b90600052602060002090601f016020900481019282610724576000855561076a565b82601f1061073d57805160ff191683800117855561076a565b8280016001018555821561076a579182015b8281111561076a57825182559160200191906001019061074f565b5061077692915061077a565b5090565b5b80821115610776576000815560010161077b565b60008083601f8401126107a157600080fd5b50813567ffffffffffffffff8111156107b957600080fd5b6020830191508360208285010111156107d157600080fd5b9250929050565b634e487b7160e01b600052604160045260246000fd5b600082601f8301126107ff57600080fd5b813567ffffffffffffffff8082111561081a5761081a6107d8565b604051601f8301601f19908116603f01168101908282118183101715610842576108426107d8565b8160405283815286602085880101111561085b57600080fd5b836020870160208301376000602085830101528094505050505092915050565b600080600080600080600060c0888a03121561089657600080fd5b873567ffffffffffffffff808211156108ae57600080fd5b6108ba8b838c0161078f565b909950975060208a0135965060408a01359150808211156108da57600080fd5b6108e68b838c016107ee565b955060608a01359150808211156108fc57600080fd5b6109088b838c016107ee565b945060808a013591508082111561091e57600080fd5b61092a8b838c016107ee565b935060a08a013591508082111561094057600080fd5b5061094d8a828b016107ee565b91505092959891949750929550565b6000806020838503121561096f57600080fd5b823567ffffffffffffffff81111561098657600080fd5b6109928582860161078f565b90969095509350505050565b6000602082840312156109b057600080fd5b813567ffffffffffffffff8111156109c757600080fd5b6109d3848285016107ee565b949350505050565b6000815180845260005b81811015610a01576020818501810151868301820152016109e5565b81811115610a13576000602083870101525b50601f01601f19169290920160200192915050565b602081526000610a3b60208301846109db565b9392505050565b60a081526000610a5560a08301886109db565b8281036020840152610a6781886109db565b90508281036040840152610a7b81876109db565b90508460608401528281036080840152610a9581856109db565b98975050505050505050565b8183823760009101908152919050565b600181811c90821680610ac557607f821691505b602082108103610ae557634e487b7160e01b600052602260045260246000fd5b5091905056fea2646970667358221220354baf32b1e9d1c62a424a600c430fd8e1c32d854ded611a1a5236406d7bdba864736f6c634300080e0033";
        public CertificateDeploymentBase() : base(BYTECODE) { }
        public CertificateDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CheckRealFakeFunction : CheckRealFakeFunctionBase { }

    [Function("check_real_fake", "uint256")]
    public class CheckRealFakeFunctionBase : FunctionMessage
    {
        [Parameter("string", "hash", 1)]
        public virtual string Hash { get; set; }
    }

    public partial class DateArrFunction : DateArrFunctionBase { }

    [Function("date_arr", "string")]
    public class DateArrFunctionBase : FunctionMessage
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class DepartmentFunction : DepartmentFunctionBase { }

    [Function("department", "string")]
    public class DepartmentFunctionBase : FunctionMessage
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetAccountDetailFunction : GetAccountDetailFunctionBase { }

    [Function("get_account_detail", typeof(GetAccountDetailOutputDTO))]
    public class GetAccountDetailFunctionBase : FunctionMessage
    {
        [Parameter("string", "account_name", 1)]
        public virtual string AccountName { get; set; }
    }

    public partial class RealFunction : RealFunctionBase { }

    [Function("real", "uint256")]
    public class RealFunctionBase : FunctionMessage
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class RealNameArrFunction : RealNameArrFunctionBase { }

    [Function("real_name_arr", "string")]
    public class RealNameArrFunctionBase : FunctionMessage
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SchoolFunction : SchoolFunctionBase { }

    [Function("school", "string")]
    public class SchoolFunctionBase : FunctionMessage
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ScoresFunction : ScoresFunctionBase { }

    [Function("scores", "uint256")]
    public class ScoresFunctionBase : FunctionMessage
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class StoreMemberFunction : StoreMemberFunctionBase { }

    [Function("store_member")]
    public class StoreMemberFunctionBase : FunctionMessage
    {
        [Parameter("string", "hash", 1)]
        public virtual string Hash { get; set; }
        [Parameter("uint256", "score", 2)]
        public virtual BigInteger Score { get; set; }
        [Parameter("string", "real_name", 3)]
        public virtual string RealName { get; set; }
        [Parameter("string", "date", 4)]
        public virtual string Date { get; set; }
        [Parameter("string", "input_school", 5)]
        public virtual string InputSchool { get; set; }
        [Parameter("string", "input_department", 6)]
        public virtual string InputDepartment { get; set; }
    }

    public partial class CheckRealFakeOutputDTO : CheckRealFakeOutputDTOBase { }

    [FunctionOutput]
    public class CheckRealFakeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DateArrOutputDTO : DateArrOutputDTOBase { }

    [FunctionOutput]
    public class DateArrOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class DepartmentOutputDTO : DepartmentOutputDTOBase { }

    [FunctionOutput]
    public class DepartmentOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetAccountDetailOutputDTO : GetAccountDetailOutputDTOBase { }

    [FunctionOutput]
    public class GetAccountDetailOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("string", "", 2)]
        public virtual string ReturnValue2 { get; set; }
        [Parameter("string", "", 3)]
        public virtual string ReturnValue3 { get; set; }
        [Parameter("uint256", "", 4)]
        public virtual BigInteger ReturnValue4 { get; set; }
        [Parameter("string", "", 5)]
        public virtual string ReturnValue5 { get; set; }
    }

    public partial class RealOutputDTO : RealOutputDTOBase { }

    [FunctionOutput]
    public class RealOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class RealNameArrOutputDTO : RealNameArrOutputDTOBase { }

    [FunctionOutput]
    public class RealNameArrOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SchoolOutputDTO : SchoolOutputDTOBase { }

    [FunctionOutput]
    public class SchoolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ScoresOutputDTO : ScoresOutputDTOBase { }

    [FunctionOutput]
    public class ScoresOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
