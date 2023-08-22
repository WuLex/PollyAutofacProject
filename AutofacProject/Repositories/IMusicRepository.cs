using AutofacProject.Models;

namespace AutofacProject.Repositories
{
    public interface IMusicRepository
    {
        List<Music> GetAllMusic();

        List<Music> GetMusicsByPage(int page, int limit);

        Music GetMusicById(int id);
        void AddMusic(Music music);
        void UpdateMusic(Music music);
        void DeleteMusic(int id);

        int TotalCount();
    }
}
