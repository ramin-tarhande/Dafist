namespace DomainApp1.Domain
{
    public class Responsible
    {
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public Responsible(int departmentId, int employeeId)
        {
            DepartmentId = departmentId;
            EmployeeId = employeeId;
        }

        public override string ToString()
        {
            return string.Format("DepartmentId:{0} EmployeeId:{1}",DepartmentId, EmployeeId);
        }
    }
}
