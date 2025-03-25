using CommunityToolkit.Mvvm.Messaging.Messages;
using TulingScadaSystem.Models;

namespace TulingScadaSystem.Messages;

public class LogoutMessage : ValueChangedMessage<User>
{
    public LogoutMessage(User value) : base(value)
    {
    }
}