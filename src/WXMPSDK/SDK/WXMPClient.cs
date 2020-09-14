using System;
namespace WXMPSDK
{
    public class WXMPClient
    {
        public WXMPClient(
            BasisServiceClient basisServiceClient,
            CustomServiceClient customServiceClient)
        {
           // AccessTokenClient = accessTokenClient;
            BasisServiceClient = basisServiceClient;
            CustomServiceClient = customServiceClient;
        }

        //public AccessTokenClient AccessTokenClient { get; }

        public BasisServiceClient BasisServiceClient { get; }

        public CustomServiceClient CustomServiceClient { get; }
    }
}
