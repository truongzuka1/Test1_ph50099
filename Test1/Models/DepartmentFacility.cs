﻿using System;
using System.Collections.Generic;

namespace Test1.Models;

public partial class DepartmentFacility
{
    public byte? Status { get; set; }

    public long? CreatedDate { get; set; }

    public long? LastModifiedDate { get; set; }

    public Guid Id { get; set; }

    public Guid? IdDepartment { get; set; }

    public Guid? IdFacility { get; set; }

    public Guid? IdStaff { get; set; }

    public virtual Department? IdDepartmentNavigation { get; set; }

    public virtual Facility? IdFacilityNavigation { get; set; }

    public virtual Staff? IdStaffNavigation { get; set; }

    public virtual ICollection<MajorFacility> MajorFacilities { get; set; } = new List<MajorFacility>();
}
