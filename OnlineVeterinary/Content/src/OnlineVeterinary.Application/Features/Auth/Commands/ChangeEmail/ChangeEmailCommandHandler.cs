using ErrorOr;
using MapsterMapper;
using MediatR;
using OnlineVeterinary.Application.Common.Interfaces.Persistence;
using OnlineVeterinary.Application.Common.Services;

namespace OnlineVeterinary.Application.Features.Auth.Commands.ChangeEmail
{
    public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, ErrorOr<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ChangeEmailCommandHandler(IUserRepository userRepository,
                                        IUnitOfWork unitOfWork,
                                        IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ErrorOr<string>> Handle(ChangeEmailCommand request,
                                                  CancellationToken cancellationToken)
        {
            var userid = StringToGuidConverter.ConvertToGuid(request.Id);

            var user = await _userRepository.GetByIdAsync(userid);

            if (user is null)
            {
                return Error.NotFound();
            }
            user.Email = request.NewEmail;

            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return "email changed succesfuly";
        }
    }
}