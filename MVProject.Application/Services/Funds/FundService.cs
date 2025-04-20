using MVProject.Application.Interfaces;
namespace MVProject.Application.Services.Funds;
using MVProject.Application.DTOs.Fund;
using MVProject.Domain.Entities;
using MVProject.Domain.Interfaces.Funds;

public class FundService : IFundService
{
    private readonly IFundRepository _fundRepository;
    public FundService(IFundRepository fundRepository)
    {
        _fundRepository = fundRepository;
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


        var fundRequest = new RegisterFundRequest
        {
            FundName = request.FundName!,
            CodeUSR = request.CodeUSR!,
            FundDescription = request.FundDescription
        };

        var result = await _fundRepository.CreateFundNotificationRequest(fundRequest, ID_User);
        return result;
    }

    public async Task<string> RejectRegisterFund(RejectRegisterFundRequest rejectRegister)
    {
        var result = await _fundRepository.RejectFundNotificationRequest(rejectRegister.ID_RegisterFundRequest);
        return result;
    }
}
