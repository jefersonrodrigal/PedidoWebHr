using System.ComponentModel.DataAnnotations;

namespace BackendApi.Models
{
    public class UserModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string Role {  get; set; } = string.Empty;
        public int CodUsu {  get; set; }
        public int CodEmp { get; set; }
    }
}
