using MVC_TravelProject.Models;

namespace MVC_TravelProject.Repository
{
	public class EmployeeRepository:IEmployeeRepository
	{
		private readonly employeeTravelContext _context;

		public EmployeeRepository(employeeTravelContext context)
		{
			_context = context;
		}
		public IEnumerable<Employee> GetEmployees()
		{
			return _context.Employees;
		}
        //Add Employee
        public void AddEmployee(Employee emp)
        {
            if (emp != null)
            {
                _context.Employees.Add(emp);
                _context.SaveChanges();
            }

        }
        public void DeleteEmployee(int EmployeeID)
        {
            Employee? emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeID);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
        }

        public Employee GetEmployeeById(int EmployeeId)
        {
            Employee? emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            return emp;
        }

        public void UpdateEmployee(Employee emp, int EmployeeId)
        {
            Employee? emp_old = _context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            if (emp_old != null)
            {
                emp_old.FirstName = emp.FirstName;
                emp_old.LastName = emp.LastName;
                emp_old.Contact = emp.Contact;
                emp_old.Dept = emp.Dept;
                emp_old.Address = emp.Address;
                emp_old.Dob = emp.Dob;
                _context.SaveChanges();

            }

        }

    }
}
