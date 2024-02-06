using CoreBackend.Configs;
using CoreBackend.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;

namespace CoreBackend.Controllers.Content
{
    public class ContentWorkFlow
    {
        private readonly IConfiguration configuration;
        public ContentWorkFlow(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public ContentResponse? GetContents(string contentType)
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("@NOTIFY_TYPE", contentType);
            hashtable.Add("@NOTIFY_KEYSEARCH", "ALL");
            hashtable.Add("@LangId", 1);

            GetConfig getConfig = new GetConfig(configuration);
            var data = Utils.Sql.ExecuteProcAsDataTable(hashtable, "proc_POKER_Player_GetContent", getConfig.GetPokerConectionString());
            ContentResponse res = new ContentResponse();
            res.ContentItems = Sql.DataTableToList<ContentItem>(data);
            return res;
        }

    }
}
