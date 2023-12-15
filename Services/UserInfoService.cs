using ApiLibrary.Responses;
using ApiLibrary.TextConstants;
using Microsoft.EntityFrameworkCore;
using SecondEndPoint.Data;
using SecondEndPoint.Models;

namespace SecondEndPoint.Services
{
    public class UserInfoService
    {
        private readonly DataContext _context;

        public UserInfoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<bool>> DeleteAsync(Guid userID)
        {
            var serviceResponse = new ApiResponse<bool>();

            try
            {
                var user = await _context.UserSecondEndPoint.FirstOrDefaultAsync(u => u.ID == userID);
                _context.UserSecondEndPoint.Remove(user);
                await _context.SaveChangesAsync();
                serviceResponse.Message = String.Format(SuccessMessages.UserDeletedAtEndPoint, "Second");
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ApiResponse<UserRegisterInfo>> InsertAsync(UserRegisterInfo newUser)
        {
            var serviceResponse = new ApiResponse<UserRegisterInfo>();

            try
            {
                _context.UserSecondEndPoint.Add(newUser);
                await _context.SaveChangesAsync();
                serviceResponse.Message = String.Format(SuccessMessages.UserInsertedAtEndPoint, "Second");
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}