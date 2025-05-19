namespace Vein360.Application.Features.Vein360Containers.UpdateContainer
{
    public record UpdateContainerRequest(int Id, int ContainerTypeId, string ContainerCode, Vein360ContainerStatus Status):IRequest<ContainerDto>
    {
    }
}
