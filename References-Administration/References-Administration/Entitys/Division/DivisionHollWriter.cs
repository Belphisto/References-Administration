using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class DivisionHollWriter : IDivisionHollWriter
    {
        private readonly NpgsqlConnection _connection;

        public DivisionHollWriter(DataBaseConntection connection)
        {
            _connection = connection.GetConnection();
        }

        public void AddDepatrment(Division department, Holl holl)
        {
            string query = "INSERT INTO department_meetingroom (departmentid, meetingroomid) VALUES (@IdDepartmnet, @IdHoll)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@IdDepartmnet", department.ID);
                command.Parameters.AddWithValue("@IdHoll", holl.ID);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveDepartment(Division department, Holl holl)
        {
            string query = "DELETE FROM department_meetingroom WHERE departmentid = @IdDepartmnet AND meetingroomid= @IdHoll";
            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@IdDepartmnet", department.ID);
                command.Parameters.AddWithValue("@IdHoll", holl.ID);
                command.ExecuteNonQuery();
            }
        }

        public void RemoveDepartmentMeetingRooms(Holl holl)
        {
            string deleteDepartmentMeetingRoomQuery = "DELETE FROM department_meetingroom WHERE MeetingRoomId = @MeetingRoomId";
            using (NpgsqlCommand deleteDepartmentMeetingRoomCommand = new NpgsqlCommand(deleteDepartmentMeetingRoomQuery, _connection))
            {
                deleteDepartmentMeetingRoomCommand.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                deleteDepartmentMeetingRoomCommand.ExecuteNonQuery();
            }
        }

        public void RemoveDepartmentMeetingRooms(Division department)
        {
            string deleteMeetingRoomQuery = "DELETE FROM department_meetingroom WHERE departmentid = @DepartmentID";
            using (NpgsqlCommand deleteMeetingRoomCommand = new NpgsqlCommand(deleteMeetingRoomQuery, _connection))
            {
                deleteMeetingRoomCommand.Parameters.AddWithValue("@DepartmentID", department.ID);
                deleteMeetingRoomCommand.ExecuteNonQuery();
            }
        }
    }
}
