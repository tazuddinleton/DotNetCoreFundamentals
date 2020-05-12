using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EnrollmentApp.Entities
{
    public class Enrollments : ICollection<Enrollment>
    {
        private List<Enrollment> _enrollments;

        public Enrollments()
        {
            _enrollments = new List<Enrollment>();
        }
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => false;

        public void Add(Enrollment item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Enrollment item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Enrollment[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Enrollment> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Enrollment item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
