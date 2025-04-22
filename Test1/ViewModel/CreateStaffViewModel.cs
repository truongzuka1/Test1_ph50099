namespace Test1.ViewModel
{
    public class CreateStaffViewModel
    {
        public string Name { get; set; }
        public string StaffCode { get; set; }
        public string AccountFe { get; set; }
        public string AccountFpt { get; set; }
        public Guid DepartmentId { get; set; } // Phòng ban
        public Guid MajorId { get; set; } // Chuyên ngành
        public byte? Status { get; set; } // Trạng thái, nếu có
    }


}
