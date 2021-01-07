using System;
using System.Net;
using NS.DTO.Acount;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using NS.Client.Services.Interfaces;

namespace NS.Client.Services
{
    public class NSApiClient : INSApiClient
    {
        // move to RestSharp
        // https://www.nuget.org/packages/RestSharp
        // https://restsharp.dev/


        private readonly HttpClient _httpClient;

        public NSApiClient(string baseAddress, string jwt = default)
        {
            // this will ignore server certificate
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            _httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };

            if (!string.IsNullOrWhiteSpace(jwt))
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        public Task<Result> Logout()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            return Task.FromResult(new Result().Succeed());
        }

        public async Task<Result> Login(string username, string password)
        {
            var body = new AuthenticateRequest { Username = username, Password = password };

            var response = await _httpClient.PostAsJsonAsync("api/User/Authenticate", body).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<AuthenticateResponse>().ConfigureAwait(false);

                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", data.Token);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return new Result().Succeed();
            }

            return new Result().Failed(response.StatusCode);
        }

        public async Task<Result<Tout>> GetAsync<Tout>(string requestUri, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<Tout>(cancellationToken).ConfigureAwait(false);

                    return new Result<Tout>().Succeed(data);
                }

                return new Result<Tout>().Failed(response.StatusCode);
            }
            catch (Exception ex)
            {
                return new Result<Tout>().Failed(message: requestUri, exception: ex);
            }
        }

        public async Task<Result<Tout>> PostAsync<Tin, Tout>(string requestUri, Tin data, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(requestUri, data, cancellationToken).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Tout>(cancellationToken).ConfigureAwait(false);

                    return new Result<Tout>().Succeed(result);
                }

                return new Result<Tout>().Failed(response.StatusCode, message: requestUri);
            }
            catch (Exception ex)
            {
                return new Result<Tout>().Failed(message: requestUri, exception: ex);
            }
        }

        public async Task<Result<Tout>> PutAsync<Tin, Tout>(string requestUri, Tin data, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(requestUri, data, cancellationToken).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Tout>(cancellationToken).ConfigureAwait(false);

                    return new Result<Tout>().Succeed(result);
                }

                return new Result<Tout>().Failed(response.StatusCode, message: requestUri);
            }
            catch (Exception ex)
            {
                return new Result<Tout>().Failed(message: requestUri, exception: ex);
            }
        }

    }
}