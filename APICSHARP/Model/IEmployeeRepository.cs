namespace APICSHARP.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> GetAll();
    }
}
