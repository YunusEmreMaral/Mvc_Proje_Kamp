using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService

    {
        List<Content> GetList();
        List<Content> GetListAra(string p);
        void ContentAdd(Content content);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        List<Content> GetListByID(int id);
        List<Content> GetListByWriter(int id);
        Content GetByID(int id);

    }
}
