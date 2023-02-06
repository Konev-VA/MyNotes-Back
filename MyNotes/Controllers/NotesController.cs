using Microsoft.AspNetCore.Mvc;
using MyNotes.BLL.Interfaces;
using MyNotes.DAL.Interfaces;
using MyNotes.DAL.Models;
using MyNotes.Models;
using System.Diagnostics;

namespace MyNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private readonly INotesBLL _notesBLL;

        public NotesController(INotesBLL notesBLL)
        {
            _notesBLL = notesBLL;
        }

        [HttpGet]
        [Route("GetNotes")]
        public IEnumerable<Note> GetNotes()
        {
            return _notesBLL.GetNotes().Result; //TODO вынести выведение результата в BLL
        }

        [HttpGet]
        [Route("GetNoteByID")]
        public Note GetNoteById(int id)
        {
            return _notesBLL.GetNoteById(id).Result ?? new Note(); //TODO вынести выведение результата в BLL
        }

        [HttpPost]
        [Route("PostNewNote")]
        public string PostNewNote(Note note)
        {
            _notesBLL.Add(note);
            return "";
        }
    }
}