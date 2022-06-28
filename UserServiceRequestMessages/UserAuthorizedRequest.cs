namespace UserServiceRequestMessages
{
    public interface UserAuthorizedRequest
    {
        string UserId { get; }
        int FolderId { get; }
    }
}
