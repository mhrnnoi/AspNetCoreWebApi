using ErrorOr;
using MapsterMapper;
using MediatR;
using OnlineVeterinary.Application.Auth.Common;
using OnlineVeterinary.Application.Common.Interfaces.Persistence;
using OnlineVeterinary.Application.Common.Interfaces.Services;
using OnlineVeterinary.Application.Common.Services;

namespace OnlineVeterinary.Application.Auth.Commands.Delete
{
    

    public class DeleteMyAccountCommandHandler : IRequestHandler<DeleteMyAccountCommand, ErrorOr<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IUserRepository _userRepository;


        public DeleteMyAccountCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IMediator mediator, IJwtGenerator jwtGenerator, IUserRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtGenerator = jwtGenerator;
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<string>> Handle(DeleteMyAccountCommand request, CancellationToken cancellationToken)
        {
            Guid id = StringToGuidConverter.ConvertToGuid(request.Id);

            var user = await _userRepository.GetByIdAsync(id);
            if (user is null )
            {
                return Error.NotFound();
            }
            _userRepository.Remove(user);
            await _unitOfWork.SaveChangesAsync();



            return "Deleted succesfuly";

        }
    }
}

