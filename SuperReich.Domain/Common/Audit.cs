﻿namespace SuperReich.Domain.Common
{
    public abstract class Audit
    {
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? IsActivated { get; set; } = true;
    }
}
