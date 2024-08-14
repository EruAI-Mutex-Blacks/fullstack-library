using LibraryApp.Data.Entity;

namespace LibraryApp.Data.Abstract;

public interface IMessageRepository
{
    public IQueryable<Message> Messages { get; }

    public void GetMessagesBySenderId(int senderId);
    public void GetMessagesByReceiverId(int receiverId);
    public void CreateMessage(Message msg);
}