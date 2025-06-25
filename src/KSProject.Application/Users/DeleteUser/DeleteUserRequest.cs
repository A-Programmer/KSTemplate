using System.Text.Json.Serialization;
using KSFramework.Contracts;

namespace KSProject.Application.Users.DeleteUser;

public sealed class DeleteUserRequest : IInjectable
{
    [JsonPropertyName("id")]
    public Guid id { get; init; }
}