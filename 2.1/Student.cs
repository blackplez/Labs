using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    internal sealed class Student : IEquatable<Student>
    {
        #region Fields
        private readonly string? _firstname;
        private readonly string? _lastname;
        private readonly string? _surname;
        private readonly string? _studyGroup;
        private readonly string? _recordBookNumber;
        private readonly int _course;
        #endregion

        #region Properties

        public string Fullname
        {
            get => $"{Firstname} {Lastname} {Surname}";
        }

        public string Firstname
        {
            get => _firstname!;
            private init => _firstname=ThrowIfNullOrEmpty(value);
        }

        public string Lastname
        {
            get => _lastname!;
            private init => _lastname=ThrowIfNullOrEmpty(value);
        }

        public string Surname
        {
            get => _surname!;
            private init => _surname=ThrowIfNullOrEmpty(value);
        }

        public string StudyGroup
        {
            get => _studyGroup!;
            private init => _studyGroup=ThrowIfNullOrEmpty(value);
        }

        public string RecordBookNumber
        {
            get => _recordBookNumber!;
            private init => _recordBookNumber=ThrowIfNullOrEmpty(value);
        }

        public int Course
        {
            get => _course;
            private init => _course = (value >= 1 && value <= 4) ? value 
                           : throw new ArgumentException($"Argument must be from 1 to 4: {paramname()}");   
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize student
        /// </summary>
        /// <param name="firstname">Students Firstname</param>
        /// <param name="lastname">Students Lastname</param>
        /// <param name="surname">Students Surname</param>
        /// <param name="studyGroup">Students StudyGroup</param>
        /// <param name="recordBookNumber">Strudent Record book number</param>
        /// <param name="course">Student course</param>
        public Student(
            string? firstname,
            string? lastname,
            string? surname,
            string? studyGroup,
            string? recordBookNumber,
            int course)
        {
            Firstname = firstname!;
            Lastname = lastname!;
            Surname = surname!;
            StudyGroup = studyGroup!;
            RecordBookNumber = recordBookNumber!;
            Course = course;
        }

        #endregion

        #region ValidateMethods
        private string ThrowIfNullOrEmpty(string str, [CallerMemberName] string paramName = "")
        {
            this.ThrowIfNull(str).ThrowIfEmpty(str);
            return str;
        }
       
        private Student ThrowIfNull(string str, [CallerMemberName] string paramName = "")
        {
            if (str is null) throw new ArgumentNullException($"Argument can'be equals null value: {paramName}");
            return this;
        }
       
        private Student ThrowIfEmpty(string str, [CallerMemberName] string paramName = "")
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentException($"Argument must be valide value: {paramName}");
            return this;
        }

        private string paramname([CallerMemberName] string paramName = "")
        {
            return paramName;
        }
        #endregion

        #region OverrideMethods


        public override string ToString()
        {
            return $"{Fullname}, group {_studyGroup}, course {_course}, record book N{_recordBookNumber}";
        }

        public override int GetHashCode()
        {          
            var value = new HashCode();
            value.Add(Firstname);
            value.Add(Lastname);
            value.Add(Surname);
            value.Add(StudyGroup);
            value.Add(RecordBookNumber);
            value.Add(Course);
            return value.ToHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Student) return false;
            return Equals(obj as Student);
        }

        //реализуем Equals из интерфейса IEquatable
        public bool Equals(Student? student)
        {
            if (student is null) return false;
            return Firstname.Equals(student.Firstname)
                && Lastname.Equals(student.Lastname)
                && Surname.Equals(student.Surname)
                && RecordBookNumber.Equals(student.RecordBookNumber)
                && Course.Equals(student.Course)
                && StudyGroup.Equals(student.StudyGroup);
        }

        #endregion
    }



}
