
using BackendApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendApi.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public string Segment {  get; set; } = string.Empty;
    }
}
