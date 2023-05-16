using HelloMvc.Data;
using HelloMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Repos {
    public class EmployeeRepo: IEmployeeRepo {
        private readonly EmployeeContext _context;

        public EmployeeRepo(EmployeeContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.Include(p=>p.VacationRequests).ToList();
        }

        public Employee CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee GetById(int employeeId)
        {
            return _context.Employees.Include(p=>p.VacationRequests).FirstOrDefault(p=>p.EmployeeId==employeeId);
        }

        public List<VacationRequest> EmployeeVacationsRetrieve(int employeeId)
        {
            return _context.VacationRequests.Where(p => p.EmployeeId == employeeId).ToList();
        }

        public VacationRequest VacationsRequestRetrieveById(int vacationRequestId)
        {
            return _context.VacationRequests.Find(vacationRequestId);
        }

        public bool VacationsRequestDelete(int vacationRequestId, int employeeId)
        {
            var  vacation=_context.VacationRequests.Find(vacationRequestId);
            if (vacation != null)
            {
                _context.VacationRequests.Remove(vacation);
            }

            _context.SaveChanges();
            return true;
        }

        public VacationRequest VacationsRequestCreate(VacationRequest vacationRequest)
        {
            _context.VacationRequests.Add(vacationRequest);
            _context.SaveChanges();
            return vacationRequest;
        }
    }
}
