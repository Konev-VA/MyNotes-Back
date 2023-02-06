using MyNotes.DAL.Models;
using MyNotes.Models;

namespace MyNotes.DAL.Interfaces
{
    public interface INotesDAL
    {
        Task<int> Add(Note note);
        Task<IEnumerable<Note>> GetNotes();
        Task<Note> GetNoteById(int id);
        Task Delete(int id);
        Task Update(int id, Note note);
    }
}