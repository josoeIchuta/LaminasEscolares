using LaminasEscolares.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaminasEscolares.Data.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;
        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public void AddPost(LaminasDto post)
        {
            _ctx.LaminasPosts.Add(post);
        }

        public List<LaminasDto> GetAllPosts()
        {
            return _ctx.LaminasPosts.ToList();
        }

        public LaminasDto GetPost(int id)
        {
            return _ctx.LaminasPosts.FirstOrDefault(p => p.Id == id);
        }

        public void RemovePost(int id)
        {
            _ctx.LaminasPosts.Remove(GetPost(id));
        }

        public void UpdatePost(LaminasDto post)
        {
            _ctx.LaminasPosts.Update(post);
        }
        public IEnumerable<LaminasDto> GetSearchPost(string SearchingTerm)
        {
            if (string.IsNullOrEmpty(SearchingTerm))
                return GetAllPosts();
            return _ctx.LaminasPosts.Where(s => s.Lamina.Contains(SearchingTerm));
        }
        public async Task<bool> SaveChangesAsync()
        {
            if (await _ctx.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
