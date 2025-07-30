namespace poms_website_project_2._0.Models
{
    public class NotificationModel
    {
        public int ParentId { get; set; }

        public virtual ICollection<ParentLearnerModel> ParentLearners { get; set; } = new List<ParentLearnerModel>();

        public virtual UserModel ParentNavigation { get; set; } = null!;
    }
}
