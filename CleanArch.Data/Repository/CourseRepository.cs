using CleanArch.Data.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private VarsityDbContext _dbContext;
        public CourseRepository(VarsityDbContext varsityDbContext)
        {
            this._dbContext = varsityDbContext;
        }
        public IEnumerable<Course> GetCourses()
        {
            return _dbContext.Courses.ToList();
        }
    }
}
