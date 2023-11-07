using System.Security.Claims;
using System.Threading.Tasks;
using Acesvv.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

public class ChaveADMService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<UsuarioModel> _userManager;

    public ChaveADMService(IHttpContextAccessor httpContextAccessor, UserManager<UsuarioModel> userManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task<bool> IsChaveADMValid(int requiredValue)
    {
        if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);

            if (user != null && user.Chave_ADM != requiredValue)
            {
                return true;
            }
        }

        return false;
    }
}
