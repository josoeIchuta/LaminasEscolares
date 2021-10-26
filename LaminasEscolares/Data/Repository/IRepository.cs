using LaminasEscolares.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaminasEscolares.Data.Repository
{
    public interface IRepository
    {
        LaminasDto GetPost(int id);
        List<LaminasDto> GetAllPosts();
        void AddPost(LaminasDto post);
        void UpdatePost(LaminasDto post);
        void RemovePost(int id);
        IEnumerable<LaminasDto> GetSearchPost(string SearchingTerm);

        Task<bool> SaveChangesAsync();
    }
}
