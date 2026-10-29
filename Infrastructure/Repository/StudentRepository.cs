using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class StudentRepository(DataBase dataBase) : IStudentRepository
{
    private DataBase data1 = dataBase;

    public bool AddStudent(Student student)
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "intsert into students(fullname, email, phone, enrollmentdate)values(@fullname, @email, @phone, @enrollmentdate)";

        var stud = conn.Execute(query, student);
        return stud > 0;
    }

    public bool DeleteStudent(int id)
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "delete from students where id = @id";

        var stud = conn.Execute(query, new{id});
        return stud > 0;
    }

    public Student GetStudent(int id)
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "select * from students where id = @id";

        var stud = conn.QuerySingleOrDefault<Student>(query, new{id});
        return stud;
    }

    public List<Student> GetStudents()
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "select * from students";

        var stud = conn.Query<Student>(query).ToList();
        return stud;
    }

    public List<StudentGroup> GetStudentsWithGroups()
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = @"select s.id, s.fullname, g.groupname from student s 
        join studentgroups sg on sg.studentid = s.studentid 
        join groups g on g.groupid = sg.groupid";

        var student = conn.Query<StudentGroup>(query).ToList();
        return student;
    }

    public List<StudentGroup> GetStudentsWithoutGroups()
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = @"select s.id, s.fullname, g.groupname from student s 
        left join studentgroups sg on sg.studentid = s.studentid 
        left join groups g on g.groupid = sg.groupid
        where sg.studentid is null";

        var student = conn.Query<StudentGroup>(query).ToList();
        return student;
    }

    public int GetTotalStudentsCount()
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "select count(*) from students";
        var student = conn.ExecuteScalar<int>(query);
        return student;
    }


    public bool UpdateStudent(Student student)
    {
        using var conn = data1.Connection();
        conn.Open();

        var query = "update students set fullname = @fullname, email = @email, phone = @phone, enrollmentdate = @enrollmentdate where id = @id";
        var stud = conn.Execute(query, student);
        return stud > 0;
    }

}
