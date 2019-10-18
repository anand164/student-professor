using ProblemStatement.Model;
using StudentProfessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProfessor
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            AccessDB access = new AccessDB();
            char ans;
            do
            {
                
                vewStudentTaughtByProfessor(access);
                Console.WriteLine("");
                Console.WriteLine("************************** STUDENT MENU ******************************");
                Console.WriteLine("1. View Student Taught By Professor.");
                Console.WriteLine("2. Add  Student.");
                Console.WriteLine("3. Change Student Enrolment.");
                Console.WriteLine("4. Add Student Enrolment.");
                Console.WriteLine("5. Remove Student Enrolment.");
                Console.WriteLine("6. Exit.");

                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("Enter Your Choice Here:-");
                int choose_number = Convert.ToInt32(Console.ReadLine());

                switch (choose_number)
                {
                    case 1:
                        vewStudentTaughtByProfessor(access);
                        break;
                    case 2:
                        addStudent(access);
                        break;
                    case 3:
                        changeStudentEnrolment(access);
                        break;
                    case 4:
                        addStudentEnrolment(access);
                        break;
                    case 5:
                        removeStudentEnrolment(access);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice....!!! Please Enter Correct Choice...!!!");
                        break;
                }
                Console.Write("Would You Like To Continue(Y/N):");
                try
                {
                    ans = Convert.ToChar(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    ans = 'n';
                }
            } while (ans == 'y' || ans == 'Y');
        }

        private static void removeStudentEnrolment(AccessDB access)
        {
            Console.Write("Enter Student Id:-");
            int studentId = Convert.ToInt32(Console.ReadLine());
            studentTable student = access.getStudentById(studentId);
            if (student != null)
            {
                List<studentEnrolTable> enrolList = access.getEnrolments(studentId);
                Console.Write("Do not enter Course Id from this list:");
                enrolList.ForEach(enrol => Console.Write("\t " + enrol.CourseId));
                Console.WriteLine("");
                Console.Write("Choose course id which you want remove ? ");
                int courseId = Convert.ToInt32(Console.ReadLine());
                if (enrolList.Exists(x => x.CourseId == courseId))
                {
                    if(enrolList.Count > 1)
                    {
                        bool result = access.removeEnrolment(studentId, courseId);
                        if (result) Console.WriteLine("Enrolment Removed Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student should have at least one enrolment!");
                    }
                }
                else
                {
                    Console.WriteLine("already exist course id it will not be added!!");
                }
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }

        private static void addStudentEnrolment(AccessDB access)
        {
            Console.Write("Enter Student Id:-");
            int studentId = Convert.ToInt32(Console.ReadLine());
            studentTable student = access.getStudentById(studentId);
            if (student != null)
            {
                Console.Write("Hello " + student.StudentName + " !!  Our Available subjects:-");
                List<courseTable> course = access.getAvailableSubjects();
                course.ForEach(c =>
                {
                    Console.WriteLine("Course Id: " + c.CourseId + ", Course Name: " + c.CourseName);
                });
                List<studentEnrolTable> enrolList = access.getEnrolments(studentId);
                Console.Write("Do not enter Course Id from this list:");
                enrolList.ForEach(enrol => Console.Write("\t " + enrol.CourseId));
                Console.WriteLine("");
                Console.Write("Choose how many subject u want?");
                int noOfSubj = Convert.ToInt32(Console.ReadLine());
                List<int> courseIdList = new List<int>();
                if (noOfSubj > course.Count)
                {
                    Console.Write("Invalid Selection!!!");
                }
                else
                {

                    for (int i = 1; i <= noOfSubj; i++)
                    {
                        Console.WriteLine("Enter " + i + " Course Id:-");
                        int courseId = Convert.ToInt32(Console.ReadLine());
                        if(!enrolList.Exists(x=>x.CourseId == courseId))
                        {
                            courseIdList.Add(courseId);
                        }
                        else
                        {
                            Console.WriteLine("already exist course id it will not be added!!");
                        }
                    }
                    if (courseIdList.Count > 0)
                    {
                        bool result = access.addEnrolment(studentId, courseIdList);
                        if (result) Console.WriteLine("Your Enrolment added successfully....");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }

        private static void changeStudentEnrolment(AccessDB access)
        {
            Console.Write("Enter Student Id:- ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            studentTable student = access.getStudentById(studentId);
            if(student != null)
            {
                List<studentEnrolTable> enrolList = access.getEnrolments(studentId);
                Console.Write("Your Course Enrolled list:");

                enrolList.ForEach(enrol => Console.Write("\t "+enrol.CourseId));
                Console.WriteLine("");
                Console.Write("Enter Course Id from this list:- ");

                int courseId = Convert.ToInt32(Console.ReadLine());
                if(enrolList.Exists(x => x.CourseId == courseId))
                {
                    Console.Write("Hello " + student.StudentName + " !!  Our Available subjects:-");
                    List<courseTable> course = access.getAvailableSubjects();
                    course.ForEach(c =>
                    {
                        Console.WriteLine("Course Id: " + c.CourseId + ", Course Name: " + c.CourseName);
                    });
                    Console.Write("Choose courseid to change u want?");
                    int _courseId = Convert.ToInt32(Console.ReadLine());
                    if (course.Exists(x => x.CourseId == _courseId))
                    {
                        bool result = access.updateEnrolment(studentId, courseId, _courseId);
                        if (result) Console.WriteLine("Your Enrolment changed successfully....");
                    }
                    else
                    {
                        Console.WriteLine("You have entered wrong course id...");
                    }
                }
                else
                {
                    Console.WriteLine("You have entered wrong course id...");
                }
            } 
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }

        private static void vewStudentTaughtByProfessor(AccessDB access)
        {
            Console.Clear();
            Console.WriteLine("Please wail while getting record...");
            List<StudentTaughtByProfessor> asdf = access.getAllStudentTaughtByProfessor();
            Console.Clear();
            if (asdf ==null || asdf.Count == 0)
            {
                Console.WriteLine("No student enrolled by any professor.");
            }
            else
            {
                asdf.ForEach(a =>
                {
                    Console.WriteLine("Professor Name :- "+ a.professorName +" and Course Name :- " + a.courseName);
                    Console.WriteLine("\tStudent Id\tStudent Name");
                    a.studentList.ForEach(ob =>
                    {
                        Console.WriteLine("\t"+ob.StudentId+"\t\t"+ob.StudentName);

                    });
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------------------------------------------------------");

                });
            }
        }

        private static void addStudent(AccessDB access)
        {
            Console.Write("Enter Your Name Here:-");
            string name = Console.ReadLine();
            Console.Write("Hello " + name + "Our Available subjects:-");
            List<courseTable> course = access.getAvailableSubjects();
            course.ForEach(c =>
            {
                Console.WriteLine("Course Id: " + c.CourseId + ",  Course Name: " + c.CourseName);
            });
            Console.Write("Choose how many subject which you want enrolment. ");
            int noOfSubj = Convert.ToInt32(Console.ReadLine());
            List<int> courseId = new List<int>();
            if (noOfSubj > course.Count)
            {
                Console.Write("Invalid Selection!!!");
            }
            else
            {

                for (int i = 1; i <= noOfSubj; i++)
                {
                    Console.WriteLine("Enter " + i + " Course Id:-");
                    courseId.Add(Convert.ToInt32(Console.ReadLine()));
                }
                bool result = access.addStudent(name, courseId);
                if (result) Console.WriteLine("Student added successfully....");
                
            }
        }
    }
}
