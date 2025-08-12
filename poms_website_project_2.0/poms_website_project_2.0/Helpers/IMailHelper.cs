using Azure;

namespace poms_website_project_2._0.Helpers
{
    public interface IMailHelper
    {
        Response SendEmail(string to, string subject, string body);
    }
}
