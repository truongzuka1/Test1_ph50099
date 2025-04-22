using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class Major
{
    public byte? Status { get; set; }

    public long? CreatedDate { get; set; }

    public long? LastModifiedDate { get; set; }

    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<MajorFacility> MajorFacilities { get; set; } = new List<MajorFacility>();
}
