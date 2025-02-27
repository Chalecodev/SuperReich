using System.ComponentModel.DataAnnotations;
using SuperReich.Domain.Common;

namespace SuperReich.Domain.Entities.PaymentMethods
{
    public class PaymentMethod: Audit
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
