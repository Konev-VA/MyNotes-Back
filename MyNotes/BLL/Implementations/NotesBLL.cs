using MyNotes.BLL.Interfaces;
using MyNotes.DAL.Interfaces;
using MyNotes.DAL.Models;

namespace MyNotes.BLL.Implementations
{
    public class NotesBLL : INotesBLL
    {
        private readonly INotesDAL _notesDAL;
        public NotesBLL(INotesDAL notesDAL)
        {
            _notesDAL = notesDAL;
        }
        public async Task Add(Note note)
        {
            await _notesDAL.Add(note);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Note> GetNoteById(int id)
        {
            return await _notesDAL.GetNoteById(id);
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            return await _notesDAL.GetNotes();
        }

        public Task Update(int id, Note note)
        {
            throw new NotImplementedException();
        }
    }
}
