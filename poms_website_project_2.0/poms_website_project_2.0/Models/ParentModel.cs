namespace poms_website_project_2._0.Models
{
    public class ParentModel
    {
        public int ParentId { get; set; }

        public virtual ICollection<ParentLearnerModel> ParentLearners { get; set; } = new List<ParentLearner>();

        public virtual UserModel ParentNavigation { get; set; } = null!;
    }
}
