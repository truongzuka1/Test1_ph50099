namespace Test1.ViewModel
{
    public class StaffViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StaffCode { get; set; }
        public string AccountFe { get; set; }
        public string AccountFpt { get; set; }
        public string DepartmentName { get; set; } // Tên phòng ban
        public string MajorName { get; set; } // Tên chuyên ngành
        public byte? Status { get; internal set; }
    }
}
