using APICSHARP.Model;

namespace APICSHARP.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext(); 
        void IEmployeeRepository.Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        List<Employee> IEmployeeRepository.GetAll()
        {
            return _context.Employees.ToList();
        }
    }
}
