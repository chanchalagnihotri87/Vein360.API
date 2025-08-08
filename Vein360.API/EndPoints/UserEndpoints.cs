using Azure.Core;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Features.Products.CreateProduct;
using Vein360.Application.Features.Products.DeleteProduct;
using Vein360.Application.Features.Products.GetAllProducts;
using Vein360.Application.Features.Products.UpdateProduct;
using Vein360.Application.Features.Users.CreateUser;
using Vein360.Application.Features.Users.DeleteUser;
using Vein360.Application.Features.Users.EncryptPasswords;
using Vein360.Application.Features.Users.GetUser;
using Vein360.Application.Features.Users.GetUsers;
using Vein360.Application.Features.Users.UpdateUser;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Enums;

namespace Vein360.API.EndPoints
{
    public static class UserEndpoints
    {
        public record CreateUserRequestData(string Username,  string Password, bool IsBuyer, bool IsDonor, bool IsAdmin, bool IsApiUser);
        public record UpdateUserRequestData(int Id, string Username, string Password, bool IsBuyer, bool IsDonor, bool IsAdmin, bool IsApiUser);

        public static void MapUserEndpoints(this WebApplication app)
        {

            app.MapGet("/users", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var users = await mediator.Send(new GetUsersRequest());

                return Results.Ok(users);
            });

            app.MapGet("/users/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var users = await mediator.Send(new GetUserRequest(id));

                return Results.Ok(users);
            });


            app.MapPost("/users", [Authorize] async (CreateUserRequestData req, IMediator mediator, CancellationToken cancellationToken) =>
            {
                try
                {
                    await mediator.Send(req.Adapt<CreateUserRequest>());
                }
                catch (DuplicateUsernameException)
                {

                    return Results.BadRequest(new { duplicateEmail = true });
                }


                return Results.Ok();
            });

            app.MapPut("/users", [Authorize] async (UpdateUserRequestData req, IMediator mediator, CancellationToken cancellationToken) =>
            {
                try
                {
                    await mediator.Send(req.Adapt<UpdateUserRequest>());
                }
                catch (DuplicateUsernameException)
                {
                    return Results.BadRequest(new { duplicateEmail = true });
                }


                return Results.Ok();
            });

            app.MapDelete("/users/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(new DeleteUserRequest(id));

                return Results.Ok();
            });

        }
    }
}
