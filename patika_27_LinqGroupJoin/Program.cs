namespace patika_27_LinqGroupJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Yapıcı method'u olan class'dan list tanımlama
            List<Students> students = new List<Students>
            {
                new Students(1, "Ali", 1),
                new Students(2, "Ayşe",2),
                new Students(3, "Mehmet",1),
                new Students(4, "Fatma",3),
                new Students(5, "Ahmet",2),
            };

            // Yapıcı methodu olmayan class'dan list tanımlama
            List<Classes> classes = new List<Classes>()
            {
                new Classes{ClassId = 1, ClassName ="Matematik"},
                new Classes{ClassId = 2, ClassName ="Türkçe"},
                new Classes{ClassId = 3, ClassName ="Kimya"},
            };

            var query = classes.GroupJoin(students,
                                          classes => classes.ClassId,
                                          student => student.ClassId,
                                          (classes,student) => new
                                          {
                                              ClassName = classes.ClassName,
                                              StudentName = student.Select(student => student.StudentName)
                                          });


            foreach(var c in query)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Sınıf: "+c.ClassName);
                Console.ResetColor();
                foreach(var s in c.StudentName)
                {
                    Console.WriteLine("Öğrenci: " + s);
                }
                Console.WriteLine("*******************\r\n");

            }

        }


        // Student Class
        public class Students
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public int ClassId { get; set; }

            public Students(int studentId, string studentName, int classId)
            {
                StudentId = studentId;
                StudentName = studentName;
                ClassId = classId;
            }
        }

        // Classes Class
        public class Classes
        {
            public int ClassId { get; set; }
            public string ClassName { get; set; }
        }
    }
}
