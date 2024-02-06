namespace CoreBackend.Controllers.Content
{
    public class ContentResponse
    {
        public List<ContentItem> ContentItems { get; set; }
    }
    public class ContentItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string SubContent { get; set; }
        public string ImageUrl { get; set; }
        public string KeySearch { get; set; }
        public int REDT_AUTOID { get; set; }
        public bool IsPublish { get; set; }
    }
}
