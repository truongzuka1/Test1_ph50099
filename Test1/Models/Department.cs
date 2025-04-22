using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class Department
{
    public byte? Status { get; set; }

    public long? CreatedDate { get; set; }

    public long? LastModifiedDate { get; set; }

    public Guid Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DepartmentFacility> DepartmentFacilities { get; set; } = new List<DepartmentFacility>();
}
