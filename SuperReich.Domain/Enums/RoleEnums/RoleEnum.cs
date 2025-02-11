using System.ComponentModel.DataAnnotations;

namespace SuperReich.Domain.Enums.RoleEnums
{
    public enum RoleEnum
    {
        [Display(Name = "Administrador")]
        Administrator = 1,

        [Display(Name = "Auxiliar")]
        Assistant = 2,

        [Display(Name = "Soporte")]
        Support = 3,

        [Display(Name = "Cajero")]
        Cashier = 4,

        [Display(Name = "Desarrollador")]
        Developer = 5
    }
}
