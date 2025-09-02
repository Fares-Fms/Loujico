using System;
using System.Collections.Generic;

namespace Loujico.Models;

public partial class TbInvoice
{
    public int Id { get; set; }

    public int? CustomerId { get; set; }

    public int? ProjectId { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? InvoicesDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public string? InvoiceStatus { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? LastVisit { get; set; }

    public bool IsDeleted { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual TbCustomer? Customer { get; set; }

    public virtual TbProject? Project { get; set; }
}
