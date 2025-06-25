using KSFramework.Contracts;
using KSFramework.KSMessaging.Abstraction;

namespace KSProject.Application.Users.ResetPassword;

public sealed class ResetPasswordCommand : ICommand<ResetPasswordResponse>, IInjectable
{
    public Guid Id { get; set; }
    public ResetPasswordRequest Payload { get; set; }
}