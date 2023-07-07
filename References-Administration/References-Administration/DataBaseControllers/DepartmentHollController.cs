using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace References_Administration
{
    public class DepartmentHollController
    {
        // Удалить связи с совещательными залами по Подразделению
        public static void RemoveDepartmentMeetingRooms(NpgsqlConnection connection, Department department)
        {
            string deleteMeetingRoomQuery = "DELETE FROM department_meetingroom WHERE departmentid = @DepartmentID";
            using (NpgsqlCommand deleteMeetingRoomCommand = new NpgsqlCommand(deleteMeetingRoomQuery, connection))
            {
                deleteMeetingRoomCommand.Parameters.AddWithValue("@DepartmentID", department.ID);
                deleteMeetingRoomCommand.ExecuteNonQuery();
            }
        }

        // Удаление всех записей в таблице department_meetingroom, связанных с совещательным залом
        public static void RemoveDepartmentMeetingRooms(NpgsqlConnection connection, Holl holl)
        {
            string deleteDepartmentMeetingRoomQuery = "DELETE FROM department_meetingroom WHERE MeetingRoomId = @MeetingRoomId";
            using (NpgsqlCommand deleteDepartmentMeetingRoomCommand = new NpgsqlCommand(deleteDepartmentMeetingRoomQuery, connection))
            {
                deleteDepartmentMeetingRoomCommand.Parameters.AddWithValue("@MeetingRoomId", holl.ID);
                deleteDepartmentMeetingRoomCommand.ExecuteNonQuery();
            }
        }

        public static void AddDepatrment(NpgsqlConnection connection, Department department, Holl holl)
        {
            string query = "INSERT INTO department_meetingroom (departmentid, meetingroomid) VALUES (@IdDepartmnet, @IdHoll)";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdDepartmnet", department.ID);
                command.Parameters.AddWithValue("@IdHoll", holl.ID);
                command.ExecuteNonQuery();
            }
        }

        public static void RemoveDepartment(NpgsqlConnection connection, Department department, Holl holl)
        {
            string query = "DELETE FROM department_meetingroom WHERE departmentid = @IdDepartmnet AND meetingroomid= @IdHoll";
            using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IdDepartmnet", department.ID);
                command.Parameters.AddWithValue("@IdHoll", holl.ID);
                command.ExecuteNonQuery();
            }
        }
    }
}
