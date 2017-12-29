using System.Collections.Generic;
using System.Threading.Tasks;
using bankWebApi.Services.DatabaseModels;
using Microsoft.AspNetCore.Mvc;

namespace bankWebApi.Services.Interfaces
{
    public interface IBankDataProvider
    {
    #region account
        Task<bool> EmployeeSignIn(string login, string password);
        Task<bool> ClientSignIn(string login, string password);
        Task SignOut();
    #endregion
    #region application
        Task<Dictionary<string, int>> ExchangeRate();
    #endregion
    #region changeInfo
        Task<bool> ChangeName(string role, int userId, string newName);
        Task<bool> ChangeLastName(string role, int userId, string newLastName);
        Task<bool> ChangeEmail(string role, int userId, string newEmail);
        Task<bool> ChangePhoneNumber(string role, int userId, string newPhoneNumber);
        Task<bool> ChangeLogin(string role, int userId, string newLogin);
        Task<bool> ChangePassword(string role, int userId, string oldPassword, string newPassword);
    #endregion
    #region client
        Task<bool> AddClient(string firstName, string lastName, string email, int phoneNumber);
        Task<bool> RemoveClient(int clientId);
        Task<ClientModel> GetClient(int clientId);
        Task<ClientAccountModel> GetClientAccount(string clientAccountNumber);
    #endregion
    #region employee
        Task<EmployeeModel> GetEmployee(int employeeId);
    #endregion
    #region test
        Task<List<ClientModel>> createClientsRandomly();
        Task<List<ClientAccountModel>> createClientAccountsRandomly();
        Task<List<ClientModel>> getAllClients();
    #endregion
    #region transaction
        Task<bool> Transfer(string senderAccountNumber, string recipientAccountNumber, int amount);
        Task<bool> Payment(string clientAccountNumber, int amount);
        Task<bool> Withdrawal(string clientAccountNumber, int amount);
    #endregion
    }
}