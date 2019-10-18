using ProblemStatement.Model;
using StudentProfessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfessor
{
    class AccessDB
    {
        StudentProfessorEntities PSE = new StudentProfessorEntities();
        public List<StudentTaughtByProfessor> getAllStudentTaughtByProfessor()
        {
           List<StudentTaughtByProfessor> studentProfList = new List<StudentTaughtByProfessor>();
            try
            {
                PSE.tblProfessors.ToList().ForEach(prof =>
                {
                    List<studentEnrolTable> enrol = PSE.studentEnrolTables.Where(x => x.CourseId == prof.CourseId).ToList();
                    if (enrol.Count != 0)
                    {
                        StudentTaughtByProfessor stp = new StudentTaughtByProfessor();
                        courseTable course = PSE.courseTables.FirstOrDefault(c => c.CourseId == prof.CourseId);
                        enrol.ForEach(o =>
                        {
                            studentTable student = PSE.studentTables.FirstOrDefault(s => s.StudentId == o.StudentId);
                            stp.studentList.Add(student);
                        });
                        stp.courseName = course.CourseName;
                        stp.professorName = prof.ProfessorName;
                        studentProfList.Add(stp);
                    }
                });
                return studentProfList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public List<courseTable> getAvailableSubjects()
        {
            try
            {
                List<courseTable> courseList = PSE.courseTables.ToList();
                return courseList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool addStudent(string name,List<int> courseId)
        {
            try {
                studentTable student = new studentTable();
                student.StudentName = name;
                PSE.studentTables.Add(student);
                PSE.SaveChanges();
                courseId.ForEach(_courseId =>
                {
                    studentEnrolTable se = new studentEnrolTable();
                    se.CourseId = _courseId;
                    se.StudentId = student.StudentId;
                    PSE.studentEnrolTables.Add(se);
                    PSE.SaveChanges();
                });
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public studentTable getStudentById(int studentId)
        {
            try
            {
                studentTable student = PSE.studentTables.FirstOrDefault(x => x.StudentId == studentId);
                return student;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<studentEnrolTable> getEnrolments(int studentId)
        {
            try
            {
                List<studentEnrolTable> enrolList = PSE.studentEnrolTables.Where(x => x.StudentId == studentId).ToList();
                return enrolList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool updateEnrolment(int studentId, int courseId, int _courseId)
        {
            try
            {
                studentEnrolTable enrol = PSE.studentEnrolTables.FirstOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
                enrol.CourseId = _courseId;
                PSE.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool addEnrolment(int studentId, List<int> courseIdList)
        {
            try
            {
                courseIdList.ForEach(_courseId =>
                {
                    studentEnrolTable se = new studentEnrolTable();
                    se.CourseId = _courseId;
                    se.StudentId = studentId;
                    PSE.studentEnrolTables.Add(se);
                    PSE.SaveChanges();
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool removeEnrolment(int studentId, int courseId)
        {
            try
            {
                studentEnrolTable enrol = PSE.studentEnrolTables.SingleOrDefault(x => x.StudentId == studentId && x.CourseId == courseId);
                PSE.studentEnrolTables.Remove(enrol);
                PSE.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }
    }
}
