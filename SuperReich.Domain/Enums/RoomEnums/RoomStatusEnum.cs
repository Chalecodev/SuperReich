using System.ComponentModel.DataAnnotations;

namespace SuperReich.Domain.Enums.RoomEnums
{
    public enum RoomStatusEnum
    {
        [Display(Name = "Disponible")]
        Available,

        [Display(Name = "Ocupado")]
        Occupied,

        [Display(Name = "En limpieza")]
        Cleaning,

        [Display(Name = "En mantenimiento")]
        Maintenance
    }
}
