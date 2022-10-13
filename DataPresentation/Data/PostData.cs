namespace DataPresentation.Data
{
    public class SendPostData
    {
        public List<string> GroupUrls { get; private set; }
        public string PostContent { get; private set; }

        public SendPostData(List<string> groupUrls, string postContent)
        {
            GroupUrls = groupUrls;
            PostContent = postContent;
        }
    }
}
