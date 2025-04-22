﻿using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class MajorFacility
{
    public byte? Status { get; set; }

    public long? CreatedDate { get; set; }

    public long? LastModifiedDate { get; set; }

    public Guid Id { get; set; }

    public Guid? IdDepartmentFacility { get; set; }

    public Guid? IdMajor { get; set; }

    public virtual DepartmentFacility? IdDepartmentFacilityNavigation { get; set; }

    public virtual Major? IdMajorNavigation { get; set; }

    public virtual ICollection<StaffMajorFacility> StaffMajorFacilities { get; set; } = new List<StaffMajorFacility>();
}
