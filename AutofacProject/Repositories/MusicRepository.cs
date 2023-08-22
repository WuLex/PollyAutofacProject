using Autofac.Extras.DynamicProxy;
using AutofacProject.Interceptors;
using AutofacProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AutofacProject.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MusicContext _dbContext;

        public MusicRepository(MusicContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Music> GetAllMusic()
        {
            return _dbContext.Musics.ToList();
        }

        public Music GetMusicById(int id)
        {
            return _dbContext.Musics.FirstOrDefault(m => m.Id == id);
        }

        public void AddMusic(Music music)
        {
            _dbContext.Musics.Add(music);
            _dbContext.SaveChanges();
        }

        public void UpdateMusic(Music music)
        {
            _dbContext.Entry(music).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteMusic(int id)
        {
            var music = _dbContext.Musics.Find(id);
            if (music != null)
            {
                _dbContext.Musics.Remove(music);
                _dbContext.SaveChanges();
            }
        }

        public  List<Music> GetMusicsByPage(int page, int pageSize)
        {
            return _dbContext.Musics.OrderBy(x => x.Title)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize)
                  .ToList();
        }

        public int TotalCount()
        {
            return _dbContext.Musics.Count();
        }
    }
}
