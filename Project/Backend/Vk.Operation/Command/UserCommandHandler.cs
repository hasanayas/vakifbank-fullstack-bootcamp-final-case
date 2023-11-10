using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;

namespace Vk.Operation.Command;

public class UserCommandHandler :
    IRequestHandler<CreateUserCommand, ApiResponse<UserResponse>>,
    IRequestHandler<UpdateUserCommand, ApiResponse>,
    IRequestHandler<DeleteUserCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var mapped = mapper.Map<User>(request.Model);
        mapped.UserPassword = Md5.Create(mapped.UserPassword);

        if (mapped.UserRole == "Admin")
            mapped.UserProfitMargin = 0;

        unitOfWork.UserRepository.Insert(mapped);
        unitOfWork.CompleteTransaction();
        var response = mapper.Map<UserResponse>(mapped);
        return new ApiResponse<UserResponse>(response);
    }

    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id, cancellationToken);
        var mapped = mapper.Map<User>(request.Model);

        mapped.Id = request.Id;
        mapped.UserNumber = request.Model.UserNumber != default ? request.Model.UserNumber : entity.UserNumber;
        mapped.UserName = request.Model.UserName != "string" ? request.Model.UserName : entity.UserName;
        mapped.UserEmail = request.Model.UserEmail != "string" ? request.Model.UserEmail : entity.UserEmail;
        mapped.UserPassword = request.Model.UserPassword != "string" ? request.Model.UserPassword : entity.UserPassword;
        mapped.UserRole = request.Model.UserRole != "string" ? request.Model.UserRole : entity.UserRole;
        mapped.UserBalance = request.Model.UserBalance != default ? request.Model.UserBalance : entity.UserBalance;
        mapped.UserProfitMargin = request.Model.UserProfitMargin != default ? request.Model.UserProfitMargin : entity.UserProfitMargin;

        unitOfWork.UserRepository.Update(mapped);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        unitOfWork.UserRepository.Delete(request.Id);
        unitOfWork.CompleteTransaction();
        return new ApiResponse();

    }
}
