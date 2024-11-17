using Google.Apis.Auth;

public class GoogleTokenService
{
    public async Task<GoogleJsonWebSignature.Payload> ValidateGoogleToken(string idToken)
    {
        try
        {
            // Giải mã và xác thực token ID
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            return payload;
        }
        catch (InvalidJwtException ex)
        {
            // Token không hợp lệ
            throw new Exception("Invalid Google ID token", ex);
        }
    }
}