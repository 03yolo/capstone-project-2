using poms_website_project_2._0.Data.Entities;
using poms_website_project_2._0.Models;

namespace poms_website_project_2._0.Repositories
{
    public interface ILearnerStore : IGenericStore<Learner>
    {
        // Method to get students by class ID
        Task<IEnumerable<Learner>> GetLearnersBySectionIdAsync(int sectionId);

        // Method to get students by status
        Task<IEnumerable<Learner>> GetLearnersByStatusAsync(string status);

        // Method to get a student with their associated courses
        Task<Learner> GetLearnerWithSubjectsAsync(int learnerId);

        // Method to get a student by full name
        Task<Learner> GetByFullNameAsync(string fullName);

        // Method to get all students with related entities
        Task<IEnumerable<Learner>> GetAllWithIncludesAsync();

        // Method to get students by school class ID
        Task<List<Learner>> GetLearnersBySchoolClassIdAsync(int schoolClassId);

        Task<int?> GetLearnerIdByUserIdAsync(int userId);

        Task<Learner> GetLearnerByUserIdAsync(int userId);
    }
}
