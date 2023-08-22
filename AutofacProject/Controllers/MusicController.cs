using Autofac.Extras.DynamicProxy;
using AutofacProject.Interceptors;
using AutofacProject.Models;
using AutofacProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AutofacProject.Controllers
{

    public class MusicController : Controller
    {
        //private readonly MusicContext _context;
        private readonly IMusicRepository _musicRepository;

        public MusicController(IMusicRepository musicRepository, MusicContext context)
        {
            _musicRepository = musicRepository;
            //_context = context;
        }

        public IActionResult Index()
        {
            //var musics = _musicRepository.GetAllMusic();
            //return View(musics);
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        public virtual PageDataResult<Music> GetAll(int page=1,int limit=10)
        {
            // 查询数据库中的所有音乐数据
            List<Music> dataList = _musicRepository.GetMusicsByPage(page,limit);
            return new PageDataResult<Music>()
            {
                Msg = "success",
                Code = 0,
                Count = _musicRepository.TotalCount(),
                Data = dataList
            };
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Music music)
        {
            if (ModelState.IsValid)
            {
                _musicRepository.AddMusic(music);
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        public IActionResult Edit(int id)
        {
            var music = _musicRepository.GetMusicById(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Music music)
        {
            if (id != music.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _musicRepository.UpdateMusic(music);
                return RedirectToAction(nameof(Index));
            }
            return View(music);
        }

        public IActionResult Delete(int id)
        {
            var music = _musicRepository.GetMusicById(id); //_context.Musics.Find(id);
            if (music == null)
            {
                return NotFound();
            }
            return View(music);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       public IActionResult DeleteConfirmed(int id)
        {
            var music = _musicRepository.GetMusicById(id);
            if (music == null)
            {
                return NotFound();
            }

            _musicRepository.DeleteMusic(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
