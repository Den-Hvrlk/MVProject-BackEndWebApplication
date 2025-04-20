using MVProject.Application.Interfaces;
namespace MVProject.Application.Services.Funds;
using MVProject.Application.DTOs.Fund;
using MVProject.Domain.Entities;
using MVProject.Domain.Interfaces.Funds;
using MVProject.Domain.Interfaces.Users;

public class FundService : IFundService
{
    private readonly IFundRepository _fundRepository;
    private readonly IUserRepository _userRepository;
    public FundService(IFundRepository fundRepository, IUserRepository userRepository)
    {
        _fundRepository = fundRepository;
        _userRepository = userRepository;
    }
    public async Task<string> RegisterFund(ResolveRegisterFundRequest request)
    {
        var registerFundRequest = await _fundRepository.GetRegisterRequestByIdAsync(request.ID_RegisterFundRequest);

        await _fundRepository.RegisterFund(request.ID_RegisterFundRequest, registerFundRequest!.ID_User);
        return "Фонд успішно зареєстровано!";
    }

    public async Task<string> CreateFundNotificationRequest(CreateFundNotificationRequest request, Guid ID_User)
    {
        var fundExists = await _fundRepository.GetByCodeAsync(request.CodeUSR!);
        if (fundExists != null)
            return "Заданий код ЄДРПОУ вже зареєстрований!";

        var user = await _userRepository.GetByIdAsync(ID_User);

        var fundRequest = new RegisterFundRequest
        {
            ID_User = user!.ID_User,
            FundName = request.FundName!,
            CodeUSR = request.CodeUSR!,
            FundDescription = request.FundDescription,
            ID_UserNavigation = user,
        };

        var result = await _fundRepository.CreateFundNotificationRequest(fundRequest);
        return result;
    }

    public async Task<string> RejectRegisterFund(RejectRegisterFundRequest rejectRegister)
    {
        var result = await _fundRepository.RejectFundNotificationRequest(rejectRegister.ID_RegisterFundRequest);
        return result;
    }

    public async Task<List<RegisterFundRequest>> GetAllRegisterFundRequests()
    {
        var result = await _fundRepository.GetAllRegisterFundRequests();
        return result;
    }
}
