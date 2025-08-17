using poms_website_project_2._0.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace poms_website_project_2._0.Repositories
{
    public class LearnerStore //: GenericStore<Learner>, ILearnerStore
    {
        /*
        private readonly PomsDbContext _context;

        public LearnerStore(PomsDbContext context) : base(context)
        {
            _context = context;
        } 

        public async Task<Learner> GetByFullNameAsync(string fullName)
        {
            return await _context.Learner
                .Include(s => s.LearnerNavigation)
                .FirstOrDefaultAsync(s => $"{s.LearnerNavigation.LastName}, {s.LearnerNavigation.FirstName} {s.LearnerNavigation.MiddleName}" == fullName);
        }

        public async Task<int?> GetLearnerIdByUserIdAsync(int userId)
        {
            var learner = await _context.Learner
               .Include(s => s.LearnerNavigation)
               .FirstOrDefaultAsync(s => s.UserId == userId);

            return learner?.UserId;
        }

        public async Task<Learner> GetLearnerByUserIdAsync(int userId)
        {
            return await _context.Learner
                .Include(s => s.LearnerNavigation)
                .FirstOrDefaultAsync(s => s.UserId == userId);
        } */
    }
}
