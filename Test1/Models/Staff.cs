using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class Staff
{
    public byte? Status { get; set; }

    public long? CreatedDate { get; set; }

    public long? LastModifiedDate { get; set; }

    public Guid Id { get; set; }

    public string? AccountFe { get; set; }

    public string? AccountFpt { get; set; }

    public string? Name { get; set; }

    public string? StaffCode { get; set; }

    public virtual ICollection<DepartmentFacility> DepartmentFacilities { get; set; } = new List<DepartmentFacility>();

    public virtual ICollection<StaffMajorFacility> StaffMajorFacilities { get; set; } = new List<StaffMajorFacility>();
}
