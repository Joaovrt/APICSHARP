using APICSHARP.Domain.DTOs;

namespace APICSHARP.Domain.Model.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<EmployeeDTO> GetAll(int pageNumber, int pageQuantity);
        Employee? Get(int id);
    }
}
