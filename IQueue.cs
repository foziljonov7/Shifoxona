public interface IQueue
{
    void AddQueue(string fio, string phoneNumber);
    void ListQueue();
    void NextQueue();
    void AcceptQueue();
    bool IfExitQueue();
}