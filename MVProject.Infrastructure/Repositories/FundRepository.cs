using Microsoft.EntityFrameworkCore;
using MVProject.Domain.Entities;
using MVProject.Domain.Interfaces.Funds;
using MVProject.Infrastructure.Db;

namespace MVProject.Infrastructure.Repositories
{
    public class FundRepository : IFundRepository
    {
        private readonly AppDbContext _context;
        public FundRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<string> RegisterFund(Guid ID_RegisterFundRequest, Guid ID_User)
        {
            var volunteerFund = await _context.RegisterFundRequests
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID_RegisterFundRequest == ID_RegisterFundRequest);

            var sql = "EXEC CreateVolunteerFund @ID_RegisterFundRequest = {0}, @UserID = {1}, @FundName = {2}, " +
                "       @CodeUSR = {3}, @FundDescription = {4}";

            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    sql,
                    ID_RegisterFundRequest,
                    ID_User,
                    volunteerFund!.FundName,
                    volunteerFund.CodeUSR,
                    volunteerFund.FundDescription ?? null!
                );


                return "Фонд успішно зареєстровано!";
            }
            catch
            {
                return "Виникла помилка при реєстрації фонду.";
            }
        }

        public async Task<VolunteerFund?> GetByCodeAsync(string code)
        {
            return await _context.VolunteerFunds
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.CodeUSR == code);
        }

        public async Task<string> CreateFundNotificationRequest(RegisterFundRequest registerFundRequest, Guid ID_User)
        {
            var sql = "EXEC CreateFundRequest @ID_User = {0}, @FundName = {1}, @CodeUSR = {2}, @FundDescription = {3}";
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    sql,
                    ID_User,
                    registerFundRequest.FundName,
                    registerFundRequest.CodeUSR,
                    registerFundRequest.FundDescription ?? null!
                );
                return "Запит на створення фонду успішно відправлено!";
            }
            catch
            {
                return "Виникла помилка при відправці запиту на створення фонду.";
            }
        }

        public async Task<RegisterFundRequest?> GetRegisterRequestByIdAsync(Guid ID_RegisterFundRequest)
        {
            return await _context.RegisterFundRequests
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ID_RegisterFundRequest == ID_RegisterFundRequest);
        }

        public async Task<string> RejectFundNotificationRequest(Guid ID_RegisterFundRequest)
        {
            var sql = "EXEC RejectCreateFundRequest {0}";
            try
            {
                await _context.Database.ExecuteSqlRawAsync(
                    sql,
                    ID_RegisterFundRequest
                );
                return "Запит на створення фонду успішно відхилено!";
            }
            catch
            {
                return "Виникла помилка при відхиленні запиту на створення фонду.";
            }
        }
    }
}
