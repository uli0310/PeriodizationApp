using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace PeriodizationApp.Client.Services
{
    public class UserSessionService
    {
        private readonly IJSRuntime _js;
        private bool _initialized = false;

        public Guid UserId { get; private set; } = Guid.Parse("01a16050-b677-7a66-8e94-f01f9e256cfc");
        public string Username { get; private set; } = "odysseus";
        public string Email { get; private set; } = "demo@odysseus.app";
        public bool IsAuthenticated { get; private set; } = true;

        public event Action? OnChange;

        public UserSessionService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task InitializeAsync()
        {
            if (_initialized) return;
            _initialized = true;

            try
            {
                var storedId = await _js.InvokeAsync<string?>("localStorage.getItem", "odysseus_user_id");
                var storedName = await _js.InvokeAsync<string?>("localStorage.getItem", "odysseus_username");
                var storedEmail = await _js.InvokeAsync<string?>("localStorage.getItem", "odysseus_email");
                var loggedOut = await _js.InvokeAsync<string?>("localStorage.getItem", "odysseus_logged_out");

                if (loggedOut == "true")
                {
                    IsAuthenticated = false;
                    UserId = Guid.Empty;
                    Username = "Invitado";
                    Email = string.Empty;
                }
                else if (Guid.TryParse(storedId, out Guid parsedId) && parsedId != Guid.Empty)
                {
                    UserId = parsedId;
                    Username = string.IsNullOrWhiteSpace(storedName) ? "Atleta" : storedName;
                    Email = storedEmail ?? string.Empty;
                    IsAuthenticated = true;
                }

                NotifyStateChanged();
            }
            catch
            {
                // Ignorar si JSInterop aún no está listo
            }
        }

        public async Task SetUserAsync(Guid id, string username, string email)
        {
            UserId = id;
            Username = username;
            Email = email;
            IsAuthenticated = true;
            _initialized = true;

            try
            {
                await _js.InvokeVoidAsync("localStorage.setItem", "odysseus_user_id", id.ToString());
                await _js.InvokeVoidAsync("localStorage.setItem", "odysseus_username", username);
                await _js.InvokeVoidAsync("localStorage.setItem", "odysseus_email", email ?? string.Empty);
                await _js.InvokeVoidAsync("localStorage.removeItem", "odysseus_logged_out");
            }
            catch { }

            NotifyStateChanged();
        }

        public async Task LogoutAsync()
        {
            IsAuthenticated = false;
            UserId = Guid.Empty;
            Username = "Invitado";
            Email = string.Empty;

            try
            {
                await _js.InvokeVoidAsync("localStorage.removeItem", "odysseus_user_id");
                await _js.InvokeVoidAsync("localStorage.removeItem", "odysseus_username");
                await _js.InvokeVoidAsync("localStorage.removeItem", "odysseus_email");
                await _js.InvokeVoidAsync("localStorage.setItem", "odysseus_logged_out", "true");
            }
            catch { }

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
