using HelloMvc.Models;

namespace HelloMvc.Repos {
    public interface IEmployeeRepo
    {
        public List<Employee> GetAllEmployees();
        public Employee CreateEmployee(Employee employee);
        public Employee GetById(int employeeId);
        public List<VacationRequest> EmployeeVacationsRetrieve(int employeeId);
        public VacationRequest VacationsRequestRetrieveById(int vacationRequestId);
        public bool VacationsRequestDelete(int vacationRequestId, int employeeId);
        public VacationRequest VacationsRequestCreate(VacationRequest vacationRequest);
    }
}
