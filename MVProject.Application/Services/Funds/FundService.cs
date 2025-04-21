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
    public async Task<string> RegisterFund(Guid ID_RegisterFundRequest)
    {
        var registerFundRequest = await _fundRepository.GetRegisterRequestByIdAsync(ID_RegisterFundRequest);

        await _fundRepository.RegisterFund(ID_RegisterFundRequest, registerFundRequest!.ID_User);
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

    public async Task<string> RejectRegisterFund(Guid ID_RegisterFundRequest)
    {
        var result = await _fundRepository.RejectFundNotificationRequest(ID_RegisterFundRequest);
        return result;
    }

    public async Task<List<RegisterFundRequestDto>> GetAllRegisterFundRequests()
    {
        var entities = await _fundRepository.GetAllRegisterFundRequests(); // EF уже сработал в репозитории

        return entities.Select(r => new RegisterFundRequestDto
        {
            ID_RegisterFundRequest = r.ID_RegisterFundRequest,
            ID_User = r.ID_User,
            FundName = r.FundName,
            CodeUSR = r.CodeUSR,
            FundDescription = r.FundDescription!,
            RegisterFundRequestDate = r.RegisterFundRequestDate,
            RegisterFundRequestStatus = r.RegisterFundRequestStatus,
            UserName = r.ID_UserNavigation?.UserName ?? "—"
        }).ToList();
    }
}
