// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var q = Student.GetStudents().SelectMany(x=>x.lessons,
    (parent,child)=>
        new
        {
            parent = parent.lessons,
            child = parent.Marks,
            
        }
    
    ).SelectMany(x=>x.child,
    (parent1,child1)=>
        new
        {
            parent1 = parent1.parent,
            child1 = parent1.child,
        }
    ).ToList();
foreach(var x in q)
{
    foreach(var y in x.parent1)
    {
        Console.WriteLine(y);

    }

    foreach (var y in x.child1)
    {
        Console.WriteLine(y.Key+":"+String.Join(" ",y.Value));

    }
}
class Student
{
    int Id { get; set; }

    public string Name { get; set; }

    public List<int> lessons { get; set; }
    public Dictionary<int, List<int>> Marks { get; set; }

    public static List<Student> GetStudents()
    {
        var students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Sevinch",
                lessons = new List<int>() { 1, 2 },
                Marks = new Dictionary<int, List<int>>() { { 1, new List<int>() { 4, 5 } }, { 2, new List<int>() { 5, 4 } } }
            },
             new Student()
            {
                Id = 2,
                Name = "Sadaf",
                lessons = new List<int>() { 1, 2 },
                Marks = new Dictionary<int, List<int>>() { { 1, new List<int>() { 4, 4 } }, { 2, new List<int>() { 4, 4 } } }
            },
        };

        return students;
    }
}