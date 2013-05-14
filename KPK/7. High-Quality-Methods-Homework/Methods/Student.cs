using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = new DateTime();
            if(!DateTime.TryParse(this.OtherInfo.Substring(this.OtherInfo.Length - 10), out firstDate))
            {
                throw new FormatException("Student's date of birth is in an invalid input format.");
            }

            DateTime secondDate = new DateTime();
            if(DateTime.TryParse(other.OtherInfo.Substring(other.OtherInfo.Length - 10), out secondDate))
            {
                throw new FormatException("Date of birth, to compare, is in an invalid input format.");
            }
            return firstDate > secondDate;
        }
    }
}
