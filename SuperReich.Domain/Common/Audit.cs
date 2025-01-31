namespace SuperReich.Domain.Common
{
    public abstract class Audit
    {
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
