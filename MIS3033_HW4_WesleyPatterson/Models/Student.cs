using System.ComponentModel.DataAnnotations;

namespace a
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; } = "";
        public double grade { get; set; } = 0.0;
        public int gradeLevel { get; set; } = 0;

        public int getGradeLevel()
        {
            int answer = 1;
            if(grade < 65)
            {
                return  3;
            }
            else if(grade < 80)
            {
                return  2;
            }
            else if(grade >= 80)
            {
                return 1;
            }  else
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return $"{name} ({Id}), Grade: {grade:F2} ({gradeLevel})";
        }
    }
}