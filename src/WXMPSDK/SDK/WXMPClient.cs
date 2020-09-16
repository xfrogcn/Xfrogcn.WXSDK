﻿using System;
namespace WXMPSDK
{
    public class WXMPClient
    {
        public WXMPClient(
            BasisServiceClient basisServiceClient,
            CustomServiceClient customServiceClient,
            TemplateServiceClient templateServiceClient,
            MenuClient menuClient,
            UserManagerClient userManagerClient,
            AccountManagerClient accountManagerClient,
            MaterialClient materialClient)
        {
            BasisServiceClient = basisServiceClient;
            CustomServiceClient = customServiceClient;
            TemplateServiceClient = templateServiceClient;
            MenuClient = menuClient;
            UserManagerClient = userManagerClient;
            AccountManagerClient = accountManagerClient;
            MaterialClient = materialClient;
        }

        public BasisServiceClient BasisServiceClient { get; }

        public CustomServiceClient CustomServiceClient { get; }
        public TemplateServiceClient TemplateServiceClient { get; }
        public MenuClient MenuClient { get; }
        public UserManagerClient UserManagerClient { get; }
        public AccountManagerClient AccountManagerClient { get; }
        public MaterialClient MaterialClient { get; }
    }
}
