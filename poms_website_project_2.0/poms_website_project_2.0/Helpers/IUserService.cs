using Microsoft.AspNetCore.Identity;
using poms_website_project_2._0.Data.Entities;
using poms_website_project_2._0.Models;

namespace poms_website_project_2._0.Helpers
{
    public interface IUserService
    {
        // Gets a user by email.
        Task<UserModel> GetUserByEmailAsync(string email);

        // Adds a new user with a password.
        Task<IdentityResult> AddUserAsync(UserModel user, string password);

        // Logs in a user with LoginViewModel data.
        Task<SignInResult> LoginAsync(LoginModel model);

        // Logs out the current user.
        Task LogoutAsync();

        // Updates an existing user.
        Task<IdentityResult> UpdateUserAsync(UserModel user);

        // Changes a user's password.
        Task<IdentityResult> ChangePasswordAsync(UserModel user, string oldPassword, string newPassword);

        // Checks if a role exists, creates it if not.
        Task CheckRoleAsync(string roleName);

        // Adds a user to a specific role.
        Task AddUserToRoleAsync(UserModel user, string roleName);

        // Checks if a user is in a specific role.
        Task<bool> IsUserInRoleAsync(UserModel user, string roleName);

        // Validates a user's password.
        Task<SignInResult> ValidatePasswordAsync(UserModel user, string password);

        // Generates an email confirmation token.
        Task<string> GenerateEmailConfirmationTokenAsync(UserModel user);

        // Confirms a user's email with a token.
        Task<IdentityResult> ConfirmEmailAsync(UserModel user, string token);

        // Gets a user by their ID.
        Task<UserModel> GetUserByIdAsync(string userId);

        // Generates a password reset token.
        Task<string> GeneratePasswordResetTokenAsync(UserModel user);

        // Resets a user's password with a token.
        Task<IdentityResult> ResetPasswordAsync(UserModel user, string token, string password);

        // Removes a user from a role.
        Task RemoveUserFromRoleAsync(UserModel user, string roleName);

        // Gets all users in a specific role.
        Task<List<UserModel>> GetAllUsersInRoleAsync(string roleName);

        // Notifies administrative staff about pending users.
        Task NotifyAdministrativeEmployeesPendingUserAsync(UserModel user);

        Task<IdentityResult> ResetPasswordWithoutTokenAsync(UserModel user, string password);

        Task<string> GetRoleAsync(UserModel user);

        Task UpdateUserDataByRoleAsync(UserModel user);

        Task<FacultyModel> GetFacultyByUserAsync(string userEmail);
    }
}
