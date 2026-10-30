using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class StudentRepository(DataBase dataBase) : IStudentRepository
{
    private DataBase data1 = dataBase;

    public async Task<bool> AddStudentAsync(Student student)
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "intsert into students(fullname, email, phone, enrollmentdate)values(@fullname, @email, @phone, @enrollmentdate)";

        var stud = await conn.ExecuteAsync(query, student);
        return stud>0;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "delete from students where id = @id";

        var stud = await conn.ExecuteAsync(query, new{id});
        return stud > 0;
    }

    public async Task<Student> GetStudentAsync(int id)
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "select * from students where id = @id";

        var stud = await conn.QuerySingleAsync<Student>(query, new{id});
        return stud;
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "select * from students";

        var stud = await conn.QueryAsync<Student>(query);
        return stud.ToList();
    }

    public async Task<List<StudentGroup>> GetStudentsWithGroupsAsync()
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = @"select s.id, s.fullname, g.groupname from student s 
        join studentgroups sg on sg.studentid = s.studentid 
        join groups g on g.groupid = sg.groupid";

        var student = await conn.QueryAsync<StudentGroup>(query);
        return student.ToList();
    }

    public async Task<List<StudentGroup>> GetStudentsWithoutGroupsAsync()
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = @"select s.id, s.fullname, g.groupname from student s 
        left join studentgroups sg on sg.studentid = s.studentid 
        left join groups g on g.groupid = sg.groupid
        where sg.studentid is null";

        var student = await conn.QueryAsync<StudentGroup>(query);
        return student.ToList();
    }

    public async Task<int> GetTotalStudentsCountAsync()
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "select count(*) from students";
        var student = await conn.ExecuteAsync(query);
        return student;
    }


    public async Task<bool> UpdateStudentAsync(Student student)
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "update students set fullname = @fullname, email = @email, phone = @phone, enrollmentdate = @enrollmentdate where id = @id";
        var stud = conn.Execute(query, student);
        return stud > 0;
    }

}
