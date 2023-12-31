using Microsoft.AspNetCore.Identity;
using TLG.Infrastructure.Data;
using TLG.Core.Entities;

namespace TLG.Api.Security
{
  public class IdentityInitializer
  {
    private readonly ApiSecurityDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityInitializer(
        ApiSecurityDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
      _context = context;
      _userManager = userManager;
      _roleManager = roleManager;
    }

    public void Initialize()
    {
      if (_context.Database.EnsureCreated())
      {
        if (!_roleManager.RoleExistsAsync(Roles.ROLE_ACESSO_APIS!).Result)
        {
          var resultado = _roleManager.CreateAsync(
              new IdentityRole(Roles.ROLE_ACESSO_APIS!)).Result;
          if (!resultado.Succeeded)
          {
            throw new Exception(
                $"Erro durante a criação da role {Roles.ROLE_ACESSO_APIS}.");
          }
        }

        CreateUser(
            new ApplicationUser()
            {
              UserName = "Guilherme",
              Email = "guilherme.pomp@tlg.com",
              EmailConfirmed = true
            }, "Usr01ApiValido01!", Roles.ROLE_ACESSO_APIS);

        CreateUser(
            new ApplicationUser()
            {
              UserName = "Pompilio",
              Email = "pompilio@tlg.com",
              EmailConfirmed = true
            }, "Usr01ApiValido01!", Roles.ROLE_ACESSO_APIS);
      }
    }

    private void CreateUser(
        ApplicationUser user,
        string password,
        string? initialRole = null)
    {
      if (_userManager.FindByNameAsync(user.UserName!).Result == null)
      {
        var resultado = _userManager
            .CreateAsync(user, password).Result;

        if (resultado.Succeeded &&
            !String.IsNullOrWhiteSpace(initialRole))
        {
          _userManager.AddToRoleAsync(user, initialRole).Wait();
        }
      }
    }
  }
}