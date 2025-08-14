using poms_website_project_2._0.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace poms_website_project_2._0.Repositories
{
    public class LearnerRepository //: GenericRepository<Learner>, ILearnerRepository
    {
        /*
        private readonly PomsDbContext _context;

        public LearnerRepository(PomsDbContext context) : base(context)
        {
            _context = context;
        } 

        public async Task<Learner> GetByFullNameAsync(string fullName)
        {
            return await _context.Learner
                .Include(s => s.LearnerNavigation)
                .FirstOrDefaultAsync(s => $"{s.LearnerNavigation.LastName}, {s.LearnerNavigation.FirstName} {s.LearnerNavigation.MiddleName}" == fullName);
        } */
    }
}
