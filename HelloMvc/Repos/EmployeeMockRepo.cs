using HelloMvc.Models;

namespace HelloMvc.Repos {
    public class EmployeeMockRepo : IEmployeeRepo {
        private List<Employee> _employees;

        public EmployeeMockRepo() {
            var eml = new List<Employee>();
            eml.Add(new Employee() {
                EmployeeId = 1,
                FirstName = "Bob", LastName = "Smith",
                VacationRequests = new List<VacationRequest>()
                {
                    new VacationRequest()
                    {
                        VacationRequestId = 1,
                        EmployeeId = 1,
                        StartDate = new DateTime(2023,12,25),
                        EndDate = new DateTime(2023,12,25),
                        Comment = "Going to visit the family for Christmas"
                    },

                    new VacationRequest()
                    {
                        VacationRequestId = 2,
                        EmployeeId = 1,
                        StartDate = new DateTime(2023,6,6),
                        EndDate = new DateTime(2023,6,9),
                        Comment = "Summer Vacation"
                    }
                }
            });

            eml.Add(new Employee() { EmployeeId = 2, FirstName = "Victoria", LastName = "Kelley" });
            eml.Add(new Employee() { EmployeeId = 3, FirstName = "Joe", LastName = "Caldwell" });
            _employees = eml;
        }
        public List<Employee> GetAllEmployees() {
            return _employees;
        }

        public Employee CreateEmployee(Employee employee) {
            employee.EmployeeId = _employees.Max(p => p.EmployeeId) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee GetById(int employeeId) {
            var response = _employees.FirstOrDefault(p => p.EmployeeId == employeeId);
            return response;
        }

        public Employee Update(Employee employee) {
            var entity = _employees.FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
            entity.FirstName = employee.FirstName;
            entity.LastName = employee.LastName;
            return entity;

        }

        public List<VacationRequest> EmployeeVacationsRetrieve(int employeeId) {
            var employee = _employees.FirstOrDefault(p => p.EmployeeId == employeeId);
            if (employee != null) {
                return employee.VacationRequests;
            }
            return null;
        }

        public VacationRequest VacationsRequestRetrieveById(int vacationRequestId) {
            var vacationRequest = _employees.SelectMany(p => p.VacationRequests)
                .FirstOrDefault(p => p.VacationRequestId == vacationRequestId);
            return vacationRequest;
        }

        public bool VacationsRequestDelete(int vacationRequestId, int employeeId) {

            var employee = _employees.FirstOrDefault(p => p.EmployeeId == employeeId);
            if (employee != null) {
                //employee.VacationRequests = employee.VacationRequests.Where(p => p.VacationRequestId != vacationRequestId).ToList();

                var vacationRequest = employee.VacationRequests.FirstOrDefault(p => p.VacationRequestId == vacationRequestId);
                employee.VacationRequests.Remove(vacationRequest);

            }
            return true;
        }

        public VacationRequest VacationsRequestCreate(VacationRequest vacationRequest)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeOfMonth()
        {
            throw new NotImplementedException();
        }
    }
}
