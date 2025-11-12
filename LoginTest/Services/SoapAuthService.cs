using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using LoginTest.Models;
using LoginTest.Services.Generated;

namespace LoginTest.Services
    {
    public class SoapAuthService : ISoapAuthService
        {
        public async Task<AuthResult> LoginAsync(string login, string password)
            {
            try
                {
                using var client = new ICUTechClient();
                var response = await client.LoginAsync(login, password, "");

                var result = JsonSerializer.Deserialize<ServiceResult>(
                    response.@return,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return new AuthResult
                    {
                    IsSuccess = result != null && result.ResultCode == 0,
                    Message = result?.ResultMessage ?? "Unknown response",
                    EntityDetails = response.@return
                    };
                }
            catch (Exception ex)
                {
                return new AuthResult
                    {
                    IsSuccess = false,
                    Message = $"Error calling service: {ex.Message}"
                    };
                }
            }

        public async Task<AuthResult> RegisterAsync(string email, string password)
            {
            try
                {
                using var client = new ICUTechClient();

                // уникальный телефон, чтобы сервис принял регистрацию
                var uniqueMobile = Guid.NewGuid().ToString().Substring(0, 10);

                var response = await client.RegisterNewCustomerAsync(
                    Email: email,
                    Password: password,
                    FirstName: "Test",
                    LastName: "User",
                    Mobile: uniqueMobile,
                    CountryID: 1,
                    aID: 0,
                    SignupIP: "127.0.0.1"
                );

                var result = JsonSerializer.Deserialize<ServiceResult>(
                    response.@return,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return new AuthResult
                    {
                    IsSuccess = result != null && result.ResultCode >= 0,
                    Message = string.IsNullOrEmpty(result?.ResultMessage) ? "Operation completed" : result!.ResultMessage,
                    EntityDetails = response.@return
                    };
                }
            catch (Exception ex)
                {
                return new AuthResult
                    {
                    IsSuccess = false,
                    Message = $"Error calling service: {ex.Message}"
                    };
                }
            }
        }
    }

namespace LoginTest.Models
    {
    public class ServiceResult
        {
        [JsonPropertyName("ResultCode")]
        public int ResultCode { get; set; }

        [JsonPropertyName("ResultMessage")]
        public string ResultMessage { get; set; } = "";

        [JsonPropertyName("EntityID")]
        public int? EntityID { get; set; }
        }
    }

