using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vk.Base.Response;
using Vk.Data.Context;
using Vk.Data.Domain;
using Vk.Data.Uow;
using Vk.Schema;

namespace Vk.Operation.Query;

public class UserQueryHandler :
     IRequestHandler<GetAllUserQuery, ApiResponse<List<UserResponse>>>,
     IRequestHandler<GetUserByIdQuery, ApiResponse<UserResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<ApiResponse<List<UserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        List<User> list = unitOfWork.UserRepository.GetAll();
        List<UserResponse> mapped = mapper.Map<List<UserResponse>>(list);
        return new ApiResponse<List<UserResponse>>(mapped);
    }

    public async Task<ApiResponse<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return new ApiResponse<UserResponse>("Record not found");
        }

        UserResponse mapped = mapper.Map<UserResponse>(entity);
        return new ApiResponse<UserResponse>(mapped);
    }
}
