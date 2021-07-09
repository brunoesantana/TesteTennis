namespace TesteTennis.Service.Interface
{
    public interface IScore
    {
        string Score { get; }

        bool Validate(int serverPoint, int receiverPoint);
    }
}