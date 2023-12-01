using MVC_TravelProject.Models;

namespace MVC_TravelProject.Repository
{
	public interface IEmployeeRepository
	{

		IEnumerable<Employee> GetEmployees();
        public void AddEmployee(Employee emp);

        public void DeleteEmployee(int EmployeeID);
        public void UpdateEmployee(Employee emp, int EmployeeID);

        public Employee GetEmployeeById(int EmployeeID);
    }
}
