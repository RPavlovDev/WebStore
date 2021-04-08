using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class AccountViewModel
    {
        public RegisterViewModel Register { get; set; }
        public LoginViewModel Login { get; set; }
    }
}
