namespace WXMPSDK
{
    public class WXMPClient
    {
        public string AppId { get; }

        public WXMPClient(
            string appId,
            TicketClient ticketClient,
            BasisServiceClient basisServiceClient,
            CustomServiceClient customServiceClient,
            TemplateServiceClient templateServiceClient,
            MenuClient menuClient,
            UserManagerClient userManagerClient,
            AccountManagerClient accountManagerClient,
            MaterialClient materialClient,
            AccessTokenManager tokenManager)
        {
            AppId = appId;
            TicketClient = ticketClient;
            BasisServiceClient = basisServiceClient;
            CustomServiceClient = customServiceClient;
            TemplateServiceClient = templateServiceClient;
            MenuClient = menuClient;
            UserManagerClient = userManagerClient;
            AccountManagerClient = accountManagerClient;
            MaterialClient = materialClient;
            TokenManager = tokenManager;
        }

        public TicketClient TicketClient { get; }

        public BasisServiceClient BasisServiceClient { get; }

        public CustomServiceClient CustomServiceClient { get; }
        public TemplateServiceClient TemplateServiceClient { get; }
        public MenuClient MenuClient { get; }
        public UserManagerClient UserManagerClient { get; }
        public AccountManagerClient AccountManagerClient { get; }
        public MaterialClient MaterialClient { get; }
        public AccessTokenManager TokenManager { get; }
    }
}
