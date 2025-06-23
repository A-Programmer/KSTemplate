using KSFramework.Contracts;

namespace KSProject.Application.Roles.CreateRole;

public sealed class CreateRoleRequest : IInjectable
{
    public required string Name { get; init; } = string.Empty;
    public required string Description { get; init; } = string.Empty;
}