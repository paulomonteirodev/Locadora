using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Paulo.Data.Identity.Models;

namespace Paulo.Data.Identity.Config
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        // Utilizado no ConfigureAuth da classe Startup.Auth.cs
        public static IDataProtectionProvider DataProtectionProvider { get; set; }

        public ApplicationUserManager(IUserStore<ApplicationUser, int> store)
            : base(store)
        {
            // Configuração de validação para o nome do usuário
            UserValidator = new UserValidator<ApplicationUser, int>(this)
            {
                // Desabilita a configuração de apenas caracteres alfanumericos.
                AllowOnlyAlphanumericUserNames = false,

                // Configuração para que o email seja unico.
                RequireUniqueEmail = true
            };

            // Configuração de validação da senha 
            PasswordValidator = new PasswordValidator
            {
                // Precisa ter no minimo 6 caracteres
                RequiredLength = 6,

                // Precisa ter pelo menos 1 caracter especial
                RequireNonLetterOrDigit = true,

                // Precisa ter pelo menos um numero
                RequireDigit = true,

                // Precisa ter pelo menos uma letra minuscula
                RequireLowercase = true,

                // Precisa ter pelo menos uma letra maiuscula
                RequireUppercase = true,
            };

            // Registrando os providers para two factor
            RegisterTwoFactorProvider("Código via SMS",
                new PhoneNumberTokenProvider<ApplicationUser, int>
                {
                    MessageFormat = "Seu código de segurança é: {0}"
                });

            RegisterTwoFactorProvider("Código via e-mail",
                new EmailTokenProvider<ApplicationUser, int>
                {
                    Subject = "Código de segurança",
                    BodyFormat = "Seu código de segurança é: {0}"
                });

            // Classe para serviço de email
            EmailService = new EmailService();

            var provider = DataProtectionProvider;
            if (provider != null)
            {
                var dataProtector = provider.Create("ASP.NET Identity");
                UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, int>(dataProtector);
            }
        }

        public override Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            user.DataDeCadastro = DateTime.Now;

            return base.CreateAsync(user, password);
        }
    }
}
