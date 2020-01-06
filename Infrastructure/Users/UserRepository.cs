using Application.Interfaces;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {

        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(UserId key)
        {
            throw new NotImplementedException();
        }

        public Task<User> CreateAsync(User value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(User value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(UserId key)
        {
            throw new NotImplementedException();
        }


        //var viewModel = new InstructorIndexData();
        //viewModel.Instructors = await _context.Instructors
        //      .Include(i => i.OfficeAssignment)
        //  .Include(i => i.CourseAssignments)
        //    .ThenInclude(i => i.Course)
        //        .ThenInclude(i => i.Enrollments)
        //            .ThenInclude(i => i.Student)
        //  .Include(i => i.CourseAssignments)
        //    .ThenInclude(i => i.Course)
        //        .ThenInclude(i => i.Department)
        //  .AsNoTracking()
        //  .OrderBy(i => i.LastName)
        //  .ToListAsync();
    }
}
