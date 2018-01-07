using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using bankWebApi.Services.Contexts;
using bankWebApi.Services.DatabaseModels;
using bankWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using bankWebApi.Services.Enums;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;

namespace bankWebApi.Services.Implements
{
    public class BankDataProvider : IBankDataProvider
    {
        private readonly bankDatabaseContext _bContext;
        public BankDataProvider(bankDatabaseContext bContext){
            _bContext = bContext;
        }

    private string Hash(string pass)
    {
        SHA1 sha1 = new SHA1CryptoServiceProvider();
        byte[] temp = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
        StringBuilder sb = new StringBuilder();
        for(int s = 0; s < temp.Length; s++)
        {
            sb.Append(temp[s].ToString());
        }
        string hash = sb.ToString();

        return hash;
    }

    #region account
        public ClaimsPrincipal EmployeeSignIn(string login, string password)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, "employee")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims
            );


            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
        public ClaimsPrincipal ClientSignIn(string login, string password)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, "client")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims
            );

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return claimsPrincipal;
        }
    #endregion

    #region application
        public Task<Dictionary<string, int>> ExchangeRate()
        {
            throw new NotImplementedException();
        }
    #endregion

    #region client
        public async Task<ClientModel> GetClient(int clientId)
        {
            return await _bContext.ClientModel.AsNoTracking()
                        .Where(d => d.Id == clientId)
                        .Select(d => d)
                        .FirstOrDefaultAsync();
        }
        public async Task<bool> AddClient(string firstName, string lastName, string email, string phoneNumber)
        {
            Random r = new Random();
            ClientModel clientModel = new ClientModel(){
                Id = await _bContext.ClientModel.AsNoTracking()
                    .Select(d => d.Id)
                    .LastAsync() + 1,
                FirstName = firstName,
                LastName = lastName,
                Login = firstName + lastName + r.Next(10,99),
                PhoneNumber = phoneNumber,
                ConfirmedPhoneNumber = true, 
                Email = email,
                ConfirmedEmail = true,
                PasswordHash = Hash("1234aA!")
            };

            StringBuilder accountNumber = new StringBuilder();
            for(int i = 0; i < 18; i++){
                accountNumber.Append(r.Next(0,9));
            }

            ClientAccountModel clientAccount = new ClientAccountModel(){
                Id = await _bContext.ClientAccountModel.AsNoTracking()
                    .Select(d => d.Id)
                    .LastAsync() + 1,
                ClientId = clientModel.Id,
                AccountNumber = accountNumber.ToString(),
                Money = 0,
                IsActive = true
            }; 

            await _bContext.AddAsync(clientModel);
            await _bContext.AddAsync(clientAccount);
            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<bool> RemoveClient(int clientId)
        {
            ClientModel clientModel = new ClientModel();
            ClientAccountModel accountModel = new ClientAccountModel();
            clientModel = await _bContext.ClientModel.AsNoTracking()
                                .Where(d => d.Id == clientId)
                                .Select(d => d)
                                .FirstOrDefaultAsync();
            accountModel = await _bContext.ClientAccountModel.AsNoTracking()
                                .Where(d => d.ClientId == clientId)
                                .Select(d => d)
                                .FirstOrDefaultAsync();

            clientModel.Login = null;
            clientModel.Email = null;
            clientModel.PhoneNumber = null;
            clientModel.PasswordHash = null;
            clientModel.ConfirmedEmail = false;
            clientModel.ConfirmedPhoneNumber = false;
            accountModel.IsActive = false;

            await _bContext.AddAsync(clientModel);
            await _bContext.AddAsync(accountModel);
            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<ClientAccountModel> GetClientAccount(string clientAccountNumber)
        {
            return await _bContext.ClientAccountModel.AsNoTracking()
                        .Where(d => d.AccountNumber == clientAccountNumber)
                        .Select(d => d)
                        .FirstOrDefaultAsync();
        }
    #endregion

    #region changeInfo
        public async Task<bool> ChangeName(string role, int userId, string newName)
        {
            string firstName = "";
            if(role == "employee")
            {
                firstName = await _bContext.EmployeeModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.FirstName)
                                        .FirstOrDefaultAsync();
            }
            else if(role == "client")
            {
                firstName = await _bContext.ClientModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.FirstName)
                                        .FirstOrDefaultAsync();
            }

            if(firstName == "")
                return false;

            firstName = newName;

            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<bool> ChangeLastName(string role, int userId, string newLastName)
        {
            string lastName = "";
            if(role == "employee")
            {
                lastName = await _bContext.EmployeeModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.LastName)
                                        .FirstOrDefaultAsync();
            }
            else if(role == "client")
            {
                lastName = await _bContext.ClientModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.LastName)
                                        .FirstOrDefaultAsync();
            }

            if(lastName == "")
                return false;

            lastName = newLastName;

            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<bool> ChangeEmail(string role, int userId, string newEmail)
        {
            string email = "";
            if(role == "employee")
            {
                email = await _bContext.EmployeeModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.Email)
                                        .FirstOrDefaultAsync();
            }
            else if(role == "client")
            {
                email = await _bContext.ClientModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.Email)
                                        .FirstOrDefaultAsync();
            }

            if(email == "")
                return false;

            email = newEmail;

            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<bool> ChangePhoneNumber(string role, int userId, string newPhoneNumber)
        {
            string phoneNumber = "";
            if(role == "employee")
            {
                phoneNumber = await _bContext.EmployeeModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.PhoneNumber)
                                        .FirstOrDefaultAsync();
            }
            else if(role == "client")
            {
                phoneNumber = await _bContext.ClientModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.PhoneNumber)
                                        .FirstOrDefaultAsync();
            }

            if(phoneNumber == "")
                return false;

            phoneNumber = newPhoneNumber;

            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<bool> ChangeLogin(string role, int userId, string newLogin)
        {
            string login = "";
            if(role == "employee")
            {
                login = await _bContext.EmployeeModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.Login)
                                        .FirstOrDefaultAsync();
            }
            else if(role == "client")
            {
                login = await _bContext.ClientModel.AsNoTracking()
                                        .Where(d => d.Id == userId)
                                        .Select(d => d.Login)
                                        .FirstOrDefaultAsync();
            }

            if(login == "")
                return false;

            login = newLogin;

            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        public async Task<bool> ChangePassword(string role, int userId, string oldPassword, string newPassword)
        {
            string password = "";
            
            if(role == "employee")
            {
                password = await _bContext.EmployeeModel.AsNoTracking()
                                .Where(d => d.Id == userId)
                                .Select(d => d.PasswordHash)
                                .FirstOrDefaultAsync();
            }
            else if(role == "client")
            {
                password = await _bContext.ClientModel.AsNoTracking()
                                .Where(d => d.Id == userId)
                                .Select(d => d.PasswordHash)
                                .FirstOrDefaultAsync();
            }

            if(Hash(oldPassword) == password){
                password = Hash(newPassword);
            }

            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
    #endregion

    #region employee
        public async Task<EmployeeModel> GetEmployee(int employeeId)
        {
            return await _bContext.EmployeeModel.AsNoTracking()
                        .Where(d => d.Id == employeeId)
                        .Select(d => d)
                        .FirstOrDefaultAsync();
        }
    #endregion

    #region test
        public async Task<List<ClientModel>> createClientsRandomly()
        {
            Random r = new Random();
            List<ClientModel> randomClients = new List<ClientModel>();
            for(int i = 2; i <= 10; i++){
                string firstName = ((FirstNameEnum)r.Next(1,78)).ToString();
                string lastName = ((LastNameEnum)r.Next(1,94)).ToString();
                string login = firstName + lastName + r.Next(11111,99999);
                string phoneNumber = "+48" + r.Next(111111111,999999999);
                string email = firstName + lastName + r.Next(10,99) + "@gmail.com";
                randomClients.Add(new ClientModel(){
                    Id = i,
                    FirstName = firstName,
                    LastName = lastName,
                    Login = login,
                    PhoneNumber = phoneNumber,
                    ConfirmedPhoneNumber = true,
                    Email = email,
                    ConfirmedEmail = true,
                    PasswordHash = Hash("1234aA!")
                });
            }
            await _bContext.AddRangeAsync(randomClients);
            await _bContext.SaveChangesAsync();
            return randomClients;
        }
        public async Task<List<ClientModel>> getAllClients()
        {
            return await _bContext.ClientModel.AsNoTracking()
                        .Select(d => d)
                        .ToListAsync();
        }
        public async Task<List<ClientAccountModel>> createClientAccountsRandomly()
        {
            Random r = new Random();
            List<ClientAccountModel> clientAccounts = new List<ClientAccountModel>();
            for(int i = 1; i <= 10; i++)
            {
                StringBuilder accountNumber = new StringBuilder();
                for(int j = 0; j < 18; j++)
                {
                    accountNumber.Append(r.Next(0, 9).ToString());
                }
                int money = r.Next(100, 300000);

                clientAccounts.Add(new ClientAccountModel(){
                    Id = i,
                    ClientId = i,
                    AccountNumber = accountNumber.ToString(),
                    Money = money,
                    IsActive = true
                });
            }
            await _bContext.ClientAccountModel.AddRangeAsync(clientAccounts);
            await _bContext.SaveChangesAsync();
            return clientAccounts;
        }

        public async Task<List<ClientAccountModel>> getAllClientsAccount()
        {
            return await _bContext.ClientAccountModel.AsNoTracking()
                    .Select(d => d)
                    .ToListAsync();
        }
        #endregion

    #region transaction
        public async Task<bool> Transfer(string senderAccountNumber, string recipientAccountNumber, int amount)
        {
            ClientAccountModel sender = await _bContext.ClientAccountModel.AsNoTracking()
                        .Where(d => d.AccountNumber == senderAccountNumber)
                        .Select(d => d)
                        .FirstOrDefaultAsync();
            ClientAccountModel recipient = await _bContext.ClientAccountModel.AsNoTracking()
                        .Where(d => d.AccountNumber == recipientAccountNumber)
                        .Select(d => d)
                        .FirstOrDefaultAsync();

            if(sender.Money - amount > 0){
                sender.Money -= amount;
                recipient.Money += amount;
            }else{
                return false;
            }

            await _bContext.AddAsync(sender);
            await _bContext.AddAsync(recipient);
            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }

        public async Task<bool> Payment(string clientAccountNumber, int amount)
        {
            ClientAccountModel money = await _bContext.ClientAccountModel.AsNoTracking()
                        .Where(d => d.AccountNumber == clientAccountNumber)
                        .Select(d => d)
                        .FirstOrDefaultAsync();

            money.Money += amount;

            await _bContext.AddAsync(money);
            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }

        public async Task<bool> Withdrawal(string clientAccountNumber, int amount)
        {
            ClientAccountModel money = await _bContext.ClientAccountModel.AsNoTracking()
                        .Where(d => d.AccountNumber == clientAccountNumber)
                        .Select(d => d)
                        .FirstOrDefaultAsync();

            if(money.Money - amount > 0){
                money.Money -= amount;
            }else{
                return false;
            }

            await _bContext.AddAsync(money);
            if(await _bContext.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        #endregion
    }
}