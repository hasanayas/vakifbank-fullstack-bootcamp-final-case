﻿using MediatR;
using Vk.Base.Response;
using Vk.Schema;

namespace Vk.Operation;

public record CreateUserCommand(UserRequest Model) : IRequest<ApiResponse<UserResponse>>;
public record UpdateUserCommand(int Id,UserUpdatedRequest Model) : IRequest<ApiResponse>;
public record DeleteUserCommand(int Id) : IRequest<ApiResponse>;
public record GetAllUserQuery() : IRequest<ApiResponse<List<UserResponse>>>;
public record GetUserByIdQuery(int Id) : IRequest<ApiResponse<UserResponse>>;


