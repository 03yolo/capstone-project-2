namespace poms_website_project_2._0.Models
{
    public class AdminDetailModel
    {
        public int AdminId { get; set; }

        public string Position { get; set; } = null!;

        public string? Office { get; set; }

        public string? ContactNo { get; set; }

        public virtual UserModel Admin { get; set; } = null!;
    }
}
