using Microsoft.AspNetCore.Identity;

namespace MVC2022.Services
{
    public class SeedRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //Metodo que cria os perfis membros e admin
        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole Role = new IdentityRole();
                Role.Name = "Member";
                Role.NormalizedName = "MEMBER";
                IdentityResult roleResult = _roleManager.CreateAsync(Role).Result;

            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole Role = new IdentityRole();
                Role.Name = "Admin";
                Role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(Role).Result;

            }
        }
        //Criar os usuario e atribuir aos perfis já criados
        public void SeedUsers()
        {
            if(_userManager.FindByEmailAsync("usuario@Localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "usuario@Localhost";
                user.Email = "usuario@Localhost";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled= false;
                user.SecurityStamp= Guid.NewGuid().ToString();
                IdentityResult result = _userManager.CreateAsync(user,"Numsey#20").Result;
               if(result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Member").Wait();
                }

            }
            if (_userManager.FindByEmailAsync("admin@Localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@Localhost";
                user.Email = "admin@Localhost";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
                IdentityResult result = _userManager.CreateAsync(user, "Numsey#20").Result;
                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }

            }
        }
    }
}
