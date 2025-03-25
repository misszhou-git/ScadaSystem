using CommunityToolkit.Mvvm.Messaging.Messages;
using TulingScadaSystem.Models;

namespace TulingScadaSystem.Messages;

public class LoginMessage:ValueChangedMessage<User>
{
    public LoginMessage(User value) : base(value)
    {
    }
}