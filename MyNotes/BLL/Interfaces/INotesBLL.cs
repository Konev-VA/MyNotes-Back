using MyNotes.DAL.Models;

namespace MyNotes.BLL.Interfaces
{
    public interface INotesBLL
    {
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> GetNoteById(int id);
        Task Add(Note note);
        Task Delete(int id);
        Task Update(int id, Note note);
    }
}