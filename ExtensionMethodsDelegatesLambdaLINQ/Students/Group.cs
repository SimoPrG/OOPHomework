/*Problem 16.* Groups

    Create a class Group with properties GroupNumber and DepartmentName.
    Introduce a property GroupNumber in the Student class.
    Extract all students from "Mathematics" department.
    Use the Join operator.
*/

namespace Students
{
    public class Group
    {
        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public int GroupNumber { get; private set; }

        public string DepartmentName { get; private set; }
    }
}
