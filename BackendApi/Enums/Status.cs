using System.ComponentModel.DataAnnotations;

namespace BackendApi.Enums
{
    public enum Status
    {

        [Display(Name = "Não Enviado")]
        NaoEnviado = 1,

        [Display(Name = "Enviado")]
        Enviado = 2
    }
}
